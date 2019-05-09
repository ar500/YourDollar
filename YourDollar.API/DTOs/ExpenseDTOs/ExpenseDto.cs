using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourDollar.API.DTOs.BankAccountDTOs;

namespace YourDollar.API.DTOs.ExpenseDTOs
{
    public class ExpenseDto
    {
        public Guid ExpenseId { get; set; }

        public string ShortName { get; set; }

        public DateTime PayoutDate { get; set; }

        public decimal Amount { get; set; }

        public BankAccountDto BankAccount { get; set; }

        public bool IsRecurring { get; set; } = false;
    }
}
