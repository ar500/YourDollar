using System;

namespace YourDollar.API.DTOs.BudgetCatDTOs
{
    public class BudgetCategoryDto
    {
        public Guid CategoryId { get; set; }

        public string ShortName { get; set; }

        public string Description { get; set; }
    }
}
