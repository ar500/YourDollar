using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YourDollar.API.DTOs.ExpenseDTOs
{
    public class ExpenseForAddDto
    {
        [Required]
        [MaxLength(20)]
        public string ShortName { get; set; }

        [Required]
        public DateTime PayoutDate { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public string CompanyName { get; set; }

        public string CompanyAccountNumber { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsRecurring { get; set; } = false;
    }
}
