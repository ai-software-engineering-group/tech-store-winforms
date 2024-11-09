using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class BrandBLL
    {
        BrandDaL brandDal = new BrandDaL();

        public BrandBLL()
        {

        }

        public List<Brand> getBrand()
        {
            return brandDal.LoadBrand();
        }

        public bool themBrand(Brand brand)
        {
            return brandDal.themBrand(brand);
        }

        public bool xoaBrand(string brand_id)
        {
            return brandDal.xoaBrand(brand_id);
        }

        public bool updateBrand(string brand_id, string brand_name, string brand_address, string brand_phone)
        {
            return brandDal.updateBrand(brand_id, brand_name, brand_address, brand_phone);
        }
    }
}
