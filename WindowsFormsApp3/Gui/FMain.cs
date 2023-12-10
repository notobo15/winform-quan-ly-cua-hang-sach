using MaterialSkin;
using MaterialSkin.Controls;
using QuanLyCuaHangSach.Bus;
using QuanLyCuaHangSach.Dto;
using QuanLyCuaHangSach.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp3
{
    public partial class FMain :  MaterialForm
    {
        private Timer timer;
        private Timer time;
        readonly MaterialSkin.MaterialSkinManager materialSkinManager;

        CategoryBus categoryBus = new CategoryBus();
        List<Category> category = null;
        public bool themmoiCategory = false;
        private FLogin fLogin;

        public FMain()
        {
            category = categoryBus.getList();
            InitializeComponent();
            InitializeTimer();
            var materialSkinManager = MaterialSkinManager.Instance;
          //  materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            // Khởi tạo Timer với khoảng thời gian là 1000ms (1 giây)
            timer = new Timer();
            timer.Interval = 1000;

            // Gắn sự kiện Tick cho Timer
            timer.Tick += Timer_Tick1;

            // Bắt đầu chạy Timer
            timer.Start();


             setButtonCategory(true);

        }

        public FMain(FLogin fLogin)
        {
            this.fLogin = fLogin;

            category = categoryBus.getList();
            InitializeComponent();
            InitializeTimer();
            var materialSkinManager = MaterialSkinManager.Instance;
            //  materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            // Khởi tạo Timer với khoảng thời gian là 1000ms (1 giây)
            timer = new Timer();
            timer.Interval = 1000;

            // Gắn sự kiện Tick cho Timer
            timer.Tick += Timer_Tick1;

            // Bắt đầu chạy Timer
            timer.Start();
        }

        private void Timer_Tick1(object sender, EventArgs e)
        {
            // Mỗi lần Timer tick, cập nhật thời gian mới và hiển thị nó trong Label
            string currentTime = DateTime.Now.ToString("dd/M/yyyyy HH:mm:ss");
            label6.Text = currentTime;
        }
        private void FMain_Load(object sender, EventArgs e)
        {

            this.FormClosed += FMain_Closing;
            AccountBus accountBus = new AccountBus();
            // dataGridView1.DataSource = accountBus.getList();

            foreach (var item in accountBus.getList())
            {
                dataGridView1.Rows.Add(item.Id, item.Name, item.UserName);
            }

            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;


            //  category 

            RenderDataGridView(dgvCategory, category);

          

        }

        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 2000 / 100; // Đặt thời gian đợi giữa các lần cập nhật ProgressBar (milliseconds)
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateProgressBar();
        }

        private void UpdateProgressBar()
        {
            materialProgressBar1.Value += 1; // Cập nhật giá trị ProgressBar

            if (materialProgressBar1.Value >= materialProgressBar1.Maximum)
            {
               materialProgressBar1.Value = materialProgressBar1.Minimum; // Reset giá trị khi nó đạt giá trị tối đa
            }
        }



        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("aaaaaaâ");
        }

   

        private void materialTabControl1_Click(object sender, EventArgs e)
        {
            var formExit = MessageBox.Show(ValidationInput.COMFIRM_EXIT, ValidationInput.TITLE, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(formExit == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void materialTabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            var formExit = MessageBox.Show(ValidationInput.COMFIRM_EXIT, ValidationInput.TITLE, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (formExit == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void materialTabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            var formExit = MessageBox.Show(ValidationInput.COMFIRM_EXIT, ValidationInput.TITLE, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (formExit == DialogResult.OK)
            {
                this.Close();
            }
        }


        void setButtonCategory(bool val)
        {
            btnCategoryAdd.Enabled = val; 
            btnCategoryDelete.Enabled = val;
            btnCategoryEdit.Enabled = val; 
            btnCategorySave.Enabled = !val; 
            btnCategoryCancel.Enabled = !val;
        }

        private void btnCategoryAdd_Click(object sender, EventArgs e)
        {
            themmoiCategory = true;
            setButtonCategory(false);
            txtCategoryName.Focus();
        }

        private void btnCategoryDelete_Click(object sender, EventArgs e)
        {
            if (dgvCategory.SelectedRows.Count > 0)
            {
                DialogResult dr = MessageBox.Show(ValidationInput.COMFIRM_DELETE, ValidationInput.TITLE, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    bool deleteIsSucess = categoryBus.DeleteById(txtCategoryId.Text.Trim());
                    if (deleteIsSucess)
                    {
                        MessageBox.Show("Xoa thanh cong");
                        setButtonCategory(true);
                        category = categoryBus.getList();
                        RenderDataGridView(dgvCategory, category);
                    }
                }


            }
            else
                MessageBox.Show("Bạn  phải  chọn  mẩu  tin  cần  xóa");
        }

        private void btnCategoryEdit_Click(object sender, EventArgs e)
        {
            if (dgvCategory.SelectedRows.Count > 0)
            {
                themmoiCategory = false;
                setButtonCategory(false);
            }
            else
            {
                MessageBox.Show(ValidationInput.MISS_DATA_EDIT,
                ValidationInput.TITLE);
            }

        }
        void setNull()
        {
            // txtHoten.Text = ""; txtDiaChi.Text = ""; txtDienThoai.Text = "";
        }
        private void btnCategorySave_Click(object sender, EventArgs e)
        {
            if (themmoiCategory)
            {
                bool IsSuccess = categoryBus.Add(new Category() { Name = txtCategoryName.Text });
                if (IsSuccess)
                {
                    MessageBox.Show(ValidationInput.SUCCESS_ADD, ValidationInput.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                bool IsSuccess = categoryBus.UpdateById(new Category() { Id = Convert.ToInt32(txtCategoryId?.Text), Name = txtCategoryName.Text });
                if (IsSuccess)
                {
                    MessageBox.Show(ValidationInput.SUCCESS_EDIT, ValidationInput.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
            }

            setButtonCategory(true);
            category = categoryBus.getList();
            RenderDataGridView(dgvCategory, category);
        }

        private void btnCategoryCancel_Click(object sender, EventArgs e)
        {
            setButtonCategory(true);
        }

        private void kryptonTextBox11_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtCategorySearch.Text.ToLower().Trim(); // Convert to lowercase for case-insensitive search
            var searchResult = category
                .Where(account =>
                    account.Id.ToString().ToLower().Contains(keyword) ||
                    account.Name.ToLower().Contains(keyword) 
                )
                .ToList();

            RenderDataGridView(dgvCategory, searchResult);
        }

        public void RenderDataGridView(DataGridView dataGridView, dynamic list)
        {
            dataGridView.Rows.Clear();
            dataGridView.Refresh();
            foreach (var item in list)
            {
                dataGridView.Rows.Add(item.Id, item.Name);
            }
        }

        private void materialButton11_Click(object sender, EventArgs e)
        {
            category = categoryBus.getList();
            RenderDataGridView(dgvCategory, category);
        }
        void RefreshData(dynamic bus, dynamic list)
        {
            list = bus?.getList();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            txtCategorySearch.Text = string.Empty;
            txtCategorySearch.Focus();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dgvCategory_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategory.SelectedRows.Count > 0)
            {
                txtCategoryId.Text = dgvCategory.SelectedRows[0].Cells[0].Value?.ToString() ?? "";
                txtCategoryName.Text = dgvCategory.SelectedRows[0].Cells[1].Value?.ToString() ?? "";
            }
            else
            {
                txtCategoryId.Text = "";
                txtCategoryName.Text = "";
            }
        }
        private void FMain_Closing(object sender, FormClosedEventArgs e)
        {
            // Close the FLogin form when FMain is closed
           // fLogin.Close();
        }

        private void FMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

       

    }
}
