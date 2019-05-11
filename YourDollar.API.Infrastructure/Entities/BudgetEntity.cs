using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourDollar.API.Infrastructure.Entities
{
    /// <summary>
    /// Models a budges
    /// </summary>
    public class BudgetEntity
    {
        /// <summary>
        /// The Primary key for the entity
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid BudgetId { get; set; }

        [Required]
        public DateTime CycleStartDate { get; set; }

        [Required]
        public DateTime CycleEndDate { get; set; }

        [Required]
        public decimal Funds { get; set; } = 0;

        [MinLength(1, ErrorMessage = "You must provide at least 1 budget member.")]
        public ICollection<PersonEntity> BudgetMembers { get; set; }

        public ICollection<ExpenseEntity> Expenses { get; set; } = new List<ExpenseEntity>();
    }
}
