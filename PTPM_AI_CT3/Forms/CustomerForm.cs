using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;
using PTPM_AI_CT3.Constants;
using PTPM_AI_CT3.AdressService;

namespace PTPM_AI_CT3.Forms
{
    public partial class CustomerForm : Form
    {
        List<Customer> customers = new List<Customer>();
        CustomersBLL customersBLL = new CustomersBLL();

        public CustomerForm()
        {
            InitializeComponent();

            dgv_DSKH.CellClick += Dgv_DSKH_CellClick;
            cb_TimKiem.SelectedIndexChanged += Cb_TimKiem_SelectedIndexChanged;
            this.Load += QLKhachHang_Load;

            btnAdd.BackColor = MyColors.GREEN;
            btnUpdate.BackColor = MyColors.LIGHTBLUE;
            btnDelete.BackColor = MyColors.RED;
            btn_TimKiem.BackColor = MyColors.LIGHTBLUE;
            btn_HienThiTatCa.BackColor = MyColors.LIGHTBLUE;


            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btn_TimKiem.Click += btn_TimKiem_Click;
            btn_HienThiTatCa.Click += btn_HienThiTatCa_Click;

            // Thêm các lựa chọn vào ComboBox
            cb_TimKiem.Items.Add("Mã khách hàng");
            cb_TimKiem.Items.Add("Tên khách hàng");
            cb_TimKiem.Items.Add("Số điện thoại");
            cb_TimKiem.Items.Add("Ngày sinh");

            cb_TimKiem.SelectedIndex = 0;
            cb_TimKiem.DropDownStyle = ComboBoxStyle.DropDownList;
            LoadProvincesAsync();
        }

