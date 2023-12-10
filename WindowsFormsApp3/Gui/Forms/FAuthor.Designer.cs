namespace WindowsFormsApp3.Gui.Forms
{
    partial class FAuthor
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
            this.materialTextBox1 = new MaterialSkin.Controls.MaterialTextBox();
            this.materialTextBox2 = new MaterialSkin.Controls.MaterialTextBox();
            this.btnAuthorSave = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // materialTextBox1
            // 
            this.materialTextBox1.AnimateReadOnly = false;
            this.materialTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.materialTextBox1.Depth = 0;
            this.materialTextBox1.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTextBox1.LeadingIcon = null;
            this.materialTextBox1.Location = new System.Drawing.Point(33, 110);
            this.materialTextBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.materialTextBox1.MaxLength = 50;
            this.materialTextBox1.MouseState = MaterialSkin.MouseState.OUT;
            this.materialTextBox1.Multiline = false;
            this.materialTextBox1.Name = "materialTextBox1";
            this.materialTextBox1.Size = new System.Drawing.Size(349, 50);
            this.materialTextBox1.TabIndex = 0;
            this.materialTextBox1.Text = "";
            this.materialTextBox1.TrailingIcon = null;
            // 
            // materialTextBox2
            // 
            this.materialTextBox2.AnimateReadOnly = false;
            this.materialTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.materialTextBox2.Depth = 0;
            this.materialTextBox2.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTextBox2.LeadingIcon = null;
            this.materialTextBox2.Location = new System.Drawing.Point(33, 207);
            this.materialTextBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.materialTextBox2.MaxLength = 50;
            this.materialTextBox2.MouseState = MaterialSkin.MouseState.OUT;
            this.materialTextBox2.Multiline = false;
            this.materialTextBox2.Name = "materialTextBox2";
            this.materialTextBox2.Size = new System.Drawing.Size(349, 50);
            this.materialTextBox2.TabIndex = 1;
            this.materialTextBox2.Text = "";
            this.materialTextBox2.TrailingIcon = null;
            // 
            // btnAuthorSave
            // 
            this.btnAuthorSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAuthorSave.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAuthorSave.Depth = 0;
            this.btnAuthorSave.HighEmphasis = true;
            this.btnAuthorSave.Icon = null;
            this.btnAuthorSave.Location = new System.Drawing.Point(164, 330);
            this.btnAuthorSave.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnAuthorSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAuthorSave.Name = "btnAuthorSave";
            this.btnAuthorSave.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnAuthorSave.Size = new System.Drawing.Size(64, 36);
            this.btnAuthorSave.TabIndex = 2;
            this.btnAuthorSave.Text = "Lưu";
            this.btnAuthorSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAuthorSave.UseAccentColor = false;
            this.btnAuthorSave.UseVisualStyleBackColor = true;
            // 
            // FAuthor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 429);
            this.Controls.Add(this.btnAuthorSave);
            this.Controls.Add(this.materialTextBox2);
            this.Controls.Add(this.materialTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_56;
            this.HelpButton = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FAuthor";
            this.Padding = new System.Windows.Forms.Padding(2, 65, 2, 2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông Tin Tác Giả";
            this.Load += new System.EventHandler(this.FAuthor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox materialTextBox1;
        private MaterialSkin.Controls.MaterialTextBox materialTextBox2;
        private MaterialSkin.Controls.MaterialButton btnAuthorSave;
    }
}