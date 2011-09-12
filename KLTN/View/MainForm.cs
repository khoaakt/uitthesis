using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using KLTN.Controller;
using KLTN.Model;
using HtmlAgilityPack;
using Fizzler.Systems.HtmlAgilityPack;

namespace KLTN.View
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            ContentTreeController controller = new ContentTreeController();
            TreeNode[] nodes = controller.Load();
            treeView.Nodes.Clear();
            treeView.Nodes.AddRange(nodes);
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // hỏi trước khi thoát
            if (MessageBox.Show(this, "Bạn có muốn thoát khỏi chương trình?", "Thoát khỏi chương trình", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
            
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // tạo và hiện about box
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }

        private void guideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // mở file help .chm
            Process proc = new Process();
            proc.StartInfo.FileName = "E:\\eBook\\2003_OReilly-JavaDatabaseBestPractices.chm";
            proc.Start();
        }

        private void providerManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // mở form quản lý provider
            ProviderManager pm = new ProviderManager();
            pm.ShowDialog();
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: implement
        }

        private void updateCatagoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusLabel.Text = "Đang cập nhật danh mục";
            catagoryUpdateBackgroundWorker.RunWorkerAsync();
            
        }    

        private void catagoryUpdateBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                ContentTreeController controller = new ContentTreeController();
                controller.Build();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Có lỗi!\nHãy kiểm tra đường truyền internet của bạn.\nThông báo cho nhà phát triển nếu không phải lỗi đường truyền", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void catagoryUpdateBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ContentTreeController controller = new ContentTreeController();
            TreeNode[] nodes = controller.Load();
            treeView.Nodes.Clear();
            treeView.Nodes.AddRange(nodes);
            statusLabel.Text = "Đã hoàn tất cập nhật danh mục";
            MessageBox.Show("Đã cập nhật xong danh mục", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void updateContentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // lấy danh mục đang được chọn
            TreeNode selected = treeView.SelectedNode;
            // nếu danh mục đang chọn không phải là provider
            if (selected.Parent != null)
            {
                CatagoryController controller = new CatagoryController();
                controller.GetCatagory(selected.Parent.Text, selected.Text);
                controller.GetAllArticles();
                var list = controller.Articles;
                
                // clear list view
                listView.Items.Clear();

                for (int i = 0; i < list.Count; i++)
                {
                    listView.Items.Add(list[i].Title);
                    listView.Items[listView.Items.Count - 1].SubItems.Add(list[i].Author);
                    listView.Items[listView.Items.Count - 1].SubItems.Add(list[i].Time.ToString());
                    listView.Items[listView.Items.Count - 1].ToolTipText = list[i].Summany;
                }
            }
        }

        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent == null)
            {
                statusLabel.Text = "Bạn đang chọn mục " + e.Node.Text;
            }
            else
            {
                statusLabel.Text = "Bạn đang chọn mục " + e.Node.Parent.Text + " > " + e.Node.Text;
            }
        }

        private void treeView_Click(object sender, EventArgs e)
        {
            // lấy danh mục đang được chọn
            TreeNode selected = treeView.SelectedNode;
            // nếu danh mục đang chọn không phải là provider
            if (selected.Parent != null)
            { 
                // TODO
            }
        }
    }
}
