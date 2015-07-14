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
    public class ValueModel
    {
        public string CloudbitDeviceId { get; set; }
        public string CloudbitAccessToken { get; set; }
    }

    public class InputController : ApiController
    {
        // /api/HelloWorld
        public string Get([FromUri]ValueModel val)
        {
            HttpClient httpClient = new HttpClient();
            var requestUri =
                new Uri(
                    "https://api-http.littlebitscloud.cc/devices/" 
                    + val.CloudbitDeviceId + 
                    "/input");
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.littlebits.v2+json"));
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(
                    "Bearer", val.CloudbitAccessToken);
            var stream = httpClient.GetStreamAsync(requestUri).Result;
            var reader = new StreamReader(stream);
            var firstLine = reader.ReadLine();
            firstLine = firstLine.Replace("data:", "");
            return firstLine;
        }
    }
}