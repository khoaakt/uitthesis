using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KLTN.Model
{
    /// <summary>
    /// This class...
    /// </summary>
    class Article
    {
        private int _id;             // id của bài báo
        private String _title;       // tiêu đề một bài báo
        private String _summany;     // đoạn tóm lược của bài báo
        private String _content;     // nội dung đầy đủ của bài báo
        private Uri _uri;            // liên kết nguyên bản của bài báo
        private DateTime _time;      // thời gian bài báo được đăng
        private String _author;

        public Article()
        {
            ID = 0;
            Title = "";
            Summany = "";
            Content = "";
            Uri = null;
            Time = DateTime.Now;
           
        }

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public String Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public String Summany
        {
            get { return _summany; }
            set { _summany = value; }
        }

        public String Content
        {
            get { return _content; }
            set { _content = value; }
        }

        public Uri Uri
        {
            get { return _uri; }
            set { _uri = value; }
        }

        public DateTime Time
        {
            get { return _time; }
            set { _time = value; }
        }

        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }

        public string[] toArray()
        {
            string[] result = new string[6];
            result[0] = Title;
            result[1] = Time.ToString();
            result[2] = Summany;
            result[3] = Content;
            result[4] = Uri.ToString();
            result[5] = Author;

            return result;
        }
    }
}
