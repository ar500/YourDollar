using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using YourDollar.API.Infrastructure.Entities;

namespace YourDollar.API.Infrastructure.Context
{
    public static class YourDollarContextExtensions
    {
        public static void EnsurePeopleSeedDataForContext(this YourDollarContext context)
        {
            if (EnumerableExtensions.Any(context.People))
            {
                return;
            }

            var people = new List<PersonEntity>()
            {
                new PersonEntity()
                {

                    FirstName = "John",

                    LastName = "Doe",

                    Email = "blah@nevergottocollege.com",

                    PhoneNumber = "123-321-1234"
                },

                new PersonEntity()
                {
                    FirstName = "Jane",

                    LastName = "Doe",

                    Email = "hi@HiImJane.com",

                    PhoneNumber = "098-098-1123",
                }
            };
            
            context.People.AddRange(people);
            context.SaveChanges();
        }

        public static void EnsureBudgetCategorySeedDataForContext(this YourDollarContext context)
        {
            if (context.BudgetCategories.FirstOrDefault(c => c.ShortName == "Food") == null)
            {
                context.BudgetCategories.Add(new BudgetCategoryEntity
                {
                    ShortName = "Food",
                    Description = "Use this category for groceries, restaurants, pet food, or any costs associated with food."
                });
            }

            if (context.BudgetCategories.FirstOrDefault(c => c.ShortName == "Shelter") == null)
            {
                context.BudgetCategories.Add(new BudgetCategoryEntity
                {
                    ShortName = "Shelter",
                    Description = "Use this category for mortgage, rent, property taxes, home repairs, HOA dues, or any costs associated with housing."
                });
            }

            if (context.BudgetCategories.FirstOrDefault(c => c.ShortName == "Utilities") == null)
            {
                context.BudgetCategories.Add(new BudgetCategoryEntity
                {
                    ShortName = "Utilities",
                    Description = "Use this category for electricity, water, heating, garbage, internet, cable, or other bills."
                });
            }

            if (context.BudgetCategories.FirstOrDefault(c => c.ShortName == "Clothing") == null)
            {
                context.BudgetCategories.Add(new BudgetCategoryEntity
                {
                    ShortName = "Clothing",
                    Description = "Use this category for children or adult clothing purchases."
                });
            }

            if (context.BudgetCategories.FirstOrDefault(c => c.ShortName == "Transportation") == null)
            {
                context.BudgetCategories.Add(new BudgetCategoryEntity
                {
                    ShortName = "Transportation",
                    Description = "Use this category for fuel, parking fees, public transportation, vehicle replacement or any costs associated with vehicle maintenance or operation."
                });
            }

            if (context.BudgetCategories.FirstOrDefault(c => c.ShortName == "Medical") == null)
            {
                context.BudgetCategories.Add(new BudgetCategoryEntity
                {
                    ShortName = "Medical",
                    Description = "Use this category for primary care, dental care, medications, or medical devices."
                });
            }

            if (context.BudgetCategories.FirstOrDefault(c => c.ShortName == "Insurance") == null)
            {
                context.BudgetCategories.Add(new BudgetCategoryEntity
                {
                    ShortName = "Insurance",
                    Description = "Use this category for any type of insurance costs."
                });
            }

            if (context.BudgetCategories.FirstOrDefault(c => c.ShortName == "Household Supplies") == null)
            {
                context.BudgetCategories.Add(new BudgetCategoryEntity
                {
                    ShortName = "Household Supplies",
                    Description = "Use this category for toiletries, laundry/dishwasher detergent, cleaning supplies or other household necessities."
                });
            }

            context.SaveChanges();
            // TODO: Add additional budgetCategories to seed data after testing the catagoryRepo.
        }

        public static void EnsureExpenseSeedDataForContext(this YourDollarContext context)
        {
            if (EnumerableExtensions.Any(context.Expenses))
            {
                return;
            }

            var expenseList = new List<ExpenseEntity>()
            {
                new ExpenseEntity()
                {
                    ShortName = "Light Bill",
                    BudgetCategory = context.BudgetCategories.FirstOrDefault(c => c.ShortName == "Utilities"),
                    Amount = 150m,
                    CompanyAccountNumber = "123-556-33322AB",
                    CompanyName = "XYZLights",
                    DueDate = DateTime.Parse("06/15/2019"),
                    PayoutDate = DateTime.Parse("05/16/2019"),
                    IsRecurring = true
                },
                new ExpenseEntity()
                {
                    ShortName = "Water Bill",
                    BudgetCategory = context.BudgetCategories.FirstOrDefault(c => c.ShortName == "Utilities"),
                    Amount = 25m,
                    CompanyAccountNumber = "ABC-ID",
                    CompanyName = "CrystalClearH2O",
                    DueDate = DateTime.Parse("05/25/2019"),
                    PayoutDate = DateTime.Parse("06/1/2019"),
                    IsRecurring = true
                },
                new ExpenseEntity()
                {
                    ShortName = "Groceries",
                    BudgetCategory = context.BudgetCategories.FirstOrDefault(c => c.ShortName == "Food"),
                    Amount = 250m,
                    PayoutDate = DateTime.Parse("05/15/2019"),
                    IsRecurring = true
                },
                new ExpenseEntity()
                {
                    ShortName = "Car Loan",
                    BudgetCategory = context.BudgetCategories.FirstOrDefault(c => c.ShortName == "Transportation"),
                    Amount = 380m,
                    PayoutDate = DateTime.Parse("05/15/2019"),
                    DueDate = DateTime.Parse("06/01/2019"),
                    CompanyName = "WeToteDaNote",
                    CompanyAccountNumber = "11111666-badjuju",
                    IsRecurring = true
                }
            };

            context.Expenses.AddRange(expenseList);
            context.SaveChanges();
        }
    }
}
