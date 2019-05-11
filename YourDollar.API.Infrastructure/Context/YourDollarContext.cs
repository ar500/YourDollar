using Microsoft.EntityFrameworkCore;
using YourDollar.API.Infrastructure.Entities;

namespace YourDollar.API.Infrastructure.Context
{
    public class YourDollarContext : DbContext
    {
        public DbSet<PersonEntity> People { get; set; }
        public DbSet<BudgetCategoryEntity> BudgetCategories { get; set; }
        public DbSet<ExpenseEntity> Expenses { get; set; }

        public YourDollarContext(DbContextOptions<YourDollarContext> options)
        : base (options)
        {
            Database.Migrate();
        }
    }
}
