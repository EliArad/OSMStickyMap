namespace OSMStickyMap
{
    partial class RadarSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RadarSettings));
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpSelectProvider = new System.Windows.Forms.GroupBox();
            this.cmbGMapProviders = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbMapAccessMode = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOSMBaseDir = new System.Windows.Forms.TextBox();
            this.grpSelectProvider.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(122, 386);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(99, 39);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "&Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(315, 386);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 39);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grpSelectProvider
            // 
            this.grpSelectProvider.Controls.Add(this.cmbGMapProviders);
            this.grpSelectProvider.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSelectProvider.Location = new System.Drawing.Point(29, 25);
            this.grpSelectProvider.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpSelectProvider.Name = "grpSelectProvider";
            this.grpSelectProvider.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpSelectProvider.Size = new System.Drawing.Size(475, 95);
            this.grpSelectProvider.TabIndex = 7;
            this.grpSelectProvider.TabStop = false;
            this.grpSelectProvider.Text = "Select Provider";
            // 
            // cmbGMapProviders
            // 
            this.cmbGMapProviders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGMapProviders.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGMapProviders.FormattingEnabled = true;
            this.cmbGMapProviders.Location = new System.Drawing.Point(9, 37);
            this.cmbGMapProviders.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbGMapProviders.Name = "cmbGMapProviders";
            this.cmbGMapProviders.Size = new System.Drawing.Size(431, 28);
            this.cmbGMapProviders.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(26, 255);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 20);
            this.label3.TabIndex = 119;
            this.label3.Text = "Map Access Mode";
            // 
            // cmbMapAccessMode
            // 
            this.cmbMapAccessMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMapAccessMode.FormattingEnabled = true;
            this.cmbMapAccessMode.Items.AddRange(new object[] {
            "Offline",
            "Online",
            "Both"});
            this.cmbMapAccessMode.Location = new System.Drawing.Point(188, 249);
            this.cmbMapAccessMode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbMapAccessMode.Name = "cmbMapAccessMode";
            this.cmbMapAccessMode.Size = new System.Drawing.Size(316, 28);
            this.cmbMapAccessMode.TabIndex = 118;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(27, 194);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 117;
            this.label4.Text = "OSM Base Dir";
            // 
            // txtOSMBaseDir
            // 
            this.txtOSMBaseDir.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtOSMBaseDir.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.txtOSMBaseDir.Location = new System.Drawing.Point(188, 191);
            this.txtOSMBaseDir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOSMBaseDir.Name = "txtOSMBaseDir";
            this.txtOSMBaseDir.Size = new System.Drawing.Size(316, 26);
            this.txtOSMBaseDir.TabIndex = 116;
            // 
            // RadarSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(522, 455);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbMapAccessMode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtOSMBaseDir);
            this.Controls.Add(this.grpSelectProvider);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RadarSettings";
            this.Text = "Settings";
            this.grpSelectProvider.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grpSelectProvider;
        private System.Windows.Forms.ComboBox cmbGMapProviders;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbMapAccessMode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOSMBaseDir;
    }
}