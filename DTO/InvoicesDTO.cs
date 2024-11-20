using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace DTO
{
    public class InvoicesDTO
    {

        public string InvoiceId { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public string PaymentMedId { get; set; }
        public string PaymentStatus { get; set; }
        public string DeliveryMedId { get; set; }
        public string DeliveryAddress { get; set; }
        public string RecipientPhone { get; set; }
        public string RecipientName { get; set; }
        public string Note { get; set; }
        public bool IsCompleted { get; set; }
        public string CustomerId { get; set; }
        public string UserId { get; set; }
        public string EmployeeId { get; set; }
        public bool IsCancelled { get; set; }
        public DateTime? CancelledDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public bool IsAccepted { get; set; }
        public DateTime? AcceptedDate { get; set; }
    }
}
