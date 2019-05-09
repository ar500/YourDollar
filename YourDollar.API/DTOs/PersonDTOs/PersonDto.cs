using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourDollar.API.DTOs.BankAccountDTOs;
using YourDollar.API.DTOs.BudgetDTOs;

namespace YourDollar.API.DTOs.PersonDTOs
{
    public class PersonDto
    {
        public Guid PersonId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}
