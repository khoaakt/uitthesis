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
using System.Runtime.InteropServices;
using System.Xml;

namespace KLTN.View
{
    public partial class MainForm : Form
    {
        #region khai bao biến ban đầu

        string appPath = "";        
        
        #endregion
        #region Hàm quan trọng trong User32.dll
        //
        // su dung su kien cua ban phim
        //
        [DllImport("user32.Dll")]
        public static extern int keybd_event(byte ch, byte scan, int flag, int info);
        //
        // su dung su kien cua chuot
        //
        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        //
        //
        //
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        //
        //
        //
        [DllImport("user32.Dll")]
        public static extern IntPtr GetMenu(IntPtr hwnd);
        //
        //
        //
        [DllImport("user32.dll")]
        static extern IntPtr GetSubMenu(IntPtr hMnu, int nPos);
        //
        //
        //
        [DllImport("user32.dll")]
        static extern int GetMenuItemCount(IntPtr hMnu);
        //
        //
        //
        [DllImport("user32.dll")]
        static extern int GetMenuString(IntPtr hMnu, int uIDItem, StringBuilder text, int nMaxCount, int uFlag);
        //
        //
        //
        [DllImport("user32.dll")]
        static extern int GetCursorPos(out Point pnt);
        //
        //
        //
        [DllImport("user32.dll")]
        static extern int GetMenuState(IntPtr hMnu, int uIDItem, int uFlags);

        #endregion
        #region Mã Font có thể dùng cho Vspeech

        const int FONT_ENGLISH = 0;
        const int FONT_VIQR = 1;
        const int FONT_ABC = 2;
        const int FONT_VNI = 3;
        const int FONT_UTF8 = 4;
        const int FONT_WIN1252 = 5;
        const int FONT_VIQRNOSIGN = 6;
        const int FONT_VNINOSIGN = 7;
        const int FONT_TELEXNOSIGN = 8;
        const int FONT_COMPOUNDUNICODE = 9;

        #endregion
        #region Hàm quan trọng trong VSpeech.dll
        //
        // khoi tao thu vien dieu khien Vspeech SDK
        //
        [DllImport("VSpeech")]
        private static extern void CreateVSpeechLibrary();
        //
        // giai phong thu vien dieu khien Vspeech SDK ra khoi bo nho
        //
        [DllImport("VSpeech")]
        private static extern void FreeVSpeechLibrary();
        //
        // xoa het cac bo tu dien da co de nhap lai tu dien tu dau
        //
        [DllImport("VSpeech")]
        private static extern void ResetVSpeechLibrary();
        //
        // bat dau tao mot tu dien moi
        //
        [DllImport("VSpeech")]
        private static extern void BeginDictionary(string name, int font);
        //
        //ket thu qua trinh nhap lieu tu dien
        //
        [DllImport("VSpeech")]
        private static extern void EndDictionary();
        //
        // huu hieu hoa mot bo tu dien
        //
        [DllImport("VSpeech")]
        private static extern void EnableDictionary(string name);
        //
        // vo hieu hoa mot bo tu dien
        //
        [DllImport("VSpeech")]
        private static extern void DisableDictionary(string name);
        //
        // them tu vung vao bo tu dien
        //
        [DllImport("VSpeech")]
        private static extern void AddWord(string word);
        //
        // ham tra ve chuoi tu vung ma thu vien nhan dang duoc
        //
        [DllImport("VSpeech")]
        private static extern string GetCommand();

        #endregion
       
        public void MainForm_Load()
        {
            TuDien("XMLCoBan.xml"); 
        }
        public void MainForm_FormClosed()
        {
            FreeVSpeechLibrary();
        }
        public MainForm()
        {
            InitializeComponent();
            ContentTreeController controller = new ContentTreeController();
            TreeNode[] nodes = controller.Load();
            treeView.Nodes.Clear();
            treeView.Nodes.AddRange(nodes);
        }

