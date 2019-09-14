using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace BGTimeService
{
    class TimeHttpServer
    {
        private HttpListener listener;

        public string Subpath { get; private set; }
        public int Port { get; private set; }

        public bool IsActive
        {
            get { return listener.IsListening; }
        }

        private readonly object contentLock = new object();
        private string currentContent;
        public string Content {
            get
            {
                lock(contentLock)
                {
                    return currentContent;
                }
            }
            set
            {
                lock(contentLock)
                {
                    currentContent = value;
                }
            }
        }

        public TimeHttpServer()
        {
            listener = new HttpListener();
            Content = "";
        }

        public void Start(string subpath, int port)
        {
            if (!listener.IsListening)
            {
                this.Subpath = subpath;
                this.Port = port;
                listener.Prefixes.Clear();
                listener.Prefixes.Add(string.Format("http://+:{0}/{1}/", Port, Subpath));
                listener.Start();
                listener.BeginGetContext(OnContext, null);
            }
        }

        public void Stop()
        {
            if(listener.IsListening)
            {
                listener.Stop();
            }
        }

        private void OnContext(IAsyncResult ar)
        {
            if (!listener.IsListening) { return; }

            HttpListenerContext context = listener.EndGetContext(ar);
            listener.BeginGetContext(OnContext, null);

            context.Response.ContentType = "application/json";
            //context.Response.OutputStream.

            using(StreamWriter stream = new StreamWriter(context.Response.OutputStream))
            {
                stream.Write(Content);
            }
            context.Response.OutputStream.Close();
        }
    }
}
