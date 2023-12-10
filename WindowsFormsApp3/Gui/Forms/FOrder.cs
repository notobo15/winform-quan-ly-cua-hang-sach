using MaterialSkin;
using MaterialSkin.Controls;
using QuanLyCuaHangSach.Bus;
using QuanLyCuaHangSach.Dto;
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
    public partial class FOrder : MaterialForm
    {
        readonly MaterialSkin.MaterialSkinManager materialSkinManager;
        BookBus bookBus = new BookBus();
        List<Book> BookList = new List<Book>();
        public FOrder()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            //  materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);


           
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {

        }

        private void FOrder_Load(object sender, EventArgs e)
        {
            BookList = bookBus.getList();
            RenderDataBook();

        }
        void RenderDataBook()
        {
            dataGridView1.Rows.Clear();

            foreach (var item in BookList)
            {
                dataGridView1.Rows.Add(item.Id.ToString(), item.Name);
            }


        }
        // Thêm biến hoặc thuộc tính để lưu trữ giá trị barcode
        private string capturedBarcode;
        private void materialButton1_Click_1(object sender, EventArgs e)
        {
            FBarCodeScanner barcodeScannerForm = new FBarCodeScanner();

            // Gắn sự kiện FormClosed để xử lý khi form FBarCodeScanner đóng
            barcodeScannerForm.FormClosed += BarcodeScannerForm_FormClosed;

            // Hiển thị form FBarCodeScanner
            barcodeScannerForm.Show();
        }

        // Sự kiện FormClosed được gọi khi form FBarCodeScanner đóng
        private void BarcodeScannerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Sử dụng phương thức GetCapturedBarcode từ form FBarCodeScanner
            FBarCodeScanner barcodeScannerForm = sender as FBarCodeScanner;
            if (barcodeScannerForm != null)
            {
                string capturedBarcode = barcodeScannerForm.GetCapturedBarcode();
                MessageBox.Show("Captured Barcode: " + capturedBarcode);
            }
        }
    }
}
