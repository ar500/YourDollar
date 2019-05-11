using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace YourDollar.API.Infrastructure.Entities
{
    public class ExpenseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ExpenseId { get; set; }

        [Required]
        public BudgetCategoryEntity BudgetCategory { get; set; }

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
