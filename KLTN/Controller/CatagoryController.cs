using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KLTN.Model;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Security.Cryptography;

namespace KLTN.Controller
{
    class CatagoryController
    {
        public const string DATA_DIR = "data";
        private Catagory _catagory;
        private List<Article> _articles;

        public Catagory Catagory
        {
            get { return _catagory; }
            set { _catagory = value; }
        }

        public List<Article> Articles
        {
            get { return _articles; }
            set { _articles = value; }
        }

        public CatagoryController()
        {
            _catagory = new Model.Catagory();
            _articles = new List<Article>();
        }

        public Catagory GetCatagory(string providerName, string catagoryName)
        {
            // load xml từ StreamReader
            XmlDocument xml = new XmlDocument();
            StreamReader sr = new StreamReader(ContentTreeController.TREE_DATA_PATH, Encoding.Unicode);
            xml.Load(sr);

            // lấy toàn bộ node của file xml
            XmlNodeList providers = xml.GetElementsByTagName("provider");

            // duyệt các node để lấy dữ liệu
            for (int i = 0; i < providers.Count; i++)
            {
                XmlNodeList children = providers[i].ChildNodes;

                if (providers[i].Attributes["name"].Value.Trim().ToLower() == providerName.Trim().ToLower()) {

                    // duyệt lấy thông tin từ node con
                    for (int j = 0; j < children.Count; j++)
                    {
                        if (children[j].Attributes["name"].Value.Trim().ToLower() == catagoryName.Trim().ToLower())
                        {
                            _catagory = new Catagory();
                            _catagory.Name = catagoryName;
                            _catagory.Uri = new Uri(children[j].InnerText);
                            ContentProviderController cpc = new ContentProviderController();
                            cpc.LoadProviders();
                            _catagory.Provider = cpc.GetProviderByName(providerName); 
                        }
                    } // end for loop
                }

            }

            sr.Close(); // đóng luồng 

            return _catagory;
        }

        public string[] GetArticleUrls()
        {
            List<string> urlList = new List<string>();
            HtmlNode[] nodes = CrawlController.Crawl(Catagory.Uri, Catagory.UrlSelector);

            for (int i = 0; i < nodes.Length; i++)
            {
                string url = "";
                if (nodes[i].Attributes["href"].Value.Contains(Catagory.Uri.Host))
                    url = nodes[i].Attributes["href"].Value;
                else // uri là đường dẫn tương đối phải chuyển thành uri đầy đủ
                    url = "http://" + Catagory.Uri.Host + nodes[i].Attributes["href"].Value;
                urlList.Add(url);
            }

            return urlList.ToArray();
        }

        public void GetAllArticles()
        {
            // tạo các thư mục để chứa dữ liệu
            Directory.CreateDirectory(DATA_DIR); // tạo thư mục data, nếu đã tồn tại hàm này không làm gì cả
            var catagory_path = Path.Combine(DATA_DIR, Catagory.Provider.Name, Catagory.Name);
            Directory.CreateDirectory(catagory_path);

            // lấy toàn bộ url của các article để crawl
            var urls = GetArticleUrls();
            ArticleController ac;

            foreach(string url in urls) 
            {
                ac = new ArticleController();
                var provider = Catagory.Provider;
                var article = ac.Get(url, provider.TitleSelector, provider.TimeSelector, provider.SummanySelector, provider.ContentSelector, provider.AuthorSelector);
                Articles.Add(article);

                // đặt tên file dữ liệu article theo url
                var md5 = new MD5CryptoServiceProvider();
                var hash = md5.ComputeHash(Encoding.Default.GetBytes(url));
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sBuilder.Append(hash[i].ToString("x2"));
                }
                var file_name = sBuilder.ToString() + ".ht";

                var file_path = Path.Combine(catagory_path, file_name);
                // lưu xuống ổ cứng
                ArticleController.Save(article, file_path);
            }
        }
    }
}
