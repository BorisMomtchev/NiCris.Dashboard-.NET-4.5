using NiCris.BusinessObjects;
using System;
using System.Net;
using System.Net.Http;

namespace NiCris.Client.BusinessStream
{
    public class HttpHelper
    {
        static readonly Uri _baseAddress = new Uri("http://localhost:36637/");
        static HttpClientHandler _handler = null;
        static HttpClient _client = null;

        static HttpHelper()
	    {
            _handler = new HttpClientHandler();
            _handler.Credentials = new NetworkCredential("Boris", "xyzxyz");
            _client = new HttpClient(_handler);
	    }

        /// <summary>
        /// Runs an HttpClient issuing a POST request against the controller.
        /// </summary>
        public static async void RunClient(BizMsgExDTO bizMsgExDTO)
        {
            // *** POST/CREATE BizMsg
            Uri address = new Uri(_baseAddress, "/api/BizMsgExService");
            HttpResponseMessage response = await _client.PostAsJsonAsync(address.ToString(), bizMsgExDTO);

            // Check that response was successful or throw exception
            response.EnsureSuccessStatusCode();
            Console.WriteLine(response.StatusCode + " - " + response.Headers.Location);
        }
    }
}