        #region phuong thuc timer1 tick
        private void timer1_Tick(object sender, EventArgs e)
        {
            string s = GetCommand();

            if (s != "")
            {
                switch (s)
                {
                        // những lệnh sử lý tin
                    case "do.c tin": 
                        {
                            break;
                        }
                    case "ta'o": 
                        {
                            SpeechLb.Text = "ta'o";
                            MessageBox.Show("Load oke");
                            break;
                        }
                    case "ca^.p nha^.t danh mu.c":
                        {
                            SpeechLb.Text = "cập nhập danh mục";
                            updateCatagoryToolStripMenuItem.PerformClick();                            
                            break;
                        }
                  
                    case "ca^.p nha^.p tin tu+'c":
                        {
                            SpeechLb.Text = "cập nhập tin tức";
                            updateContentToolStripMenuItem.PerformClick();
                            break;
                        }
                    case "danh mu.c":
                        {
                            SpeechLb.Text = "Danh mục";
                            treeView.Select();
                            break;
                        }
                    case "danh sa'ch tin":
                        { 
                            SpeechLb.Text = "danh sách tin";
                            //di chuyển đến khung danh sách tin
                            if (listView.Items.Count > 0)
                            {
                                listView.Items[0].Selected = true;
                                listView.Select();
                            }
                            else
                            {
                                MessageBox.Show("Danh sách tin không chứa tin, vui lòng cập nhật tin.");
                            } 
                            break;
                        }
                    case "xem":
                        {
                            SpeechLb.Text = "xem chi tiết tin";
                            if (listView.SelectedItems.Count > 0)
                            {
                                this.listView_ItemActivate(null, e);                                
                            }
                            else
                            {
                                MessageBox.Show("Vui lòng chọn một tin trong danh sách tin để xem chi tiết");
                            }
                            break; 
                        }

                    case "chi tie^'t":
                        {
                            SpeechLb.Text = "chi tiết tin - tới khung chi tiết"; 
                            if (webBrowser.Url != null)
                            {
                                webBrowser.Select();
                            }
                            else
                            {
                                MessageBox.Show("Bạn phải chọn 1 bản tin nào đó.");
                            }
                            break;
                        } 
                    case "nguo^`n tin":
                        {
                            SpeechLb.Text = "nguồn tin"; 
                            providerManagerToolStripMenuItem.PerformClick();
                            break;
                        } 
                    case "giu'p":
                        {
                            //đến khung hướng dẫn
                            SpeechLb.Text = "giúp";
                            guideToolStripMenuItem.PerformClick();
                            break;
                        }
                    case "lu+u tin":
                        {
                            break;
                        }

                    // Những lệch cơ bản
                    case "le^n":
                        {
                            SpeechLb.Text = "lên";
                            keybd_event((byte)Keys.Up, 0, 0, 0);
                            keybd_event((byte)Keys.Up, 0, 2, 0);
                            break;
                        }
                    case "xuo^'ng":
                        {
                            SpeechLb.Text = "xuống";
                            keybd_event((byte)Keys.Down, 0, 0, 0);
                            keybd_event((byte)Keys.Down, 0, 2, 0);
                            break;
                        }
                    case "pha?i":
                        {
                            SpeechLb.Text = "phải";
                            keybd_event((byte)Keys.Right, 0, 0, 0);
                            keybd_event((byte)Keys.Right, 0, 2, 0);
                            break;
                        }
                    case "tra'i":
                        {
                            SpeechLb.Text = "trái";
                            keybd_event((byte)Keys.Left, 0, 0, 0);
                            keybd_event((byte)Keys.Left, 0, 2, 0);
                            break;
                        }
                    case "page up": 
                        {
                            SpeechLb.Text = "page up";
                            keybd_event((byte)Keys.PageUp, 0, 0, 0);
                            keybd_event((byte)Keys.PageUp, 0, 2, 0);
                            break;
                        }
                    case "page down": 
                        {
                            SpeechLb.Text = "page down ";
                            keybd_event((byte)Keys.PageDown, 0, 0, 0);
                            keybd_event((byte)Keys.PageDown, 0, 2, 0);
                            break;
                        }
                    case "dda^`u tie^n":
                        {
                            SpeechLb.Text = "đầu tiên";
                            keybd_event((byte)Keys.Home, 0, 0, 0);
                            keybd_event((byte)Keys.Home, 0, 2, 0);
                            break;
                        }
                    case "sau cu`ng":
                        {
                            SpeechLb.Text = "sau cùng";
                            keybd_event((byte)Keys.End, 0, 0, 0);
                            keybd_event((byte)Keys.End, 0, 2, 0);
                            break;
                        }
                    case "ta'p":
                        {
                            SpeechLb.Text = "táp";
                            keybd_event((byte)Keys.Tab, 0, 0, 0);
                            keybd_event((byte)Keys.Tab, 0, 2, 0);
                            break;
                        }
                    case "caps lock":
                        {
                            SpeechLb.Text = "caps lock";
                            keybd_event((byte)Keys.CapsLock, 0, 0, 0);
                            keybd_event((byte)Keys.CapsLock, 0, 2, 0);
                            break;
                        }
                    case "enter":
                        {
                            SpeechLb.Text = "enter";
                            keybd_event((byte)Keys.Enter, 0, 0, 0);
                            keybd_event((byte)Keys.Enter, 0, 2, 0);
                            break;
                        }
                    case "ddo`ng y'":
                        {
                            SpeechLb.Text = "đồng ý";
                            keybd_event((byte)Keys.Y, 0, 0, 0);
                            keybd_event((byte)Keys.Y, 0, 2, 0);
                            break;
                        }
                    case "kho^ng ddo`ng y'":
                        {
                            SpeechLb.Text = "không đồng ý";
                            keybd_event((byte)Keys.N, 0, 0, 0);
                            keybd_event((byte)Keys.N, 0, 2, 0);
                            break;
                        }
                    case "cancel":
                        {
                            SpeechLb.Text = "xóa";
                            keybd_event((byte)Keys.Escape, 0, 0, 0);
                            keybd_event((byte)Keys.Escape, 0, 2, 0);
                            break;
                        }
                    case "xo'a":
                        {
                            SpeechLb.Text = "";
                            keybd_event((byte)Keys.Delete, 0, 0, 0);
                            keybd_event((byte)Keys.Delete, 0, 2, 0);
                            break;
                        }
                    case "ta^'t ca?":
                        {
                            SpeechLb.Text = "tất cả";
                            keybd_event((byte)Keys.LControlKey, 0, 0, 0);
                            keybd_event((byte)Keys.A, 0, 0, 0);
                            keybd_event((byte)Keys.A, 0, 2, 0);
                            keybd_event((byte)Keys.LControlKey, 0, 2, 0);
                            break;
                        }
                    case "copy":
                        {
                            SpeechLb.Text = "copy";
                            keybd_event((byte)Keys.LControlKey, 0, 0, 0);
                            keybd_event((byte)Keys.C, 0, 0, 0);
                            keybd_event((byte)Keys.C, 0, 2, 0);
                            keybd_event((byte)Keys.LControlKey, 0, 2, 0);
                            break;
                        }
                    case "paste":
                        {
                            SpeechLb.Text = "paste";
                            keybd_event((byte)Keys.LControlKey, 0, 0, 0);
                            keybd_event((byte)Keys.V, 0, 0, 0);
                            keybd_event((byte)Keys.V, 0, 2, 0);
                            keybd_event((byte)Keys.LControlKey, 0, 2, 0);
                            break;
                        }
                    case "lu`i la.i":
                        {
                            SpeechLb.Text = "lùi lại";
                            keybd_event((byte)Keys.Back, 0, 0, 0);
                            keybd_event((byte)Keys.Back, 0, 2, 0);
                            break;
                        }

                }
            }
        }
        #endregion
        
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
            pm.Select();
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
             //   this.treeView_Click(null, e);

