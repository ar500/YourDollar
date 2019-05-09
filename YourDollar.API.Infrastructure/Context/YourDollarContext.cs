using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using YourDollar.API.Infrastructure.Entities;

namespace YourDollar.API.Infrastructure.Context
{
    public class YourDollarContext : DbContext
    {
        public DbSet<PersonEntity> People { get; set; }
        public DbSet<BudgetCategoryEntity> BudgetCategories { get; set; }

        public YourDollarContext(DbContextOptions<YourDollarContext> options)
        : base (options)
        {
            Database.Migrate();
        }
    }
}
