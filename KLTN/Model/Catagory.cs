using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KLTN.Model
{
    class Catagory
    {
        private string _name;
        private Uri _uri;
        private ContentProvider _provider;

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

        public ContentProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }

        public string UrlSelector
        {
            get { return _provider.UrlSelector; }
        }
    }
}
