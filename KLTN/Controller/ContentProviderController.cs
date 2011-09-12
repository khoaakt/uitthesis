using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using KLTN.Model;

namespace KLTN.Controller
{
    class ContentProviderController
    {
        public const string PROVIDER_FILE_PATH = "ContentProvider.xml";
        private XmlDocument _xml;
        private List<ContentProvider> _providers;

        public XmlDocument Xml
        {
            get { return _xml; }
            set { _xml = value; }
        }

        public List<ContentProvider> Providers
        {
            get { return _providers; }
            set { _providers = value; }
        }

        public ContentProviderController()
        {
            // khởi tạo
            Xml = new XmlDocument();
            Providers = new List<ContentProvider>();
        }

        public void LoadProviders()
        {
            // load xml từ StreamReader
            StreamReader sr = new StreamReader(PROVIDER_FILE_PATH, Encoding.Unicode);
            Xml.Load(sr);

            // lấy toàn bộ node của file xml
            XmlNodeList nodes = Xml.GetElementsByTagName("provider");

            // duyệt các node để lấy dữ liệu
            for (int i = 0; i < nodes.Count; i++)
            {
                XmlNodeList children = nodes[i].ChildNodes;
                ContentProvider provider = new ContentProvider();

                // duyệt lấy thông tin từ node con
                for (int j = 0; j < children.Count; j++)
                {
                    switch (children[j].Name)
                    {
                        case "name":
                            provider.Name = children[j].InnerText;
                            break;
                        case "uri":
                            provider.Uri = new Uri(children[j].InnerText);
                            break;
                        case "catagory":
                            provider.CatagorySelector = children[j].InnerText;
                            break;
                        case "title":
                            provider.TitleSelector = children[j].InnerText;
                            break;
                        case "summany":
                            provider.SummanySelector = children[j].InnerText;
                            break;
                        case "content":
                            provider.ContentSelector = children[j].InnerText;
                            break;
                        case "time":
                            provider.TimeSelector = children[j].InnerText;
                            break;
                        case "url":
                            provider.UrlSelector = children[j].InnerText;
                            break;
                        case "author":
                            provider.AuthorSelector = children[j].InnerText;
                            break;
                    } // end switch case statement
                } // end for loop

                // thêm provider vào list
                Providers.Add(provider);       
            }
            sr.Close(); // đóng luồng 
        }

        public void SaveProviders()
        {

            // tạo root element
            XmlElement root_element = Xml.CreateElement("providers");
            Xml.AppendChild(root_element);

            for (int i = 0; i < Providers.Count; i++)
            {
                // tạo các xml element
                XmlElement provider_element = Xml.CreateElement("provider");
                XmlElement name_element = Xml.CreateElement("name");
                XmlElement uri_element = Xml.CreateElement("uri");
                XmlElement catagory_element = Xml.CreateElement("catagory");
                XmlElement title_element = Xml.CreateElement("title");
                XmlElement summany_element = Xml.CreateElement("summany");
                XmlElement content_element = Xml.CreateElement("content");
                XmlElement time_element = Xml.CreateElement("time");
                XmlElement url_element = Xml.CreateElement("url");
                XmlElement author_element = Xml.CreateElement("author");

                // gán inner text cho các xml element
                name_element.InnerText = Providers[i].Name;
                uri_element.InnerText = Providers[i].Uri.ToString();
                catagory_element.InnerText = Providers[i].CatagorySelector;
                title_element.InnerText = Providers[i].TitleSelector;
                summany_element.InnerText = Providers[i].SummanySelector;
                content_element.InnerText = Providers[i].ContentSelector;
                time_element.InnerText = Providers[i].TimeSelector;
                url_element.InnerText = Providers[i].UrlSelector;
                author_element.InnerText = Providers[i].AuthorSelector;

                // gán element con cho provider element
                provider_element.AppendChild(name_element);
                provider_element.AppendChild(uri_element);
                provider_element.AppendChild(catagory_element);
                provider_element.AppendChild(title_element);
                provider_element.AppendChild(summany_element);
                provider_element.AppendChild(content_element);
                provider_element.AppendChild(time_element);
                provider_element.AppendChild(url_element);
                provider_element.AppendChild(author_element);

                // thêm provider element vào xml document
                Xml.DocumentElement.AppendChild(provider_element);

            }

            // tạo luồng để lưu xml
            StreamWriter sw = new StreamWriter(PROVIDER_FILE_PATH, false, Encoding.Unicode);
            // lưu tập tin xml
            Xml.Save(sw);
            sw.Flush(); // flush luồng
            sw.Close(); // đóng luồng
        }

        public ContentProvider GetProviderByName(string name) 
        {
            for (int i = 0; i < Providers.Count; i++)
            {
                if (Providers[i].Name.Trim().ToLower() == name.Trim().ToLower())
                    return Providers[i];             
            }
            return null;
        }

    }
}
