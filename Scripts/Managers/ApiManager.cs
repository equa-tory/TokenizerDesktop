using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace TicketApp.Managers
{
    /// <summary>
    /// .NET 3.5 compatible API client using HttpWebRequest (no HttpClient/async).
    /// </summary>
    public static class ApiManager
    {
        private const string BaseUrl = "https://equatory.ddns.net:8000";
        private const string TicketTypesPath = "/ticket/types/";

        // TLS 1.2 = 0x0C00 (not in SecurityProtocolType enum in .NET 3.5)
        private const SecurityProtocolType Tls12 = (SecurityProtocolType)0x0C00;

        static ApiManager()
        {
            // Prefer TLS 1.2 so modern servers accept the connection (Windows 7+ with updates)
            ServicePointManager.SecurityProtocol = Tls12;
            // Accept server certificate (e.g. self-signed or custom CA)
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(AcceptCertificate);
        }

        private static bool AcceptCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        /// <summary>
        /// Performs a GET request to the ticket types endpoint.
        /// Returns raw response body as string.
        /// </summary>
        public static string GetTicketTypes()
        {
            string url = BaseUrl + TicketTypesPath;
            HttpWebRequest request = null;
            HttpWebResponse response = null;

            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "application/json";
                request.Timeout = 15000;
                request.ReadWriteTimeout = 15000;
                request.UserAgent = "TicketApp/1.0 (.NET 3.5)";
                request.KeepAlive = false;

                response = (HttpWebResponse)request.GetResponse();

                using (Stream responseStream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8))
                {
                    return reader.ReadToEnd();
                }
            }
            finally
            {
                if (response != null)
                    response.Close();
            }
        }
    }
}
