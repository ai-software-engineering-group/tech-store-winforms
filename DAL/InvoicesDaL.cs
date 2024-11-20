using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using DTO;

namespace DAL
{
    public class InvoicesDaL
    {
        scriptDataContext db = new scriptDataContext();
        public InvoicesDaL()
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


    }
}
