using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourDollar.API.Core.Models
{
    public class BankAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid BankAccountId { get; set; }

        [Required]
        [MaxLength(100)]
        public string AccountName { get; set; }

        [Required]
        public AccountTypes AccountType { get; set; }

        public decimal Balance { get; set; } = 0;

        [Required]
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