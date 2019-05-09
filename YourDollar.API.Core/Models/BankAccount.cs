using System.Collections.Generic;

namespace YourDollar.API.Core.Models
{
    public class BankAccount
    {
        public string AccountName { get; set; }

        public AccountTypes AccountType { get; set; }

        public decimal Balance { get; set; } = 0;

        public ICollection<Person> AccountOwners { get; set; } = new List<Person>();

        public void AddFunds(decimal amount)
        {
            Balance += amount;
        }

        public void WithdrawFunds(decimal amount)
        {
            Balance -= amount;
        }
    }
}