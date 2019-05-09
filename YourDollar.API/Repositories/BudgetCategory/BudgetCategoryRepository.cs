using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Remotion.Linq.Clauses;
using YourDollar.API.Infrastructure.Context;
using YourDollar.API.Infrastructure.Entities;

namespace YourDollar.API.Repositories.BudgetCategory
{
    public class BudgetCategoryRepository
    {
        private readonly YourDollarContext _context;

        public BudgetCategoryRepository(YourDollarContext context)
        {
            _context = context;
        }

        public IEnumerable<BudgetCategoryEntity> GetCategories()
        {
            return _context.BudgetCategories
                .OrderBy(c => c.ShortName)
                .ToList();
        }

        public BudgetCategoryEntity GetCategoryById(Guid id)
        {
            return _context.BudgetCategories
                .FirstOrDefault(c => c.CategoryId == id);
        }

        public void AddCategory(BudgetCategoryEntity category)
        {
            _context.BudgetCategories.Add(category);
        }

        public void RemoveCategory(BudgetCategoryEntity category)
        {
            _context.BudgetCategories.Remove(category);
        }

        // TODO: Make an generic exists method and add to a base class
        public bool CategoryExists(Guid categoryId)
        {
            return _context.BudgetCategories.Any(c => c.CategoryId == categoryId);
        }

        // TODO: Move SaveChanges to base class.
        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
