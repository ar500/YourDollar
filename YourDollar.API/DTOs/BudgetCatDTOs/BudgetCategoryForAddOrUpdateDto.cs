using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YourDollar.API.DTOs.BudgetCatDTOs
{
    public class BudgetCategoryForAddOrUpdateDto
    {
        [Required]
        [MaxLength(100)]
        public string ShortName { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
    }
}
