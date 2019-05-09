using System;
using System.ComponentModel.DataAnnotations;

namespace YourDollar.API.Infrastructure.Entities
{
    public class FixedExpenseEntity : ExpenseEntity
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
