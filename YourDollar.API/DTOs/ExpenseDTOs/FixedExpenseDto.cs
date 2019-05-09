using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourDollar.API.DTOs.ExpenseDTOs
{
    public class FixedExpenseDto
    {
        public string CompanyName { get; set; }

        public string CompanyAccountNumber { get; set; }

        public DateTime DueDate { get; set; }
    }
}
