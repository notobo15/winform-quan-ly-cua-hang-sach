using MaterialSkin.Controls;
using QuanLyCuaHangSach.Bus;
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
using WindowsFormsApp3.Dto;

namespace WindowsFormsApp3.Gui.Forms
{
    public partial class FResetPassword : MaterialForm
    {
        private bool IsSuccess { get; set; } = false;
        AccountBus AccountBus { get; set; } = new AccountBus();
        private string password {  get; set; }
        private string passwordConfirm {  get; set; }
        public string Username { get; set; }
        public FResetPassword()
        {
            InitializeComponent();
        }

        private void FResetPassword_Load(object sender, EventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            string password = txtPassword.Text;
            string passwordConfirm = txtPasswordConfirm.Text;


            if (ValidationInput.IsValidEmpty(password))
            {
                label1.Text = "Mật khẩu không được bỏ trống.";
                //MessageBox.Show("Mật khẩu không được bỏ trống.", ValidationInput.TITLE, MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }
            if (ValidationInput.IsValidEmpty(passwordConfirm))
            {
               // MessageBox.Show("Nhập lại mật khẩu không được bỏ trống.", ValidationInput.TITLE, MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);

                label1.Text = "Nhập lại mật khẩu không được bỏ trống.";
               txtPasswordConfirm.Focus();
                return;
            }
            if (!password.Equals(passwordConfirm))
            {
                label1.Text = "Mật khẩu và nhập lại mật khẩu không trùng khớp.";
                // MessageBox.Show("Mật khẩu và nhập lại mật khẩu không trùng khớp.", ValidationInput.TITLE, MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                txtPassword.Focus();
                txtPassword.Text = "";
                txtPasswordConfirm.Text = "";
                return;
            }
            if (AccountBus.ResetPassword("admin1", password))
            {
                MessageBox.Show("Reset mật khẩu thành công.", ValidationInput.TITLE);
                IsSuccess = true;
                //materialButton2_Click(sender, e);
                this.Hide();
            }
            /* 
               
            
            
             */
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
