using System.ComponentModel.DataAnnotations;

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
