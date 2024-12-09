using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class InvoicesStatusDTO
    {
        public string InvoiceId { get; set; }
        public string Status { get; set; }

        public DateTime ? dateUpdate { get; set; }
    }
}
