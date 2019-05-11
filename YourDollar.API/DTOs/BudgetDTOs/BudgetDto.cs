using System;
using System.Collections.Generic;
using YourDollar.API.DTOs.PersonDTOs;
using YourDollar.API.Infrastructure.Entities;

namespace YourDollar.API.DTOs.BudgetDTOs
{
    public class BudgetDto
    {
        public Guid BudgetId { get; set; }

        public DateTime CycleStartDate { get; set; }

        public DateTime CycleEndDate { get; set; }

        public decimal Funds { get; set; } = 0;

        public ICollection<PersonDto> BudgetMembers { get; set; } = new List<PersonDto>();

        public ICollection<ExpenseEntity> Expenses { get; set; } = new List<ExpenseEntity>();
    }
}
