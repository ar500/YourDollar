using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourDollar.API.Core.Models
{
    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public ICollection<Budget> Budgets { get; set; } = new List<Budget>();

        public ICollection<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();
    }
}
