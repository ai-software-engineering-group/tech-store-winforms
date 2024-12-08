using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SupplierBLL
    {
        private SupplierDAL dal;

        public SupplierBLL()
        {
            dal = new SupplierDAL();
        }

        public List<Supplier> GetSuppliers()
        {
            return dal.GetSuppliers();
        }

        public Supplier GetSupplierById(string id)
        {
            return dal.GetSupplierById(id);
        }
    }
}
