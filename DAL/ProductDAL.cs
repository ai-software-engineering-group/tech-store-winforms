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

        public PagedList<Product> SearchProducts(int page, int pageSize, string search)
        {
            return context.Products.Where(p => p.ProductId == search ||
                   p.ProductName.ToLower().Contains(search))
                .ToPagedList(page, pageSize);
        }

        public List<Product> SearchProducts(string search)
        {
            return context.Products.Where(p => p.ProductId == search ||
                   p.ProductName.ToLower().Contains(search))
                .ToList();
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

        public bool UpdateProduct(Product product, List<ProductImage> images, List<ProductSpecification> specs)
        {
            Product _product = GetProductById(product.ProductId);
            if (_product == null)
            {
                return false;
            }

            try
            {
                _product.ProductName = product.ProductName;
                _product.OriginalPrice = product.OriginalPrice;
                _product.Price = product.Price;
                _product.ShortDescription = product.ShortDescription;
                _product.Description = product.Description;
                _product.Warranty = product.Warranty;
                _product.ManufacturedYear = product.ManufacturedYear;
                _product.CategoryId = product.CategoryId;
                _product.BrandId = product.BrandId;

                //_product.ProductImages.Clear();
                //foreach (var image in images)
                //{
                //    _product.ProductImages.Add(image);
                //}

                _product.ProductSpecifications.Clear();
                foreach (var spec in specs)
                {
                    _product.ProductSpecifications.Add(spec);
                }

                context.SubmitChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteProduct(string productId)
        {
            Product product = GetProductById(productId);
            if (product == null)
            {
                return false;
            }

            if(product.WarehouseProducts.Count > 0)
            {
                return false;
            }

            if(product.WarehouseImportDetails.Count > 0)
            {
                return false;
            }

            if(product.WarehouseExportDetails.Count > 0)
            {
                return false;
            }

            if(product.InvoiceDetails.Count > 0)
            {
                return false;
            }

            try
            {
                context.Products.DeleteOnSubmit(product);
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
