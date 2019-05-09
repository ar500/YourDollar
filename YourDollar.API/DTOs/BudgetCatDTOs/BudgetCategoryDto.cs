using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourDollar.API.DTOs.ExpenseDTOs;

namespace YourDollar.API.DTOs.BudgetCatDTOs
{
    public class BudgetCategoryDto
    {
        public Guid CategoryId { get; set; }

        public string ShortName { get; set; }

        public string Description { get; set; }

        public ICollection<ExpenseDto> Expenses { get; set; } = new List<ExpenseDto>();
    }
}
