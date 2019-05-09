﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourDollar.API.Core.Models
{
    public class Deposit
    {
        public string Description { get; set; }

        public ICollection<DateTime> DepositDates { get; set; } = new List<DateTime>();

        public bool IsRecurring { get; set; } = false;

        public BankAccount DepositAccount { get; set; }

        public decimal DepositAmount { get; set; }
    }
}