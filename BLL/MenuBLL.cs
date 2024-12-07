using DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;


namespace BLL
{
    public class MenuBLL
    {
        MenuDAL menuDAL = new MenuDAL();

        public MenuBLL() { }

        public List<Menu> GetMenus()
        {
            try
            {
                return menuDAL.LoadMenus();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách danh mục: " + ex.Message);
                return null;
            }
        }

        // Phương thức thêm mới menu, tự động sinh mã
        public void AddMenu(Menu menu)
        {
            try
            {
                int lastMenuId = menuDAL.GetLastMenuId();
                menu.Id = lastMenuId + 1;  // Tăng giá trị mã menu lên 1
                menuDAL.AddMenu(menu);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm danh mục: " + ex.Message);
            }
        }

        // Các phương thức sửa, xóa cũng có thể sử dụng tương tự
        public void DeleteMenu(int id)
        {
            menuDAL.DeleteMenu(id);
        }

        public void UpdateMenu(Menu menu)
        {
            menuDAL.UpdateMenu(menu);
        }
    }

}
