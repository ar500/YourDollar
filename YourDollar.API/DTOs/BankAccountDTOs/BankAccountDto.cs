using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using YourDollar.API.DTOs.DepositDTOs;
using YourDollar.API.DTOs.PersonDTOs;
using YourDollar.API.Infrastructure.Enums;

namespace YourDollar.API.DTOs.BankAccountDTOs
{
    public class BankAccountDto
    {
        public Guid BankAccountId { get; set; }

        public string AccountName { get; set; }

        public AccountTypes AccountType { get; set; }

        public decimal Balance { get; set; } = 0;

        public ICollection<PersonDto> AccountOwners { get; set; } = new List<PersonDto>();

        public ICollection<DepositDto> Deposits { get; set; } = new List<DepositDto>();
    }
}
