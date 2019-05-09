using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

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
