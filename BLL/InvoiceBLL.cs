using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class InvoiceBLL
    {
        InvoicesDAL invoicesdal = new InvoicesDAL();
        public InvoiceBLL()
        {

        }

        public List<InvoicesStatusDTO> GetInvoiceStatuses()
        {
            return invoicesdal.invoiceStatuses();
        }
        public List<InvoicesDTO> GetInvoices()
        {
            return invoicesdal.LoadInvoices();
        }

        public bool UpdateAcceptedStatusAndInvoiceStatus(string invoiceId, bool isAccepted)
        {
            DateTime? acceptedDate = isAccepted ? DateTime.Now : (DateTime?)null;

            return invoicesdal.UpdateAcceptedStatusAndInvoiceStatus(invoiceId, isAccepted, acceptedDate);
        }

        public bool UpdateCompletedStatusAndInvoiceStatus(string invoiceId, bool isCompleted)
        {
            DateTime? completedDate = isCompleted ? DateTime.Now : (DateTime?)null;

            return invoicesdal.UpdateCompletedStatusAndInvoiceStatus(invoiceId, isCompleted, completedDate);
        }

        public bool UpdateCancelledStatus(string invoiceId, bool isCancelled)
        {
            return invoicesdal.UpdateCancelledStatus(invoiceId, isCancelled);
        }
        public InvoicesDTO find_invoicesId(string invoiceId)
        {
            return invoicesdal.FindInvoice(invoiceId);
        }

        public InvoicesStatusDTO Find_InvoicesStatusDTO(string invoiceId)
        {
            return invoicesdal.FindinvoiceStatus(invoiceId);
        }

        public int GetMonthlyProductsSold(int month, int year)
        {
            return invoicesdal.GetMonthlyProductsSold(month, year);
        }

        public decimal GetMonthlySales(int month, int year)
        {
            return invoicesdal.GetMonthlySales(month, year);
        }

        public int GetMonthlyOrders(int month, int year)
        {
            return invoicesdal.GetMonthlyOrders(month, year);
        }

        public List<ProductSalesDTO> GetTopSellingProducts(int month, int year)
        {
            return invoicesdal.GetTopSellingProducts(month, year);
        }

        public List<SalesChartDTO> GetSalesDataForChart(int month, int year)
        {
            return invoicesdal.GetSalesDataForChart(month, year);
        }

        public List<UserActivityDTO> GetActiveUsers()
        {
            return invoicesdal.GetActiveUsers();
        }
        public List<SalesData> GetSalesDataForChart(int year)
        {
            return invoicesdal.GetSalesDataForChart(year);
        }
    }
}
