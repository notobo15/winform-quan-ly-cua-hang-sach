using MaterialSkin.Controls;
using Microsoft.ReportingServices.Diagnostics.Internal;
using MySql.Data.MySqlClient;
using OfficeOpenXml;
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
    public partial class ImportExcel : MaterialForm
    {
        CategoryBus CategoryBus { get; set; } = new CategoryBus();
        public string path {  get; set; }
        public bool IsCheckSuccess { get; set; } = false;
        public ImportExcel(string path)
        {
            InitializeComponent();
            this.path = path;
            LoadExcelData(path);
        }

        private void LoadExcelData(string filePath)
        {
            IsCheckSuccess = false;
            using (ExcelPackage package = new ExcelPackage(new System.IO.FileInfo(filePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                DataTable dt = new DataTable();

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

        private void materialButton1_Click(object sender, EventArgs e)
        {

            if (ValidateData(dataGridView1))
            {
                IsCheckSuccess = true;
                MessageBox.Show($"Đữ liệu hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                IsCheckSuccess = false;
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            LoadExcelData(path);
        }

        private void materialButton2_Click(object sender, EventArgs e)
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
                    var newDate = new Category()
                    {
                        Name = row.Cells[1].Value.ToString(),
                    };
                    CategoryBus.Add(newDate);
                    count++;
                }
            }
            if(count == dataGridView1.Rows.Count)
            {
                MessageBox.Show($"Import dữ liệu vào DB thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        
    }
}
