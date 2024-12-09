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

        public List<InvoicesDTO>GetInvoices()
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
        // Lấy dữ liệu doanh thu cho biểu đồ(mới thêm vào)
        public List<SalesChartDTO> GetSalesDataForChart()
        {
            return invoicesdal.GetSalesDataForChart();
        }
        // Lấy tổng doanh thu
        public decimal GetTotalSales()
        {
            return invoicesdal.GetTotalSales();
        }

        // Lấy tổng số đơn hàng
        public int GetTotalOrders()
        {
            return invoicesdal.GetTotalOrders();
        }

        // Lấy sản phẩm bán chạy
        public List<ProductSalesDTO> GetTopSellingProducts()
        {
            return invoicesdal.GetTopSellingProducts();
        }

        // Lấy người dùng hoạt động
        public List<UserActivityDTO> GetActiveUsers()
        {
            return invoicesdal.GetActiveUsers();
        }

    }
}
