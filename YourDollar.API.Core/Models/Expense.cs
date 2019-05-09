﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourDollar.API.Core.Models
{
    public class Expense
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ExpenseId { get; set; }

        [Required]
        [MaxLength(20)]
        public string ShortName { get; set; }

        [Required]
        public DateTime PayoutDate { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public BankAccount BankAccount { get; set; }

        public bool IsRecurring { get; set; } = false;
    }
}