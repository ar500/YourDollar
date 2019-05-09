using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourDollar.API.Core.Models
{
    public class Budget
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid BudgetId { get; set; }

        [Required]
        public DateTime TargetDate { get; set; }

        [Required]
        public int MonthlySplit { get; set; } = 1;

        [Required]
        public ICollection<Deposit> Deposits { get; } = new List<Deposit>();

        [Required]
        public ICollection<Person> Owners { get; } = new List<Person>();

        [Required]
        public ICollection<BudgetCategory> BudgetCategories { get; } = new List<BudgetCategory>();
    }
}