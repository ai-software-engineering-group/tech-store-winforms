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
        BrandDAL brandDal = new BrandDAL();

        public BrandBLL()
        {

        }

        public List<Brand> GetBrands()
        {
            return brandDal.LoadBrands();
        }

        public bool themBrand(Brand brand)
        {
            return brandDal.themBrand(brand);
        }

        public bool xoaBrand(string brand_id)
        {
            return brandDal.xoaBrand(brand_id);
        }

        public bool updateBrand(string brand_id, string brand_name, string brand_address, string brand_phone,string brand_Logo)
        {
            return brandDal.updateBrand(brand_id, brand_name, brand_address, brand_phone,brand_Logo);
        }

        public Brand find_brand(string brand_id)
        { 
            return brandDal.FindBrandById(brand_id);
        }

    }
}
