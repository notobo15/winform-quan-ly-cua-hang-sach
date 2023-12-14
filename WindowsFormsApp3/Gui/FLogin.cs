using MaterialSkin.Controls;
using QuanLyCuaHangSach.Bus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp3.Dto;
using Timer = System.Windows.Forms.Timer;

namespace WindowsFormsApp3
{
    public partial class FLogin : MaterialForm
    {

        readonly MaterialSkin.MaterialSkinManager materialSkinManager;
        AccountBus accountBus = new AccountBus();
        RoleBus roleBus = new RoleBus();
        public FLogin()
        {
            InitializeComponent();

            materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            // materialSkinManager.AddFormToManage(this);
            // materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Green700, MaterialSkin.Primary.Teal900, MaterialSkin.Primary.Indigo100, MaterialSkin.Accent.Green700, MaterialSkin.TextShade.WHITE);
        }

        private void FLogin_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {





            var loginSuccess = accountBus.Login(txtUsername.Text, txtPassword.Text);
            if (loginSuccess != null)
            {
                Authentication.Username = txtUsername.Text;
                Authentication.UserId = loginSuccess.Id;
                Authentication.RoleId = loginSuccess.RoleId;

                var role = roleBus.getFirstById(loginSuccess.RoleId.ToString());
                Authentication.Role = role.Name;
                this.Hide();
                var fLoading = new FLoading();
                fLoading.Show();
                var fMain = new FMain();

                var timer = new Timer();
                int totalMilliseconds = 2000;
                int interval = 100;
                int steps = totalMilliseconds / interval;
                int progress = 0;
                timer.Interval = interval;
                timer.Tick += (s, args) =>
                {
                    if (progress >= steps)
                    {
                        timer.Stop();
                        fMain.Show();
                        fLoading.Hide();
                    }
                    else
                    {
                        progress++;
                    }
                };
                timer.Start();
            }else
            {
                MessageBox.Show("Đăng nhập thất bại.Vui lòng kiểm tra Username và Password.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
