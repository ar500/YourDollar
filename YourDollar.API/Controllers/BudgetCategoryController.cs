using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using YourDollar.API.DTOs.BudgetCatDTOs;
using YourDollar.API.Infrastructure.Entities;
using YourDollar.API.Repositories.BudgetCategory;

namespace YourDollar.API.Controllers
{
    [Route("api/budgetcategories")]
    [ApiController]
    public class BudgetCategoryController : ControllerBase
    {
        private readonly IBudgetCategoryRepository _budgetCategoryRepository;

        public BudgetCategoryController(IBudgetCategoryRepository budgetCategoryRepository)
        {
            _budgetCategoryRepository = budgetCategoryRepository;
        }

        // GET: api/BudgetCategory
        [HttpGet]
        public IActionResult GetBudgetCategories()
        {
            var categoriesFromRepo = _budgetCategoryRepository.GetCategories();

            var mappedCategories = Mapper.Map<IEnumerable<BudgetCategoryDto>>(categoriesFromRepo);

            return Ok(mappedCategories);
        }

        // GET: api/BudgetCategory/5
        [HttpGet("{id}", Name = "GetCategoryById")]
        public IActionResult GetCategoryById(Guid id)
        {
            if (!_budgetCategoryRepository.CategoryExists(id))
            {
                return NotFound();
            }

            var categoryFromRepo = _budgetCategoryRepository.GetCategoryById(id);

            var mappedCategory = Mapper.Map<BudgetCategoryDto>(categoryFromRepo);

            return Ok(mappedCategory);
        }

        // POST: api/BudgetCategory
        [HttpPost]
        public IActionResult AddCategory([FromBody] BudgetCategoryForAddOrUpdateDto budgetCategory)
        {
            if (budgetCategory == null)
            {
                return BadRequest();
            }

            var categoryToAddMapped = Mapper.Map<BudgetCategoryEntity>(budgetCategory);

            _budgetCategoryRepository.AddCategory(categoryToAddMapped);

            if (!_budgetCategoryRepository.SaveChanges())
            {
                return StatusCode(500, "The server was unable to handle your request.");
            }

            var createdCategoryForReturn = Mapper.Map<BudgetCategoryDto>(categoryToAddMapped);

            return CreatedAtRoute("GetCategoryById", new
                {id = createdCategoryForReturn.CategoryId}, createdCategoryForReturn);
        }

        // PUT: api/BudgetCategory/5
        [HttpPatch("{id}")]
        public IActionResult UpdateCategory(Guid id, [FromBody] JsonPatchDocument<BudgetCategoryForAddOrUpdateDto> patchDocument)
        {
            if (patchDocument == null)
            {
                return BadRequest();
            }

            if (!_budgetCategoryRepository.CategoryExists(id))
            {
                return NotFound();
            }

            var categoryToUpdate = _budgetCategoryRepository.GetCategoryById(id);

            if (categoryToUpdate == null)
            {
                return NotFound();
            }

            var categoryToPatch = Mapper.Map<BudgetCategoryForAddOrUpdateDto>(categoryToUpdate);

            patchDocument.ApplyTo(categoryToPatch, ModelState);

            TryValidateModel(categoryToPatch);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Mapper.Map(categoryToPatch, categoryToUpdate);

            if (!_budgetCategoryRepository.SaveChanges())
            {
                return StatusCode(500, "The server was unable to handle your request.");
            }

            return CreatedAtRoute("GetCategoryById", new
                { id = categoryToUpdate.CategoryId }, categoryToUpdate);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult RemoveCategory(Guid id)
        {
            if (!_budgetCategoryRepository.CategoryExists(id))
            {
                return NotFound();
            }

            var categoryToRemove = _budgetCategoryRepository.GetCategoryById(id);

            _budgetCategoryRepository.RemoveCategory(categoryToRemove);

            if (!_budgetCategoryRepository.SaveChanges())
            {
                return StatusCode(500, "The server was unable to handle your request.");
            }

            return NoContent();
        }
    }
}