                var list = controller.LoadAllArticles();
                // clear list view
                listView.Items.Clear();

                // refresh list view
                for (int i = 0; i < list.Count; i++)
                {
                    listView.Items.Add(list[i].Title);
                    listView.Items[listView.Items.Count - 1].SubItems.Add(list[i].Author);
                    listView.Items[listView.Items.Count - 1].SubItems.Add(list[i].Time.ToString());
                    listView.Items[listView.Items.Count - 1].ToolTipText = list[i].Summany;
                    listView.Items[listView.Items.Count - 1].Tag = list[i];
                }
                statusLabel.Text = "Hoàn tất thu thập tin tức";
                
            }
            else
            {
                MessageBox.Show("Bạn phải chọn một mục tin tức");
                
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

        private void listView_ItemActivate(object sender, EventArgs e)
        {
            Article article = (Article) listView.SelectedItems[0].Tag;
            webBrowser.DocumentText = article.Content; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (SpeechLb.Visible == true)
            {
                this.button1.BackColor = System.Drawing.SystemColors.Control;
                SpeechLb.Hide();
                // giải phóng từ điển đã tạo
                FreeVSpeechLibrary();
                // ngừng hoạt động timer 1
                timer1.Enabled = false;
            }
            else
            {
                // thay đổi khi active
                this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
                SpeechLb.Visible = true;

                //tạo lại từ điển khởi đầu
                /*
                CreateVSpeechLibrary();
                ResetVSpeechLibrary();
                BeginDictionary("khoidau", FONT_VIQR);
                AddWord("hoa.t ddo^.ng");
                AddWord("ta'o");
                AddWord("le^n");
                AddWord("xuo^'ng");           
                EndDictionary();
                EnableDictionary("khoidau");
                */
                //kich hoat tu dien hoat dong
                 TuDien("XMLCoBan.xml");
                // kích hoạt timer1 hoạt động lại
                timer1.Enabled = true;
                

            }
        }     

        #region Phuong thuc ho tro Vspeech
        // phương thức nạp từ điển 
        private void TuDien(string tenTuDien)
        {
            CreateVSpeechLibrary();
            //tạo từ điển ứng dụng
            ResetVSpeechLibrary();
            BeginDictionary(tenTuDien,FONT_VIQR);
            // mở file
            XmlTextReader XmlReader = new System.Xml.XmlTextReader(appPath + tenTuDien);
            string tenlenh = "";
            bool startRead = false;

            //nạp chuỗi cho từ điển ungdung
            while (XmlReader.Read())
            {
                tenlenh = XmlReader["NAME"];

                //nếu đã đọc xong các thành phần đã hoàn tất thì ngừng đọc 
                if (startRead == true && XmlReader.Name == "RULE")
                    startRead = false;

                // nếu tìm thấy thì bắt đầu đọc
                if (tenlenh == "Lenh")
                    startRead = true;

                //đọc các thành phần trong p
                if (startRead == true && XmlReader.Name == "P")
                {
                    
                    tenlenh = XmlReader.ReadString();
                   
                    AddWord(tenlenh);
                }
            }
            //đóng file
            XmlReader.Close();
            
            EndDictionary();
            EnableDictionary(tenTuDien);
        }

        #endregion

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // lấy danh mục đang được chọn
            TreeNode selected = treeView.SelectedNode;
            // nếu danh mục đang chọn không phải là provider
            if (selected.Parent != null)
            {
                CatagoryController controller = new CatagoryController();
                controller.GetCatagory(selected.Parent.Text, selected.Text);
                var list = controller.LoadAllArticles();
                // clear list view
                listView.Items.Clear();

                // refresh list view
                for (int i = 0; i < list.Count; i++)
                {
                    listView.Items.Add(list[i].Title);
                    listView.Items[listView.Items.Count - 1].SubItems.Add(list[i].Author);
                    listView.Items[listView.Items.Count - 1].SubItems.Add(list[i].Time.ToString());
                    listView.Items[listView.Items.Count - 1].ToolTipText = list[i].Summany;
                    listView.Items[listView.Items.Count - 1].Tag = list[i];
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.FileName = "espeak.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;

            // lưu dữ liệu cần đọc ra tập tin txt tạm
            System.IO.File.WriteAllText(@"temp.txt", webBrowser.DocumentText);


            startInfo.Arguments = "-v vi -m -f temp.txt";

            try
            {
                // Start the process with the info we specified.
                // Call WaitForExit and then the using statement will close.
                using (Process exeProcess = Process.Start(startInfo))
                {
                    //exeProcess.WaitForExit();
                }
            }
            catch
            {
                // Log error.
            }
        }
    }
}
