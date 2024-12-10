using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class WareHouseExportDAL
    {
        STechDBDataContext db = new STechDBDataContext();
        public WareHouseExportDAL()
        { 

        }

        public List<warehouseExportDTO>loadwareHouse()
        {
          
            return db.WarehouseExports.Select(wh => new warehouseExportDTO 
            { 
                WEId = wh.WEId,
                DateCreate = wh.DateCreate,
                DateExport = wh.DateExport,
                ReasonExport = wh.ReasonExport,
                Note = wh.Note,
                InvoiceId = wh.InvoiceId,
                EmployeeId = wh.EmployeeId,
                WarehouseId = wh.WarehouseId,
            }).ToList();
        }

        
        public bool Update_warehouseExport(warehouseExportDTO warehouseExportDTO)
        {
            try
            {
                var whExport = db.WarehouseExports.SingleOrDefault(wh => wh.WEId == warehouseExportDTO.WEId);
                if (whExport != null)
                {
                    whExport.DateExport = warehouseExportDTO.DateExport;
                    whExport.EmployeeId = warehouseExportDTO.EmployeeId;
                    whExport.Note = warehouseExportDTO.Note;

                    db.SubmitChanges();
                    return true; 
                }
                return false; 
            }
            catch (Exception)
            {
                return false;
            }
        }

        public warehouseExportDTO SearchWarehouseExportById(string weId)
        {
            try
            {
                var whExport = db.WarehouseExports
                                  .Where(wh => wh.WEId == weId)
                                  .Select(wh => new warehouseExportDTO
                                  {
                                      WEId = wh.WEId,
                                      DateCreate = wh.DateCreate,
                                      DateExport = wh.DateExport,
                                      ReasonExport = wh.ReasonExport,
                                      Note = wh.Note,
                                      InvoiceId = wh.InvoiceId,
                                      EmployeeId = wh.EmployeeId,
                                      WarehouseId = wh.WarehouseId,
                                  })
                                  .SingleOrDefault();

                return whExport;
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
