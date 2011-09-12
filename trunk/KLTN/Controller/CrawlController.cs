using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using Fizzler.Systems.HtmlAgilityPack;

namespace KLTN.Controller
{
    class CrawlController
    {
        public static HtmlNode[] Crawl(string url, string selector)
        {
            HtmlDocument html = CrawlController.Crawl(url);
            var document = html.DocumentNode;

            // xóa tất cả html comment
            CrawlController.RemoveHtmlComments(document);
            
            HtmlNode[] nodes = document.QuerySelectorAll(selector).ToArray();

            return nodes;
        }

        public static HtmlNode[] Crawl(Uri uri, string selector)
        {
            string url = uri.ToString();
            return CrawlController.Crawl(url, selector);
        }

        public static HtmlDocument Crawl(Uri uri)
        {
            string url = uri.ToString();
            return CrawlController.Crawl(url);
        }

        public static HtmlDocument Crawl(string url)
        {
            HtmlWeb hw = new HtmlWeb();
            HtmlDocument html = hw.Load(url);

            return html;
        }

        public static void RemoveHtmlComments(HtmlNode node)
        {
            // nếu node type là comment thì xóa
            if (node.NodeType == HtmlNodeType.Comment)
            {
                node.ParentNode.RemoveChild(node);
                return;
            }

            // nếu không có node con thì thoát khỏi hàm
            if (!node.HasChildNodes)
                return;

            // gọi đệ quy cho tất cả các nốt con
            foreach (HtmlNode subNode in node.ChildNodes)
            {
                RemoveHtmlComments(subNode);
            }
        }
    }
}
