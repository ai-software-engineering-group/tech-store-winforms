using DAL;
using DTO;
using System.Collections.Generic;

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
    }
}
