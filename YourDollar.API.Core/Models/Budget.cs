using System;
using System.Collections.Generic;

namespace YourDollar.API.Core.Models
{
    public class Budget
    {
        public DateTime TargetDate { get; set; }

        public int MonthlySplit { get; set; } = 1;

        public ICollection<Deposit> Deposits { get; } = new List<Deposit>();

        public ICollection<Person> Owners { get; } = new List<Person>();

        public ICollection<BudgetCategory> BudgetCategories { get; } = new List<BudgetCategory>();
    }
}