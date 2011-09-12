using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace KLTN.Model
{
    class WebRequest
    {
        private int _timeout;
        private WebHeaderCollection _headers;
        private string _header;
        private Uri _requestUri;
        private string _method;
        private WebResponse _response;
        private bool _keepAlive;

        public int Timeout
        {
            get { return _timeout; }
            set { _timeout = value; }
        }

        public WebHeaderCollection Headers 
        {
            get { return _headers; }
            set { _headers = value; }
        }

        public string Header
        {
            get { return _header; }
            set { _header = value; }
        }

        public Uri RequestUri
        {
            get { return _requestUri; }
            set { _requestUri = value; }
        }

        public string Method
        {
            get { return _method; }
            set { _method = value; }
        }

        public WebResponse Response
        {
            get { return _response; }
            set { _response = value; }
        }

        public bool KeepAlive
        {
            get { return _keepAlive; }
            set { _keepAlive = value; }
        }

        public WebRequest(Uri uri, bool bKeepAlive)
		{
			Headers = new WebHeaderCollection();
			RequestUri = uri;
			Headers["Host"] = uri.Host;
			KeepAlive = bKeepAlive;
			if(KeepAlive)
				Headers["Connection"] = "Keep-Alive";
			Method = "GET";
		}

		public static WebRequest Create(Uri uri, WebRequest aliveRequest, bool keepAlive)
		{
			if( keepAlive &&
				aliveRequest != null &&
				aliveRequest.Response != null &&
                aliveRequest.Response.KeepAlive &&
                aliveRequest.Response.Socket.Connected && 
				aliveRequest.RequestUri.Host == uri.Host)
			{
				aliveRequest.RequestUri = uri;
				return aliveRequest;
			}
			return new WebRequest(uri, keepAlive);
		}
        public WebResponse GetResponse()
        {
            if (Response == null || Response.Socket == null || Response.Socket.Connected == false)
            {
                Response = new WebResponse();
                Response.Connect(this);
                Response.SetTimeout(Timeout);
            }
            Response.SendRequest(this);
            Response.ReceiveHeader();
            return Response;
        }	
    }
}
