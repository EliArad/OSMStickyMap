namespace OSMStickyMap
{
    partial class FormSelectMapCity
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelectMapCity));
            this.label9 = new System.Windows.Forms.Label();
            this.txtMapKeyCity = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMapKeyCountry = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(188, 38);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 20);
            this.label9.TabIndex = 84;
            this.label9.Text = "City";
            // 
            // txtMapKeyCity
            // 
            this.txtMapKeyCity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMapKeyCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMapKeyCity.Location = new System.Drawing.Point(188, 63);
            this.txtMapKeyCity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMapKeyCity.Name = "txtMapKeyCity";
            this.txtMapKeyCity.Size = new System.Drawing.Size(134, 35);
            this.txtMapKeyCity.TabIndex = 83;
            this.txtMapKeyCity.Text = "Tel Aviv";
            this.txtMapKeyCity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 38);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 20);
            this.label8.TabIndex = 82;
            this.label8.Text = "Country";
            // 
            // txtMapKeyCountry
            // 
            this.txtMapKeyCountry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMapKeyCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMapKeyCountry.Location = new System.Drawing.Point(14, 63);
            this.txtMapKeyCountry.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMapKeyCountry.Name = "txtMapKeyCountry";
            this.txtMapKeyCountry.Size = new System.Drawing.Size(134, 35);
            this.txtMapKeyCountry.TabIndex = 81;
            this.txtMapKeyCountry.Text = "Israel";
            this.txtMapKeyCountry.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(105, 152);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(116, 42);
            this.btnOk.TabIndex = 86;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // FormSelectMapCity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 200);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtMapKeyCity);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtMapKeyCountry);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FormSelectMapCity";
            this.Text = "Select City";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSelectMapCity_FormClosing);
            this.Load += new System.EventHandler(this.FormSelectMapCity_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMapKeyCity;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMapKeyCountry;
        private System.Windows.Forms.Button btnOk;
    }
}