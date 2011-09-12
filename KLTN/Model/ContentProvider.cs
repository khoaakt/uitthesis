using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KLTN.Model
{
    class ContentProvider
    {
        private string _name;               // tên của trang web cung cấp tin tức
        private Uri _uri;                   // uri của trang web cung cấp tin tức
        private string _catagorySelector;   // css selector để lọc danh mục
        private string _titleSelector;      // css selector để lọc tiêu đề bài báo
        private string _summanySelector;    // css selector để lọc tóm tắt bài báo
        private string _contentSelector;    // css selector để lọc nội dung bài báo
        private string _timeSelector;       // css selector để lọc thời gian bài báo
        private string _urlSelector;        // css selector để lọc ra url của bài báo
        private string _authorSelector;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Uri Uri
        {
            get { return _uri; }
            set { _uri = value; }
        }

        public string CatagorySelector
        {
            get { return _catagorySelector; }
            set { _catagorySelector = value; }
        }

        public string TitleSelector
        {
            get { return _titleSelector; }
            set { _titleSelector = value; }
        }

        public string SummanySelector
        {
            get { return _summanySelector; }
            set { _summanySelector = value; }
        }

        public string ContentSelector
        {
            get { return _contentSelector; }
            set { _contentSelector = value; }
        }

        public string TimeSelector
        {
            get { return _timeSelector; }
            set { _timeSelector = value; }
        }

        public string UrlSelector
        {
            get { return _urlSelector; }
            set { _urlSelector = value; }
        }

        public string AuthorSelector
        {
            get { return _authorSelector; }
            set { _authorSelector = value; }
        }

    }
}