        private void Cb_TimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_TimKiem.SelectedItem.ToString() == "Ngày sinh")
            {
                dtpTuNgay.Enabled = true;
                dtpDenNgay.Enabled = true;
                txt_TimKiem.Enabled = false;
            }
            else
            {
                dtpTuNgay.Enabled = false;
                dtpDenNgay.Enabled = false;
                txt_TimKiem.Enabled = true;
            }
        }

        private async void Dgv_DSKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_DSKH.Rows[e.RowIndex];

                txt_MaKH.Text = row.Cells["CustomerId"].Value?.ToString();
                txt_TenKH.Text = row.Cells["CustomerName"].Value?.ToString();
                txt_SDT.Text = row.Cells["Phone"].Value?.ToString();
                txt_Email.Text = row.Cells["Email"].Value?.ToString();

                if (DateTime.TryParse(row.Cells["DOB"].Value?.ToString(), out DateTime dob) && dob >= dtpNgaySinh.MinDate && dob <= dtpNgaySinh.MaxDate)
                {
                    dtpNgaySinh.Value = dob;
                }
                else
                {
                    dtpNgaySinh.Value = DateTime.Now;
                }

                // Chọn Giới tính
                if (row.Cells["Gender"].Value?.ToString() == "Nam")
                {
                    radio_Nam.Checked = true;
                }
                else
                {
                    radio_Nu.Checked = true;
                }

                txt_DiaChi.Text = row.Cells["Address"].Value?.ToString();

                // Lấy thông tin tỉnh, quận, phường từ dòng dữ liệu
                string provinceCode = row.Cells["ProvinceCode"].Value?.ToString();
                string districtCode = row.Cells["DistrictCode"].Value?.ToString();
                string wardCode = row.Cells["WardCode"].Value?.ToString();

                // Hiển thị mã Tỉnh, Quận, Phường vào các TextBox
                txt_MaTinh.Text = provinceCode;
                txt_MaQuan.Text = districtCode;
                txt_MaPhuong.Text = wardCode;

                // Chọn tỉnh trong cb_Tinh
                if (!string.IsNullOrEmpty(provinceCode))
                {
                    cb_Tinh.SelectedValue = provinceCode;
                }

                // Tải và chọn quận trong cb_Quan
                if (!string.IsNullOrEmpty(districtCode))
                {
                    await LoadDistrictsByProvince(provinceCode); // Tải quận khi tỉnh đã được chọn
                    cb_Quan.SelectedValue = districtCode;
                }

                // Tải và chọn phường trong cb_Phuong
                if (!string.IsNullOrEmpty(wardCode))
                {
                    await LoadWardsByDistrict(districtCode); // Tải phường khi quận đã được chọn
                    cb_Phuong.SelectedValue = wardCode;
                }
            }
        }


        private async Task LoadDistrictsByProvince(string provinceCode)
        {
            try
            {
                List<District> districts = await AddressService.GetDistrictsByProvinceAsync(provinceCode);
                cb_Quan.DataSource = districts;
                cb_Quan.DisplayMember = "Name";
                cb_Quan.ValueMember = "Code";
                cb_Quan.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách quận/huyện: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadWardsByDistrict(string districtCode)
        {
            try
            {
                List<Ward> wards = await AddressService.GetWardsByDistrictAsync(districtCode);
                cb_Phuong.DataSource = wards;
                cb_Phuong.DisplayMember = "Name";
                cb_Phuong.ValueMember = "Code";
                cb_Phuong.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách xã/phường: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm lấy danh sách tỉnh
        private async void LoadProvincesAsync()
        {
            try
            {
                List<Province> provinces = await AddressService.GetAllProvincesAsync();
                cb_Tinh.DataSource = provinces;
                cb_Tinh.DisplayMember = "Name";
                cb_Tinh.ValueMember = "Code";
                cb_Tinh.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
            }
        }

        // Hàm xử lý sự kiện chọn tỉnh
        private async void cb_Tinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Tinh.SelectedValue == null)
            {
                return; // Nếu không chọn tỉnh, không làm gì
            }

            string selectedProvinceCode = cb_Tinh.SelectedValue.ToString();

            txt_MaTinh.Text = selectedProvinceCode;

            try
            {
                // Lấy danh sách quận/huyện theo tỉnh đã chọn
                List<District> districts = await AddressService.GetDistrictsByProvinceAsync(selectedProvinceCode);
                cb_Quan.DataSource = districts;
                cb_Quan.DisplayMember = "Name";
                cb_Quan.ValueMember = "Code";
                cb_Quan.SelectedIndex = -1;

                // Reset lại xã/phường khi thay đổi tỉnh
                cb_Phuong.DataSource = null;
                cb_Phuong.SelectedIndex = -1;  // Không chọn xã/phường mặc định

            }
            catch (Exception ex)
            {
            }
        }


        // Hàm xử lý sự kiện chọn quận
        private async void cb_Quan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Quan.SelectedValue == null)
            {
                return; // Nếu không chọn quận, không làm gì
            }

            string selectedDistrictCode = cb_Quan.SelectedValue.ToString();

            // Hiển thị mã Quận vào TextBox
            txt_MaQuan.Text = selectedDistrictCode;

            try
            {
                // Lấy danh sách xã/phường theo quận đã chọn
                List<Ward> wards = await AddressService.GetWardsByDistrictAsync(selectedDistrictCode);
                cb_Phuong.DataSource = wards;
                cb_Phuong.DisplayMember = "Name";
                cb_Phuong.ValueMember = "Code";
                cb_Phuong.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
            }
        }

        private void cb_Phuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Phuong.SelectedValue == null)
            {
                return; // Nếu không chọn phường, không làm gì
            }

            string selectedWardCode = cb_Phuong.SelectedValue.ToString();

            // Hiển thị mã Phường vào TextBox
            txt_MaPhuong.Text = selectedWardCode;
        }

        // Đăng ký sự kiện và load dữ liệu
        private void QLKhachHang_Load(object sender, EventArgs e)
        {
            cb_Tinh.SelectedIndexChanged += cb_Tinh_SelectedIndexChanged;
            cb_Quan.SelectedIndexChanged += cb_Quan_SelectedIndexChanged;
            cb_Phuong.SelectedIndexChanged += cb_Phuong_SelectedIndexChanged;
            loadDB();
        }

        public void loadDB()
        {
            dgv_DSKH.DataSource = customersBLL.GetCustomers();
            CustomizeDataGridView();
        }
        private void CustomizeDataGridView()
        {
            dgv_DSKH.Columns["CustomerId"].HeaderText = "Mã khách hàng";
            dgv_DSKH.Columns["CustomerName"].HeaderText = "Tên khách hàng";
            dgv_DSKH.Columns["Phone"].HeaderText = "Số điện thoại";
            dgv_DSKH.Columns["Email"].HeaderText = "Email";
            dgv_DSKH.Columns["DOB"].HeaderText = "Ngày sinh";
            dgv_DSKH.Columns["Gender"].HeaderText = "Giới tính";
            dgv_DSKH.Columns["Address"].HeaderText = "Địa chỉ";
            dgv_DSKH.Columns["Ward"].HeaderText = "Phường/Xã";
            dgv_DSKH.Columns["District"].HeaderText = "Quận/Huyện";
            dgv_DSKH.Columns["Province"].HeaderText = "Thành phố/Tỉnh";
            dgv_DSKH.Columns["WardCode"].HeaderText = "Mã phưỡng/xã";
            dgv_DSKH.Columns["DistrictCode"].HeaderText = "Mã quận/huyện";
            dgv_DSKH.Columns["ProvinceCode"].HeaderText = "Mã thành phố/tỉnh";

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateCustomerData())
                return;
            Customer newCustomer = new Customer
            {
                CustomerName = txt_TenKH.Text,
                Phone = txt_SDT.Text,
                Email = txt_Email.Text,
                DOB = dtpNgaySinh.Value,
                Gender = radio_Nam.Checked ? "Nam" : "Nữ",
                Address = txt_DiaChi.Text,
                Ward = cb_Phuong.Text,
                District = cb_Quan.Text,
                Province = cb_Tinh.Text,
                WardCode = txt_MaPhuong.Text,
                DistrictCode = txt_MaQuan.Text,
                ProvinceCode = txt_MaTinh.Text
            };

            bool isSuccess = customersBLL.AddCustomer(newCustomer);
            if (isSuccess)
            {
                MessageBox.Show("Thêm khách hàng thành công.");
                loadDB();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi thêm khách hàng.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateCustomerData())
                return;
            Customer updatedCustomer = new Customer
            {
                CustomerId = txt_MaKH.Text, // Mã khách hàng cần sửa
                CustomerName = txt_TenKH.Text,
                Phone = txt_SDT.Text,
                Email = txt_Email.Text,
                DOB = dtpNgaySinh.Value,
                Gender = radio_Nam.Checked ? "Nam" : "Nữ",
                Address = txt_DiaChi.Text,
                Ward = cb_Phuong.Text,
                District = cb_Quan.Text,
                Province = cb_Tinh.Text,
                WardCode = txt_MaPhuong.Text,
                DistrictCode = txt_MaQuan.Text,
                ProvinceCode = txt_MaTinh.Text
            };

            if (customersBLL.UpdateCustomer(updatedCustomer))
            {
                MessageBox.Show("Cập nhật khách hàng thành công");
                loadDB(); // Reload danh sách khách hàng
            }
            else
            {
                MessageBox.Show("Cập nhật khách hàng thất bại");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string customerId = txt_MaKH.Text;

            if (string.IsNullOrWhiteSpace(customerId))
            {
                MessageBox.Show("Vui lòng chọn khách hàng để xóa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (customersBLL.DeleteCustomer(customerId))
            {
                MessageBox.Show("Xóa khách hàng thành công");
                loadDB(); // Reload danh sách khách hàng
            }
            else
            {
                MessageBox.Show("Xóa khách hàng thất bại");
            }
        }
        private bool ValidateCustomerData()
        {
            // Kiểm tra tên khách hàng
            if (string.IsNullOrWhiteSpace(txt_TenKH.Text))
            {
                MessageBox.Show("Tên khách hàng không được để trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Kiểm tra số điện thoại
            string phonePattern = @"^(\+84|0)[0-9]{9,10}$"; // Kiểm tra số điện thoại Việt Nam
            if (!System.Text.RegularExpressions.Regex.IsMatch(txt_SDT.Text, phonePattern))
            {
                MessageBox.Show("Số điện thoại không hợp lệ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Kiểm tra email
            try
            {
                var email = new System.Net.Mail.MailAddress(txt_Email.Text);
            }
            catch
            {
                MessageBox.Show("Email không hợp lệ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Kiểm tra ngày sinh
            if (dtpNgaySinh.Value > DateTime.Now || dtpNgaySinh.Value < new DateTime(1900, 1, 1))
            {
                MessageBox.Show("Ngày sinh không hợp lệ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Kiểm tra địa chỉ
            if (string.IsNullOrWhiteSpace(txt_DiaChi.Text))
            {
                MessageBox.Show("Địa chỉ không được để trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Kiểm tra tỉnh, quận, phường
            if (cb_Tinh.SelectedIndex == -1 || cb_Quan.SelectedIndex == -1 || cb_Phuong.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ thông tin tỉnh, quận, phường", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txt_TimKiem.Text.Trim();
            string searchBy = cb_TimKiem.SelectedItem.ToString();

            List<Customer> results = new List<Customer>();

            switch (searchBy)
            {
                case "Mã khách hàng":
                    results = customersBLL.SearchCustomersById(keyword);
                    break;
                case "Tên khách hàng":
                    results = customersBLL.SearchCustomersByName(keyword);
                    break;
                case "Số điện thoại":
                    results = customersBLL.SearchCustomersByPhone(keyword);
                    break;
                case "Ngày sinh":
                    DateTime startDate = dtpTuNgay.Value.Date;
                    DateTime endDate = dtpDenNgay.Value.Date;
                    results = customersBLL.SearchCustomersByDOB(startDate, endDate);
                    break;
            }

            if (results.Any())
            {
                dgv_DSKH.DataSource = results;
            }
            else
            {
                MessageBox.Show("Không tìm thấy kết quả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgv_DSKH.DataSource = null;
            }
        }

        private void btn_HienThiTatCa_Click(object sender, EventArgs e)
        {
            loadDB();
        }
    }
}
