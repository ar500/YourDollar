using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourDollar.API.Infrastructure.Entities
{
    public class BudgetCategoryEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CategoryId { get; set; }

        [Required]
        [MaxLength(100)]
        public string ShortName { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        public ICollection<ExpenseEntity> Expenses { get; set; } = new List<ExpenseEntity>();
    }
}
