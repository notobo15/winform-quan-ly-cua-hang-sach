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

namespace WindowsFormsApp3
{
    public partial class FLoading : MaterialForm
    {
        private Timer timer; 
        readonly MaterialSkin.MaterialSkinManager materialSkinManager;
        public FLoading()
        {
            InitializeComponent();
            InitializeTimer();
            materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            // materialSkinManager.AddFormToManage(this);
            // materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Green700, MaterialSkin.Primary.Teal900, MaterialSkin.Primary.Indigo100, MaterialSkin.Accent.Green700, MaterialSkin.TextShade.WHITE);
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
            progressBar2.Value += 1; // Cập nhật giá trị ProgressBar

            if (progressBar2.Value >= progressBar2.Maximum)
            {
                progressBar2.Value = progressBar2.Minimum; // Reset giá trị khi nó đạt giá trị tối đa
            }
        }
        private void FLoading_Load(object sender, EventArgs e)
        {

        }

       
    }
}
