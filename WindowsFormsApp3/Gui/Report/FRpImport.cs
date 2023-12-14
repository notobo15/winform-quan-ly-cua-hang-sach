using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp3.Gui.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using QuanLyCuaHangSach.Dto;
using QuanLyCuaHangSach.Bus;
using WindowsFormsApp3.Dto;

namespace WindowsFormsApp3.Gui.Report
{
    public partial class FRpImport : Form
    {
        BookBus BookBus = new BookBus();
        BookDetailBus BookDetailBus = new BookDetailBus();
        AccountBus AccountBus = new AccountBus();
        CustomerBus CustomerBus = new CustomerBus();
        OrderBus OrderBus = new OrderBus();
        OrderDetailBus OrderDetailBus = new OrderDetailBus();
        public int LastId { get; set; }
        public string NameSeller { get; set; }
        public int CustomerId { get; set; }
        public List<FOrder.CustomBook> Carts = new List<FOrder.CustomBook>();
        ImportBus ImportBus = new ImportBus();
        ImportDetailBus ImportDetailBus = new ImportDetailBus();
        public string orderId { get; set; }

        public bool OnlyPrint { get; set; } = false;

        public FRpImport()
        {
            InitializeComponent();
        }
        public FRpImport(string orderId)
        {
            InitializeComponent();
            this.orderId = orderId;
            OnlyPrint = true;
        }
    

        private void FRpOrder_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
           // reportViewer1.LocalReport.ReportPath = "C:\\Users\\notobo\\source\\repos\\BT C#\\WindowsFormsApp3\\WindowsFormsApp3\\Gui\\Report\\RpImport.rdlc";

            CustomOrder CustomOrder = null;
            if (OnlyPrint)
            {
                btnOrderConfirm.Enabled = false;
                var order = ImportBus.getFirstById(orderId);
                Carts = ImportBus.getListOrder(orderId);
                var account = AccountBus.getFirstById(order.AccountId.ToString());
                CustomOrder = new CustomOrder()
                {
                    CashierName = account.Name,
                    OrderDate = order.ImportDate,
                    OrderID = order.Id
                };

            }
            else {

                btnOrderConfirm.Enabled = true;
                LastId = ImportBus.CreateImport(new Import()
                {
                    ImportDate = DateTime.Now,
                    Status = "Đang thanh toán",
                    AccountId = 1
                });
               

                CustomOrder = new CustomOrder()
                {
                    CashierName = Authentication.Username,
                    OrderDate = DateTime.Now,
                    OrderID = LastId
                };
            }

            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", Carts);
            ReportDataSource reportDataSourceOrder = new ReportDataSource();

            reportDataSourceOrder.Name = "DataSet2";
            reportDataSourceOrder.Value = new List<CustomOrder>() { CustomOrder };
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            reportViewer1.LocalReport.DataSources.Add(reportDataSourceOrder);

            // Refresh báo cáo
            reportViewer1.RefreshReport();
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            var mess = MessageBox.Show("Bạn có chắc chắn kiểm tra thông tin chính xác ?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (mess == DialogResult.OK)
            {
               

                foreach (var item in Carts)
                {
                    ImportDetailBus.Add(new ImportDetail() { 
                        BookDetailId = item.BookDetailId,
                        BuyQuantity = item.Quantity,
                        ImportId = LastId,
                        Price = item.Price,
                    });
                }
                foreach (var item in Carts)
                {
                    BookDetailBus.UpdateQuantityImport(item.BookDetailId, item.Quantity);
                }
                OrderBus.UpdateStatusSuccess(LastId);
                MessageBox.Show("Đặt hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            ImportBus.DeleteHardById(LastId);
        }
    }
}
