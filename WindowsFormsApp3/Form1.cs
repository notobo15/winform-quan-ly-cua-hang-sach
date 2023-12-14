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

namespace WindowsFormsApp3
{
    public partial class Form1 : MaterialForm
    {
        readonly MaterialSkin.MaterialSkinManager materialSkinManager;

        AccountBus account = new AccountBus();
        public List<Account> list = null;
        public Form1()
        {
            InitializeComponent();
            materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Indigo300, MaterialSkin.Primary.Indigo300,MaterialSkin.Primary.Indigo100, MaterialSkin.Accent.LightBlue700, MaterialSkin.TextShade.WHITE);
        }
      
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        private Bitmap Bitmap;


        private void materialButton1_Click(object sender, EventArgs e)
        {
            // this.Hide();
            Form2 form2 = new Form2();
              form2.Show();
            ///  

            Bitmap  = Util.GeneratorQR("1001"); ;
            pictureBox1.Image = Bitmap;


        }

        private void materialButton2_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG files (*.png)|*.png";
            saveFileDialog.Title = "Save QR Code Image";
            saveFileDialog.ShowDialog();
            saveFileDialog.FileName =  "qrcode.png"; // Đặt tên mặc định
            // Kiểm tra xem người dùng đã chọn nơi để lưu chưa
            if (!string.IsNullOrEmpty(saveFileDialog.FileName))
            {
                // Lưu hình ảnh QR vào tệp
                Bitmap.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                Console.WriteLine($"QR Code saved to: {saveFileDialog.FileName}");
            }

            // Giải phóng tài nguyên
          //  qrCodeImage.Dispose();
        }
    }
}
