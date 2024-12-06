using DTO;
using System.Collections.Generic;
using System.Linq;

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
    }
}
