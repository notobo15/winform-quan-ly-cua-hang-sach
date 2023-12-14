using Google.Protobuf.WellKnownTypes;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Reporting.WinForms;
using QuanLyCuaHangSach.Bus;
using QuanLyCuaHangSach.Dto;
using QuanLyCuaHangSach.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp3.Gui.Report;

namespace WindowsFormsApp3.Gui.Forms
{

    public partial class FImport : MaterialForm
    {
        readonly MaterialSkin.MaterialSkinManager materialSkinManager;
        BookBus BookBus = new BookBus();
        BookDetailBus BookDetailBus = new BookDetailBus();
        CustomerBus CustomerBus = new CustomerBus();
        DiscountBus DiscountBus = new DiscountBus();

        ImportBus ImportBus = new ImportBus();
        ImportDetailBus ImportDetailBus = new ImportDetailBus();

        List<Book> Books = new List<Book>();
        List<BookDetail> BookDetails = new List<BookDetail>();
        List<Customer> Customers = new List<Customer>();
        List<Discount> Discounts = new List<Discount>();



        public List<FOrder.CustomBook> ListBooks = new List<FOrder.CustomBook>();
        public List<FOrder.CustomBook> Carts = new List<FOrder.CustomBook>();
        public FImport()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            //  materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }


      
        private void FOrder_Load(object sender, EventArgs e)
        {
            UpdateListBooks();
        }

        public void UpdateListBooks()
        {
            Books = BookBus.getList();
            BookDetails = BookDetailBus.getList();

            var result = from b in Books
                         join bd in BookDetails
                         on b.Id equals bd.BookId
                         join d in Discounts on b.DiscountId equals d.Id
                         select new FOrder.CustomBook
                         {
                             Barcode = bd.Barcode,
                             BookDetailId = bd.Id,
                             BookId = b.Id,
                             Name = b.Name,
                             ImageName = b.Image,
                             Format = b.Format,
                             Price = b.Price,
                             Quantity = bd.Quantity,
                             TotalPage = b.TotalPage,
                             Language = b.Language,
                             Value = d.Value,
                             
                         };
            Discounts = DiscountBus.getList();  
            ListBooks = result.ToList();
            RenderDataBook(dataGridView1, result);
        }
        void RenderDataBook(DataGridView dataGridView, dynamic list)
        {
            dataGridView.Rows.Clear();

            foreach (var item in list)
            {
                dataGridView.Rows.Add(item.Barcode, item.BookId.ToString(), item.Name, item.Price, item.Quantity, item.Format, item.Language, item.ImageName);
            }
        }

        void RenderDataCart(DataGridView dataGridView, dynamic list)
        {
            dataGridView.Rows.Clear();
            int i = 1;

            foreach (var item in list)
            {
                dataGridView.Rows.Add(i++, item.Barcode, item.Name, item.Price, item.Quantity,item.Value, item.TotalCost);
            }


        }
        private string capturedBarcode;
        private void materialButton1_Click_1(object sender, EventArgs e)
        {
            FBarCodeScanner barcodeScannerForm = new FBarCodeScanner();

            barcodeScannerForm.FormClosed += BarcodeScannerForm_FormClosed;

            barcodeScannerForm.Show();
        }

