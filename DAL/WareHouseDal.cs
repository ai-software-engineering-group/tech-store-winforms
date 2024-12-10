using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using DTO;

namespace DAL
{
    public class WareHouseDAL
    {
        STechDBDataContext db = new STechDBDataContext();   
        public WareHouseDAL()
        {

        }

        public List<warehouseDTO>Loadwarehouses()
        {
            return db.Warehouses.Select(w => new warehouseDTO
            {
                WareHouseId = w.WarehouseId,
                WareHouseName= w.WarehouseName,
                Address = w.Address,
                Ward = w.Ward,
                District = w.District,
                Province = w.Province,
                Type = w.Type,
            }).ToList();

        }

        public bool KTKC()
        {
            return false;
        }

        public bool InsertWareHouse(Warehouse wh)
        {
            try
            {
                var warehouse = new Warehouse
                {
                    WarehouseId = wh.WarehouseId,
                    WarehouseName = wh.WarehouseName,
                    Address = wh.Address,
                    WardCode = wh.WardCode,
                    DistrictCode = wh.DistrictCode,
                    ProvinceCode = wh.ProvinceCode,
                    Ward = wh.Ward,
                    District = wh.District,
                    Province = wh.Province,
                    Type = wh.Type,   
                };

                db.Warehouses.InsertOnSubmit(warehouse);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
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

        public bool updateWareHouse(warehouseDTO wh)
        {
            try
            {
                Warehouse warehouse_dt = db.Warehouses.FirstOrDefault(w => w.WarehouseId == wh.WareHouseId);

                if (warehouse_dt == null)
                {
                    return false;
                }

                warehouse_dt.WarehouseName = wh.WareHouseName;
                warehouse_dt.Address = wh.Address;
                warehouse_dt.Ward = wh.Ward;
                warehouse_dt.District = wh.District;
                warehouse_dt.Province = wh.Province;
                warehouse_dt.Type = wh.Type;

                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        #region Warehouse Import

        public bool CreateImportSlip(WarehouseImport slip)
        {
            try
            {
                db.WarehouseImports.InsertOnSubmit(slip);
                db.SubmitChanges();

                foreach (WarehouseImportDetail detail in slip.WarehouseImportDetails)
                {
                    WarehouseProduct wp = db.WarehouseProducts.FirstOrDefault(w => w.WarehouseId == slip.WarehouseId
                    && w.ProductId == detail.ProductId);

                    if (wp != null)
                    {
                        wp.Quantity += detail.Quantity;
                    }
                    else
                    {
                        WarehouseProduct new_wp = new WarehouseProduct
                        {
                            Quantity = detail.Quantity,
                            ProductId = detail.ProductId,
                            WarehouseId = slip.WarehouseId
                        };

                        db.WarehouseProducts.InsertOnSubmit(new_wp);
                    }

                    //Create import history
                    WarehouseImportHistory history = new WarehouseImportHistory
                    {
                        HistoryId = Guid.NewGuid().ToString(),
                        BatchNumber = $"{detail.ProductId}_{slip.DateImport.Value.ToString("ddMMyyyyHHmm")}",
                        ImportDate = slip.DateImport.Value,
                        ProductId = detail.ProductId,
                        Quantity = detail.Quantity,
                        WIId = slip.WIId,
                    };

                    db.WarehouseImportHistories.InsertOnSubmit(history);
                }

                db.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion


        // Export
    }
}
