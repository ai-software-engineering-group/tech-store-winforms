using DAL.Extensions;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductDAL
    {
        private STechDBDataContext context = new STechDBDataContext();

        public List<Product> GetProducts()
        {
            return context.Products.ToList();
        }

        public PagedList<Product> GetProducts(int page, int pageSize)
        {
            return context.Products.ToPagedList(page, pageSize);
        }
    }
}
