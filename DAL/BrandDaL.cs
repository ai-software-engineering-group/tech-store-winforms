﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using DTO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DAL
{
    public class BrandDaL
    {
        STechDBDataContext db = new STechDBDataContext();

        public BrandDaL() { }

        public List<Brand> LoadBrand()
        {
            return db.Brands.Select(Brand => Brand).ToList();
        }

        public bool themBrand(Brand br)
        {
            if (db.Brands.Any(existingBrand => existingBrand.BrandId == br.BrandId))
            {
                MessageBox.Show("BrandId đã tồn tại. Vui lòng nhập mã khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!IsValidPhone(br.Phone))
            {
                MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập số điện thoại hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                db.Brands.InsertOnSubmit(br);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                MessageBox.Show("Thêm Brand thất bại do lỗi hệ thống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool IsValidPhone(string phone)
        {
            return Regex.IsMatch(phone, @"^\d{10}$");
        }

        public bool xoaBrand(string brand_id)
        {
            Brand dtBrand = db.Brands.FirstOrDefault(mh => mh.BrandId == brand_id);
            if (dtBrand == null)
            {
                MessageBox.Show("Không tìm thấy Brand với BrandId đã cung cấp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                db.Brands.DeleteOnSubmit(dtBrand);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                MessageBox.Show("Xóa Brand thất bại do lỗi hệ thống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool updateBrand(string brand_id, string brand_name, string brand_address, string brand_phone)
        {
            Brand brandToUpdate = db.Brands.FirstOrDefault(br => br.BrandId == brand_id);
            if (brandToUpdate == null)
            {
                MessageBox.Show("Không tìm thấy Brand với BrandId đã cung cấp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!IsValidPhone(brand_phone))
            {
                MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập số điện thoại hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            brandToUpdate.BrandName = brand_name;
            brandToUpdate.Address = brand_address;
            brandToUpdate.Phone = brand_phone;

            try
            {
                db.SubmitChanges();
                return true;
            }
            catch
            {
                MessageBox.Show("Cập nhật Brand thất bại do lỗi hệ thống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
