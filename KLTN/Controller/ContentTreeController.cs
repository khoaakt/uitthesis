using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using KLTN.Model;
using System.Windows.Forms;

namespace KLTN.Controller
{
    class ContentTreeController
    {
        public const string TREE_DATA_PATH = "ContentTree.xml"; // đường dẫn đến file xml chứa dữ liệu cây danh mục
        private List<ContentProvider> _providers; // danh sách các provider

        public ContentTreeController()
        {
            ContentProviderController providerController = new ContentProviderController();
            // lấy danh sách các provider từ xml
            providerController.LoadProviders();
            _providers = providerController.Providers;
        }

        public void Build()
        {
            // tạo file xml
            XmlDocument xml = new XmlDocument();
            // tạo root element
            XmlElement root_element = xml.CreateElement("tree");
            xml.AppendChild(root_element);
            

            // duyệt các provider để lấy dữ liệu về danh mục
            for (int i = 0; i < _providers.Count; i++)
            {
                // tạo provider element, gán thuộc tính
                XmlElement provider_element = xml.CreateElement("provider");
                provider_element.SetAttribute("name", _providers[i].Name);

                // crawl lấy dữ liệu về danh mục dựa trên uri và selector của từng provider
                Uri uri = _providers[i].Uri;
                string selector = _providers[i].CatagorySelector;
                HtmlNode[] nodes = CrawlController.Crawl(uri, selector);

                // duyệt qua các nodes đã crawl được để lấy dữ liệu danh mục
                for (int j = 0; j < nodes.Length; j++)
                {
                    // kiểm tra để loại bỏ trang chủ khỏi danh sách danh mục
                    if (nodes[j].Attributes["href"].Value != "/")
                    {
                        // lấy dữ liệu uri danh mục
                        string catagory_uri = "";
                        // nếu uri danh mục trong html là đường dẫn đầy đủ (bao gồm cả domain)
                        if (nodes[j].Attributes["href"].Value.Contains(uri.Host))
                            catagory_uri = nodes[j].Attributes["href"].Value;
                        else // uri là đường dẫn tương đối phải chuyển thành uri đầy đủ
                            catagory_uri = "http://" + uri.Host + nodes[j].Attributes["href"].Value;
                        // lấy dữ liệu tên danh mục
                        string catagory_name = nodes[j].InnerText;
                        // chuẩn hóa tên danh mục (loại bỏ kí tự html thừa và Trim)
                        catagory_name = catagory_name.Replace("\r", "").Replace("\n", "").Replace("\t", "").Trim();

                        // tạo xml element về danh mục
                        XmlElement catagory_element = xml.CreateElement("catagory");
                        catagory_element.SetAttribute("name", catagory_name);
                        catagory_element.InnerText = catagory_uri;
                        // chèn catagory element vào provider element
                        provider_element.InsertAfter(catagory_element, provider_element.LastChild);
                    }
                }

                // chèn provider element vào file xml
                xml.DocumentElement.InsertAfter(provider_element, xml.DocumentElement.LastChild);
            }

            // tạo luồng ghi
            StreamWriter sw = new StreamWriter(TREE_DATA_PATH, false, Encoding.Unicode);
            // lưu xml vào luồng
            xml.Save(sw);
            // đóng luồng
            sw.Flush();
            sw.Close();
        }

        public TreeNode[] Load()
        {
            // load xml từ StreamReader
            XmlDocument xml = new XmlDocument();
            StreamReader sr = new StreamReader(TREE_DATA_PATH, Encoding.Unicode);
            xml.Load(sr);

            // lấy toàn bộ node của file xml
            XmlNodeList providers = xml.GetElementsByTagName("provider");

             // tạo mảng tree_nodes là giá trị trả về
            TreeNode[] tree_nodes = new TreeNode[providers.Count];

            // duyệt các node để lấy dữ liệu
            for (int i = 0; i < providers.Count; i++)
            {
                XmlNodeList children = providers[i].ChildNodes;

                // tạo mảng TreeNode là các node con của provider_node
                TreeNode[] catagory_nodes = new TreeNode[children.Count]; 

                // duyệt lấy thông tin từ node con
                for (int j = 0; j < children.Count; j++)
                {
                    // tạo TreeNode ứng với mỗi catagory
                    TreeNode catagory_node = new TreeNode(children[j].Attributes["name"].Value);
                    // thêm TreeNode vừa tạo vào trong mảng TreeNode catagory_nodes
                    catagory_nodes[j] = catagory_node;
                } // end for loop

                // tạo TreeNode provider_node
                TreeNode provider_node = new TreeNode(providers[i].Attributes["name"].Value, catagory_nodes);
                // thêm TreeNode provider_node vừa tạo vào mảng TreeNode trả về
                tree_nodes[i] = provider_node;
            }

            sr.Close(); // đóng luồng 
            return tree_nodes;
        }
    }
}
