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

        public List<InvoicesStatusDTO> invoiceStatuses()
        {
            return db.InvoiceStatus.Select(invoice => new InvoicesStatusDTO
            {
                InvoiceId = invoice.InvoiceId,
                Status = invoice.Status,
                dateUpdate = invoice.DateUpdated,
            }).ToList();
           
        }

        public InvoicesStatusDTO FindinvoiceStatus(string invoiceId)
        {
            try
            {
                var invoice = db.InvoiceStatus.FirstOrDefault(i => i.InvoiceId == invoiceId);
                if (invoice != null)
                {
                    return new InvoicesStatusDTO
                    {
                        InvoiceId = invoice.InvoiceId,
                        Status = invoice.Status,
                        dateUpdate = invoice.DateUpdated ?? DateTime.MinValue,
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error finding invoice: {ex.Message}");
                return null;
            }
        }
        public InvoicesDTO FindInvoice(string invoiceId)
        {
            try
            {
                var invoice = db.Invoices.SingleOrDefault(i => i.InvoiceId == invoiceId);
                if (invoice != null)
                {
                    return new InvoicesDTO
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
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error finding invoice: {ex.Message}");
                return null;
            }
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
        public int GetMonthlyProductsSold(int month, int year)
        {
          
            var productsSold = db.InvoiceDetails
                .Where(id => id.Invoice.OrderDate.Value.Month == month && id.Invoice.OrderDate.Value.Year == year && id.Invoice.IsCancelled == false)
                .Sum(id => (int?)id.Quantity) ?? 0; 
            return productsSold;
        }

        public decimal GetMonthlySales(int month, int year)
        {
            var totalSales = db.Invoices
                .Where(i => i.OrderDate.Value.Month == month && i.OrderDate.Value.Year == year && i.IsCancelled == false)
                .Sum(i => (decimal?)i.Total) ?? 0m;  
            return totalSales;
        }

        public int GetMonthlyOrders(int month, int year)
        {
            var totalOrders = db.Invoices
                .Where(i => i.OrderDate.Value.Month == month && i.OrderDate.Value.Year == year && i.IsCancelled == false)
                .Count();
            return totalOrders;
        }


        public List<ProductSalesDTO> GetTopSellingProducts(int month, int year)
        {
            return (from id in db.InvoiceDetails
                    join p in db.Products on id.ProductId equals p.ProductId
                    where id.Invoice.OrderDate.Value.Month == month && id.Invoice.OrderDate.Value.Year == year && id.Invoice.IsCancelled == false
                    group id by p.ProductName into g
                    orderby g.Sum(x => x.Quantity) descending
                    select new ProductSalesDTO
                    {
                        ProductName = g.Key,
                        TotalSold = g.Sum(x => x.Quantity)
                    }).Take(10).ToList();
        }

        public List<SalesChartDTO> GetSalesDataForChart(int month, int year)
        {
            return (from invoice in db.Invoices
                    where invoice.OrderDate.Value.Month == month && invoice.OrderDate.Value.Year == year && invoice.IsCancelled == false
                    group invoice by new
                    {
                        Year = invoice.OrderDate.Value.Year,
                        Month = invoice.OrderDate.Value.Month
                    } into g
                    select new SalesChartDTO
                    {
                        Date = new DateTime(g.Key.Year, g.Key.Month, 1),
                        TotalSales = g.Sum(x => x.Total),
                        TotalOrders = g.Count()
                    }).ToList();
        }
        public List<SalesData> GetSalesDataForChart(int year)
        {
            var salesData = db.Invoices
            .Where(i => i.OrderDate.Value.Year == year && i.IsCancelled == false)  
            .GroupBy(i => i.OrderDate.Value.Month)
            .Select(g => new SalesData
            {
                Date = g.First().OrderDate.Value,
                TotalSales = g.Sum(i => i.Total),
                TotalOrders = g.Count() 
            })
            .ToList();


            var allMonthsData = Enumerable.Range(1, 12).Select(month => new SalesData
            {
                Date = new DateTime(year, month, 1),
                TotalSales = salesData.FirstOrDefault(d => d.Date.Month == month)?.TotalSales ?? 0,
                TotalOrders = salesData.FirstOrDefault(d => d.Date.Month == month)?.TotalOrders ?? 0
            }).ToList();

            return allMonthsData;
        }
        public List<UserActivityDTO> GetActiveUsers()
        {
            return (from u in db.Users
                    join i in db.Invoices on u.UserId equals i.UserId
                    where u.IsActive == true
                    group i by u.FullName into g
                    orderby g.Count() descending
                    select new UserActivityDTO
                    {
                        FullName = g.Key,
                        OrdersCount = g.Count()
                    }).ToList();
        }
    }
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
        public int TotalOrders { get; set; } 
    }
    public class SalesData
    {
        public DateTime Date { get; set; } 
        public decimal TotalSales { get; set; } 
        public int TotalOrders { get; set; } 
    }

}
