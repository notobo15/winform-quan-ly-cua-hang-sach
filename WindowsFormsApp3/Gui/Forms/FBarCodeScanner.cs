using AForge.Video.DirectShow;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace WindowsFormsApp3.Gui.Forms
{
    public partial class FBarCodeScanner : MaterialForm
    {
        public FBarCodeScanner()
        {
            InitializeComponent();
        }
        public string barcode {  get; set; }

        FilterInfoCollection FilterInfoCollection { get; set; }
        VideoCaptureDevice VideoCaptureDevice { get; set; }

        private void FBarCodeScanner_Load(object sender, EventArgs e)
        {
            FilterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo item in FilterInfoCollection)
            {
                materialComboBox1.Items.Add(item.Name);
            }
            materialComboBox1.SelectedIndex = 1;
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
         
        }
        public bool IsSuccess = false;
        private void VideoCaptureDevice_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {

            if(IsSuccess)
            {
                if (VideoCaptureDevice != null)
                {
                    if (VideoCaptureDevice.IsRunning)
                    {
                        // Dừng quá trình quay video trước khi đóng form
                        VideoCaptureDevice.SignalToStop();
                        VideoCaptureDevice.WaitForStop();
                    }
                }
                return;

            }
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            BarcodeReader reader = new BarcodeReader();
            var result = reader.Decode(bitmap);
            if(result != null) {

               // MessageBox.Show(result.ToString());
                IsSuccess = true;
                barcode = result.ToString();

                this.Invoke((MethodInvoker)delegate
                {
                    this.Close();
                });

            }
            pictureBox1.Image = bitmap;
        }

        private void FBarCodeScanner_FormClosing(object sender, FormClosingEventArgs e)
        {
         
        }

        private void materialComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            VideoCaptureDevice = new VideoCaptureDevice(FilterInfoCollection[materialComboBox1.SelectedIndex].MonikerString);
            VideoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            VideoCaptureDevice.Start();
        }

        public string GetCapturedBarcode()
        {
            return barcode;
        }

        private void materialButton1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
