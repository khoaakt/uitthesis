namespace KLTN.View
{
    partial class ProviderManager
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
            this.providerGridView = new System.Windows.Forms.DataGridView();
            this.saveButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.Provider = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.URI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CatagorySelector = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UrlSelector = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TitleSelector = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SummanySelector = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContentSelector = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeSelector = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AuthorSelector = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.providerGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // providerGridView
            // 
            this.providerGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.providerGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.providerGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.providerGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Provider,
            this.URI,
            this.CatagorySelector,
            this.UrlSelector,
            this.TitleSelector,
            this.SummanySelector,
            this.ContentSelector,
            this.TimeSelector,
            this.AuthorSelector});
            this.providerGridView.Location = new System.Drawing.Point(12, 12);
            this.providerGridView.Name = "providerGridView";
            this.providerGridView.Size = new System.Drawing.Size(978, 175);
            this.providerGridView.TabIndex = 0;
            this.providerGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.providerGridView_CellValueChanged);
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(386, 197);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(98, 42);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Lưu dữ liệu";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(490, 197);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(98, 42);
            this.exitButton.TabIndex = 2;
            this.exitButton.Text = "Thoát";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // Provider
            // 
            this.Provider.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Provider.HeaderText = "Tên";
            this.Provider.Name = "Provider";
            this.Provider.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Provider.ToolTipText = "Tên nguồn tin";
            // 
            // URI
            // 
            this.URI.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.URI.HeaderText = "URI";
            this.URI.Name = "URI";
            this.URI.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.URI.ToolTipText = "Địa chỉ trang internet của nguồn tin";
            this.URI.Width = 32;
            // 
            // CatagorySelector
            // 
            this.CatagorySelector.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CatagorySelector.HeaderText = "DH Danh mục";
            this.CatagorySelector.Name = "CatagorySelector";
            this.CatagorySelector.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CatagorySelector.ToolTipText = "Dấu hiệu để xác định danh mục";
            // 
            // UrlSelector
            // 
            this.UrlSelector.HeaderText = "DH Đường dẫn";
            this.UrlSelector.Name = "UrlSelector";
            this.UrlSelector.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UrlSelector.ToolTipText = "Dấu hiệu nhận biết đường dẫn bài báo";
            this.UrlSelector.Width = 77;
            // 
            // TitleSelector
            // 
            this.TitleSelector.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TitleSelector.HeaderText = "DH Tiêu đề";
            this.TitleSelector.Name = "TitleSelector";
            this.TitleSelector.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TitleSelector.ToolTipText = "Dấu hiệu nhận biết tiêu đề bài báo";
            // 
            // SummanySelector
            // 
            this.SummanySelector.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SummanySelector.HeaderText = "DH Tóm tắt";
            this.SummanySelector.Name = "SummanySelector";
            this.SummanySelector.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SummanySelector.ToolTipText = "Dấu hiệu nhận biết tóm tắt của bài báo";
            // 
            // ContentSelector
            // 
            this.ContentSelector.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ContentSelector.HeaderText = "DH Nội dung";
            this.ContentSelector.Name = "ContentSelector";
            this.ContentSelector.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ContentSelector.ToolTipText = "Dấu hiệu nhận biết nội dung đầy đủ của bài báo";
            // 
            // TimeSelector
            // 
            this.TimeSelector.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TimeSelector.HeaderText = "DH Thời gian";
            this.TimeSelector.Name = "TimeSelector";
            this.TimeSelector.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TimeSelector.ToolTipText = "Dấu hiệu nhận biết thời gian của bài báo";
            // 
            // AuthorSelector
            // 
            this.AuthorSelector.HeaderText = "DH Tác giả";
            this.AuthorSelector.Name = "AuthorSelector";
            this.AuthorSelector.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.AuthorSelector.ToolTipText = "Dấu hiệu nhận biết tác giả bài báo";
            this.AuthorSelector.Width = 49;
            // 
            // ProviderManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 251);
            this.ControlBox = false;
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.providerGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ProviderManager";
            this.Text = "Quản lý nguồn tin";
            this.Load += new System.EventHandler(this.ProviderManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.providerGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView providerGridView;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Provider;
        private System.Windows.Forms.DataGridViewTextBoxColumn URI;
        private System.Windows.Forms.DataGridViewTextBoxColumn CatagorySelector;
        private System.Windows.Forms.DataGridViewTextBoxColumn UrlSelector;
        private System.Windows.Forms.DataGridViewTextBoxColumn TitleSelector;
        private System.Windows.Forms.DataGridViewTextBoxColumn SummanySelector;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContentSelector;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeSelector;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuthorSelector;
    }
}