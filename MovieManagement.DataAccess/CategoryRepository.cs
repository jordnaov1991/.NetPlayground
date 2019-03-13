using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.DataAccess
{
    public class CategoryRepository : BaseRepository
    {
        //adding access methods for application interaction with the DB - table Categories.
        public List<Category> SearchCategories()
        {
            return dbContext.Categories.ToList();
        }
        public Category GetCategory(Guid categoryId)
        {
            var category = dbContext.Categories.FirstOrDefault(a => a.id == categoryId);
            return category;

        }

        public void AddCategory(Category newCategory)
        {
            dbContext.Categories.Add(newCategory);
            dbContext.SaveChanges();
        }

        public void DeleteCategory(Guid categoryId)
        {
            var category = dbContext.Categories.FirstOrDefault(a => a.id == categoryId);
            if (category != null)
            {

                dbContext.Categories.Remove(category);
                dbContext.SaveChanges();
            }
        }

        public void UpdateCategory(Category updateCategory)
        {

            var existingCategory = dbContext.Categories.FirstOrDefault(a => a.id == updateCategory.id);
            if (existingCategory != null)
            {
                existingCategory.name = updateCategory.name;
                dbContext.SaveChanges();
            }

        }

    }
}
