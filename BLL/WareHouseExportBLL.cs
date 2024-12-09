using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class WareHouseExportBLL
    {
        WareHouseExportDAL warehouseExprot = new WareHouseExportDAL();
        public WareHouseExportBLL() { }

        public List<warehouseExportDTO> GetWarehouseExports()
        {
            return warehouseExprot.loadwareHouse();
        }

        public bool UpdateWarehouseExport(warehouseExportDTO warehouseExportDTO)
        {
            return warehouseExprot.Update_warehouseExport(warehouseExportDTO);
        }

        public warehouseExportDTO SearchWarehouseExportById(string weId)
        {
            return warehouseExprot.SearchWarehouseExportById(weId);
        }

    }
}
