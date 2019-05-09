using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Internal;
using YourDollar.API.Infrastructure.Entities;

namespace YourDollar.API.Infrastructure.Context
{
    public static class YourDollarContextExtensions
    {
        public static void EnsurePeopleSeedDataForContext(this YourDollarContext context)
        {
            if (context.People.Any())
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
    }
}
