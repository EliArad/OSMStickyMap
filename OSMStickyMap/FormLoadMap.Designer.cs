namespace OSMStickyMap
{
    partial class FormLoadMap
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
            this.buttonLoadMap = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxZoom = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxLong = new System.Windows.Forms.TextBox();
            this.textBoxLat = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonLoadMap
            // 
            this.buttonLoadMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLoadMap.Location = new System.Drawing.Point(42, 252);
            this.buttonLoadMap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonLoadMap.Name = "buttonLoadMap";
            this.buttonLoadMap.Size = new System.Drawing.Size(174, 53);
            this.buttonLoadMap.TabIndex = 37;
            this.buttonLoadMap.Text = "Load Map";
            this.buttonLoadMap.UseVisualStyleBackColor = true;
            this.buttonLoadMap.Click += new System.EventHandler(this.buttonLoadMap_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 155);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 36;
            this.label1.Text = "Zoom";
            // 
            // comboBoxZoom
            // 
            this.comboBoxZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxZoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxZoom.FormattingEnabled = true;
            this.comboBoxZoom.Location = new System.Drawing.Point(38, 182);
            this.comboBoxZoom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxZoom.Name = "comboBoxZoom";
            this.comboBoxZoom.Size = new System.Drawing.Size(176, 37);
            this.comboBoxZoom.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 34;
            this.label2.Text = "Longitude";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 17);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 20);
            this.label5.TabIndex = 33;
            this.label5.Text = "Latitude";
            // 
            // textBoxLong
            // 
            this.textBoxLong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLong.Location = new System.Drawing.Point(38, 110);
            this.textBoxLong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxLong.Name = "textBoxLong";
            this.textBoxLong.Size = new System.Drawing.Size(176, 35);
            this.textBoxLong.TabIndex = 32;
            this.textBoxLong.Text = "33";
            // 
            // textBoxLat
            // 
            this.textBoxLat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLat.Location = new System.Drawing.Point(38, 42);
            this.textBoxLat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxLat.Name = "textBoxLat";
            this.textBoxLat.Size = new System.Drawing.Size(176, 35);
            this.textBoxLat.TabIndex = 31;
            this.textBoxLat.Text = "33";
            // 
            // FormLoadMap
            // 
            this.AcceptButton = this.buttonLoadMap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 319);
            this.Controls.Add(this.buttonLoadMap);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxZoom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxLong);
            this.Controls.Add(this.textBoxLat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FormLoadMap";
            this.Text = "Load";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormLoadMap_FormClosing);
            this.Load += new System.EventHandler(this.FormLoadMap_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLoadMap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxZoom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxLong;
        private System.Windows.Forms.TextBox textBoxLat;
    }
}