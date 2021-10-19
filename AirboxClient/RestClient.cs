using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web;

namespace AirboxClient
{
    public class RestClient
    {
        protected HttpClient httpClient;
        private Uri uri;
        protected string baseUrl;
        protected int port;


        public RestClient(IConfiguration config)
        {
            baseUrl = config["Settings:Host"];
            port = int.Parse(config["Settings:Port"]);
 
            this.Initialise();
        }

        public void Initialise()
        {

            this.uri = new Uri($"{baseUrl}:{port}");

            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };

            this.httpClient = new HttpClient(handler)
            {
                BaseAddress = this.uri
            };

            this.httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            this.httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip");
        }

        protected string BuildUri(string url, Dictionary<string, string> queryString)
        {
            var uriBuilder = new UriBuilder(url);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            foreach (var element in queryString)
            {
                query[element.Key] = element.Value;
            }

            return $"{url}?{query}";
        }
        protected string ExecuteRequest(HttpRequestMessage request)
        {
            var response = this.httpClient.Send(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    var result = response.Content.ReadAsStringAsync().Result;

                    return result;
                }
                catch (IOException e)
                {
                    throw new Exception(e.Message);
                }
            }
            return null;
        }
        protected T ExecuteRequest<T>(HttpRequestMessage request)
        { 
           var response = this.httpClient.Send(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    var result = response.Content.ReadAsStringAsync().Result;

                    return JsonConvert.DeserializeObject<T>(result);
                }
                catch (IOException e)
                {
                    throw new Exception(e.Message);
                }
            }
            return default(T);
        }
    }
}
