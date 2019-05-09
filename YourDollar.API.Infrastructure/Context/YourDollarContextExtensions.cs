using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore.Internal;
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
    }
}
