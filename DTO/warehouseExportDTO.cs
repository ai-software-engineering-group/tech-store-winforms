using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class warehouseExportDTO
    {
       public string WEId { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime ? DateExport { get; set; }
        public string ReasonExport { get; set; }
        public string Note { get; set; }
        public string InvoiceId {  get; set; }
        public string EmployeeId { get; set; }
        public string WarehouseId { get; set; }
    }
}
