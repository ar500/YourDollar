using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourDollar.API.DTOs.BudgetCatDTOs;
using YourDollar.API.DTOs.DepositDTOs;
using YourDollar.API.DTOs.PersonDTOs;

namespace YourDollar.API.DTOs.BudgetDTOs
{
    public class BudgetDto
    {
        public Guid BudgetId { get; set; }

        public DateTime TargetDate { get; set; }

        public int MonthlySplit { get; set; } = 1;

        public ICollection<BudgetCategoryDto> BudgetCategories { get; set; } = new List<BudgetCategoryDto>();
    }
}
