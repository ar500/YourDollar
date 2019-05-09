using System;

namespace YourDollar.API.Core.Models
{
    public class Expense
    {
        public string ShortName { get; set; }

        public DateTime PayoutDate { get; set; }

        public decimal Amount { get; set; }

        public BankAccount BankAccount { get; set; }

        public bool IsRecurring { get; set; } = false;
    }
}