namespace KLTN.View
{
    partial class MainForm
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
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Văn hóa");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Thể thao");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("VnExpress", new System.Windows.Forms.TreeNode[] {
            treeNode19,
            treeNode20});
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Quốc tế");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Âm nhạc");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Giải trí");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Dân Trí", new System.Windows.Forms.TreeNode[] {
            treeNode22,
            treeNode23,
            treeNode24});
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Vietnamnet");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("Tuổi trẻ");
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.treeView = new System.Windows.Forms.TreeView();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateCatagoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateContentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.providerManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.helpProvider = new System.Windows.Forms.HelpProvider();
            this.catagoryUpdateBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 24);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.treeView);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.splitContainer.Panel2.Controls.Add(this.listView);
            this.splitContainer.Size = new System.Drawing.Size(634, 482);
            this.splitContainer.SplitterDistance = 189;
            this.splitContainer.TabIndex = 0;
            // 
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.FullRowSelect = true;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            treeNode19.Name = "Node4";
            treeNode19.Text = "Văn hóa";
            treeNode20.Name = "Node5";
            treeNode20.Text = "Thể thao";
            treeNode21.Name = "Node0";
            treeNode21.Text = "VnExpress";
            treeNode22.Name = "Node6";
            treeNode22.Text = "Quốc tế";
            treeNode23.Name = "Node7";
            treeNode23.Text = "Âm nhạc";
            treeNode24.Name = "Node8";
            treeNode24.Text = "Giải trí";
            treeNode25.Name = "Node1";
            treeNode25.Text = "Dân Trí";
            treeNode26.Name = "Node2";
            treeNode26.Text = "Vietnamnet";
            treeNode27.Name = "Node3";
            treeNode27.Text = "Tuổi trẻ";
            this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode21,
            treeNode25,
            treeNode26,
            treeNode27});
            this.treeView.Size = new System.Drawing.Size(189, 482);
            this.treeView.TabIndex = 0;
            this.treeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_NodeMouseClick);
            this.treeView.Click += new System.EventHandler(this.treeView_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(634, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateCatagoryToolStripMenuItem,
            this.updateContentToolStripMenuItem,
            this.toolStripSeparator1,
            this.hideToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.fileToolStripMenuItem.Text = "&Tác vụ";
            // 
            // updateCatagoryToolStripMenuItem
            // 
            this.updateCatagoryToolStripMenuItem.AutoToolTip = true;
            this.updateCatagoryToolStripMenuItem.Name = "updateCatagoryToolStripMenuItem";
            this.updateCatagoryToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.updateCatagoryToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.updateCatagoryToolStripMenuItem.Text = "Cập nhật &danh mục";
            this.updateCatagoryToolStripMenuItem.ToolTipText = "Cập nhật danh sách các danh mục";
            this.updateCatagoryToolStripMenuItem.Click += new System.EventHandler(this.updateCatagoryToolStripMenuItem_Click);
            // 
            // updateContentToolStripMenuItem
            // 
            this.updateContentToolStripMenuItem.Name = "updateContentToolStripMenuItem";
            this.updateContentToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.updateContentToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.updateContentToolStripMenuItem.Text = "&Cập nhật tin tức";
            this.updateContentToolStripMenuItem.Click += new System.EventHandler(this.updateContentToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(217, 6);
            // 
            // hideToolStripMenuItem
            // 
            this.hideToolStripMenuItem.AutoToolTip = true;
            this.hideToolStripMenuItem.Name = "hideToolStripMenuItem";
            this.hideToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.hideToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.hideToolStripMenuItem.Text = "Ẩ&n cửa sổ";
            this.hideToolStripMenuItem.ToolTipText = "Ẩn chương trình xuống khay hệ thống";
            this.hideToolStripMenuItem.Click += new System.EventHandler(this.hideToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.AutoToolTip = true;
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.quitToolStripMenuItem.Text = "&Thoát";
            this.quitToolStripMenuItem.ToolTipText = "Thoát khỏi chương trình";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.providerManagerToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.editToolStripMenuItem.Text = "&Chỉnh sửa";
            // 
            // providerManagerToolStripMenuItem
            // 
            this.providerManagerToolStripMenuItem.AutoToolTip = true;
            this.providerManagerToolStripMenuItem.Name = "providerManagerToolStripMenuItem";
            this.providerManagerToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.providerManagerToolStripMenuItem.Text = "&Quản lý nguồn tin";
            this.providerManagerToolStripMenuItem.ToolTipText = "Quản lý các nguồn tin cập nhật";
            this.providerManagerToolStripMenuItem.Click += new System.EventHandler(this.providerManagerToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.guideToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.helpToolStripMenuItem.Text = "&Giúp đỡ";
            // 
            // guideToolStripMenuItem
            // 
            this.guideToolStripMenuItem.AutoToolTip = true;
            this.guideToolStripMenuItem.Name = "guideToolStripMenuItem";
            this.guideToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.guideToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.guideToolStripMenuItem.Text = "&Hướng dẫn";
            this.guideToolStripMenuItem.ToolTipText = "Hướng dẫn sử dụng chương trình";
            this.guideToolStripMenuItem.Click += new System.EventHandler(this.guideToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.AutoToolTip = true;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.aboutToolStripMenuItem.Text = "&Thông tin";
            this.aboutToolStripMenuItem.ToolTipText = "Thông tin về chương trình";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 484);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(634, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Text = "notifyIcon";
            this.notifyIcon.Visible = true;
            // 
            // helpProvider
            // 
            this.helpProvider.HelpNamespace = "E:\\eBook\\2003_OReilly-JavaDatabaseBestPractices.chm";
            // 
            // catagoryUpdateBackgroundWorker
            // 
            this.catagoryUpdateBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.catagoryUpdateBackgroundWorker_DoWork);
            this.catagoryUpdateBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.catagoryUpdateBackgroundWorker_RunWorkerCompleted);
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.ShowItemToolTips = true;
            this.listView.Size = new System.Drawing.Size(441, 482);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên bài báo";
            this.columnHeader1.Width = 259;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tác giả";
            this.columnHeader2.Width = 90;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Thời gian đăng";
            this.columnHeader3.Width = 186;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 506);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Tin tức tự động";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateCatagoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.HelpProvider helpProvider;
        private System.Windows.Forms.ToolStripMenuItem providerManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateContentToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker catagoryUpdateBackgroundWorker;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}