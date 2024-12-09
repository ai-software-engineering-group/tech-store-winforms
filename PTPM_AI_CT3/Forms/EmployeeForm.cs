using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;
using PTPM_AI_CT3.Constants;
using PTPM_AI_CT3.Utils;
using PTPM_AI_CT3.AdressService;
using System.ComponentModel.Design;

namespace PTPM_AI_CT3.Forms
{
    public partial class EmployeeForm : Form
    {
        EmployeeBLL employeeBLL = new EmployeeBLL();
        UserBLL userBLL = new UserBLL();

        public EmployeeForm()
        {
            InitializeComponent();
            employeeBLL = new EmployeeBLL();
            dgv_NV.CellClick += Dgv_NV_CellClick;
            this.Load += EmployeeForm_Load;
            LoadProvincesAsync(); cb_TimKiem.Items.Add("Mã nhân viên");
            cb_TimKiem.Items.Add("Tên nhân viên");
            cb_TimKiem.Items.Add("Số điện thoại");
            cb_TimKiem.Items.Add("Ngày sinh");

            btn_TimKiem.BackColor = MyColors.LIGHTBLUE;
            btn_HienThiTatCa.BackColor = MyColors.LIGHTBLUE;
            btnAdd.BackColor = MyColors.GREEN;
            btnUpdate.BackColor = MyColors.LIGHTBLUE;
            btnDelete.BackColor = MyColors.RED;

            btn_TimKiem.Click += btn_TimKiem_Click;
            btn_HienThiTatCa.Click += btn_HienThiTatCa_Click;
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;

            cb_TimKiem.SelectedIndex = 0;
            cb_TimKiem.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_TimKiem.SelectedIndexChanged += Cb_TimKiem_SelectedIndexChanged;
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

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            cb_Tinh.SelectedIndexChanged += cb_Tinh_SelectedIndexChanged;
            cb_Quan.SelectedIndexChanged += cb_Quan_SelectedIndexChanged;
            cb_Phuong.SelectedIndexChanged += cb_Phuong_SelectedIndexChanged;
            LoadEmployee();
        }
        private bool ValidateEmployeeData()
        {
            // Kiểm tra tên khách hàng
            if (string.IsNullOrWhiteSpace(txt_TenNV.Text))
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

        private async void Dgv_NV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_NV.Rows[e.RowIndex];

                txt_MaNV.Text = row.Cells["EmployeeId"].Value?.ToString();
                txt_TenNV.Text = row.Cells["EmployeeName"].Value?.ToString();
                txt_SDT.Text = row.Cells["Phone"].Value?.ToString();
                txt_Email.Text = row.Cells["Email"].Value?.ToString();
                txt_CMT.Text = row.Cells["CitizenId"].Value?.ToString();
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
        private void LoadEmployee()
        {
            var employee = employeeBLL.GetEmployees();
            if (employee != null && employee.Any())
            {
                dgv_NV.DataSource = employee;
                dgv_NV.Columns["EmployeeId"].HeaderText = "Mã danh mục";
                dgv_NV.Columns["EmployeeName"].HeaderText = "Tên danh mục";
                dgv_NV.Columns["Phone"].HeaderText = "Số điện thoại";
                dgv_NV.Columns["Email"].HeaderText = "Email";
                dgv_NV.Columns["DOB"].HeaderText = "Ngày sinh";
                dgv_NV.Columns["Gender"].HeaderText = "Giới tính";
                dgv_NV.Columns["CitizenId"].HeaderText = "Chứng minh thư";
                dgv_NV.Columns["Address"].HeaderText = "Địa chỉ";
                dgv_NV.Columns["Ward"].HeaderText = "Phường/Xã";
                dgv_NV.Columns["District"].HeaderText = "Quận/Huyện";
                dgv_NV.Columns["Province"].HeaderText = "Thành phố/Tỉnh";
                dgv_NV.Columns["WardCode"].HeaderText = "Mã phưỡng/xã";
                dgv_NV.Columns["DistrictCode"].HeaderText = "Mã quận/huyện";
                dgv_NV.Columns["ProvinceCode"].HeaderText = "Mã thành phố/tỉnh";
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để hiển thị!");
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
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateEmployeeData())
                return;
            Employee newEmployee = new Employee
            {
                EmployeeName = txt_TenNV.Text,
                Phone = txt_SDT.Text,
                Email = txt_Email.Text,
                DOB = dtpNgaySinh.Value,
                Gender = radio_Nam.Checked ? "Nam" : "Nữ",
                CitizenId = txt_CMT.Text,
                Address = txt_DiaChi.Text,
                Ward = cb_Phuong.Text,
                District = cb_Quan.Text,
                Province = cb_Tinh.Text,
                WardCode = txt_MaPhuong.Text,
                DistrictCode = txt_MaQuan.Text,
                ProvinceCode = txt_MaTinh.Text
            };

            string employeeId = employeeBLL.AddEmployee(newEmployee);
            if (employeeId != null)
            {
                string password = RandomUtils.GenerateRandomString(10);
                string hashKey = RandomUtils.GenerateRandomString(20);

                bool result = userBLL.CreateUser(new User
                {
                    UserId = Guid.NewGuid().ToString(),
                    Username = employeeId,
                    PasswordHash = password.HashPasswordMD5(hashKey),
                    CreateAt = DateTime.Now,
                    Email = newEmployee.Email,
                    DOB = newEmployee.DOB,
                    FirstLogin = true,
                    Gender = newEmployee.Gender,
                    FullName = newEmployee.EmployeeName,
                    Phone = newEmployee.Phone,
                    RandomKey = hashKey,
                    IsActive = true,
                    RoleId = "admin",
                    EmployeeId = newEmployee.EmployeeId
                });

                if(result)
                {
                    Clipboard.SetText(password);
                    MessageBox.Show($"Thêm nhân viên thành công. \n" +
                        $"Tài khoản đăng nhập: {employeeId}\n" +
                        $"Mật khẩu: {password} \n\n" +
                        $"Đã copy mật khẩu vào clipboard");
                }

                LoadEmployee();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi thêm khách hàng.");
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateEmployeeData())
                return;
            Employee updateEmployee = new Employee
            {
                EmployeeId = txt_MaNV.Text,
                EmployeeName = txt_TenNV.Text,
                Phone = txt_SDT.Text,
                Email = txt_Email.Text,
                DOB = dtpNgaySinh.Value,
                Gender = radio_Nam.Checked ? "Nam" : "Nữ",
                CitizenId = txt_CMT.Text,
                Address = txt_DiaChi.Text,
                Ward = cb_Phuong.Text,
                District = cb_Quan.Text,
                Province = cb_Tinh.Text,
                WardCode = txt_MaPhuong.Text,
                DistrictCode = txt_MaQuan.Text,
                ProvinceCode = txt_MaTinh.Text
            };

            if (employeeBLL.UpdateEmployee(updateEmployee))
            {
                MessageBox.Show("Cập nhật nhân viên thành công");
                LoadEmployee(); 
            }
            else
            {
                MessageBox.Show("Cập nhật nhân viên thất bại");
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string employeeId = txt_MaNV.Text;

            if (string.IsNullOrWhiteSpace(employeeId))
            {
                MessageBox.Show("Vui lòng chọn nhân viên để xóa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            userBLL.DeleteEmployeeUser(employeeId);

            if(employeeBLL.DeleteEmployee(employeeId))
            {
                MessageBox.Show("Xóa nhân viên thành công");
            }
            else
            {
                MessageBox.Show("Xóa nhân viên thất bại");
                return;
            }
            LoadEmployee(); 
        }
        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txt_TimKiem.Text.Trim();
            string searchBy = cb_TimKiem.SelectedItem.ToString();

            List<Employee> results = new List<Employee>();

            switch (searchBy)
            {
                case "Mã nhân viên":
                    results = employeeBLL.SearchEmployeesById(keyword);
                    break;
                case "Tên nhân viên":
                    results = employeeBLL.SearchEmployeeByName(keyword);
                    break;
                case "Số điện thoại":
                    results = employeeBLL.SearchEmployeeByPhone(keyword);
                    break;
                case "Ngày sinh":
                    DateTime startDate = dtpTuNgay.Value.Date;
                    DateTime endDate = dtpDenNgay.Value.Date;
                    results = employeeBLL.SearchEmployeeByDOB(startDate, endDate);
                    break;
            }

            if (results.Any())
            {
                dgv_NV.DataSource = results;
            }
            else
            {
                MessageBox.Show("Không tìm thấy kết quả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgv_NV.DataSource = null;
            }
        }
        private void btn_HienThiTatCa_Click(object sender, EventArgs e)
        {
            LoadEmployee();
        }
    }
}
