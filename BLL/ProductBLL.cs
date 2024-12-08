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

        public PagedList<Product> SearchProducts(int page, int pageSize, string search)
        {
            return productDAL.SearchProducts(page, pageSize, search);
        }

        public List<Product> SearchProducts(string search)
        {
            return productDAL.SearchProducts(search);
        }

        public Product GetProductById(string productId)
        {
            return productDAL.GetProductById(productId);
        }

        public bool AddProduct(Product product, List<ProductImage> images, List<ProductSpecification> specs)
        {
            return productDAL.AddProduct(product, images, specs);
        }

        public bool UpdateProduct(Product product, List<ProductImage> images, List<ProductSpecification> specs)
        {
            return productDAL.UpdateProduct(product, images, specs);
        }

        public bool DeleteProduct(string productId)
        {
            return productDAL.DeleteProduct(productId);
        }
    }
}
