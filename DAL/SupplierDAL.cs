using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SupplierDAL
    {
        STechDBDataContext context;
        public SupplierDAL()
        {
            context = new STechDBDataContext();
        }

        public List<Supplier> GetSuppliers()
        {
            return context.Suppliers.ToList();
        }

        public Supplier GetSupplierById(string supplierId)
        {
            return context.Suppliers
                .FirstOrDefault(s => s.SupplierId == supplierId);
        }
    }
}
