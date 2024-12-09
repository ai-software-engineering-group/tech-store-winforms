using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class WarehouseBLL
    {
        WareHouseDAL wareHouseDal = new WareHouseDAL();
        public WarehouseBLL()
        {

        }

        public List<warehouseDTO>GetWareHouse()
        {
            return wareHouseDal.Loadwarehouses();
        }

        public bool insertWareHouse(Warehouse wh)
        {
            return wareHouseDal.InsertWareHouse(wh);
        }

        public bool delete_wareHouse(string wh_id)
        {
            return wareHouseDal.deleteWareHouse(wh_id);
        }

        public bool updaate_warehouse(warehouseDTO wh)
        {
            return wareHouseDal.updateWareHouse(wh);
        }


        #region Warehouse Import

        public bool CreateImportSlip(WarehouseImport slip)
        {
            return wareHouseDal.CreateImportSlip(slip);
        }

        #endregion
    }
}
