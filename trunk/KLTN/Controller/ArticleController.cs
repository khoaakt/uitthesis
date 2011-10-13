using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KLTN.Model;
using System.IO;
using HtmlAgilityPack;
using Fizzler.Systems.HtmlAgilityPack;

namespace KLTN.Controller
{
    class ArticleController
    {
        public const string FLAG_TO_SAVE = "\n[!@#$HIEU%^&*]\n"; // cờ phân cách giữa các phần bài báo
        private Article _article;   // đối tượng model của bài báo
        private string _path;       // đường dẫn tới tập tin lưu trữ
        private Uri _uri;           // uri tới nguyên bản của bài báo 

        public ArticleController()
        {
            // khởi tạo
            Article = new Article();
            _path = "";
            _uri = null;
        }

        public Article Article
        {
            get { return _article; }
            set { _article = value; }
        }

        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }

        public Uri Uri
        {
            get { return _uri; }
            set { _uri = value; }
        }
  
        public void Read()
        {
            Article = ArticleController.Read(Path);
        }

        public static Article Read(string path)
        {
            // kiểm tra file tồn tại
            if (!File.Exists(path))
            {
                throw new Exception("Tập tin không tồn tại hoặc đường dẫn không hợp lệ:\n " + path);
            }
            // tạo luồng đọc
            StreamReader sr = File.OpenText(path);

            string file_content = sr.ReadToEnd(); // đọc toàn bộ string từ luồng
            string[] separators = new string[] { FLAG_TO_SAVE }; // khai báo cờ phân cách giữa các thành phần bài báo 
            string[] article_data = file_content.Split(separators, StringSplitOptions.None); // tách các phần bài báo thành mảng string

            // tạo đối tượng model article mới
            Article article = new Article();

            // lấy dữ liệu từ mảng string đọc từ luồng truyền vào đối tượng model
            article.Title = article_data[0];
            article.Time = DateTime.Parse(article_data[1]);
            article.Summany = article_data[2];
            article.Content = article_data[3];
            article.Uri = new Uri(article_data[4]);
            article.Author = article_data[5];
            

            sr.Close(); // đóng luồng

            return article; // trả về đối tượng model
        }

        public void Save()
        {
            ArticleController.Save(Article, Path);      
        }

        public static void Save(Article article, string path)
        {
            // khởi tạo nội dung tập tin trước khi lưu
            string file_content = String.Join(FLAG_TO_SAVE, article.toArray());
            // tạo luồng ghi
            StreamWriter sw = new StreamWriter(path, false, Encoding.Unicode);
            // ghi nội dung vào tập tin
            sw.Write(file_content);
            sw.Flush(); // flush luồng
            sw.Close(); // đóng luồng
        }

        public Article Get(string url, string titleSelector, string timeSelector, string summanySelector, string contentSelector, string authorSelector) 
        {
            // crawl dữ liệu
            var document = CrawlController.Crawl(url).DocumentNode;
            CrawlController.RemoveHtmlComments(document);
            var title_node = document.QuerySelector(titleSelector);
            var time_node = document.QuerySelector(timeSelector);
            var summany_node = document.QuerySelector(summanySelector);
            var content_node = document.QuerySelector(contentSelector);
            var author_node = document.QuerySelector(authorSelector);

            // validate dữ liệu
            
            // code was here

            //

            // gán dữ liệu vào đối tượng model
            Article.Uri = new System.Uri(url);
            Article.Title = title_node.InnerText.Replace("\r", "").Replace("\n", "").Replace("\t", "").Trim();
            Article.Summany = summany_node.InnerText.Replace("\r", "").Replace("\n", "").Replace("\t", "").Trim();
            if (author_node != null)
                Article.Author = author_node.InnerText.Replace("\r", "").Replace("\n", "").Replace("\t", "").Trim();
            else
                Article.Author = "Khuyết danh";
            Article.Content = content_node.InnerHtml.Trim();
            if (time_node != null)
            {
                var time_string = time_node.InnerText.Replace("\r", "").Replace("\n", "").Replace("\t", "").Trim();
                DateTime time;
                if (!DateTime.TryParse(time_string, out time))
                {
                    time = DateTime.Now;
                }

                Article.Time = time;
            }
            else Article.Time = DateTime.Now;


            return Article;
        }

    }
}
