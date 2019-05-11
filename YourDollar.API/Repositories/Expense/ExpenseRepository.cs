using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YourDollar.API.Infrastructure.Context;
using YourDollar.API.Infrastructure.Entities;

namespace YourDollar.API.Repositories.Expense
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly YourDollarContext _context;

        public ExpenseRepository(YourDollarContext context)
        {
            _context = context;
        }

        public IEnumerable<ExpenseEntity> GetExpenses()
        {
            return _context.Expenses
                .Include(c => c.BudgetCategory)
                .ToList();
        }

        public ExpenseEntity GetExpenseById(Guid id)
        {
            return _context.Expenses
                .Include(c => c.BudgetCategory)
                .FirstOrDefault(e => e.ExpenseId == id);
        }

        public void AddExpense(ExpenseEntity expense)
        {
            _context.Expenses.Add(expense);
        }

        public void RemoveExpense(ExpenseEntity expense)
        {
            _context.Expenses.Remove(expense);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public bool ExpenseExists(Guid id)
        {
            return _context.Expenses.Any(e => e.ExpenseId == id);
        }
    }
}
