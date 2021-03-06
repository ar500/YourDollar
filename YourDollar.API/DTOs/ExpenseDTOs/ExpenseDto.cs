﻿using System;
using YourDollar.API.DTOs.BudgetCatDTOs;

namespace YourDollar.API.DTOs.ExpenseDTOs
{
    public class ExpenseDto
    {
        public Guid ExpenseId { get; set; }

        public string ShortName { get; set; }

        public DateTime PayoutDate { get; set; }

        public decimal Amount { get; set; }

        public BudgetCategoryDto BudgetCategory { get; set; }

        public string CompanyName { get; set; }

        public string CompanyAccountNumber { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsRecurring { get; set; } = false;

    }
}
