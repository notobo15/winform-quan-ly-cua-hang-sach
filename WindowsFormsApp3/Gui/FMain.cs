
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using LiveCharts;
using LiveCharts.Wpf;
using MaterialSkin;
using MaterialSkin.Controls;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Org.BouncyCastle.Crypto;
using QuanLyCuaHangSach.Bus;
using QuanLyCuaHangSach.Dao;
using QuanLyCuaHangSach.Dto;
using QuanLyCuaHangSach.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Shapes;
using WindowsFormsApp3.Dto;
using WindowsFormsApp3.Gui.Forms;
using WindowsFormsApp3.Gui.Report;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Path = System.IO.Path;

namespace WindowsFormsApp3
{
    public partial class FMain : MaterialForm
    {
        private Timer timer;
        private Timer time;
        readonly MaterialSkin.MaterialSkinManager materialSkinManager;

        CategoryBus categoryBus = new CategoryBus();
        AccountBus AccountBus = new AccountBus();
        BookBus BookBus = new BookBus();
        BookDetailBus BookDetailBus = new BookDetailBus();
        AuthorBus AuthorBus = new AuthorBus();
        CategoryBus CategoryBus = new CategoryBus();
        CustomerBus CustomerBus = new CustomerBus();
        DiscountBus DiscountBus = new DiscountBus();
        RoleBus RoleBus = new RoleBus();
        SupplierBus SupplierBus = new SupplierBus();
        PublisherBus PublisherBus = new PublisherBus();
        OrderBus OrderBus = new OrderBus();
        OrderDetailBus OrderDetailBus = new OrderDetailBus();
        ImportBus ImportBus = new ImportBus();
        ImportDetailBus ImportDetailBus = new ImportDetailBus();


        List<Category> Categories = new List<Category>();
        List<Book> Books = new List<Book>();
        List<BookDetail> BookDetails = new List<BookDetail>();
        List<Author> Authors = new List<Author>();
        List<Customer> Customers = new List<Customer>();
        List<Role> Roles = new List<Role>();
        List<Supplier> Suppliers = new List<Supplier>();
        List<Publisher> Publishers = new List<Publisher>();
        List<Account> Accounts = new List<Account>();
        List<Discount> Discounts = new List<Discount>();
        List<Order> Orders = new List<Order>();
        List<OrderDetail> OrderDetails = new List<OrderDetail>();
        List<Import> Imports = new List<Import>();
        List<ImportDetail> ImportDetails = new List<ImportDetail>();


        dynamic TempBook = null;
        public bool themmoiCategory = false;
        public bool themmoAccount = false;
        public bool themmoAuthor = false;
        public bool themmoBook = false;
        public bool themmoBookDetail = false;
        public bool themmoCustomer = false;
        public bool themmoPublisher = false;
        public bool themmoSupplier = false;
        public bool themmoRole = false;
        public bool themmoDiscount = false;

        private FLogin fLogin;

        public FMain()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            //   materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            timer = new Timer();
            timer.Interval = 1000;

            timer.Tick += Timer_Tick1;

            timer.Start();

            setButtonCategory(true);
            setButtonAuthor(true);
            setButtonBook(true);
            setButtonBookDetail(true);
            setButtonSupplier(true);
            setButtonCustomer(true);
            setButtonPublisher(true);
            setButtonRole(true);
            setButtonDiscount(true);
            initBus();

            cbxImport.Items.AddRange(new object[] { "Category", "Account", "Author", "Book", "Book Detail", "Role", "Customer", "Publisher", "Supplier" });

        }

        public void initBus()
        {
            Categories = categoryBus.getList();
            Authors = AuthorBus.getList();
            Accounts = AccountBus.getList();
            Books = BookBus.getList();
            BookDetails = BookDetailBus.getList();
            Authors = AuthorBus.getList();
            Customers = CustomerBus.getList();
            Roles = RoleBus.getList();
            Suppliers = SupplierBus.getList();
            Publishers = PublisherBus.getList();
            Discounts = DiscountBus.getList();
            Orders = OrderBus.getList();
            OrderDetails = OrderDetailBus.getList();

            Imports = ImportBus.getList();
            ImportDetails = ImportDetailBus.getList();


            // thong ke

            labelCountBook.Text = $"Tổng Sách: {BookDetails.Sum(b => b.Quantity)}";
            labelCountCustomer.Text = $"Tổng Khách Hàng: {Customers.Count}";
            labelCountOrder.Text = $"Tổng Đơn Hàng: {Orders.Count}";
            labelCountUser.Text = $"Tổng User: {Accounts.Count}";






        }

