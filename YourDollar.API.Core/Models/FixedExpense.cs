using System;
using System.ComponentModel.DataAnnotations;

namespace YourDollar.API.Core.Models
{
    public class FixedExpense : Expense
    {
        public string CompanyName { get; set; }

        public string CompanyAccountNumber { get; set; }

        public DateTime DueDate { get; set; }
    }
}