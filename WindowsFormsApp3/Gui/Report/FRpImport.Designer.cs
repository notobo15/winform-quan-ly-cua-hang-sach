namespace WindowsFormsApp3.Gui.Report
{
    partial class FRpImport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.materialButton2 = new MaterialSkin.Controls.MaterialButton();
            this.btnOrderConfirm = new MaterialSkin.Controls.MaterialButton();
            this.customBookBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customBookBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Left;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "WindowsFormsApp3.Gui.Report.RpImport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(796, 661);
            this.reportViewer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.materialButton2);
            this.panel1.Controls.Add(this.btnOrderConfirm);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(796, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(188, 661);
            this.panel1.TabIndex = 2;
            // 
            // materialButton2
            // 
            this.materialButton2.AutoSize = false;
            this.materialButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton2.Depth = 0;
            this.materialButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.materialButton2.HighEmphasis = true;
            this.materialButton2.Icon = global::WindowsFormsApp3.Properties.Resources.reject;
            this.materialButton2.Location = new System.Drawing.Point(17, 292);
            this.materialButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton2.Name = "materialButton2";
            this.materialButton2.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton2.Size = new System.Drawing.Size(158, 116);
            this.materialButton2.TabIndex = 1;
            this.materialButton2.Text = "QUAY LẠI";
            this.materialButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton2.UseAccentColor = false;
            this.materialButton2.UseVisualStyleBackColor = true;
            this.materialButton2.Click += new System.EventHandler(this.materialButton2_Click);
            // 
            // btnOrderConfirm
            // 
            this.btnOrderConfirm.AutoSize = false;
            this.btnOrderConfirm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOrderConfirm.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnOrderConfirm.Depth = 0;
            this.btnOrderConfirm.HighEmphasis = true;
            this.btnOrderConfirm.Icon = global::WindowsFormsApp3.Properties.Resources.add;
            this.btnOrderConfirm.Location = new System.Drawing.Point(17, 71);
            this.btnOrderConfirm.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnOrderConfirm.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnOrderConfirm.Name = "btnOrderConfirm";
            this.btnOrderConfirm.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnOrderConfirm.Size = new System.Drawing.Size(158, 116);
            this.btnOrderConfirm.TabIndex = 0;
            this.btnOrderConfirm.Text = "XÁC NHẬN THANH TOÁN";
            this.btnOrderConfirm.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnOrderConfirm.UseAccentColor = false;
            this.btnOrderConfirm.UseVisualStyleBackColor = true;
            this.btnOrderConfirm.Click += new System.EventHandler(this.materialButton1_Click);
            // 
            // customBookBindingSource
            // 
            this.customBookBindingSource.DataSource = typeof(WindowsFormsApp3.Gui.Forms.FOrder.CustomBook);
            // 
            // FRpImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.materialButton2;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FRpImport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRpOrder";
            this.Load += new System.EventHandler(this.FRpOrder_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.customBookBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource customBookBindingSource;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialButton materialButton2;
        private MaterialSkin.Controls.MaterialButton btnOrderConfirm;
    }
}