        private void Timer_Tick1(object sender, EventArgs e)
        {
            // Mỗi lần Timer tick, cập nhật thời gian mới và hiển thị nó trong Label
            string currentTime = DateTime.Now.ToString("dd/M/yyyyy HH:mm:ss");
            label6.Text = currentTime;
        }
        private void FMain_Load(object sender, EventArgs e)
        {
            labelUserName.Text = Authentication.Username;
            labelRoleName.Text = Authentication.Role;

            txtDiscountStartDate.CustomFormat = "dd/MM/yyyy HH:mm";
            txtDiscountEndDate.CustomFormat = "dd/MM/yyyy HH:mm";
            this.FormClosed += FMain_Closing;

            dgvAuthor.BorderStyle = BorderStyle.None;
            dgvAuthor.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgvAuthor.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAuthor.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgvAuthor.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgvAuthor.BackgroundColor = Color.White;

            dgvAuthor.EnableHeadersVisualStyles = false;
            dgvAuthor.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvAuthor.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dgvAuthor.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;


            //  category 

            RenderDataGridView(dgvCategory, Categories);
            RenderDataGridViewAccount(dgvAccount, Accounts);
            RenderDataGridViewAuthor(dgvAuthor, Authors);
            RenderDataGridViewBook(dgvBook, Books);
            RenderDataGridViewBookDetail(dgvBookDetail, BookDetails);
            RenderDataGridViewCustomer(dgvCustomer, Customers);
            RenderDataGridViewRole(dgvRole, Roles);
            RenderDataGridViewSupplier(dgvSupplier, Suppliers);
            RenderDataGridViewPublisher(dgvPublisher, Publishers);
            RenderDataGridViewDiscount(dgvDiscount, Discounts);

            RenderDataGridViewOrder(dgvOrder, Orders);
            RenderDataGridViewImport(dgvImport, Imports);



            InitBook();
            InitAccount();
            InitBookDetail();
            setButtonAccount(true);
            setButtonBook(true);
            InitImport();
            InitOrders();

            cartesianChart1.Dock = DockStyle.Fill;
            var a = GetMonthlyTotalOrders(Orders);

            cartesianChart1.Series = new LiveCharts.SeriesCollection
            {

            new ColumnSeries
                {
                    Title = "Số đơn đặt hàng",
                   //Values = new ChartValues<int>() {1,2,2,3,3,20,10,2,1,2,3,3},
                   Values = new ChartValues<int>(GetMonthlyTotalOrders(Orders)),
                }
            };

            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Tháng",
                Labels = GetMonthLabels()
            });

          
        }
        public static List<int> GetMonthlyTotalOrders(List<Order> orders)
        {
            var monthlyTotals = new List<int>();

            for (int i = 1; i <= 12; i++)
            {
                int count = orders.Count(o => o.OrderDate.Month == i);
                monthlyTotals.Add(count);
            }

            return monthlyTotals;
        }
        private List<string> GetMonthLabels()
        {
            return Enumerable.Range(1, 12).Select(i => $"Tháng {i}").ToList();
        }
        public void InitAccount()
        {

            cbxAccountRole.DataSource = Roles;
            cbxAccountRole.DisplayMember = "Name";
            cbxAccountRole.ValueMember = "Id";
        }

        public void InitOrders()
        {

            cbxOrderBook.DataSource = Books;
            cbxOrderBook.DisplayMember = "Name";
            cbxOrderBook.ValueMember = "Id";
        }

        public void InitImport()
        {

            txtImportDetailBook.DataSource = Books;
            txtImportDetailBook.DisplayMember = "Name";
            txtImportDetailBook.ValueMember = "Id";
        }
        public void InitBook()
        {
            cbxBookAuthor.DataSource = Authors;
            cbxBookAuthor.DisplayMember = "FullName";
            cbxBookAuthor.ValueMember = "Id";

            cbxBookCategory.DataSource = Categories;
            cbxBookCategory.DisplayMember = "Name";
            cbxBookCategory.ValueMember = "Id";

            cbxBookPublisher.DataSource = Publishers;
            cbxBookPublisher.DisplayMember = "Name";
            cbxBookPublisher.ValueMember = "Id";

            cbxBookFormat.Items.Add("Bìa Cứng");
            cbxBookFormat.Items.Add("Bìa Mềm");

            var dis = Discounts;
            //dis.Insert(0, new Discount() { Id = 0, Name = "Không giảm giá" });
            cbxBookDiscount.DataSource = dis;
            cbxBookDiscount.DisplayMember = "Name";
            cbxBookDiscount.ValueMember = "Id";

        }
        public void InitBookDetail()
        {

            cbxBookDetailBook.DataSource = Books;
            cbxBookDetailBook.DisplayMember = "Name";
            cbxBookDetailBook.ValueMember = "Id";

            cbxBookDetailSuplier.DataSource = Suppliers;
            cbxBookDetailSuplier.DisplayMember = "Name";
            cbxBookDetailSuplier.ValueMember = "Id";
        }

        private void materialTabControl1_Click(object sender, EventArgs e)
        {
            var formExit = MessageBox.Show(ValidationInput.COMFIRM_EXIT, ValidationInput.TITLE, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (formExit == DialogResult.OK)
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
                        Categories = categoryBus.getList();
                        RenderDataGridView(dgvCategory, Categories);
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
            if (Util.checkEmpty(txtCategoryName, "Tên"))
                return;

            var newData = new Category() { Id = Convert.ToInt32(txtCategoryId?.Text), Name = txtCategoryName.Text };
            if (themmoiCategory)
            {
                bool IsSuccess = categoryBus.Add(newData);
                if (IsSuccess)
                {
                    MessageBox.Show(ValidationInput.SUCCESS_ADD, ValidationInput.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                bool IsSuccess = categoryBus.UpdateById(newData);
                if (IsSuccess)
                {
                    MessageBox.Show(ValidationInput.SUCCESS_EDIT, ValidationInput.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
            }

            setButtonCategory(true);
            Categories = categoryBus.getList();
            RenderDataGridView(dgvCategory, Categories);
        }

        private void btnCategoryCancel_Click(object sender, EventArgs e)
        {
            setButtonCategory(true);
        }

        private void kryptonTextBox11_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtCategorySearch.Text.ToLower().Trim(); // Convert to lowercase for case-insensitive search
            var searchResult = Categories
                .Where(account =>
                    account.Id.ToString().ToLower().Contains(keyword) ||
                    account.Name.ToLower().Contains(keyword)
                )
                .ToList();

            RenderDataGridView(dgvCategory, searchResult);
        }

        public void RenderDataGridViewAuthor(DataGridView dataGridView, List<Author> list)
        {
            dataGridView.Rows.Clear();
            dataGridView.Refresh();
            string Gender = "";
            foreach (var item in list)
            {
                if (item.Gender == 1)
                    Gender = "Nam";
                else
                    Gender = "Nữ";
                dataGridView.Rows.Add(item.Id, item.FirstName, item.LastName, item.BirthDay.ToString("yyyy/M/dd"), Gender);
            }
        }
        public void RenderDataGridViewOrder(DataGridView dataGridView, List<Order> list)
        {
            dataGridView.Rows.Clear();
            dataGridView.Refresh();

            var result = from o in list
                         join c in Customers on o.CustomerId equals c.Id
                         join a in Accounts on o.AccountId equals a.Id

                         select new
                         {
                             o.Id,
                             o.OrderDate,
                             o.Status,
                             Customer = c.Name,
                             UserName = a.UserName
                         };

            foreach (var item in result.ToList())
            {
                dataGridView.Rows.Add(item.Id, item.OrderDate.ToString("yyyy/MM/dd hh:mm:ss"), item.UserName, item.Customer, item.Status);
            }
        }
        public void RenderDataGridViewOrderDetail(int orderId)
        {
            dgvOrderDetail.Rows.Clear();
            dgvOrderDetail.Refresh();

            var result = (from od in OrderDetails
                          join o in Orders on od.OrderId equals o.Id
                          join bd in BookDetails on od.BookDetailId equals bd.Id
                          join b in Books on bd.BookId equals b.Id
                          select new
                          {
                              od.Id,
                              b.Name,
                              bd.Barcode,
                              od.Price,
                          }).ToList();

            /*
               var result = (from od in OrderDetails
                          join o in Orders on od.OrderId equals o.Id
                          join bd in BookDetails on od.BookDetailId equals bd.Id
                          join b in Books on bd.BookId equals b.Id
                          join d in Discounts on b.DiscountId equals d.Id
                          where od.OrderId == orderId
                          let DiscountPrice = (o.OrderDate >= d.StartDate && o.OrderDate <= d.EndDate) ? (float)od.Price / 100 * d.Value : (float)od.Price
                          select new
                          {
                              od.Id,
                              b.Name,
                              bd.Barcode,
                              StartDiscount = d.StartDate,
                              EndDiscount = d.EndDate,
                              od.Price,
                              Discount = d.Name,
                              Value = d.Value,
                              DiscountPrice
                          }).ToList();
             
             */
            foreach (var item in result)
            {
                dgvOrderDetail.Rows.Add(item.Id, item.Barcode, item.Name, item.Price);
            }
        }
        public void RenderDataGridViewImport(DataGridView dataGridView, List<Import> list)
        {
            dataGridView.Rows.Clear();
            dataGridView.Refresh();

            var result = from o in list
                         join a in Accounts on o.AccountId equals a.Id

                         select new
                         {
                             o.Id,
                             o.ImportDate,
                             o.Status,
                             a.Name
                         };

            foreach (var item in result.ToList())
            {
                dataGridView.Rows.Add(item.Id, item.ImportDate.ToString("yyyy/MM/dd hh:mm:ss"), item.Name, item.Status);
            }
        }

        public void RenderDataGridViewImportDetail(int importId)
        {
            dgvImportDetail.Rows.Clear();
            dgvImportDetail.Refresh();


            var result = from id in ImportDetails
                         join bd in BookDetails on id.BookDetailId equals bd.Id
                         join b in Books on bd.BookId equals b.Id
                         where id.ImportId == importId
                         select new { 
                            id.Id,
                            id.Price,
                            id.BuyQuantity,
                            id.BookDetailId,
                            Book = b.Name,
                            bd.Barcode
                         };

            foreach (var item in result.ToList())
            {
                dgvImportDetail.Rows.Add(item.Id, item.Barcode, item.Book, item.BuyQuantity,  item.Price);
            }
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

        public void RenderDataGridViewAccount(DataGridView dataGridView, List<Account> list)
        {
            Roles = RoleBus.getList();
            var result = from a in list
                         join r in Roles
                         on a.RoleId equals r.Id
                         select new
                         {
                             a.Id,
                             a.Name,
                             a.UserName,
                             a.Phone,
                             a.BirthDay,
                             a.Gender,
                             Role = r.Name,
                         };
            result.ToList();
            dataGridView.Rows.Clear();
            dataGridView.Refresh();
            string Gender = "";
            foreach (var item in result)
            {
                if (item.Gender == 1)
                {
                    Gender = "Nam";

                }
                else
                {
                    Gender = "Nữ";
                }
                dataGridView.Rows.Add(item.Id, item.Name, item.UserName, item.Phone, item.BirthDay.ToString("yyyy/M/dd"), Gender, item.Role);
            }
        }


        public void RenderDataGridViewBook(DataGridView dataGridView, List<Book> list)
        {

            Categories = CategoryBus.getList();
            Authors = AuthorBus.getList();
            Publishers = PublisherBus.getList();
            var result = from b in list
                         join c in Categories on b.CategoryId equals c.Id
                         join a in Authors on b.AuthorId equals a.Id
                         join p in Publishers on b.PublisherId equals p.Id
                         join d in Discounts on b.DiscountId equals d.Id
                         select new
                         {
                             b.Id,
                             b.Name,
                             b.Format,
                             b.Price,
                             b.PublicationDate,
                             b.TotalPage,
                             b.Quantity,
                             b.Language,
                             b.Image,
                             Category = c.Name,
                             Author = a.FullName,
                             Publisher = p.Name,
                             Discount = d.Name,
                         };
            result.ToList();


            dataGridView.Rows.Clear();
            dataGridView.Refresh();
            foreach (var item in result)
            {
                dataGridView.Rows.Add(item.Id, item.Name, item.Price, item.Format, item.PublicationDate.ToString("yyyy/M/dd"), item.TotalPage, item.Quantity, item.Category, item.Author, item.Publisher, item.Image, item.Discount, item.Language);
            }
        }

        public void RenderDataGridViewBookDetail(DataGridView dataGridView, List<BookDetail> list)
        {
            dataGridView.Rows.Clear();
            dataGridView.Refresh();
            Books = BookBus.getList();
            Suppliers = SupplierBus.getList();
            var result = from bd in list
                         join b in Books on bd.BookId equals b.Id
                         join s in Suppliers on bd.SupplierId equals s.Id
                         select new
                         {
                             bd.Id,
                             bd.Barcode,
                             b.Image,
                             Book = b.Name,
                             Supplier = s.Name
                         };
            foreach (var item in result.ToList())
            {
                dataGridView.Rows.Add(item.Id, item.Barcode, item.Book, item.Supplier, item.Image);
            }
        }

        public void RenderDataGridViewCustomer(DataGridView dataGridView, List<Customer> list)
        {
            dataGridView.Rows.Clear();
            dataGridView.Refresh();
            var Gender = "";
            foreach (var item in list)
            {
                if (item.Gender == 1)
                    Gender = "Nam";
                else
                    Gender = "Nữ";
                dataGridView.Rows.Add(item.Id, item.Name, item.Phone, item.BirthDay.ToString("yyyy/M/dd"), item.Address, Gender);
            }
        }
        public void RenderDataGridViewRole(DataGridView dataGridView, List<Role> list)
        {
            dataGridView.Rows.Clear();
            dataGridView.Refresh();
            foreach (var item in list)
            {
                dataGridView.Rows.Add(item.Id, item.Name);
            }
        }
        public void RenderDataGridViewSupplier(DataGridView dataGridView, List<Supplier> list)
        {
            dataGridView.Rows.Clear();
            dataGridView.Refresh();
            foreach (var item in list)
            {
                dataGridView.Rows.Add(item.Id, item.Name, item.Phone, item.Address);
            }
        }
        public void RenderDataGridViewPublisher(DataGridView dataGridView, List<Publisher> list)
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
            Categories = categoryBus.getList();
            RenderDataGridView(dgvCategory, Categories);
        }

        public void RenderDataGridViewDiscount(DataGridView dataGridView, List<Discount> list)
        {
            dataGridView.Rows.Clear();
            dataGridView.Refresh();
            foreach (var item in list)
            {
                dataGridView.Rows.Add(item.Id, item.Name, item.Value, item.Quantity, item.StartDate.ToString("yyyy/MM/dd HH:mm"), item.EndDate.ToString("yyyy/MM/dd HH:mm"));
            }
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

        private void materialButton11_Click_1(object sender, EventArgs e)
        {
            var fOrder = new FOrder();
            fOrder.ShowDialog();
        }


        private void dgvBook_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBook.SelectedRows.Count > 0)
            {
                //  MessageBox.Show("" + cbxBookFormat.FindString(dgvBook.SelectedRows[0].Cells[3].Value?.ToString().Trim()));
                txtBookId.Text = dgvBook.SelectedRows[0].Cells[0].Value?.ToString() ?? "";
                txtBookName.Text = dgvBook.SelectedRows[0].Cells[1].Value?.ToString() ?? "";
                txtBookPrice.Value = Convert.ToDecimal(dgvBook.SelectedRows[0].Cells[2].Value?.ToString());

                cbxBookFormat.SelectedIndex = cbxBookFormat.FindString(dgvBook.SelectedRows[0].Cells[3].Value?.ToString().Trim());
                cbxBookFormat.Refresh();
                txtBookPublisherDate.Value = Convert.ToDateTime(dgvBook.SelectedRows[0].Cells[4].Value?.ToString());


                txtBookTotalPage.Value = Convert.ToDecimal(dgvBook.SelectedRows[0].Cells[5].Value?.ToString());
                txtBookQuantity.Value = Convert.ToDecimal(dgvBook.SelectedRows[0].Cells[6].Value?.ToString());

                cbxBookCategory.SelectedIndex = cbxBookCategory.FindString(dgvBook.SelectedRows[0].Cells[7].Value?.ToString().Trim());
                cbxBookCategory.Refresh();

                cbxBookAuthor.SelectedIndex = cbxBookAuthor.FindString(dgvBook.SelectedRows[0].Cells[8].Value?.ToString().Trim());
                cbxBookAuthor.Refresh();

                cbxBookPublisher.SelectedIndex = cbxBookPublisher.FindString(dgvBook.SelectedRows[0].Cells[9].Value?.ToString().Trim());
                cbxBookPublisher.Refresh();

                string path = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;

                string url = Path.Combine(path, "images", dgvBook.SelectedRows[0].Cells[10].Value?.ToString().Trim());

                if (System.IO.File.Exists(url))
                {
                    ptbBook.Image = System.Drawing.Image.FromFile(url);
                }


                cbxBookDiscount.SelectedIndex = cbxBookDiscount.FindString(dgvBook.SelectedRows[0].Cells[11].Value?.ToString().Trim());
                cbxBookDiscount.Refresh();


                txtBookLanguage.Text = (dgvBook.SelectedRows[0].Cells[12].Value?.ToString());


            }
            else
            {
                txtCategoryId.Text = "";
                txtCategoryName.Text = "";
            }
        }

        private void cbxBookSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtBookSearch.Text.ToLower().Trim(); // Convert to lowercase for case-insensitive search
            var searchResult = Books
                .Where(account =>
                    account.Id.ToString().ToLower().Contains(keyword) ||
                    account.Price.ToString().ToLower().Contains(keyword) ||
                    account.Format.ToString().ToLower().Contains(keyword) ||
                    account.Language.ToString().ToLower().Contains(keyword) ||
                    account.Quantity.ToString().ToLower().Contains(keyword) ||
                    account.TotalPage.ToString().ToLower().Contains(keyword) ||
                    account.Name.ToLower().Contains(keyword)
                )
                .ToList();

            RenderDataGridViewBook(dgvBook, searchResult);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            txtBookSearch.Text = string.Empty;
            txtBookSearch.Focus();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Categories = CategoryBus.getList();
            InitBook();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Authors = AuthorBus.getList();
            InitBook();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Publishers = PublisherBus.getList();
            InitBook();
        }

        private void dgvCustomer_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomer.SelectedRows.Count > 0)
            {
                txtCustomerId.Text = dgvCustomer.SelectedRows[0].Cells[0].Value?.ToString() ?? "";
                txtCustomerName.Text = dgvCustomer.SelectedRows[0].Cells[1].Value?.ToString() ?? "";
                txtCustomerPhone.Text = dgvCustomer.SelectedRows[0].Cells[2].Value?.ToString() ?? "";
                txtCustomerBirthday.Value = Convert.ToDateTime(dgvCustomer.SelectedRows[0].Cells[3].Value?.ToString());
                txtCustomerAddress.Text = dgvCustomer.SelectedRows[0].Cells[4].Value?.ToString() ?? "";
                if (dgvCustomer.SelectedRows[0].Cells[5].Value?.ToString() == "Nam")
                    rdxCustomerNam.Checked = true;
                else
                    rdxCustomerNu.Checked = true;

            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            txtCustomerSearch.Text = string.Empty;
            txtCustomerSearch.Focus();
        }

        private void txtCustomerSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtCustomerSearch.Text.ToLower().Trim(); // Convert to lowercase for case-insensitive search

            var searchResult = Customers
                .Where(account =>
                    account.Id.ToString().ToLower().Contains(keyword) ||
                    account.Name.ToString().ToLower().Contains(keyword) ||
                    account.Address.ToString().ToLower().Contains(keyword) ||
                    account.BirthDay.ToString().ToLower().Contains(keyword) ||
                    account.Phone.ToLower().Contains(keyword)
                )
                .ToList();

            RenderDataGridViewCustomer(dgvCustomer, searchResult);
        }

        private void dgvRole_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRole.SelectedRows.Count > 0)
            {
                txtRoleId.Text = dgvRole.SelectedRows[0].Cells[0].Value?.ToString() ?? "";
                txtRoleName.Text = dgvRole.SelectedRows[0].Cells[1].Value?.ToString() ?? "";

            }
        }

        private void txtRoleSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtRoleSearch.Text.ToLower().Trim(); // Convert to lowercase for case-insensitive search

            var searchResult = Roles
                .Where(account =>
                    account.Id.ToString().ToLower().Contains(keyword) ||
                    account.Name.ToString().ToLower().Contains(keyword)
                )
                .ToList();

            RenderDataGridViewRole(dgvRole, searchResult);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            txtRoleSearch.Text = string.Empty;
            txtRoleSearch.Focus();
        }

        private void dgvPublisher_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPublisher.SelectedRows.Count > 0)
            {
                txtPublisherId.Text = dgvPublisher.SelectedRows[0].Cells[0].Value?.ToString() ?? "";
                txtPublisherName.Text = dgvPublisher.SelectedRows[0].Cells[1].Value?.ToString() ?? "";
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            txtPublisherSearch.Text = string.Empty;
            txtPublisherSearch.Focus();
        }

        private void txtPublisherSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtPublisherSearch.Text.ToLower().Trim(); // Convert to lowercase for case-insensitive search

            var searchResult = Publishers
                .Where(account =>
                    account.Id.ToString().ToLower().Contains(keyword) ||
                    account.Name.ToString().ToLower().Contains(keyword)
                )
                .ToList();

            RenderDataGridViewPublisher(dgvPublisher, searchResult);
        }

        private void dgvSupplier_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSupplier.SelectedRows.Count > 0)
            {
                txtSupplierId.Text = dgvSupplier.SelectedRows[0].Cells[0].Value?.ToString() ?? "";
                txtSupplierName.Text = dgvSupplier.SelectedRows[0].Cells[1].Value?.ToString() ?? "";
                txtSupplierPhone.Text = dgvSupplier.SelectedRows[0].Cells[2].Value?.ToString() ?? "";
                txtSupplierAddress.Text = dgvSupplier.SelectedRows[0].Cells[3].Value?.ToString() ?? "";

            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            txtSupplierSearch.Text = string.Empty;
            txtSupplierSearch.Focus();
        }

        private void txtSupplierSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSupplierSearch.Text.ToLower().Trim(); // Convert to lowercase for case-insensitive search

            var searchResult = Suppliers
                .Where(account =>
                    account.Id.ToString().ToLower().Contains(keyword) ||
                    account.Name.ToString().ToLower().Contains(keyword) ||
                    account.Phone.ToString().ToLower().Contains(keyword) ||
                    account.Address.ToString().ToLower().Contains(keyword)
                )
                .ToList();

            RenderDataGridViewSupplier(dgvSupplier, searchResult);
        }




        private void btnAccountSave_Click(object sender, EventArgs e)
        {
            if(Util.checkEmpty(txtAccountName, "Tên"))
                return;
            if (Util.checkEmpty(txtAccountPhone, "Phone"))
                return;
            if (Util.checkEmpty(txtAccountUsername, "Username"))
                return;
            if (Util.checkName(txtAccountName))
                return;
            if (Util.checkPhone(txtAccountPhone))
                return;
            if (Util.checkBirthday(txtAccountBirthday, "Ngày sinh"))
                return;


            var check = Accounts.FirstOrDefault(a => a.UserName.Trim() == txtAccountUsername.Text.Trim());
            if(check != null)
            {
                MessageBox.Show("Username đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAccountUsername.Focus();
                return;
            }
            var newData = new Account()
            {
                Id = Convert.ToInt32(txtAccountId?.Text),
                Name = txtAccountName.Text,
                UserName = txtAccountUsername.Text,
                Phone = txtAccountPhone.Text,
                BirthDay = txtAccountBirthday.Value,
                Gender = rdoAccountNam.Checked == true ? 1 : 0,
                RoleId = Convert.ToInt32(cbxAccountRole.SelectedValue.ToString()),
            };
            if (themmoAccount)
            {
                bool IsSuccess = AccountBus.Add(newData);
                if (IsSuccess)
                {
                    MessageBox.Show(ValidationInput.SUCCESS_ADD, ValidationInput.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                bool IsSuccess = AccountBus.UpdateById(newData);
                if (IsSuccess)
                {
                    MessageBox.Show(ValidationInput.SUCCESS_EDIT, ValidationInput.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
            }

            setButtonAccount(true);
            Accounts = AccountBus.getList();
            RenderDataGridViewAccount(dgvAccount, Accounts);
        }
        void setButtonAccount(bool val)
        {
            btnAccountAdd.Enabled = val;
            btnAccountDelete.Enabled = val;
            btnAccountEdit.Enabled = val;
            btnAccountSave.Enabled = !val;
            btnAccountCancel.Enabled = !val;
        }
        void setInputAccountNull()
        {
            txtAccountName.Text = string.Empty;
            txtAccountPhone.Text = string.Empty;
            txtAccountUsername.Text = string.Empty;
        }
        private void btnAccountEdit_Click(object sender, EventArgs e)
        {
            if (dgvAccount.SelectedRows.Count == 1)
            {
                themmoAccount = false;
                setButtonAccount(false);
            }
            else if (dgvAccount.SelectedRows.Count == 0)
                MessageBox.Show(ValidationInput.ERROR_NO_SELECT, ValidationInput.TITLE, MessageBoxButtons.OK,
                 MessageBoxIcon.Question);
            else
                MessageBox.Show(ValidationInput.ERROR_MANY_SELECTED, ValidationInput.TITLE, MessageBoxButtons.OK,
                 MessageBoxIcon.Question);
        }

        private void btnAccountDelete_Click(object sender, EventArgs e)
        {
            if (dgvAccount.SelectedRows.Count == 1)
            {
                DialogResult dr = MessageBox.Show(ValidationInput.COMFIRM_DELETE, ValidationInput.TITLE, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    bool deleteIsSucess = AccountBus.DeleteById(txtAccountId.Text.Trim());
                    if (deleteIsSucess)
                    {
                        MessageBox.Show(ValidationInput.SUCCESS_DELETE, ValidationInput.TITLE, MessageBoxButtons.OK,
                         MessageBoxIcon.Question);
                        setButtonAccount(true);
                        Accounts = AccountBus.getList();
                        RenderDataGridViewAccount(dgvAccount, Accounts);
                    }
                }
            }
            else if (dgvAccount.SelectedRows.Count == 0)
                MessageBox.Show(ValidationInput.ERROR_NO_SELECT, ValidationInput.TITLE, MessageBoxButtons.OK,
                 MessageBoxIcon.Question);
            else
                MessageBox.Show(ValidationInput.ERROR_MANY_SELECTED, ValidationInput.TITLE, MessageBoxButtons.OK,
                 MessageBoxIcon.Question);
        }

        private void btnAccountAdd_Click(object sender, EventArgs e)
        {
            setInputAccountNull();
            themmoAccount = true;
            setButtonAccount(false);
            txtAccountUsername.Focus();
        }

        private void btnAccountRefresh_Click(object sender, EventArgs e)
        {
            Accounts = AccountBus.getList();
            RenderDataGridViewAccount(dgvAccount, Accounts);
        }
        private void btnAccountCancel_Click(object sender, EventArgs e)
        {
            setButtonAccount(true);
        }
        private void dgvAccount_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAccount.SelectedRows.Count > 0)
            {
                txtAccountId.Text = dgvAccount.SelectedRows[0].Cells[0].Value?.ToString() ?? "";
                txtAccountName.Text = dgvAccount.SelectedRows[0].Cells[1].Value?.ToString() ?? "";
                txtAccountUsername.Text = dgvAccount.SelectedRows[0].Cells[2].Value?.ToString() ?? "";
                txtAccountPhone.Text = dgvAccount.SelectedRows[0].Cells[3].Value?.ToString() ?? "";
                txtAccountBirthday.Value = Convert.ToDateTime(dgvAccount.SelectedRows[0].Cells[4].Value?.ToString());
                if (dgvAccount.SelectedRows[0].Cells[5].Value?.ToString().Trim() == "Nam")
                    rdoAccountNam.Checked = true;
                else
                    rdoAccountNu.Checked = true;
                cbxAccountRole.SelectedIndex = cbxAccountRole.FindString(dgvAccount.SelectedRows[0].Cells[6].Value?.ToString().Trim());
                cbxAccountRole.Refresh();

            }
        }
        private void txtAccountSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtAccountSearch.Text.ToLower().Trim(); // Convert to lowercase for case-insensitive search

            var searchResult = Accounts
                .Where(account =>
                    account.Id.ToString().ToLower().Contains(keyword) ||
                    account.UserName.ToString().ToLower().Contains(keyword) ||
                    account.Name.ToString().ToLower().Contains(keyword)
                )
                .ToList();

            RenderDataGridViewAccount(dgvAccount, searchResult);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            txtAccountSearch.Text = string.Empty;
            txtAccountSearch.Focus();
        }
        // -------------------------------------------------------

        void setButtonAuthor(bool val)
        {
            btnAuthorAdd.Enabled = val;
            btnAuthorDelete.Enabled = val;
            btnAuthorEdit.Enabled = val;
            btnAuthorSave.Enabled = !val;
            btnAuthorCancel.Enabled = !val;
        }
        void setInputAuthorNull()
        {
            txtAuthorFirstName.Text = string.Empty;
            txtAuthorLastName.Text = string.Empty;
        }
        private void btnAuthorAdd_Click(object sender, EventArgs e)
        {
            setInputAccountNull();
            themmoAuthor = true;
            setButtonAuthor(false);
            txtAuthorFirstName.Focus();
        }

        private void btnAuthorDelete_Click(object sender, EventArgs e)
        {

            if (dgvAuthor.SelectedRows.Count == 1)
            {
                DialogResult dr = MessageBox.Show(ValidationInput.COMFIRM_DELETE, ValidationInput.TITLE, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    bool deleteIsSucess = AuthorBus.DeleteById(txtAuthorId.Text.Trim());
                    if (deleteIsSucess)
                    {
                        MessageBox.Show(ValidationInput.SUCCESS_DELETE, ValidationInput.TITLE, MessageBoxButtons.OK,
                         MessageBoxIcon.Question);
                        setButtonAuthor(true);
                        Authors = AuthorBus.getList();
                        RenderDataGridViewAuthor(dgvAuthor, Authors);
                    }
                }
            }
            else if (dgvAuthor.SelectedRows.Count == 0)
                MessageBox.Show(ValidationInput.ERROR_NO_SELECT, ValidationInput.TITLE, MessageBoxButtons.OK,
                 MessageBoxIcon.Question);
            else
                MessageBox.Show(ValidationInput.ERROR_MANY_SELECTED, ValidationInput.TITLE, MessageBoxButtons.OK,
                 MessageBoxIcon.Question);

        }

        private void btnAuthorEdit_Click(object sender, EventArgs e)
        {
            if (dgvAuthor.SelectedRows.Count == 1)
            {
                themmoAuthor = false;
                setButtonAuthor(false);
            }
            else if (dgvAuthor.SelectedRows.Count == 0)
                MessageBox.Show(ValidationInput.ERROR_NO_SELECT, ValidationInput.TITLE, MessageBoxButtons.OK,
                 MessageBoxIcon.Question);
            else
                MessageBox.Show(ValidationInput.ERROR_MANY_SELECTED, ValidationInput.TITLE, MessageBoxButtons.OK,
                 MessageBoxIcon.Question);
        }

        private void btnAuthorSave_Click(object sender, EventArgs e)
        {
            if (Util.checkEmpty(txtAuthorFirstName, "FirstName"))
                return;
            if (Util.checkEmpty(txtAuthorLastName, "LastName"))
                return;
          
            if (Util.checkName(txtAuthorFirstName))
                return;

            if (Util.checkName(txtAuthorLastName))
                return;

            if (Util.checkBirthday(txtAuthorBirthDay, "Ngày sinh"))
                return;
            var newData = new Author()
            {
                Id = Convert.ToInt32(txtAccountId?.Text),
                FirstName = txtAuthorFirstName.Text,
                LastName = txtAuthorLastName.Text,
                BirthDay = Convert.ToDateTime(txtAuthorBirthDay.Value),
            };
            if (themmoAuthor)
            {
                bool IsSuccess = AuthorBus.Add(newData);
                if (IsSuccess)
                {
                    MessageBox.Show(ValidationInput.SUCCESS_ADD, ValidationInput.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                bool IsSuccess = AuthorBus.UpdateById(newData);
                if (IsSuccess)
                {
                    MessageBox.Show(ValidationInput.SUCCESS_EDIT, ValidationInput.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
            }

            setButtonAuthor(true);
            Authors = AuthorBus.getList();
            RenderDataGridViewAuthor(dgvAuthor, Authors);
        }

        private void btnAuthorCancel_Click(object sender, EventArgs e)
        {
            setButtonAuthor(true);
        }

        private void btnAuthorRefresh_Click(object sender, EventArgs e)
        {
            Authors = AuthorBus.getList();
            RenderDataGridViewAuthor(dgvAuthor, Authors);
        }

        private void txtAuthorSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtAuthorSearch.Text.ToLower().Trim(); // Convert to lowercase for case-insensitive search

            var searchResult = Authors
                .Where(account =>
                    account.Id.ToString().ToLower().Contains(keyword) ||
                    account.FirstName.ToString().ToLower().Contains(keyword) ||
                    account.LastName.ToString().ToLower().Contains(keyword)
                )
                .ToList();

            RenderDataGridViewAuthor(dgvAuthor, searchResult);
        }

        private void dgvAuthor_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAuthor.SelectedRows.Count > 0)
            {
                txtAuthorId.Text = dgvAuthor.SelectedRows[0].Cells[0].Value?.ToString() ?? "";
                txtAuthorFirstName.Text = dgvAuthor.SelectedRows[0].Cells[1].Value?.ToString() ?? "";
                txtAuthorLastName.Text = dgvAuthor.SelectedRows[0].Cells[2].Value?.ToString() ?? "";
                txtAuthorBirthDay.Value = Convert.ToDateTime(dgvAuthor.SelectedRows[0].Cells[3].Value?.ToString());
                if (dgvAuthor.SelectedRows[0].Cells[4].Value?.ToString().Trim() == "Nam")
                    rdxAuthorNam.Checked = true;
                else
                    rdxAuthorNu.Checked = true;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            txtAuthorSearch.Text = string.Empty;
            txtAuthorSearch.Focus();
        }

        // -------------------------------
        void setButtonBook(bool val)
        {
            btnBookAdd.Enabled = val;
            btnBookDelete.Enabled = val;
            btnBookEdit.Enabled = val;
            btnBookSave.Enabled = !val;
            btnBookCancel.Enabled = !val;
        }
        void setInputBookNull()
        {
            txtBookName.Text = string.Empty;
        }
        private void btnBookAdd_Click(object sender, EventArgs e)
        {
            ptbBook.Enabled = true;
            setInputBookNull();
            themmoBook = true;
            setButtonBook(false);
            txtBookName.Focus();
        }

        private void btnBookDelete_Click(object sender, EventArgs e)
        {
            if (dgvBook.SelectedRows.Count == 1)
            {
                DialogResult dr = MessageBox.Show(ValidationInput.COMFIRM_DELETE, ValidationInput.TITLE, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    bool deleteIsSucess = BookBus.DeleteById(txtBookId.Text.Trim());
                    if (deleteIsSucess)
                    {
                        MessageBox.Show(ValidationInput.SUCCESS_DELETE, ValidationInput.TITLE, MessageBoxButtons.OK,
                         MessageBoxIcon.Question);
                        setButtonBook(true);
                        Books = BookBus.getList();
                        RenderDataGridViewBook(dgvBook, Books);
                    }
                }
            }
            else if (dgvBook.SelectedRows.Count == 0)
                MessageBox.Show(ValidationInput.ERROR_NO_SELECT, ValidationInput.TITLE, MessageBoxButtons.OK,
                 MessageBoxIcon.Question);
            else
                MessageBox.Show(ValidationInput.ERROR_MANY_SELECTED, ValidationInput.TITLE, MessageBoxButtons.OK,
                 MessageBoxIcon.Question);
        }

        private void btnBookEdit_Click(object sender, EventArgs e)
        {
            if (dgvBook.SelectedRows.Count == 1)
            {
                ptbBook.Enabled = true;
                themmoBook = false;
                setButtonBook(false);
            }
            else if (dgvBook.SelectedRows.Count == 0)
                MessageBox.Show(ValidationInput.ERROR_NO_SELECT, ValidationInput.TITLE, MessageBoxButtons.OK,
                 MessageBoxIcon.Question);
            else
                MessageBox.Show(ValidationInput.ERROR_MANY_SELECTED, ValidationInput.TITLE, MessageBoxButtons.OK,
                 MessageBoxIcon.Question);

        }

        private void btnBookSave_Click(object sender, EventArgs e)
        {
            if (Util.checkEmpty(txtBookName, "Tên sách"))
                return;
            if (Util.checkEmpty(txtBookLanguage, "Language"))
                return;
           
            if (Util.checkBirthday(txtBookPublisherDate, "ngày xuât bản"))
                return;

            
            var newData = new Book()
            {
                Id = Convert.ToInt32(txtBookId?.Text.Trim()),
                Name = txtBookName.Text,
                PublicationDate = Convert.ToDateTime(txtBookPublisherDate.Value),
                TotalPage = Convert.ToInt32(txtBookTotalPage.Value),
                Format = cbxBookFormat.SelectedItem.ToString(),
                Quantity = Convert.ToInt32(txtBookQuantity.Value),
                Price = Convert.ToDouble(txtBookPrice.Value),
                Language = txtBookLanguage.Text,
                CategoryId = Convert.ToInt32(cbxBookCategory.SelectedValue.ToString()),
                PublisherId = Convert.ToInt32(cbxBookPublisher.SelectedValue.ToString()),
                AuthorId = Convert.ToInt32(cbxBookAuthor.SelectedValue.ToString()),

                Image = fileNameBook,
            };
            if (themmoBook)
            {
                bool IsSuccess = BookBus.Add(newData);
                if (IsSuccess)
                {
                    MessageBox.Show(ValidationInput.SUCCESS_ADD, ValidationInput.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                bool IsSuccess = BookBus.UpdateById(newData);
                if (IsSuccess)
                {
                    MessageBox.Show(ValidationInput.SUCCESS_EDIT, ValidationInput.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            ptbBook.Enabled = false;
            setButtonBook(true);
            Books = BookBus.getList();
            RenderDataGridViewBook(dgvBook, Books);
        }

        private void btnBookCancel_Click(object sender, EventArgs e)
        {
            setButtonBook(true);
            ptbBook.Enabled = false;
        }

        private void btnBookRefresh_Click(object sender, EventArgs e)
        {
            Books = BookBus.getList();
            RenderDataGridViewBook(dgvBook, Books);
        }

        private void dgvBookDetail_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBookDetail.SelectedRows.Count > 0)
            {
                txtBookDetailId.Text = dgvBookDetail.SelectedRows[0].Cells[0].Value?.ToString() ?? "";
                txtBookDetailBarcode.Text = dgvBookDetail.SelectedRows[0].Cells[1].Value?.ToString() ?? "";

                cbxBookDetailBook.SelectedIndex = cbxBookDetailBook.FindString(dgvBookDetail.SelectedRows[0].Cells[2].Value?.ToString().Trim());
                cbxBookDetailBook.Refresh();

                cbxBookDetailSuplier.SelectedIndex = cbxBookDetailSuplier.FindString(dgvBookDetail.SelectedRows[0].Cells[3].Value?.ToString().Trim());
                cbxBookDetailSuplier.Refresh();

                string path = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;
                string url = Path.Combine(path, "images", dgvBookDetail.SelectedRows[0].Cells[4].Value?.ToString().Trim());

                if (System.IO.File.Exists(url))
                {
                    ptcBookDetail.Image = System.Drawing.Image.FromFile(url);
                }
                ptcBookDetailBarcode.Image = Util.GeneratorQR(txtBookDetailBarcode.Text);

            }
        }


        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Discounts = DiscountBus.getList();
            InitBook();
        }


        // -----------------------
        void setButtonBookDetail(bool val)
        {
            btnBookDetailAdd.Enabled = val;
            btnBookDetailDelete.Enabled = val;
            btnBookDetailEdit.Enabled = val;
            btnBookDetailSave.Enabled = !val;
            btnBookDetailCancel.Enabled = !val;
        }
        void setInputBookDetailNull()
        {
            // txtBoText = string.Empty;
        }

        private void btnBookDetailAdd_Click(object sender, EventArgs e)
        {
            setInputBookDetailNull();
            themmoBookDetail = true;
            setButtonBookDetail(false);
            // txtBookName.Focus();
        }

        private void btnBookDetailDelete_Click(object sender, EventArgs e)
        {
            if (dgvBookDetail.SelectedRows.Count == 1)
            {
                DialogResult dr = MessageBox.Show(ValidationInput.COMFIRM_DELETE, ValidationInput.TITLE, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    bool deleteIsSucess = BookDetailBus.DeleteById(txtBookDetailId.Text.Trim());
                    if (deleteIsSucess)
                    {
                        MessageBox.Show(ValidationInput.SUCCESS_DELETE, ValidationInput.TITLE, MessageBoxButtons.OK,
                         MessageBoxIcon.Question);
                        setButtonBookDetail(true);
                        BookDetails = BookDetailBus.getList();
                        RenderDataGridViewBookDetail(dgvBookDetail, BookDetails);
                    }
                }
            }
            else if (dgvBookDetail.SelectedRows.Count == 0)
                MessageBox.Show(ValidationInput.ERROR_NO_SELECT, ValidationInput.TITLE, MessageBoxButtons.OK,
                 MessageBoxIcon.Question);
            else
                MessageBox.Show(ValidationInput.ERROR_MANY_SELECTED, ValidationInput.TITLE, MessageBoxButtons.OK,
                 MessageBoxIcon.Question);
        }

        private void btnBookDetailEdit_Click(object sender, EventArgs e)
        {
            if (dgvBookDetail.SelectedRows.Count == 1)
            {
                themmoBookDetail = false;
                setButtonBookDetail(false);
            }
            else if (dgvBookDetail.SelectedRows.Count == 0)
                MessageBox.Show(ValidationInput.ERROR_NO_SELECT, ValidationInput.TITLE, MessageBoxButtons.OK,
                 MessageBoxIcon.Question);
            else
                MessageBox.Show(ValidationInput.ERROR_MANY_SELECTED, ValidationInput.TITLE, MessageBoxButtons.OK,
                 MessageBoxIcon.Question);

        }

        private void btnBookDetailSave_Click(object sender, EventArgs e)
        {
           
            var newData = new BookDetail()
            {
                Id = Convert.ToInt32(txtBookId?.Text.Trim()),
                Barcode = txtBookDetailBarcode.Text,
                BookId = Convert.ToInt32(cbxBookDetailBook.SelectedValue.ToString()),
                SupplierId = Convert.ToInt32(cbxBookDetailSuplier.SelectedValue.ToString()),
            };
            if (themmoBookDetail)
            {
                var barcode = Convert.ToInt32(BookDetails.Last().Barcode) + 1;
                newData.Barcode = barcode.ToString();
                bool IsSuccess = BookDetailBus.Add(newData);
                if (IsSuccess)
                {
                    MessageBox.Show(ValidationInput.SUCCESS_ADD, ValidationInput.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                bool IsSuccess = BookDetailBus.UpdateById(newData);
                if (IsSuccess)
                {
                    MessageBox.Show(ValidationInput.SUCCESS_EDIT, ValidationInput.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            setButtonBookDetail(true);
            BookDetails = BookDetailBus.getList();
            RenderDataGridViewBookDetail(dgvBookDetail, BookDetails);
        }

        private void btnBookDetailCancel_Click(object sender, EventArgs e)
        {
            setButtonBookDetail(true);
        }

        private void btnBookDetailRefresh_Click(object sender, EventArgs e)
        {
            BookDetails = BookDetailBus.getList();
            RenderDataGridViewBookDetail(dgvBookDetail, BookDetails);
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }

        private void cbxBookDetailSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtBookDetailSearch.Text.ToLower().Trim(); // Convert to lowercase for case-insensitive search

            var searchResult = BookDetails
                .Where(account =>
                    account.Id.ToString().ToLower().Contains(keyword) ||
                    account.Barcode.ToString().ToLower().Contains(keyword)
                )
                .ToList();

            RenderDataGridViewBookDetail(dgvBookDetail, searchResult);
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            Books = BookBus.getList();
            Suppliers = SupplierBus.getList();
            InitBookDetail();
        }
        // ----------------------- 
        void setButtonCustomer(bool val)
        {
            btnCustomerAdd.Enabled = val;
            btnCustomerDelete.Enabled = val;
            btnCustomerEdit.Enabled = val;
            btnCustomerSave.Enabled = !val;
            btnCustomerCancel.Enabled = !val;
        }
        void setInputCustomerNull()
        {
            txtCustomerName.Text = string.Empty;
            txtCustomerAddress.Text = string.Empty;
            txtCustomerPhone.Text = string.Empty;
        }


        private void pictureBox16_Click(object sender, EventArgs e)
        {
            InitBookDetail();
        }

        private void btnCustomerAdd_Click(object sender, EventArgs e)
        {
            setInputCustomerNull();
            themmoCustomer = true;
            setButtonCustomer(false);
            txtCustomerName.Focus();
        }

        private void btnCustomerDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.SelectedRows.Count == 1)
            {
                DialogResult dr = MessageBox.Show(ValidationInput.COMFIRM_DELETE, ValidationInput.TITLE, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    bool deleteIsSucess = CustomerBus.DeleteById(txtBookDetailId.Text.Trim());
                    if (deleteIsSucess)
                    {
                        MessageBox.Show(ValidationInput.SUCCESS_DELETE, ValidationInput.TITLE, MessageBoxButtons.OK,
                         MessageBoxIcon.Question);
                        setButtonCustomer(true);
                        Customers = CustomerBus.getList();
                        RenderDataGridViewCustomer(dgvCustomer, Customers);
                    }
                }
            }
            else if (dgvCustomer.SelectedRows.Count == 0)
                MessageBox.Show(ValidationInput.ERROR_NO_SELECT, ValidationInput.TITLE, MessageBoxButtons.OK,
                 MessageBoxIcon.Question);
            else
                MessageBox.Show(ValidationInput.ERROR_MANY_SELECTED, ValidationInput.TITLE, MessageBoxButtons.OK,
                 MessageBoxIcon.Question);
        }

        private void btnCustomerEdit_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.SelectedRows.Count == 1)
            {
                themmoCustomer = false;
                setButtonCustomer(false);
            }
            else if (dgvCustomer.SelectedRows.Count == 0)
                MessageBox.Show(ValidationInput.ERROR_NO_SELECT, ValidationInput.TITLE, MessageBoxButtons.OK,
                 MessageBoxIcon.Question);
            else
                MessageBox.Show(ValidationInput.ERROR_MANY_SELECTED, ValidationInput.TITLE, MessageBoxButtons.OK,
                 MessageBoxIcon.Question);
        }

        private void btnCustomerSave_Click(object sender, EventArgs e)
        {
            if (Util.checkEmpty(txtCustomerName, "Tên"))
                return;
            if (Util.checkEmpty(txtCustomerPhone, "Phone"))
                return;
            if (Util.checkEmpty(txtCustomerAddress, "Address"))
                return;

            if (Util.checkName(txtCustomerName))
                return;
            if (Util.checkPhone(txtCustomerPhone))
                return;

            if (Util.checkBirthday(txtCustomerBirthday, "Ngày sinh"))
                return;
            var newData = new Customer()
            {
                Id = Convert.ToInt32(txtCustomerId?.Text.Trim()),
                Address = txtCustomerAddress?.Text.Trim(),
                Name = txtCustomerName?.Text.Trim(),
                Phone = txtCustomerPhone?.Text.Trim(),
                BirthDay = Convert.ToDateTime(txtCustomerBirthday.Value),
                Gender = rdxCustomerNam.Checked ? 1 : 0
            };
            if (themmoCustomer)
            {
                bool IsSuccess = CustomerBus.Add(newData);
                if (IsSuccess)
                {
                    MessageBox.Show(ValidationInput.SUCCESS_ADD, ValidationInput.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                bool IsSuccess = CustomerBus.UpdateById(newData);
                if (IsSuccess)
                {
                    MessageBox.Show(ValidationInput.SUCCESS_EDIT, ValidationInput.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            setButtonCustomer(true);
            Customers = CustomerBus.getList();
            RenderDataGridViewCustomer(dgvCustomer, Customers);
        }

        private void btnCustomerCancel_Click(object sender, EventArgs e)
        {
            setButtonCustomer(true);
        }

        private void btnCustomerRefresh_Click(object sender, EventArgs e)
        {
            Customers = CustomerBus.getList();
            RenderDataGridViewCustomer(dgvCustomer, Customers);

        }
        // ----------------------------------

        void setButtonRole(bool val)
        {
            btnRoleAdd.Enabled = val;
            btnRoleDelete.Enabled = val;
            btnRoleEdit.Enabled = val;
            btnRoleSave.Enabled = !val;
            btnRoleCancel.Enabled = !val;
        }
        void setInputRoleNull()
        {
            txtRoleName.Text = string.Empty;
        }


        private void btnRoleAdd_Click(object sender, EventArgs e)
        {
            setInputRoleNull();
            themmoRole = true;
            setButtonRole(false);
            txtRoleName.Focus();
        }

        private void btnRoleDelete_Click(object sender, EventArgs e)
        {
            if (dgvRole.SelectedRows.Count == 1)
            {
                DialogResult dr = MessageBox.Show(ValidationInput.COMFIRM_DELETE, ValidationInput.TITLE, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    bool deleteIsSucess = RoleBus.DeleteById(txtBookDetailId.Text.Trim());
                    if (deleteIsSucess)
                    {
                        MessageBox.Show(ValidationInput.SUCCESS_DELETE, ValidationInput.TITLE, MessageBoxButtons.OK,
                         MessageBoxIcon.Question);
                        setButtonRole(true);
                        Roles = RoleBus.getList();
                        RenderDataGridViewRole(dgvRole, Roles);
                    }
                }
            }
            else if (dgvRole.SelectedRows.Count == 0)
                MessageBox.Show(ValidationInput.ERROR_NO_SELECT, ValidationInput.TITLE, MessageBoxButtons.OK,
                 MessageBoxIcon.Question);
            else
                MessageBox.Show(ValidationInput.ERROR_MANY_SELECTED, ValidationInput.TITLE, MessageBoxButtons.OK,
                 MessageBoxIcon.Question);
        }

        private void btnRoleEdit_Click(object sender, EventArgs e)
        {
            if (dgvRole.SelectedRows.Count == 1)
            {
                themmoRole = false;
                setButtonRole(false);
            }
            else if (dgvRole.SelectedRows.Count == 0)
                MessageBox.Show(ValidationInput.ERROR_NO_SELECT, ValidationInput.TITLE, MessageBoxButtons.OK,
                 MessageBoxIcon.Question);
            else
                MessageBox.Show(ValidationInput.ERROR_MANY_SELECTED, ValidationInput.TITLE, MessageBoxButtons.OK,
                 MessageBoxIcon.Question);
        }

        private void btnRoleSave_Click(object sender, EventArgs e)
        {
            if (Util.checkEmpty(txtRoleName, "Tên"))
                return;
            var newData = new Role()
            {
                Id = Convert.ToInt32(txtRoleId?.Text.Trim()),
                Name = txtRoleName?.Text.Trim(),
            };
            if (themmoRole)
            {
                bool IsSuccess = RoleBus.Add(newData);
                if (IsSuccess)
                {
                    MessageBox.Show(ValidationInput.SUCCESS_ADD, ValidationInput.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                bool IsSuccess = RoleBus.UpdateById(newData);
                if (IsSuccess)
                {
                    MessageBox.Show(ValidationInput.SUCCESS_EDIT, ValidationInput.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            setButtonRole(true);
            Roles = RoleBus.getList();
            RenderDataGridViewRole(dgvRole, Roles);
        }

        private void btnRoleCancel_Click(object sender, EventArgs e)
        {
            setButtonRole(true);
        }

        private void btnRoleRefresh_Click(object sender, EventArgs e)
        {
            Roles = RoleBus.getList();
            RenderDataGridViewRole(dgvRole, Roles);
        }

        // -----------------------


        void setButtonSupplier(bool val)
        {
            btnSupplierAdd.Enabled = val;
            btnSupplierDelete.Enabled = val;
            btnSupplierEdit.Enabled = val;
            btnSupplierSave.Enabled = !val;
            btnSupplierCancel.Enabled = !val;
        }
        void setInputSupplierNull()
        {
            txtSupplierName.Text = string.Empty;
            txtSupplierPhone.Text = string.Empty;
            txtSupplierAddress.Text = string.Empty;
        }

        private void btnSupplierAdd_Click(object sender, EventArgs e)
        {
            setInputSupplierNull();
            themmoSupplier = true;
            setButtonSupplier(false);
            txtSupplierName.Focus();
        }

        private void btnSupplierDelete_Click(object sender, EventArgs e)
        {
            if (dgvSupplier.SelectedRows.Count == 1)
            {
                DialogResult dr = MessageBox.Show(ValidationInput.COMFIRM_DELETE, ValidationInput.TITLE, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    bool deleteIsSucess = SupplierBus.DeleteById(txtSupplierId.Text.Trim());
                    if (deleteIsSucess)
                    {
                        MessageBox.Show(ValidationInput.SUCCESS_DELETE, ValidationInput.TITLE, MessageBoxButtons.OK,
                         MessageBoxIcon.Question);
                        setButtonSupplier(true);
                        Suppliers = SupplierBus.getList();
                        RenderDataGridViewSupplier(dgvSupplier, Suppliers);
                    }
                }
            }
            else if (dgvRole.SelectedRows.Count == 0)
                MessageBox.Show(ValidationInput.ERROR_NO_SELECT, ValidationInput.TITLE, MessageBoxButtons.OK,
                 MessageBoxIcon.Question);
            else
                MessageBox.Show(ValidationInput.ERROR_MANY_SELECTED, ValidationInput.TITLE, MessageBoxButtons.OK,
                 MessageBoxIcon.Question);
        }

        private void btnSupplierEdit_Click(object sender, EventArgs e)
        {
            if (dgvSupplier.SelectedRows.Count == 1)
            {
                themmoSupplier = false;
                setButtonSupplier(false);
            }
            else if (dgvSupplier.SelectedRows.Count == 0)
                MessageBox.Show(ValidationInput.ERROR_NO_SELECT, ValidationInput.TITLE, MessageBoxButtons.OK,
                 MessageBoxIcon.Question);
            else
                MessageBox.Show(ValidationInput.ERROR_MANY_SELECTED, ValidationInput.TITLE, MessageBoxButtons.OK,
                 MessageBoxIcon.Question);
        }

        private void btnSupplierSave_Click(object sender, EventArgs e)
        {
            if (Util.checkEmpty(txtSupplierName, "Tên"))
                return;
            if (Util.checkEmpty(txtSupplierPhone, "Phone"))
                return;
            if (Util.checkEmpty(txtSupplierAddress, "Address"))
                return;


            if (Util.checkPhone(txtSupplierPhone))
                return;
       
            var newData = new Supplier()
            {
                Id = Convert.ToInt32(txtSupplierId?.Text.Trim()),
                Name = txtSupplierName?.Text.Trim(),
                Phone = txtSupplierPhone?.Text.Trim(),
                Address = txtSupplierAddress?.Text.Trim(),
            };
            if (themmoSupplier)
            {
                bool IsSuccess = SupplierBus.Add(newData);
                if (IsSuccess)
                {
                    MessageBox.Show(ValidationInput.SUCCESS_ADD, ValidationInput.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                bool IsSuccess = SupplierBus.UpdateById(newData);
                if (IsSuccess)
                {
                    MessageBox.Show(ValidationInput.SUCCESS_EDIT, ValidationInput.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            setButtonSupplier(true);
            Suppliers = SupplierBus.getList();
            RenderDataGridViewSupplier(dgvSupplier, Suppliers);
        }

        private void btnSupplierCancel_Click(object sender, EventArgs e)
        {
            setButtonSupplier(true);
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            Suppliers = SupplierBus.getList();
            RenderDataGridViewSupplier(dgvSupplier, Suppliers);
        }
        // ----------------------------------------------------------

        void setButtonPublisher(bool val)
        {
            btnPublisherAdd.Enabled = val;
            btnPublisherDelete.Enabled = val;
            btnPublisherEdit.Enabled = val;
            btnPublisherSave.Enabled = !val;
            btnPublisherCancel.Enabled = !val;
        }
        void setInputPublisherNull()
        {
            txtPublisherName.Text = string.Empty;
        }
        private void btnPublisherAdd_Click(object sender, EventArgs e)
        {
            setInputPublisherNull();
            themmoPublisher = true;
            setButtonPublisher(false);
            txtPublisherName.Focus();
        }

        private void btnPublisherDelete_Click(object sender, EventArgs e)
        {
            if (dgvPublisher.SelectedRows.Count == 1)
            {
                DialogResult dr = MessageBox.Show(ValidationInput.COMFIRM_DELETE, ValidationInput.TITLE, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    bool deleteIsSucess = PublisherBus.DeleteById(txtPublisherId.Text.Trim());
                    if (deleteIsSucess)
                    {
                        MessageBox.Show(ValidationInput.SUCCESS_DELETE, ValidationInput.TITLE, MessageBoxButtons.OK,
                         MessageBoxIcon.Question);
                        setButtonPublisher(true);
                        Suppliers = SupplierBus.getList();
                        RenderDataGridViewSupplier(dgvSupplier, Suppliers);
                    }
                }
            }
            else if (dgvRole.SelectedRows.Count == 0)
                MessageBox.Show(ValidationInput.ERROR_NO_SELECT, ValidationInput.TITLE, MessageBoxButtons.OK,
                 MessageBoxIcon.Question);
            else
                MessageBox.Show(ValidationInput.ERROR_MANY_SELECTED, ValidationInput.TITLE, MessageBoxButtons.OK,
                 MessageBoxIcon.Question);
        }

        private void btnPublisherEdit_Click(object sender, EventArgs e)
        {
            if (dgvPublisher.SelectedRows.Count == 1)
            {
                themmoPublisher = false;
                setButtonPublisher(false);
            }
            else if (dgvPublisher.SelectedRows.Count == 0)
                MessageBox.Show(ValidationInput.ERROR_NO_SELECT, ValidationInput.TITLE, MessageBoxButtons.OK,
                 MessageBoxIcon.Question);
            else
                MessageBox.Show(ValidationInput.ERROR_MANY_SELECTED, ValidationInput.TITLE, MessageBoxButtons.OK,
                 MessageBoxIcon.Question);
        }

        private void btnPublisherSave_Click(object sender, EventArgs e)
        {
            if (Util.checkEmpty(txtPublisherName, "Tên"))
                return;
         
            var newData = new Publisher()
            {
                Id = Convert.ToInt32(txtPublisherId?.Text.Trim()),
                Name = txtPublisherName?.Text.Trim(),
            };
            if (themmoPublisher)
            {
                bool IsSuccess = PublisherBus.Add(newData);
                if (IsSuccess)
                {
                    MessageBox.Show(ValidationInput.SUCCESS_ADD, ValidationInput.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                bool IsSuccess = PublisherBus.UpdateById(newData);
                if (IsSuccess)
                {
                    MessageBox.Show(ValidationInput.SUCCESS_EDIT, ValidationInput.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            setButtonPublisher(true);
            Publishers = PublisherBus.getList();
            RenderDataGridViewPublisher(dgvPublisher, Publishers);
        }

        private void btnPublisherCancel_Click(object sender, EventArgs e)
        {
            setButtonPublisher(true);
        }

        private void btnPublisherRefresh_Click(object sender, EventArgs e)
        {
            Publishers = PublisherBus.getList();
            RenderDataGridViewPublisher(dgvPublisher, Publishers);
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            if (dgvDiscount.SelectedRows.Count > 0)
            {
                bool IsShow = false;
                if (!IsShow)
                {
                    var FResetPassword = new FResetPassword();
                    FResetPassword.Username = dgvDiscount.SelectedRows[0].Cells[2].Value?.ToString();
                    FResetPassword.Show();
                    IsShow = true;
                }


            }
        }
        // ----------------------------

        private void dgvDiscount_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDiscount.SelectedRows.Count > 0)
            {
                txtDiscountId.Text = dgvDiscount.SelectedRows[0].Cells[0].Value?.ToString() ?? "";
                txtDiscountName.Text = dgvDiscount.SelectedRows[0].Cells[1].Value?.ToString() ?? "";
                txtDiscountValue.Value = Convert.ToDecimal(dgvDiscount.SelectedRows[0].Cells[2].Value?.ToString());
                txtDiscountQuantity.Value = Convert.ToDecimal(dgvDiscount.SelectedRows[0].Cells[3].Value?.ToString());
                txtDiscountStartDate.Value = Convert.ToDateTime(dgvDiscount.SelectedRows[0].Cells[4].Value?.ToString());
                txtDiscountEndDate.Value = Convert.ToDateTime(dgvDiscount.SelectedRows[0].Cells[5].Value?.ToString());
            }
        }

        private void txDiscountSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txDiscountSearch.Text.ToLower().Trim(); // Convert to lowercase for case-insensitive search
            var searchResult = Discounts
                .Where(account =>
                    account.Id.ToString().ToLower().Contains(keyword) ||
                    account.Name.ToString().ToLower().Contains(keyword) ||
                    account.Value.ToString().ToLower().Contains(keyword) ||
                    account.Quantity.ToString().ToLower().Contains(keyword)

                )
                .ToList();

            RenderDataGridViewDiscount(dgvDiscount, searchResult);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

            txDiscountSearch.Text = string.Empty;
            txDiscountSearch.Focus();
        }
        void setButtonDiscount(bool val)
        {
            btnDiscountAdd.Enabled = val;
            btnDiscountDelete.Enabled = val;
            btnDiscountEdit.Enabled = val;
            btnDiscountSave.Enabled = !val;
            btnDiscountCancel.Enabled = !val;
        }
        void setInpuDiscountNull()
        {
            txtDiscountName.Text = string.Empty;
            txtDiscountValue.Value = 0;
            txtDiscountQuantity.Value = 0;
            txtDiscountStartDate.Value = DateTime.Now;
            txtDiscountEndDate.Value = DateTime.Now;
        }
        private void btnDiscountAdd_Click(object sender, EventArgs e)
        {
            setInpuDiscountNull();
            themmoPublisher = true;
            setButtonDiscount(false);
            txtDiscountName.Focus();
        }

        private void btnDiscountDelete_Click(object sender, EventArgs e)
        {
            if (dgvDiscount.SelectedRows.Count == 1)
            {
                DialogResult dr = MessageBox.Show(ValidationInput.COMFIRM_DELETE, ValidationInput.TITLE, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    bool deleteIsSucess = PublisherBus.DeleteById(txtPublisherId.Text.Trim());
                    if (deleteIsSucess)
                    {
                        MessageBox.Show(ValidationInput.SUCCESS_DELETE, ValidationInput.TITLE, MessageBoxButtons.OK,
                         MessageBoxIcon.Question);
                        setButtonDiscount(true);
                        Discounts = DiscountBus.getList();
                        RenderDataGridViewDiscount(dgvDiscount, Discounts);
                    }
                }
            }
        }
        private void btnDiscountEdit_Click(object sender, EventArgs e)
        {
            if (dgvDiscount.SelectedRows.Count == 1)
            {
                themmoDiscount = false;
                setButtonDiscount(false);
            }
            else if (dgvDiscount.SelectedRows.Count == 0)
                MessageBox.Show(ValidationInput.ERROR_NO_SELECT, ValidationInput.TITLE, MessageBoxButtons.OK,
                 MessageBoxIcon.Question);
            else
                MessageBox.Show(ValidationInput.ERROR_MANY_SELECTED, ValidationInput.TITLE, MessageBoxButtons.OK,
                 MessageBoxIcon.Question);
        }

        private void btnDiscountSave_Click(object sender, EventArgs e)
        {
            if (Util.checkEmpty(txtDiscountName, "Tên"))
                return;
            if(txtDiscountStartDate.Value > txtDiscountEndDate.Value)
            {
                MessageBox.Show("Ngày End không hợp lệ phải lớn hơn Start", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            
            var newData = new Discount()
            {
                Id = Convert.ToInt32(txtDiscountId?.Text.Trim()),
                Name = txtDiscountName?.Text.Trim(),
                Value = (float)txtDiscountValue.Value,
                Quantity = (int)txtDiscountQuantity.Value,
                StartDate = (DateTime)txtDiscountStartDate.Value,
                EndDate = (DateTime)txtDiscountEndDate.Value,
            };
            if (themmoDiscount)
            {
                bool IsSuccess = DiscountBus.Add(newData);
                if (IsSuccess)
                {
                    MessageBox.Show(ValidationInput.SUCCESS_ADD, ValidationInput.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                bool IsSuccess = DiscountBus.UpdateById(newData);
                if (IsSuccess)
                {
                    MessageBox.Show(ValidationInput.SUCCESS_EDIT, ValidationInput.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            setButtonDiscount(true);
            Discounts = DiscountBus.getList();
            RenderDataGridViewDiscount(dgvDiscount, Discounts);
        }

        private void btnDiscountCancel_Click(object sender, EventArgs e)
        {
            setButtonDiscount(true);
        }

        private void btnDiscountRefresh_Click(object sender, EventArgs e)
        {
            Discounts = DiscountBus.getList();
            RenderDataGridViewDiscount(dgvDiscount, Discounts);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrder.SelectedRows.Count > 0)
            {
                var id = dgvOrder.SelectedRows[0].Cells[0].Value?.ToString() ?? "0";

                RenderDataGridViewOrderDetail(Convert.ToInt32(id));

                txtOrderId.Text = dgvOrder.SelectedRows[0].Cells[0].Value?.ToString() ?? "";
                txtOrderStatus.Text = dgvOrder.SelectedRows[0].Cells[4].Value?.ToString() ?? "";

            }

        }

        private void dgvOrderDetail_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrderDetail.SelectedRows.Count > 0)
            {
                txtOrderDetailId.Text = dgvOrderDetail.SelectedRows[0].Cells[0].Value?.ToString() ?? "";
                txtOrderDetailPrice.Value = Convert.ToDecimal(dgvOrderDetail.SelectedRows[0].Cells[3].Value?.ToString());
                cbxOrderBook.SelectedIndex = cbxOrderBook.FindString(dgvOrderDetail.SelectedRows[0].Cells[2].Value?.ToString().Trim());
                cbxOrderBook.Refresh();
            }
        }

        private void materialButton61_Click(object sender, EventArgs e)
        {
            Orders = OrderBus.getList();
            RenderDataGridViewOrder(dgvOrder, Orders);
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            txtOrderSearch.Text = string.Empty;
            txtOrderSearch.Focus();
        }

        private void kryptonTextBox7_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtOrderSearch.Text.ToLower().Trim(); // Convert to lowercase for case-insensitive search
            var searchResult = Orders
                .Where(account =>
                    account.Id.ToString().ToLower().Contains(keyword) ||
                    account.Status.ToString().ToLower().Contains(keyword)

                )
                .ToList();

            RenderDataGridViewOrder(dgvOrder, searchResult);
        }

        // ----------------
        private void materialButton4_Click(object sender, EventArgs e)
        {
            Util.ExportToExcel(dgvCategory);

        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void materialButton3_Click(object sender, EventArgs e)
        {

            Util.ImportToExcel();
        }

        private void materialButton24_Click(object sender, EventArgs e)
        {
            if (dgvBookDetail.SelectedRows.Count == 1)
            {
                Util.SaveFileBarcode(dgvBookDetail.SelectedRows[0].Cells[1].Value?.ToString());
            }
            else if (dgvBookDetail.SelectedRows.Count == 0)
                MessageBox.Show(ValidationInput.ERROR_NO_SELECT, ValidationInput.TITLE, MessageBoxButtons.OK,
                 MessageBoxIcon.Question);
            else
                MessageBox.Show(ValidationInput.ERROR_MANY_SELECTED, ValidationInput.TITLE, MessageBoxButtons.OK,
                 MessageBoxIcon.Question);
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            if (dgvOrder.SelectedRows.Count == 1)
            {

                var orderId = dgvOrder.SelectedRows[0].Cells[0].Value?.ToString();
                FRpOrder fRpOrder = new FRpOrder(orderId);
                fRpOrder.ShowDialog();
            }
        }

        private void dgvImport_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvImport.SelectedRows.Count > 0)
            {
                var id = dgvImport.SelectedRows[0].Cells[0].Value?.ToString() ?? "0";

                RenderDataGridViewImportDetail(Convert.ToInt32(id));

                txtImportId.Text = dgvImport.SelectedRows[0].Cells[0].Value?.ToString() ?? "";
                txtImportStatus.Text = dgvImport.SelectedRows[0].Cells[2].Value?.ToString() ?? "";

            }
        }

        private void dgvImportDetail_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvImportDetail.SelectedRows.Count > 0)
            {
                txtImportDetailId.Text = dgvImportDetail.SelectedRows[0].Cells[0].Value?.ToString() ?? "";
                txtImportDetailBook.SelectedIndex = txtImportDetailBook.FindString(dgvImportDetail.SelectedRows[0].Cells[2].Value?.ToString().Trim());
                txtImportDetailBook.Refresh();
                txtImportDetailQuantity.Value = Convert.ToDecimal(dgvImportDetail.SelectedRows[0].Cells[3].Value?.ToString());

            }
        }

        private void btnImportRefresh_Click(object sender, EventArgs e)
        {
            Imports = ImportBus.getList();
            RenderDataGridViewImport(dgvImport, Imports);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            var fOrder = new FImport();
            fOrder.ShowDialog();
        }

        private void txtImportSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtImportSearch.Text.ToLower().Trim(); // Convert to lowercase for case-insensitive search
            var searchResult = Imports
                .Where(account =>
                    account.Id.ToString().ToLower().Contains(keyword) ||
                    account.Status.ToString().ToLower().Contains(keyword)

                )
                .ToList();

            RenderDataGridViewImport(dgvImport, searchResult);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            txtImportSearch.Text = string.Empty;
            txtImportSearch.Focus();
        }

        private void materialButton28_Click(object sender, EventArgs e)
        {
            if (dgvImport.SelectedRows.Count == 1)
            {

                var orderId = dgvImport.SelectedRows[0].Cells[0].Value?.ToString();
                var fRpOrder = new FRpImport(orderId);
                fRpOrder.ShowDialog();
            }
        }

        private void btnImportDelete_Click(object sender, EventArgs e)
        {
            if (dgvImport.SelectedRows.Count == 1)
            {

                var orderId = dgvImport.SelectedRows[0].Cells[0].Value?.ToString();
                if(ImportBus.DeleteById(orderId)) {
                    MessageBox.Show(ValidationInput.SUCCESS_DELETE, ValidationInput.TITLE, MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
                    Imports = ImportBus.getList();
                    RenderDataGridViewImport(dgvImport, Imports);
                }
            }
        }

        private void materialButton57_Click(object sender, EventArgs e)
        {
            if (dgvOrder.SelectedRows.Count == 1)
            {

                var orderId = dgvOrder.SelectedRows[0].Cells[0].Value?.ToString();
                if (ImportBus.DeleteById(orderId))
                {
                    MessageBox.Show(ValidationInput.SUCCESS_DELETE, ValidationInput.TITLE, MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
                    Orders = OrderBus.getList();
                    RenderDataGridViewOrder(dgvOrder, Orders);
                }
            }
        }

        private void materialButton6_Click(object sender, EventArgs e)
        {
            Util.ExportToExcel(dgvAuthor);
        }

        private void materialButton8_Click(object sender, EventArgs e)
        {
            Util.ExportToExcel(dgvAuthor);
        }

        private void materialButton10_Click(object sender, EventArgs e)
        {
            Util.ExportToExcel(dgvBook);
        }

        private void materialButton13_Click(object sender, EventArgs e)
        {
            Util.ExportToExcel(dgvBookDetail);
        }

        private void materialButton15_Click(object sender, EventArgs e)
        {
            Util.ExportToExcel(dgvCustomer);
        }

        private void materialButton17_Click(object sender, EventArgs e)
        {
            Util.ExportToExcel(dgvRole);
        }

        private void materialButton19_Click(object sender, EventArgs e)
        {
            Util.ExportToExcel(dgvDiscount);
        }

        private void materialButton21_Click(object sender, EventArgs e)
        {
            Util.ExportToExcel(dgvSupplier);
        }

        private void materialButton23_Click(object sender, EventArgs e)
        {
            Util.ExportToExcel(dgvPublisher);
        }
        public string fileNameBook {  get; set; }

        private void ptbBook_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.png;*.gif)|*.bmp;*.jpg;*.png;*.gif|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Lấy đường dẫn của tệp hình ảnh đã chọn
                    string imagePath = openFileDialog.FileName;
                    fileNameBook = imagePath;

                    // Hiển thị hình ảnh trong PictureBox
                    ptbBook.ImageLocation = imagePath;
                    string path = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;
                    fileNameBook = Guid.NewGuid().ToString() + ".png";
                    string randomFileName = Path.Combine(path,"images",  fileNameBook);
                    try
                    {
                        File.Copy(imagePath, randomFileName, true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Đã xảy ra lỗi khi copy ảnh: {ex.Message}");
                    }
                }
            }
        }
        // --------------------------------------------------
        public string pathImPortExcel { get; set; }
        public bool IsCheckSuccess { get; set; } = false;

        private void materialButton25_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(pathImPortExcel);
            LoadExcelData(pathImPortExcel);
        }
        DataTable dt = null;
        private void LoadExcelData(string filePath)
        {
            IsCheckSuccess = false;
            using (ExcelPackage package = new ExcelPackage(new System.IO.FileInfo(filePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                dt = new DataTable();

                // Lặp qua các cột và thêm chúng vào DataTable
                foreach (var firstRowCell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
                {
                    dt.Columns.Add(firstRowCell.Text);
                }

                // Lặp qua các dòng và thêm chúng vào DataTable
                for (int rowNumber = 2; rowNumber <= worksheet.Dimension.End.Row; rowNumber++)
                {
                    var row = worksheet.Cells[rowNumber, 1, rowNumber, worksheet.Dimension.End.Column];
                    DataRow newRow = dt.Rows.Add();
                    foreach (var cell in row)
                    {
                        newRow[cell.Start.Column - 1] = cell.Text;
                    }
                }

                // Hiển thị dữ liệu trong DataGridView
                dataGridView1.DataSource = dt;
            }
        }


        private bool ValidateData(DataGridView dataGridView)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value == null || string.IsNullOrWhiteSpace(cell.Value.ToString()))
                        {
                            MessageBox.Show($"Dữ liệu tại hàng {cell.RowIndex + 1}, cột {cell.ColumnIndex + 1} không được để trống. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void materialButton22_Click(object sender, EventArgs e)
        {

            this.pathImPortExcel = Util.ImportToExcel();
            LoadExcelData(pathImPortExcel);
        }

        private void materialButton27_Click(object sender, EventArgs e)
        {

            if (!IsCheckSuccess)
            {
                MessageBox.Show($"Bạn chưa check dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int count = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Kiểm tra nếu hàng không phải là hàng trống và có dữ liệu để chèn
                if (!row.IsNewRow)
                {
                    count++;
                    string name = cbxImport.SelectedItem.ToString().Trim().ToLower();
                    switch (name)
                    {
                        case "category":
                            var newDate = new Category()
                            {
                                Name = row.Cells[1].Value.ToString(),
                            };
                            CategoryBus.Add(newDate);
                            break;
                        case "account":

                            int gender;
                            if (row.Cells[4].Value.ToString() == "Nam")
                                gender = 1;
                            else
                                gender = 0;
                            var account = new Account()
                            {
                                Name = row.Cells[1].Value.ToString(),
                                UserName = row.Cells[2].Value.ToString(),
                                Phone = row.Cells[3].Value.ToString(),
                                BirthDay = Convert.ToDateTime(row.Cells[4].Value.ToString()),
                                Gender = gender,
                                RoleId = 1

                            };
                            AccountBus.Add(account);
                            break;
                        case "author":

                            break;
                        case "book":

                            break;
                        case "book detail":

                            break;
                        case "role":

                            break;
                        case "customer":

                            break;
                        case "discount":

                            break;
                        case "publisher":

                            break;
                        case "supplier":

                            break;
                    }
                }
            }
            if (count == dataGridView1.Rows.Count)
            {
                MessageBox.Show($"Import dữ liệu vào DB thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void materialButton26_Click(object sender, EventArgs e)
        {
            if (ValidateData(dataGridView1))
            {
                IsCheckSuccess = true;
                string name = cbxImport.SelectedItem.ToString().Trim().ToLower();
                switch (name) { 
                    case "category":
                        if (!ValidateColumnNames(dt, new string[] { "id",  "name" }))
                            return;
                        else
                            IsCheckSuccess = true;
                        break;
                    case "account":
                        if (!ValidateColumnNames(dt, new string[] { "id", "name", "username", "phone", "birthday", "gender", "role" }))
                            return;
                        else
                            IsCheckSuccess = true;
                        break;
                    case "author":
                        if (!ValidateColumnNames(dt, new string[] { "id", "firstname","lastname",  "birthday", "gender" }))
                            return;
                        else
                            IsCheckSuccess = true;
                        break;
                    case "book":
                        if (!ValidateColumnNames(dt, new string[] { "id", "name", "price", "format", "publisherDate", "Totalpage", "Quantity", "category", "AuthorId", "SupplierId" }))
                            return;
                        else
                            IsCheckSuccess = true;
                        break;
                    case "book detail":
                        if (!ValidateColumnNames(dt, new string[] { "id", "barcode", "book", "supplierId" }))
                            return;
                        else
                            IsCheckSuccess = true;
                        break;
                    case "role":
                        if (!ValidateColumnNames(dt, new string[] { "id", "name" }))
                            return;
                        else
                            IsCheckSuccess = true;
                        break;
                    case "customer":
                        if (!ValidateColumnNames(dt, new string[] { "id", "name", "phone", "birthday", "address", "gender" }))
                            return;
                        else
                            IsCheckSuccess = true;
                        break;
                    case "discount":
                        if (!ValidateColumnNames(dt, new string[] { "id", "name", "value","quantity", "start date", "end date"  }))
                            return;
                        else
                            IsCheckSuccess = true;
                        break;
                    case "publisher":
                        if (!ValidateColumnNames(dt, new string[] { "id", "name" }))
                            return;
                        else
                            IsCheckSuccess = true;
                        break;
                    case "supplier":
                        if (!ValidateColumnNames(dt, new string[] { "id", "name", "phone","address" }))
                            return;
                        else
                            IsCheckSuccess = true;
                        break;

                }
                if(IsCheckSuccess)
                {
                    MessageBox.Show($"kiểm tra dữ liệu thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                IsCheckSuccess = false;
                 MessageBox.Show($"Đữ liệu không được bỏ trống.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private bool ValidateColumnNames(DataTable dt)
        {
            string[] expectedColumns = { "id", "name" };

            if (dt.Columns.Count != expectedColumns.Length)
            {
                MessageBox.Show("Có lỗi.Bạn phải chắc chắc file excel có đủ cột", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Check if the column names match the expected order
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (!string.Equals(dt.Columns[i].ColumnName, expectedColumns[i], StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show($"Invalid column name at position {i + 1}. The column should be named '{expectedColumns[i]}'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }
        private bool ValidateColumnNames(DataTable dt, string[] expectedColumns)
        {
            if (dt.Columns.Count != expectedColumns.Length )
            {
                string expectedColumnList = string.Join(", ", expectedColumns);
                MessageBox.Show($"Có lỗi. Bạn phải chắc chắn file Excel có đủ {expectedColumns.Length} cột ({expectedColumnList}).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Check if the column names match the expected order
            List<string> incorrectColumns = new List<string>();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (!string.Equals(dt.Columns[i].ColumnName, expectedColumns[i], StringComparison.OrdinalIgnoreCase))
                {
                    incorrectColumns.Add(dt.Columns[i].ColumnName);
                }
            }

            if (incorrectColumns.Count > 0)
            {
                string incorrectColumnsList = string.Join(", ", incorrectColumns);
                MessageBox.Show($"Các cột không hợp lệ: {incorrectColumnsList}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }



    }
}
