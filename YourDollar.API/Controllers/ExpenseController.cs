using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using YourDollar.API.DTOs.ExpenseDTOs;
using YourDollar.API.Infrastructure.Entities;
using YourDollar.API.Repositories.BudgetCategory;
using YourDollar.API.Repositories.Expense;

namespace YourDollar.API.Controllers
{
    [Route("api/expenses")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IBudgetCategoryRepository _budgetCategoryRepository;

        public ExpenseController(IExpenseRepository expenseRepository, IBudgetCategoryRepository budgetCategoryRepository)
        {
            _expenseRepository = expenseRepository;
            _budgetCategoryRepository = budgetCategoryRepository;
        }

        // GET: api/Expense
        [HttpGet]
        public IActionResult GetExpenses()
        {
            var expensesFromRepo = _expenseRepository.GetExpenses();

            var mappedExpenses = Mapper.Map<IEnumerable<ExpenseDto>>(expensesFromRepo);

            return Ok(mappedExpenses);
        }

        // GET: api/Expense/5
        [HttpGet("{id}", Name = "GetExpenseById")]
        public IActionResult GetExpenseById(Guid id)
        {
            if (!_expenseRepository.ExpenseExists(id))
            {
                return NotFound();
            }

            var expenseFromStore = _expenseRepository.GetExpenseById(id);

            var mappedExpense = Mapper.Map<ExpenseDto>(expenseFromStore);

            return Ok(mappedExpense);
        }

        // POST: api/Expense
        [HttpPost("{categoryId}")]
        public IActionResult AddExpense(Guid categoryId, [FromBody] ExpenseForAddDto expense)
        {
            if (expense == null)
            {
                return BadRequest();
            }

            if (!_budgetCategoryRepository.CategoryExists(categoryId))
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var budgetCategory = _budgetCategoryRepository.GetCategoryById(categoryId);

            var expenseToCreate = Mapper.Map<ExpenseEntity>(expense);

            expenseToCreate.BudgetCategory = budgetCategory;

            _expenseRepository.AddExpense(expenseToCreate);

            if (!_expenseRepository.SaveChanges())
            {
                return StatusCode(500, "The server was unable to handle your request.");
            }

            var createdExpenseForReturn = Mapper.Map<ExpenseDto>(expenseToCreate);

            return CreatedAtRoute("GetExpenseById", new
                { id = createdExpenseForReturn.ExpenseId }, createdExpenseForReturn);
        }

        // PATCH: api/Expense/5
        [HttpPatch("{id}")]
        public IActionResult UpdateExpense(Guid id, [FromBody] JsonPatchDocument<ExpenseForUpdateDto> patchDocument)
        {
            if (patchDocument == null)
            {
                return BadRequest();
            }

            var expenseToUpdate = _expenseRepository.GetExpenseById(id);

            if (expenseToUpdate == null)
            {
                return NotFound();
            }

            var expenseToPatch = Mapper.Map<ExpenseForUpdateDto>(expenseToUpdate);

            patchDocument.ApplyTo(expenseToPatch, ModelState);

            TryValidateModel(expenseToPatch);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Mapper.Map(expenseToPatch, expenseToUpdate);

            if (!_expenseRepository.SaveChanges())
            {
                return StatusCode(500, "The server was unable to handle your request.");
            }

            return CreatedAtRoute("GetExpenseById", new
                { id = expenseToUpdate.ExpenseId }, expenseToUpdate);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult DeleteExpense(Guid id)
        {
            if (_expenseRepository.ExpenseExists(id))
            {
                return NotFound();
            }

            var expenseToDelete = _expenseRepository.GetExpenseById(id);
            if (expenseToDelete == null)
            {
                return NotFound();
            }

            _expenseRepository.RemoveExpense(expenseToDelete);

            if (!_expenseRepository.SaveChanges())
            {
                return StatusCode(500, "The server was unable to handle your request.");
            }

            return NoContent();
        }
    }
}