        private void BarcodeScannerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FBarCodeScanner barcodeScannerForm = sender as FBarCodeScanner;
            if (barcodeScannerForm != null)
            {
                string Barcode = barcodeScannerForm.GetCapturedBarcode();
                //  MessageBox.Show("Captured Barcode: " + Barcode);

                var item = ListBooks.FirstOrDefault(x => x.Barcode == Barcode);

                if (item != null)
                {

                    var itemcarted = Carts.FirstOrDefault(i => i?.Barcode == Barcode);

                    if (itemcarted != null)
                    {
                        itemcarted.Quantity += 1;
                        item.SetTotalCost();
                    }
                    else
                    {
                        item.Quantity = 1;
                        item.SetTotalCost();
                        Carts.Add(item);
                    }
                    RenderDataCart(dataGridView2, Carts);
                }
                else
                {
                  //  MessageBox.Show("Lỗi không nhận được QR Code");
                }
            }
        }
        private void FOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
        }

        private void materialButton11_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                foreach (DataGridViewRow selectedRow in dataGridView1.SelectedRows)
                {
                    int selectedIndex = selectedRow.Index;
                    object cellValue = dataGridView1.Rows[selectedIndex].Cells[0].Value;
                    var item = ListBooks.FirstOrDefault(i => i?.Barcode == cellValue.ToString());

                    var Quantity = Convert.ToInt32(txtCartQuantity.Value);

                    var itemcarted = Carts.FirstOrDefault(i => i?.Barcode == cellValue.ToString());

                    if (itemcarted != null)
                    {
                        itemcarted.Quantity += Quantity;

                        itemcarted.TotalCost = item.Quantity * itemcarted.Price;
                    }
                    else
                    {
                        item.Quantity = Quantity;
                        //item.Price = Convert.ToDouble(txtEditCartPrice.Value);
                        Carts.Add(item);
                    }
                    txtCartQuantity.Value = 1;
                    RenderDataCart(dataGridView2, Carts);

                    // RenderDataBook(dataGridView1, ListBooks);
                }

            }
            else
            {
                MessageBox.Show("Bạn phải chọn mẩu tin cần xóa");
            }

            UpdateLabelTotalCost();
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView2.SelectedCells[0].RowIndex;

                object cellValue = dataGridView2.Rows[selectedIndex].Cells[4].Value;
                txtEditCartQuantity.Value = Convert.ToInt32(cellValue.ToString());
                object Price = dataGridView2.Rows[selectedIndex].Cells[3].Value;
                txtEditCartPrice.Value = Convert.ToDecimal(Price.ToString());

            }
            UpdateLabelTotalCost();
        }

        private void UpdateLabelTotalCost()
        {
            var totalCost = Carts.Sum(x => x.TotalCost);
            string temp = $"{string.Format("{0:N}", totalCost)}";
            lbTotalCost.Text = temp.Substring(0, temp.Length - 3) + "đ";
        }

        private void materialButton6_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView2.SelectedCells[0].RowIndex;


                object cellValue = dataGridView2.Rows[selectedIndex].Cells[1].Value;
                var item = Carts.FirstOrDefault(i => i?.Barcode == cellValue.ToString());

                var Quantity = Convert.ToInt32(txtEditCartQuantity.Value);
                item.Quantity = Quantity;
               // item.SetTotalCost();

                RenderDataCart(dataGridView2, Carts);


            }

            UpdateLabelTotalCost();
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {


            if (dataGridView2.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView2.SelectedCells[0].RowIndex;

                object cellValue = dataGridView2.Rows[selectedIndex].Cells[1].Value;

                var mess = MessageBox.Show(ValidationInput.COMFIRM_DELETE, ValidationInput.TITLE, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (mess == DialogResult.OK)
                {
                    var item = Carts.FirstOrDefault(b => b.Barcode == cellValue.ToString());
                    Carts.Remove(item);
                    RenderDataCart(dataGridView2, Carts);
                }
            }

        }

        private void materialButton4_Click(object sender, EventArgs e)
        {

            var mess = MessageBox.Show("Bạn có chắc chắn muốn clear giỏ hàng ?", ValidationInput.TITLE, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (mess == DialogResult.OK)
            {
                Carts.Clear();
                RenderDataCart(dataGridView2, Carts);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedCells[0].RowIndex;


                object cellValue = dataGridView1.Rows[selectedIndex].Cells[7].Value;
                string path = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;

                string url = Path.Combine(path, "images", cellValue.ToString().Trim());

                if (System.IO.File.Exists(url))
                {
                    Image image = Image.FromFile(url);

                    pictureBox1.Image = image;
                }
            }
        }
        private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.ToLower().Trim();
            var searchResult = ListBooks
                .Where(account =>
                    account.BookId.ToString().ToLower().Contains(keyword)
                    || account.Name.ToLower().Contains(keyword)
                    || account.Barcode.ToLower().Contains(keyword)
                    || account.Price.ToString().ToLower().Contains(keyword)
                    || account.Quantity.ToString().ToLower().Contains(keyword)
                    || account.TotalPage.ToString().ToLower().Contains(keyword)
                    || account.Language.ToString().ToLower().Contains(keyword)
                )
                .ToList();

            RenderDataBook(dataGridView1, searchResult);
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            UpdateListBooks();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            txtSearch.Focus();
            RenderDataBook(dataGridView1, ListBooks);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
     

        private void materialButton7_Click(object sender, EventArgs e)
        {
           if(Carts.Count > 0)
            {

                FRpImport FRpOrder = new FRpImport();
                FRpOrder.Carts = Carts;

                FRpOrder.ShowDialog();
            }else
            {
                var mess = MessageBox.Show("Giỏ hàng đang trống. Bạn bần phải thêm sản phẩm.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void materialButton5_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView2.SelectedCells[0].RowIndex;


                object cellValue = dataGridView2.Rows[selectedIndex].Cells[1].Value;
                var item = Carts.FirstOrDefault(i => i?.Barcode == cellValue.ToString());

                var Price = Convert.ToInt32(txtEditCartPrice.Value);
                item.Price = Price;
                item.TotalCost = item.Price * item.Quantity;
                // item.SetTotalCost();
                RenderDataCart(dataGridView2, Carts);

            }

            UpdateLabelTotalCost();
        }
    }
}
