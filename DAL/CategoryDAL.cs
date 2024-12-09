using DTO;
using PTPM_AI_CT3.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class CategoryDAL
    {
        private STechDBDataContext db;

        public CategoryDAL()
        {
            db = new STechDBDataContext();
        }

        public IEnumerable<Category> GetCategories()
        {
            return db.Categories.ToList();
        }
        public List<Category> LoadCategory()
        {
            try
            {
                if (db == null)
                {
                    throw new InvalidOperationException("Chưa có dữ liệu");
                }

                var categoriesList = db.Categories.ToList();
                return categoriesList ?? new List<Category>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return new List<Category>();
            }
        }
        public bool AddCategory(Category category)
        {
            try
            {
                db.Categories.InsertOnSubmit(category);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding category: " + ex.Message);
                return false;
            }
        }

        public bool UpdateCategory(Category category)
        {
            try
            {
                var existingCategory = db.Categories.SingleOrDefault(c => c.CategoryId == category.CategoryId);
                if (existingCategory != null)
                {
                    existingCategory.CategoryName = category.CategoryName;
                    existingCategory.ImageSrc = category.ImageSrc;
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating category: " + ex.Message);
                return false;
            }
        }

        public bool DeleteCategory(string categoryId)
        {
            try
            {
                var category = db.Categories.SingleOrDefault(c => c.CategoryId == categoryId);
                if (category != null)
                {
                    db.Categories.DeleteOnSubmit(category);
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting category: " + ex.Message);
                return false;
            }
        }

    }
}
