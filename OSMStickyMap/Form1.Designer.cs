namespace OSMStickyMap
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.mapPanel = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem16 = new System.Windows.Forms.ToolStripMenuItem();
            this.findCityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem15 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.calcDistanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripSeparator();
            this.pinHereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllPinsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem17 = new System.Windows.Forms.ToolStripSeparator();
            this.screenShotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fetchSelectedRegioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.askEveryZoomLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addObjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ariPLaneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.browseForObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem26 = new System.Windows.Forms.ToolStripSeparator();
            this.objectOnTargetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem22 = new System.Windows.Forms.ToolStripSeparator();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showCoordinatorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.latLonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.showZoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.moveAndResizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topMostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStartFetch = new System.Windows.Forms.Button();
            this.lblMapPopupMsg = new System.Windows.Forms.Label();
            this.lblLon = new System.Windows.Forms.Label();
            this.lblLat = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxZoom = new System.Windows.Forms.ComboBox();
            this.mapPanel.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mapPanel
            // 
            this.mapPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mapPanel.ContextMenuStrip = this.contextMenuStrip1;
            this.mapPanel.Controls.Add(this.label3);
            this.mapPanel.Controls.Add(this.label2);
            this.mapPanel.Controls.Add(this.btnStartFetch);
            this.mapPanel.Controls.Add(this.lblMapPopupMsg);
            this.mapPanel.Controls.Add(this.lblLon);
            this.mapPanel.Controls.Add(this.lblLat);
            this.mapPanel.Controls.Add(this.label1);
            this.mapPanel.Controls.Add(this.comboBoxZoom);
            this.mapPanel.Location = new System.Drawing.Point(4, 1);
            this.mapPanel.Margin = new System.Windows.Forms.Padding(2);
            this.mapPanel.Name = "mapPanel";
            this.mapPanel.Size = new System.Drawing.Size(865, 554);
            this.mapPanel.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.settingsToolStripMenuItem,
            this.loadMapToolStripMenuItem,
            this.loadHistoryToolStripMenuItem,
            this.toolStripMenuItem16,
            this.findCityToolStripMenuItem,
            this.homeToolStripMenuItem,
            this.toolStripSeparator2,
            this.toolStripMenuItem15,
            this.toolStripMenuItem14,
            this.toolStripMenuItem13,
            this.toolStripSeparator1,
            this.lineToolStripMenuItem,
            this.lineToolStripMenuItem1,
            this.calcDistanceToolStripMenuItem,
            this.toolStripMenuItem12,
            this.pinHereToolStripMenuItem,
            this.clearAllPinsToolStripMenuItem,
            this.toolStripMenuItem17,
            this.screenShotToolStripMenuItem,
            this.fetchSelectedRegioToolStripMenuItem,
            this.addObjectsToolStripMenuItem,
            this.showCoordinatorsToolStripMenuItem,
            this.toolStripSeparator3,
            this.showZoomToolStripMenuItem,
            this.toolStripMenuItem3,
            this.moveAndResizeToolStripMenuItem,
            this.topMostToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(184, 508);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 6);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // loadMapToolStripMenuItem
            // 
            this.loadMapToolStripMenuItem.Name = "loadMapToolStripMenuItem";
            this.loadMapToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.loadMapToolStripMenuItem.Text = "Load Map";
            this.loadMapToolStripMenuItem.Click += new System.EventHandler(this.loadMapToolStripMenuItem_Click);
            // 
            // loadHistoryToolStripMenuItem
            // 
            this.loadHistoryToolStripMenuItem.Name = "loadHistoryToolStripMenuItem";
            this.loadHistoryToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.loadHistoryToolStripMenuItem.Text = "Load History";
            this.loadHistoryToolStripMenuItem.Click += new System.EventHandler(this.loadHistoryToolStripMenuItem_Click);
            // 
            // toolStripMenuItem16
            // 
            this.toolStripMenuItem16.Name = "toolStripMenuItem16";
            this.toolStripMenuItem16.Size = new System.Drawing.Size(183, 22);
            this.toolStripMenuItem16.Text = "Save Location";
            this.toolStripMenuItem16.Click += new System.EventHandler(this.toolStripMenuItem16_Click);
            // 
            // findCityToolStripMenuItem
            // 
            this.findCityToolStripMenuItem.Name = "findCityToolStripMenuItem";
            this.findCityToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.findCityToolStripMenuItem.Text = "Find Location";
            this.findCityToolStripMenuItem.Click += new System.EventHandler(this.findCityToolStripMenuItem_Click);
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.homeToolStripMenuItem.Text = "Home";
            this.homeToolStripMenuItem.Click += new System.EventHandler(this.homeToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(180, 6);
            // 
            // toolStripMenuItem15
            // 
            this.toolStripMenuItem15.Name = "toolStripMenuItem15";
            this.toolStripMenuItem15.Size = new System.Drawing.Size(183, 22);
            this.toolStripMenuItem15.Text = "Mark Point A";
            this.toolStripMenuItem15.Click += new System.EventHandler(this.toolStripMenuItem15_Click);
            // 
            // toolStripMenuItem14
            // 
            this.toolStripMenuItem14.Name = "toolStripMenuItem14";
            this.toolStripMenuItem14.Size = new System.Drawing.Size(183, 22);
            this.toolStripMenuItem14.Text = "Mark Point B";
            this.toolStripMenuItem14.Click += new System.EventHandler(this.toolStripMenuItem14_Click);
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Size = new System.Drawing.Size(183, 22);
            this.toolStripMenuItem13.Text = "Calc Air Distance";
            this.toolStripMenuItem13.Click += new System.EventHandler(this.toolStripMenuItem13_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(180, 6);
            // 
            // lineToolStripMenuItem
            // 
            this.lineToolStripMenuItem.Name = "lineToolStripMenuItem";
            this.lineToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.lineToolStripMenuItem.Text = "Clear";
            this.lineToolStripMenuItem.Click += new System.EventHandler(this.lineToolStripMenuItem_Click);
            // 
            // lineToolStripMenuItem1
            // 
            this.lineToolStripMenuItem1.Name = "lineToolStripMenuItem1";
            this.lineToolStripMenuItem1.Size = new System.Drawing.Size(183, 22);
            this.lineToolStripMenuItem1.Text = "Line";
            this.lineToolStripMenuItem1.Click += new System.EventHandler(this.lineToolStripMenuItem1_Click);
            // 
            // calcDistanceToolStripMenuItem
            // 
            this.calcDistanceToolStripMenuItem.Name = "calcDistanceToolStripMenuItem";
            this.calcDistanceToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.calcDistanceToolStripMenuItem.Text = "Calc Distance";
            this.calcDistanceToolStripMenuItem.Click += new System.EventHandler(this.calcDistanceToolStripMenuItem_Click);
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(180, 6);
            // 
            // pinHereToolStripMenuItem
            // 
            this.pinHereToolStripMenuItem.Name = "pinHereToolStripMenuItem";
            this.pinHereToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.pinHereToolStripMenuItem.Text = "Pin here";
            this.pinHereToolStripMenuItem.Click += new System.EventHandler(this.pinHereToolStripMenuItem_Click);
            // 
            // clearAllPinsToolStripMenuItem
            // 
            this.clearAllPinsToolStripMenuItem.Name = "clearAllPinsToolStripMenuItem";
            this.clearAllPinsToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.clearAllPinsToolStripMenuItem.Text = "Clear All Pins";
            this.clearAllPinsToolStripMenuItem.Click += new System.EventHandler(this.clearAllPinsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem17
            // 
            this.toolStripMenuItem17.Name = "toolStripMenuItem17";
            this.toolStripMenuItem17.Size = new System.Drawing.Size(180, 6);
            // 
            // screenShotToolStripMenuItem
            // 
            this.screenShotToolStripMenuItem.Name = "screenShotToolStripMenuItem";
            this.screenShotToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.screenShotToolStripMenuItem.Text = "Screen shot";
            this.screenShotToolStripMenuItem.Click += new System.EventHandler(this.screenShotToolStripMenuItem_Click);
            // 
            // fetchSelectedRegioToolStripMenuItem
            // 
            this.fetchSelectedRegioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.askEveryZoomLevelToolStripMenuItem});
            this.fetchSelectedRegioToolStripMenuItem.Name = "fetchSelectedRegioToolStripMenuItem";
            this.fetchSelectedRegioToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.fetchSelectedRegioToolStripMenuItem.Text = "Fetch Selected Regio";
            this.fetchSelectedRegioToolStripMenuItem.Click += new System.EventHandler(this.fetchSelectedRegioToolStripMenuItem_Click);
            // 
            // askEveryZoomLevelToolStripMenuItem
            // 
            this.askEveryZoomLevelToolStripMenuItem.Name = "askEveryZoomLevelToolStripMenuItem";
            this.askEveryZoomLevelToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.askEveryZoomLevelToolStripMenuItem.Text = "ask every zoom level";
            this.askEveryZoomLevelToolStripMenuItem.Click += new System.EventHandler(this.askEveryZoomLevelToolStripMenuItem_Click);
            // 
            // addObjectsToolStripMenuItem
            // 
            this.addObjectsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ariPLaneToolStripMenuItem,
            this.browseForObjectToolStripMenuItem,
            this.toolStripMenuItem26,
            this.objectOnTargetToolStripMenuItem,
            this.toolStripMenuItem22,
            this.clearToolStripMenuItem});
            this.addObjectsToolStripMenuItem.Name = "addObjectsToolStripMenuItem";
            this.addObjectsToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.addObjectsToolStripMenuItem.Text = "Add Objects";
            // 
            // ariPLaneToolStripMenuItem
            // 
            this.ariPLaneToolStripMenuItem.Name = "ariPLaneToolStripMenuItem";
            this.ariPLaneToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.ariPLaneToolStripMenuItem.Text = "Air Plane";
            this.ariPLaneToolStripMenuItem.Click += new System.EventHandler(this.ariPLaneToolStripMenuItem_Click);
            // 
            // browseForObjectToolStripMenuItem
            // 
            this.browseForObjectToolStripMenuItem.Name = "browseForObjectToolStripMenuItem";
            this.browseForObjectToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.browseForObjectToolStripMenuItem.Text = "Browse for object";
            this.browseForObjectToolStripMenuItem.Click += new System.EventHandler(this.browseForObjectToolStripMenuItem_Click);
            // 
            // toolStripMenuItem26
            // 
            this.toolStripMenuItem26.Name = "toolStripMenuItem26";
            this.toolStripMenuItem26.Size = new System.Drawing.Size(163, 6);
            // 
            // objectOnTargetToolStripMenuItem
            // 
            this.objectOnTargetToolStripMenuItem.Name = "objectOnTargetToolStripMenuItem";
            this.objectOnTargetToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.objectOnTargetToolStripMenuItem.Text = "Object on Target";
            this.objectOnTargetToolStripMenuItem.Click += new System.EventHandler(this.objectOnTargetToolStripMenuItem_Click);
            // 
            // toolStripMenuItem22
            // 
            this.toolStripMenuItem22.Name = "toolStripMenuItem22";
            this.toolStripMenuItem22.Size = new System.Drawing.Size(163, 6);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // showCoordinatorsToolStripMenuItem
            // 
            this.showCoordinatorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OffToolStripMenuItem,
            this.latLonToolStripMenuItem,
            this.xxToolStripMenuItem});
            this.showCoordinatorsToolStripMenuItem.Name = "showCoordinatorsToolStripMenuItem";
            this.showCoordinatorsToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.showCoordinatorsToolStripMenuItem.Text = "Show Coordinators";
            // 
            // OffToolStripMenuItem
            // 
            this.OffToolStripMenuItem.Name = "OffToolStripMenuItem";
            this.OffToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.OffToolStripMenuItem.Text = "Off";
            this.OffToolStripMenuItem.Click += new System.EventHandler(this.OffToolStripMenuItem_Click);
            // 
            // latLonToolStripMenuItem
            // 
            this.latLonToolStripMenuItem.Name = "latLonToolStripMenuItem";
            this.latLonToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.latLonToolStripMenuItem.Text = "Lat Lon";
            this.latLonToolStripMenuItem.Click += new System.EventHandler(this.latLonToolStripMenuItem_Click);
            // 
            // xxToolStripMenuItem
            // 
            this.xxToolStripMenuItem.Name = "xxToolStripMenuItem";
            this.xxToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.xxToolStripMenuItem.Text = "ECEF (X,Y,Z)";
            this.xxToolStripMenuItem.Click += new System.EventHandler(this.xxToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(180, 6);
            // 
            // showZoomToolStripMenuItem
            // 
            this.showZoomToolStripMenuItem.Name = "showZoomToolStripMenuItem";
            this.showZoomToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.showZoomToolStripMenuItem.Text = "Show Zoom ";
            this.showZoomToolStripMenuItem.Click += new System.EventHandler(this.showZoomToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(180, 6);
            // 
            // moveAndResizeToolStripMenuItem
            // 
            this.moveAndResizeToolStripMenuItem.Name = "moveAndResizeToolStripMenuItem";
            this.moveAndResizeToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.moveAndResizeToolStripMenuItem.Text = "Move And Resize";
            this.moveAndResizeToolStripMenuItem.Click += new System.EventHandler(this.moveAndResizeToolStripMenuItem_Click);
            // 
            // topMostToolStripMenuItem
            // 
            this.topMostToolStripMenuItem.Name = "topMostToolStripMenuItem";
            this.topMostToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.topMostToolStripMenuItem.Text = "Top Most";
            this.topMostToolStripMenuItem.Click += new System.EventHandler(this.topMostToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(724, 538);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Lon";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(605, 538);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Lat:";
            // 
            // btnStartFetch
            // 
            this.btnStartFetch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStartFetch.Location = new System.Drawing.Point(151, 526);
            this.btnStartFetch.Margin = new System.Windows.Forms.Padding(2);
            this.btnStartFetch.Name = "btnStartFetch";
            this.btnStartFetch.Size = new System.Drawing.Size(75, 21);
            this.btnStartFetch.TabIndex = 33;
            this.btnStartFetch.Text = "Fetch Map..";
            this.btnStartFetch.UseVisualStyleBackColor = true;
            this.btnStartFetch.Visible = false;
            this.btnStartFetch.Click += new System.EventHandler(this.btnStartFetch_Click);
            // 
            // lblMapPopupMsg
            // 
            this.lblMapPopupMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMapPopupMsg.AutoSize = true;
            this.lblMapPopupMsg.Location = new System.Drawing.Point(329, 229);
            this.lblMapPopupMsg.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMapPopupMsg.Name = "lblMapPopupMsg";
            this.lblMapPopupMsg.Size = new System.Drawing.Size(35, 13);
            this.lblMapPopupMsg.TabIndex = 32;
            this.lblMapPopupMsg.Text = "label2";
            this.lblMapPopupMsg.Visible = false;
            // 
            // lblLon
            // 
            this.lblLon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLon.AutoSize = true;
            this.lblLon.BackColor = System.Drawing.Color.Transparent;
            this.lblLon.Location = new System.Drawing.Point(752, 538);
            this.lblLon.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLon.Name = "lblLon";
            this.lblLon.Size = new System.Drawing.Size(35, 13);
            this.lblLon.TabIndex = 1;
            this.lblLon.Text = "lblLon";
            // 
            // lblLat
            // 
            this.lblLat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLat.AutoSize = true;
            this.lblLat.BackColor = System.Drawing.Color.Transparent;
            this.lblLat.Location = new System.Drawing.Point(632, 538);
            this.lblLat.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLat.Name = "lblLat";
            this.lblLat.Size = new System.Drawing.Size(32, 13);
            this.lblLat.TabIndex = 0;
            this.lblLat.Text = "lblLat";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 531);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Zoom";
            this.label1.Visible = false;
            // 
            // comboBoxZoom
            // 
            this.comboBoxZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxZoom.FormattingEnabled = true;
            this.comboBoxZoom.Location = new System.Drawing.Point(43, 529);
            this.comboBoxZoom.Name = "comboBoxZoom";
            this.comboBoxZoom.Size = new System.Drawing.Size(91, 21);
            this.comboBoxZoom.TabIndex = 30;
            this.comboBoxZoom.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 557);
            this.Controls.Add(this.mapPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.mapPanel.ResumeLayout(false);
            this.mapPanel.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mapPanel;
        private System.Windows.Forms.Label lblLon;
        private System.Windows.Forms.Label lblLat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxZoom;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem16;
        private System.Windows.Forms.ToolStripMenuItem findCityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem15;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem14;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem13;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem lineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem calcDistanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem12;
        private System.Windows.Forms.ToolStripMenuItem pinHereToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearAllPinsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem17;
        private System.Windows.Forms.ToolStripMenuItem screenShotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fetchSelectedRegioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem askEveryZoomLevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addObjectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ariPLaneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem browseForObjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem26;
        private System.Windows.Forms.ToolStripMenuItem objectOnTargetToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem22;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showCoordinatorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem latLonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xxToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem showZoomToolStripMenuItem;
        private System.Windows.Forms.Label lblMapPopupMsg;
        private System.Windows.Forms.Button btnStartFetch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem moveAndResizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem topMostToolStripMenuItem;
    }
}

