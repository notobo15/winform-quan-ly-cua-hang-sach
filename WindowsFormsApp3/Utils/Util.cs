using OfficeOpenXml;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp3.Gui.Forms;
using System.Drawing;
using System.Windows.Controls;

namespace QuanLyCuaHangSach.Utils
{
    public class Util
    {
        public static string FormatDateTime(DateTime? date)
        {
            if (date == null)
                return "";
            return date?.ToString("yyyy-MM-dd HH:mm:ss");
        } 

        public static Bitmap GeneratorQR(string data)
        {

            // Tạo đối tượng QRCodeGenerator
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);

            // Tạo đối tượng QRCode từ dữ liệu
           QRCode qrCode = new QRCode(qrCodeData);

            // Tạo bitmap từ mã QR
            Bitmap qrCodeImage = qrCode.GetGraphic(20); // 20 là kích thước của mỗi module (pixel)


            return qrCodeImage;
        }

        public static void ExportToExcel(DataGridView dataGridView, string filePath)
        {
            using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

                // Headers
                for (int i = 1; i <= dataGridView.Columns.Count; i++)
                {
                    worksheet.Cells[1, i].Value = dataGridView.Columns[i - 1].HeaderText;
                }

                // Data
                for (int row = 0; row < dataGridView.Rows.Count; row++)
                {
                    for (int col = 0; col < dataGridView.Columns.Count; col++)
                    {
                        worksheet.Cells[row + 2, col + 1].Value = dataGridView.Rows[row].Cells[col].Value;
                    }
                }

                package.Save();
            }
        }
        public static void ImportToExcel()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files|*.xls;*.xlsx;*.xlsm",
                Title = "Select an Excel File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                ImportExcel importExcel = new ImportExcel(filePath);
                importExcel.ShowDialog();
            }
        }
        public static void ExportToExcel(DataGridView dataGridView)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                Title = "Save Excel File",
                FileName = "ExportedData.xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Util.ExportToExcel(dataGridView, saveFileDialog.FileName);
                MessageBox.Show("Export dữ liệu thành công.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static void SaveFileBarcode(string barcode)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG files (*.png)|*.png";
            saveFileDialog.Title = "Save QR Code Image";
            saveFileDialog.FileName = "qrcode.png";
            saveFileDialog.ShowDialog();
            if (!string.IsNullOrEmpty(saveFileDialog.FileName))
            {
                var Bitmap = Util.GeneratorQR(barcode.Trim()) ;
                Bitmap.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        public static bool checkEmpty(dynamic control, string str)
        {
            if(ValidationInput.IsValidEmpty(control.Text.Trim()))
            {
                MessageBox.Show($"{str} không được bỏ trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                control.Focus();
                return true;
            }
            return false;
          
        }
        public static bool checkEmail(dynamic control)
        {
            if (!ValidationInput.IsValidEmail(control.Text.Trim()))
            {
                MessageBox.Show($"Email không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                control.Focus();
                return true;
            }
            return false;

        }
        public static bool checkName(dynamic control)
        {
            if (!ValidationInput.IsNamePersonValid(control.Text.Trim()))
            {
                MessageBox.Show($"Tên chỉ chứa kí tự chữ cái lan tin không được chứa kí tự số hay đặt biệt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                control.Focus();
                return true;
            }
            return false;

        }
        public static bool checkPhone(dynamic control)
        {
            if (!ValidationInput.IsPhoneNumberValid(control.Text.Trim()))
            {
                MessageBox.Show($"Phone phải dài 10 kí tự và chỉ chứa kí tự số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                control.Focus();
                return true;
            }
            return false;

        }
        public static bool checkBirthday(dynamic control, string str)
        {
            if (!ValidationInput.IsBirthDayValid(control.Value))
            {
                MessageBox.Show($"{str} không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                control.Focus();
                return true;
            }
            return false;

        }
    }
}
