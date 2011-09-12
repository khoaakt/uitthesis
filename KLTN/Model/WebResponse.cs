using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace KLTN.Model
{
    class WebResponse
    {
        private Uri _responseUri;
        private string _contentType;
        private int _contentLength;
        private WebHeaderCollection _headers;
        private string _header;
        private Socket _socket;
        private bool _keepAlive;

        public Uri ResponseUri
        {
            get { return _responseUri; }
            set { _responseUri = value; }
        }

        public string ContentType
        {
            get { return _contentType; }
            set { _contentType = value; }
        }
        public int ContentLength
        {
            get { return _contentLength; }
            set { _contentLength = value; }
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
        public Socket Socket
        {
            get { return _socket; }
            set { _socket = value; }
        }
        public bool KeepAlive
        {
            get { return _keepAlive; }
            set { _keepAlive = value; }
        }

        public void Connect(WebRequest request)
        {
            ResponseUri = request.RequestUri;

            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint remoteEP = new IPEndPoint(Dns.GetHostEntry(ResponseUri.Host).AddressList[0], ResponseUri.Port);
            Socket.Connect(remoteEP);
        }
        public void SendRequest(WebRequest request)
        {
            ResponseUri = request.RequestUri;

            request.Header = request.Method + " " + ResponseUri.PathAndQuery + " HTTP/1.0\r\n" + request.Headers;
            Socket.Send(Encoding.ASCII.GetBytes(request.Header));
        }
        public void SetTimeout(int timeout)
        {
            Socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, timeout * 1000);
            Socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, timeout * 1000);
        }
        public void ReceiveHeader()
        {
            Header = "";
            Headers = new WebHeaderCollection();

            byte[] bytes = new byte[10];
            while (Socket.Receive(bytes, 0, 1, SocketFlags.None) > 0)
            {
                Header += Encoding.ASCII.GetString(bytes, 0, 1);
                if (bytes[0] == '\n' && Header.EndsWith("\r\n\r\n"))
                    break;
            }
            MatchCollection matches = new Regex("[^\r\n]+").Matches(Header.TrimEnd('\r', '\n'));
            for (int n = 1; n < matches.Count; n++)
            {
                string[] strItem = matches[n].Value.Split(new char[] { ':' }, 2);
                if (strItem.Length > 0)
                    Headers[strItem[0].Trim()] = strItem[1].Trim();
            }
            // check if the page should be transfered to another location
            if (matches.Count > 0 && (
                matches[0].Value.IndexOf(" 302 ") != -1 ||
                matches[0].Value.IndexOf(" 301 ") != -1))
                // check if the new location is sent in the "location" header
                if (Headers["Location"] != null)
                {
                    try { ResponseUri = new Uri(Headers["Location"]); }
                    catch { ResponseUri = new Uri(ResponseUri, Headers["Location"]); }
                }
            ContentType = Headers["Content-Type"];
            if (Headers["Content-Length"] != null)
                ContentLength = int.Parse(Headers["Content-Length"]);
            KeepAlive = (Headers["Connection"] != null && Headers["Connection"].ToLower() == "keep-alive") ||
                        (Headers["Proxy-Connection"] != null && Headers["Proxy-Connection"].ToLower() == "keep-alive");
        }
        public void Close()
        {
            Socket.Close();
        }
        
    }
}
