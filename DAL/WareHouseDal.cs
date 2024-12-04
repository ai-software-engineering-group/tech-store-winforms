using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using DTO;

namespace DAL
{
    public class WareHouseDal
    {
        STechDBDataContext db = new STechDBDataContext();   
        public WareHouseDal()
        {

        }

        public List<Warehouse>Loadwarehouses()
        {
            return db.Warehouses.Select(w => w).ToList();
        }

        public bool KTKC()
        {
            return false;
        }

        public bool insertWareHouse(Warehouse wh)
        {
            try
            {
                db.Warehouses.InsertOnSubmit(wh);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

       public bool deleteWareHouse(string warehouseID)
        {
            try
            {
                Warehouse warehouse_dt = db.Warehouses.FirstOrDefault(wh => wh.WarehouseId == warehouseID);
                if(warehouseID == null)
                {
                    return false;
                }
                else
                {
                    db.Warehouses.DeleteOnSubmit(warehouse_dt);
                    db.SubmitChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool updateWareHouse(Warehouse wh)
        {
            try
            {
                Warehouse warehouse_dt = db.Warehouses.FirstOrDefault(w => w.WarehouseId == wh.WarehouseId);

                if (warehouse_dt == null)
                {
                    return false;
                }

                warehouse_dt.WarehouseName = wh.WarehouseName;
                warehouse_dt.Address = wh.Address;
                warehouse_dt.Ward = wh.Ward;
                warehouse_dt.WardCode = wh.WardCode;
                warehouse_dt.District = wh.District;
                warehouse_dt.DistrictCode = wh.DistrictCode;
                warehouse_dt.Province = wh.Province;
                warehouse_dt.ProvinceCode = wh.ProvinceCode;
                warehouse_dt.Type = wh.Type;
                warehouse_dt.Latitude = wh.Latitude;
                warehouse_dt.Longtitude = wh.Longtitude;

                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



    }
}
