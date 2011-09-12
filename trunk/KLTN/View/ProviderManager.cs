using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using KLTN.Model;
using KLTN.Controller;

namespace KLTN.View
{
    public partial class ProviderManager : Form
    {
        private bool _isGridViewChanged; // cờ để kiểm tra grid view đã thay đổi chưa

        public ProviderManager()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {

            if (_isGridViewChanged)
            {
                // nếu grid view có sửa đổi hiện confirm box trước khi thoát
                if (MessageBox.Show(this, "Bạn có muốn thoát?\nNhững thay đổi của bạn sẽ KHÔNG có hiệu lực", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    providerGridView.CancelEdit();
                    this.Close();
                }
            }
            else // nếu không có sửa đổi close luôn
            {
                this.Close();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

            ContentProviderController controller = new ContentProviderController();
            List<ContentProvider> providers = controller.Providers;
            var rows = providerGridView.Rows; // lấy tất cả các row của grid view
            for (int i = 0; i < rows.Count; i++)
            {
                // kiểm tra uri không được rỗng
                if (rows[i].Cells[1].Value != null)
                {
                    ContentProvider provider = new ContentProvider();
                    provider.Name = rows[i].Cells[0].Value.ToString();
                    provider.Uri = new Uri(rows[i].Cells[1].Value.ToString());
                    provider.CatagorySelector = rows[i].Cells[2].Value.ToString();
                    provider.UrlSelector = rows[i].Cells[3].Value.ToString();
                    provider.TitleSelector = rows[i].Cells[4].Value.ToString();
                    provider.SummanySelector = rows[i].Cells[5].Value.ToString();
                    provider.ContentSelector = rows[i].Cells[6].Value.ToString();
                    provider.TimeSelector = rows[i].Cells[7].Value.ToString();
                    provider.AuthorSelector = rows[i].Cells[8].Value.ToString();
                    
                    // thêm provider vào list providers
                    providers.Add(provider);
                }               
            }
            // truyền providers cho controller
            controller.Providers = providers;
            // lưu provider xuống file xml
            controller.SaveProviders();
            // hiện thông báo thành công
            MessageBox.Show(this, "Đã lưu dữ liệu thành công", "Lưu dữ liệu thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _isGridViewChanged = false; // gán lại cờ grid view thay đổi = false
        }

        private void ProviderManager_Load(object sender, EventArgs e)
        {
            // khởi tạo controller
            ContentProviderController controller = new ContentProviderController();
            // load provider từ file xml
            controller.LoadProviders();
            List<ContentProvider> providers = controller.Providers;

            for (int i = 0; i < providers.Count; i++)
            {
                string[] row = new string[] { providers[i].Name, 
                    providers[i].Uri.ToString() , 
                    providers[i].CatagorySelector,
                    providers[i].UrlSelector,
                    providers[i].TitleSelector,
                    providers[i].SummanySelector,
                    providers[i].ContentSelector,
                    providers[i].TimeSelector,
                    providers[i].AuthorSelector
                };
                // thêm một row vào grid view
                providerGridView.Rows.Add(row);
            }
            // khởi tạo cờ thay đổi = false
            _isGridViewChanged = false;
        }

        private void providerGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // khi grid view có thay đổi đặt cờ = true
            _isGridViewChanged = true;
        }
    }
}
