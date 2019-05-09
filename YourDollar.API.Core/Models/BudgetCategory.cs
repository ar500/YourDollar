using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourDollar.API.Core.Models
{
    public class BudgetCategory
    {
        public Guid CategoryId { get; set; }

        public string ShortName { get; set; }

        public string Description { get; set; }

        public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
    }
}