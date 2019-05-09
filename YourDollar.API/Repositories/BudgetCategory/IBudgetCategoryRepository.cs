using System;
using System.Collections.Generic;
using YourDollar.API.Infrastructure.Entities;

namespace YourDollar.API.Repositories.BudgetCategory
{
    public interface IBudgetCategoryRepository
    {
        IEnumerable<BudgetCategoryEntity> GetCategories();
        BudgetCategoryEntity GetCategoryById(Guid id);
        void AddCategory(BudgetCategoryEntity category);
        void RemoveCategory(BudgetCategoryEntity category);
        bool CategoryExists(Guid categoryId);
        bool SaveChanges();
    }
}