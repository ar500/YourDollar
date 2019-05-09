using System;
using System.ComponentModel.DataAnnotations;

namespace YourDollar.API.Core.Models
{
    public class FixedExpense : Expense
    {
        [Required]
        [MaxLength(20)]
        public string CompanyName { get; set; }

        [MaxLength(20)]
        public string CompanyAccountNumber { get; set; }

        [Required]
        public DateTime DueDate { get; set; }
    }
}