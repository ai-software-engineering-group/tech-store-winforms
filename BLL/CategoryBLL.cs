using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL
{
    public class CategoryBLL
    {
        private CategoryDAL dal;

        public CategoryBLL()
        {
            dal = new CategoryDAL();
        }

        public IEnumerable<Category> GetCategories()
        {
            return dal.GetCategories();
        }
        public List<Category> GetCategory()
        {
            try
            {
                return dal.LoadCategory();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách khách hàng: " + ex.Message);
                return null;
            }
        }
        public bool AddCategory(Category category)
        {
            return dal.AddCategory(category);
        }

        public bool UpdateCategory(Category category)
        {
            return dal.UpdateCategory(category);
        }

        public bool DeleteCategory(string categoryId)
        {
            return dal.DeleteCategory(categoryId);
        }

    }
}
