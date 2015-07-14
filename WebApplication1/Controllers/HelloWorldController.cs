using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web;
using System.IO;

namespace WebApplication1.Controllers
{
    public class HelloWorldController : ApiController
    {
        // /api/HelloWorld
        public string Get()
        {
            HttpClient httpClient = new HttpClient();
            var requestUri =
                new Uri("https://api-http.littlebitscloud.cc/devices/00e04c032d62/input");
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.littlebits.v2+json"));
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(
                    "Bearer",
                    "04784c7ae09bea78704572648c547c472f61dfce0bdf00075fb050f85eaff8ab");
            var stream = httpClient.GetStreamAsync(requestUri).Result;
            var reader = new StreamReader(stream);
            var firstLine = reader.ReadLine();
            return firstLine;
        }
    }
}
