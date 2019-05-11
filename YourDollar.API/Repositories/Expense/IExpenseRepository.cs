using System;
using System.Collections.Generic;
using YourDollar.API.Infrastructure.Entities;

namespace YourDollar.API.Repositories.Expense
{
    public interface IExpenseRepository
    {
        IEnumerable<ExpenseEntity> GetExpenses();
        ExpenseEntity GetExpenseById(Guid id);
        void AddExpense(ExpenseEntity expense);
        void RemoveExpense(ExpenseEntity expense);
        bool SaveChanges();
        bool ExpenseExists(Guid id);
    }
}