using MaterialSkin.Controls;
using QuanLyCuaHangSach.Bus;
using QuanLyCuaHangSach.Dto;
using QuanLyCuaHangSach.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3.Gui.Forms
{
    public partial class FAddCustomer : MaterialForm
    {
        readonly MaterialSkin.MaterialSkinManager materialSkinManager;

        CustomerBus customerBus;
        public FAddCustomer()
        {
            InitializeComponent();

            customerBus = new CustomerBus();
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string phone = txtPhone.Text;
            string address = txtAddress.Text;

            DateTime birthday = txtBirthDay.Value;

            bool IsFemale = rdoNam.Enabled;

            rdoNam.Checked = true;

            if (ValidationInput.IsValidEmpty(name))
            {
                MessageBox.Show("Name không được bỏ trống.", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            if (ValidationInput.IsValidEmpty(phone))
            {
                MessageBox.Show("Phone không được bỏ trống.", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return;
            }
            if (ValidationInput.IsValidEmpty(address))
            {
                MessageBox.Show("Address không được bỏ trống.", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return;
            }

            if (!ValidationInput.IsNamePersonValid(name))
            {
                MessageBox.Show("Tên chỉ chứa kí tự chữ.", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            if (!ValidationInput.IsPhoneNumberValid(phone))
            {
                MessageBox.Show("Phone chỉ dài 10 kí tự và chỉ chứa kí tự số.", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return;
            }
            if (!ValidationInput.IsBirthDayValid(birthday))
            {
                MessageBox.Show("Ngày sinh không hợp lệ.", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBirthDay.Focus();
                return;
            }

            int gender;
            if(IsFemale)
            {
                gender = 1;
            }else
            {
                gender = 0;
            }
          
            var IsSuccess = customerBus.Add(new Customer
            {

                Name = name,
                Phone = phone,
                Address = address,
                Gender = gender,
                BirthDay = birthday,
            });

            if(IsSuccess)
            {
                MessageBox.Show("Thêm khách hàng mới thành công.", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
