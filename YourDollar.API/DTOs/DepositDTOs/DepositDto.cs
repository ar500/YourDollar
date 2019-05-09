using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourDollar.API.DTOs.BankAccountDTOs;

namespace YourDollar.API.DTOs.DepositDTOs
{
    public class DepositDto
    {
        public Guid DepositId { get; set; }

        public string Description { get; set; }

        public DateTime DepositDate { get; set; }

        public bool IsRecurring { get; set; } = false;

        public decimal DepositAmount { get; set; }
    }
}
