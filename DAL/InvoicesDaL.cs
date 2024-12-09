using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using DTO;
using System.Globalization;
namespace DAL
{
    public class InvoicesDAL
    {
        STechDBDataContext db = new STechDBDataContext();
        public InvoicesDAL()
        {

        }

        public List<InvoicesDTO> LoadInvoices()
        {
            return db.Invoices.Select(invoice => new InvoicesDTO
            {
                InvoiceId = invoice.InvoiceId,
                OrderDate = invoice.OrderDate,
                SubTotal = invoice.SubTotal,
                Total = invoice.Total,
                PaymentMedId = invoice.PaymentMedId,
                PaymentStatus = invoice.PaymentStatus,
                DeliveryMedId = invoice.DeliveryMedId,
                DeliveryAddress = invoice.DeliveryAddress,
                RecipientPhone = invoice.RecipientPhone,
                RecipientName = invoice.RecipientName,
                Note = invoice.Note,
                IsCompleted = invoice.IsCompleted,
                CustomerId = invoice.CustomerId,
                UserId = invoice.UserId,
                EmployeeId = invoice.EmployeeId,
                IsCancelled = invoice.IsCancelled,
                CancelledDate = invoice.CancelledDate,
                CompletedDate = invoice.CompletedDate,
                IsAccepted = invoice.IsAccepted,
                AcceptedDate = invoice.AcceptedDate
            }).ToList();
        }

        public bool UpdateAcceptedStatusAndInvoiceStatus(string invoiceId, bool isAccepted, DateTime? acceptedDate)
        {
            try
            {
                var invoice = db.Invoices.SingleOrDefault(i => i.InvoiceId == invoiceId);
                if (invoice != null)
                {
                    invoice.IsAccepted = isAccepted;
                    invoice.AcceptedDate = acceptedDate;

                    if (isAccepted)
                    {
                        var invoiceStatus = db.InvoiceStatus.SingleOrDefault(s => s.InvoiceId == invoiceId);
                        if (invoiceStatus != null)
                        {
                            invoiceStatus.Status = "Đã xác nhận";
                            invoiceStatus.DateUpdated = DateTime.Now;
                        }
                        else
                        {
                            db.InvoiceStatus.InsertOnSubmit(new InvoiceStatus
                            {
                                InvoiceId = invoiceId,
                                Status = "Đã xác nhận",
                                DateUpdated = DateTime.Now
                            });
                        }
                    }

                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating invoice: {ex.Message}");
                return false;
            }
        }

        public bool UpdateCompletedStatusAndInvoiceStatus(string invoiceId, bool isCompleted, DateTime? completedDate)
        {
            try
            {
                var invoice = db.Invoices.SingleOrDefault(i => i.InvoiceId == invoiceId);
                if (invoice != null)
                {
                    invoice.IsCompleted = isCompleted;
                    invoice.CompletedDate = completedDate;
                    if (isCompleted)
                    {
                        var invoiceStatus = db.InvoiceStatus.SingleOrDefault(s => s.InvoiceId == invoiceId);
                        if (invoiceStatus != null)
                        {
                            invoiceStatus.Status = "Đã hoàn thành";
                            invoiceStatus.DateUpdated = DateTime.Now;
                        }
                        else
                        {
                            db.InvoiceStatus.InsertOnSubmit(new InvoiceStatus
                            {
                                InvoiceId = invoiceId,
                                Status = "Đã hoàn thành",
                                DateUpdated = DateTime.Now
                            });
                        }
                    }

                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating invoice: {ex.Message}");
                return false;
            }
        }

        public bool UpdateCancelledStatus(string invoiceId, bool isCancelled)
        {
            try
            {
                var invoice = db.Invoices.SingleOrDefault(i => i.InvoiceId == invoiceId);
                if (invoice != null)
                {
                    invoice.IsCancelled = isCancelled;
                    invoice.CancelledDate = isCancelled ? DateTime.Now : (DateTime?)null;
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating invoice cancellation: {ex.Message}");
                return false;
            }
        }
        // Hàm lấy dữ liệu doanh thu theo tháng
        public List<SalesChartDTO> GetSalesDataForChart()
        {
            var salesData = (from invoice in db.Invoices
                             where invoice.IsCancelled == false
                             // Kiểm tra null và lấy Year và Month nếu có giá trị
                             group invoice by new
                             {
                                 Month = invoice.OrderDate.HasValue ? invoice.OrderDate.Value.Month : (int?)null,
                                 Year = invoice.OrderDate.HasValue ? invoice.OrderDate.Value.Year : (int?)null
                             } into g
                             orderby g.Key.Year, g.Key.Month
                             select new SalesChartDTO
                             {
                                 Date = new DateTime(g.Key.Year.Value, g.Key.Month.Value, 1),
                                 TotalSales = g.Sum(x => x.Total)
                             }).ToList();

            return salesData;
        }

        // Hàm tính tổng doanh thu
        public decimal GetTotalSales()
        {
            return db.Invoices
                .Where(i => i.IsCancelled == false)
                .Sum(i => i.Total);
        }

        // Hàm tính tổng số đơn hàng
        public int GetTotalOrders()
        {
            return db.Invoices
                .Where(i => i.IsCancelled == false)
                .Count();
        }

        // Hàm lấy sản phẩm bán chạy
        public List<ProductSalesDTO> GetTopSellingProducts()
        {
            var topSellingProducts = (from id in db.InvoiceDetails
                                      join p in db.Products on id.ProductId equals p.ProductId
                                      where id.Invoice.IsCancelled == false
                                      group id by p.ProductName into g
                                      orderby g.Sum(x => x.Quantity) descending
                                      select new ProductSalesDTO
                                      {
                                          ProductName = g.Key,
                                          TotalSold = g.Sum(x => x.Quantity)
                                      }).Take(10).ToList();
            return topSellingProducts;
        }

        // Hàm lấy người dùng hoạt động
        public List<UserActivityDTO> GetActiveUsers()
        {
            var activeUsers = (from u in db.Users
                               join i in db.Invoices on u.UserId equals i.UserId
                               where u.IsActive == true
                               group i by u.FullName into g
                               orderby g.Count() descending
                               select new UserActivityDTO
                               {
                                   FullName = g.Key,
                                   OrdersCount = g.Count()
                               }).ToList();
            return activeUsers;
        }
    }
}
// DTO để truyền dữ liệu của sản phẩm bán chạy và người dùng hoạt động
public class ProductSalesDTO
{
    public string ProductName { get; set; }
    public int TotalSold { get; set; }
}

public class UserActivityDTO
{
    public string FullName { get; set; }
    public int OrdersCount { get; set; }
}
public class SalesChartDTO
{
    public DateTime Date { get; set; }
    public decimal TotalSales { get; set; }

    
}
