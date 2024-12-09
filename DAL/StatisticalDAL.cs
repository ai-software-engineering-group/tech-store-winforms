using System;
using System.Collections.Generic;
using System.Linq;
using DTO;

namespace DAL
{
    public class StatisticalDAL
    {
        private STechDBDataContext db;

        public StatisticalDAL()
        {
            db = new STechDBDataContext();
        }
        // Phương thức lấy thống kê doanh thu theo ngày
        public List<RevenueStatDTO> GetRevenueStats(DateTime startDate, DateTime endDate)
        {
            var query = from sale in db.Sales
                        join saleProduct in db.SaleProducts on sale.SaleId equals saleProduct.SaleId
                        join product in db.Products on saleProduct.ProductId equals product.ProductId
                        where sale.StartDate >= startDate && sale.EndDate <= endDate
                        group saleProduct by product.ProductName into g
                        select new RevenueStatDTO
                        {
                            ProductName = g.Key,
                            TotalRevenue = g.Sum(x => x.SalePrice * x.SaleQuantity)
                        };

            return query.ToList();
        }



    }
}