using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProductBLL
    {
        private ProductDAL productDAL = new ProductDAL();

        public List<Product> GetProducts()
        {
            return productDAL.GetProducts();
        }

        public PagedList<Product> GetProducts(int page, int pageSize)
        {
            return productDAL.GetProducts(page, pageSize);
        }
    }
}
