using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YourDollar.API.Infrastructure.Enums;

namespace YourDollar.API.Infrastructure.Entities
{
    public class BankAccountEntity
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
        public ICollection<PersonEntity> AccountOwners { get; set; } = new List<PersonEntity>();

        public ICollection<DepositEntity> Deposits { get; set; } = new List<DepositEntity>();

    }
}
