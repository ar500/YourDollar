using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YourDollar.API.Infrastructure.Entities
{
    public class DepositEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid DepositId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        public ICollection<DateTime> DepositDates { get; set; } = new List<DateTime>();

        [Required]
        public bool IsRecurring { get; set; } = false;

        [Required]
        public BankAccountEntity DepositAccount { get; set; }

        [Required]
        public decimal DepositAmount { get; set; }
    }
}
