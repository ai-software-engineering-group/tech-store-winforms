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

        public Product GetProductById(string productId)
        {
            return context.Products.FirstOrDefault(p => p.ProductId == productId);
        }

        public bool AddProduct(Product product, List<ProductImage> images, List<ProductSpecification> specs)
        {
            try
            {
                context.Products.InsertOnSubmit(product);
                context.SubmitChanges();

                foreach (var image in images)
                {
                    image.ProductId = product.ProductId;
                    context.ProductImages.InsertOnSubmit(image);
                }

                foreach (var spec in specs)
                {
                    spec.ProductId = product.ProductId;
                    context.ProductSpecifications.InsertOnSubmit(spec);
                }

                context.SubmitChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
