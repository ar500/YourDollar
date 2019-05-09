using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using YourDollar.API.DTOs.BankAccountDTOs;
using YourDollar.API.DTOs.BudgetCatDTOs;
using YourDollar.API.DTOs.BudgetDTOs;
using YourDollar.API.DTOs.DepositDTOs;
using YourDollar.API.DTOs.ExpenseDTOs;
using YourDollar.API.DTOs.PersonDTOs;
using YourDollar.API.Infrastructure.Enums;

namespace YourDollar.API
{
    public class DummyDataStore
    {
        public static DummyDataStore Current { get; } = new DummyDataStore();

        public List<PersonDto> People { get; set; } = new List<PersonDto>();
        public List<BankAccountDto> BankAccounts { get; set; } = new List<BankAccountDto>();
        public List<BudgetDto> Budgets { get; set; } = new List<BudgetDto>();

        public Guid Person1Id = Guid.NewGuid();
        public Guid Person2Id = Guid.NewGuid();

        public Guid Account1Id = Guid.NewGuid();
        public Guid Account2Id = Guid.NewGuid();
        public Guid Account3Id = Guid.NewGuid();

        public Guid Budget1Id = Guid.NewGuid();

        public DummyDataStore()
        {
            People = new List<PersonDto>()
            {
                new PersonDto()
                {
                    PersonId = Person1Id,

                    FirstName = "John",

                    LastName = "Doe",

                    Email = "blah@nevergottocollege.com",

                    PhoneNumber = "123-321-1234"
                },

                new PersonDto()
                {
                    PersonId = Person2Id,

                    FirstName = "Jane",

                    LastName = "Doe",

                    Email = "hi@HiImJane.com",

                    PhoneNumber = "098-098-1123",
                }
            };

            BankAccounts = new List<BankAccountDto>()
            {
                new BankAccountDto()
                {
                    BankAccountId = Account1Id,
                    AccountName = "PrimaryChecking",
                    AccountType = AccountTypes.Checking,
                    Balance = 1000
                },
                new BankAccountDto()
                {
                    BankAccountId = Account2Id,
                    AccountName = "KidsCollegeFund",
                    AccountType = AccountTypes.Savings,
                    Balance = 50
                },
                new BankAccountDto()
                {
                    BankAccountId = Account3Id,
                    AccountName = "DivorceFund",
                    AccountType = AccountTypes.Other,
                    Balance = 10000
                }
            };
            BankAccounts[0].AccountOwners.Add(People[0]);
            BankAccounts[0].AccountOwners.Add(People[1]);
            BankAccounts[1].AccountOwners.Add(People[1]);
            BankAccounts[0].Deposits.Add(new DepositDto()
            {
                DepositId = Guid.NewGuid(),
                Description = "Paycheck",
                DepositAmount = 1200m,
                DepositDate = DateTime.Parse("05/15/2019"),
                IsRecurring = true
            });

            Budgets.Add(new BudgetDto()
            {
                BudgetId = Budget1Id,
                MonthlySplit = 2,
                TargetDate = DateTime.Parse("05/15/2019")
            });
            Budgets[0].BudgetCategories.Add(new BudgetCategoryDto()
            {
                CategoryId = Guid.NewGuid(),
                ShortName = "Transportation",
                Description = "Vehicle Upkeep Costs, Public transportation costs, Car Loans, etc...",
                Expenses = new List<ExpenseDto>()
                {
                    new ExpenseDto()
                    {
                        ExpenseId = Guid.NewGuid(),
                        PayoutDate = DateTime.Parse("05/20/2019"),
                        IsRecurring = true,
                        ShortName = "Truck Payment",
                        Amount = 78,
                        BankAccount = BankAccounts.FirstOrDefault(p => Enumerable
                            .Select<PersonDto, bool>(p.AccountOwners, o => o.PersonId == Person1Id && p.BankAccountId == Account1Id)
                            .FirstOrDefault())
                    },
                    new ExpenseDto()
                    {
                        ExpenseId = Guid.NewGuid(),
                        PayoutDate = DateTime.Parse("06/01/2019"),
                        ShortName = "Fuel",
                        IsRecurring = true,
                        Amount = 50,
                        BankAccount = BankAccounts.FirstOrDefault(p => Enumerable
                            .Select<PersonDto, bool>(p.AccountOwners, o => o.PersonId == Person1Id && p.BankAccountId == Account1Id)
                            .FirstOrDefault())
                    },
                    new ExpenseDto()
                    {
                        ExpenseId = Guid.NewGuid(),
                        PayoutDate = DateTime.Parse("06/05/2019"),
                        ShortName = "Big hawkin' Muddin' tyres",
                        IsRecurring = false,
                        Amount = 150000,
                        BankAccount = BankAccounts.FirstOrDefault(p => Enumerable
                            .Select<PersonDto, bool>(p.AccountOwners, o => o.PersonId == Person1Id && p.BankAccountId == Account1Id)
                            .FirstOrDefault())
                    }
                }
            });
            Budgets[0].BudgetCategories.Add(new BudgetCategoryDto()
            {
                CategoryId = Guid.NewGuid(),
                ShortName = "Food",
                Description = "Groceries, eating out, school lunches, etc...",
                Expenses = new List<ExpenseDto>()
                {
                    new ExpenseDto()
                    {
                        ExpenseId = Guid.NewGuid(),
                        PayoutDate = DateTime.Parse("05/20/2019"),
                        IsRecurring = true,
                        ShortName = "Groceries",
                        Amount = 250,
                        BankAccount = BankAccounts.FirstOrDefault(p => Enumerable
                            .Select<PersonDto, bool>(p.AccountOwners, o => o.PersonId == Person1Id && p.BankAccountId == Account1Id)
                            .FirstOrDefault())
                    },
                    new ExpenseDto()
                    {
                        ExpenseId = Guid.NewGuid(),
                        PayoutDate = DateTime.Parse("05/20/2019"),
                        ShortName = "Eating out",
                        IsRecurring = false,
                        Amount = 20,
                        BankAccount = BankAccounts.FirstOrDefault(p => Enumerable
                            .Select<PersonDto, bool>(p.AccountOwners, o => o.PersonId == Person1Id && p.BankAccountId == Account1Id)
                            .FirstOrDefault())
                    },
                    new ExpenseDto()
                    {
                        ExpenseId = Guid.NewGuid(),
                        PayoutDate = DateTime.Parse("05/17/2019"),
                        ShortName = "Divorce Day travel meal",
                        IsRecurring = false,
                        Amount = 0.25m,
                        BankAccount = BankAccounts.FirstOrDefault(p => p.BankAccountId == Account3Id)
                    }
                }
            });
            Budgets[0].BudgetCategories.Add(new BudgetCategoryDto()
            {
                CategoryId = Guid.NewGuid(),
                ShortName = "Savings",
                Description = "Savings expenses go here",
                Expenses = new List<ExpenseDto>()
                {
                    new ExpenseDto()
                    {
                        ExpenseId = Guid.NewGuid(),
                        ShortName = "College Savings",
                        PayoutDate = DateTime.Parse("05/15/2019"),
                        BankAccount = BankAccounts.FirstOrDefault(p => p.BankAccountId == Account2Id)
                    }
                }
            });
        }
    }
}
