using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourDollar.API.Infrastructure.Entities
{
    public class BudgetEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid BudgetId { get; set; }

        [Required]
        public DateTime TargetDate { get; set; }

        [Required]
        public int MonthlySplit { get; set; } = 1;

        [Required]
        public ICollection<BudgetCategoryEntity> BudgetCategories { get; set; } = new List<BudgetCategoryEntity>();

        [Required]
        public ICollection<PersonEntity> Owners { get; set; } = new List<PersonEntity>();
    }
}
