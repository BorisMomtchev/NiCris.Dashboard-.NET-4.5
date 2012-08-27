using NiCris.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

namespace NiCris.HttpClient.NET4._5
{
    class Program
    {
        static readonly Uri _baseAddress = new Uri("http://localhost:36637/");

        static void Main(string[] args)
        {
            // Run HttpClient issuing requests
            RunClient();

            Console.WriteLine("Hit ENTER to exit...");
            Console.ReadLine();
        }

        /// <summary>
        /// Runs an HttpClient issuing a POST request against the controller.
        /// </summary>
        static async void RunClient()
        {
            var handler = new HttpClientHandler();
            handler.Credentials = new NetworkCredential("Boris", "xyzxyz");
            var client = new System.Net.Http.HttpClient(handler);

            BizMsgDTO bizMsg = new BizMsgDTO
            {
                Name = "Boris",
                Date = DateTime.Now,
                User = "Boris.Momtchev",
            };

            // Post contact
            Uri address = new Uri(_baseAddress, "/api/BizMsg");
            HttpResponseMessage response = await client.PostAsJsonAsync(address.ToString(), bizMsg);

            // Check that response was successful or throw exception
            response.EnsureSuccessStatusCode();

            // Read result as Contact
            BizMsg result = await response.Content.ReadAsAsync<BizMsg>();
            Console.WriteLine("Result: Name: {0}, Date: {1}, User: {2}, Id: {3}", result.Name, result.Date.ToString(), result.User, result.Id);
        }
    }

}
