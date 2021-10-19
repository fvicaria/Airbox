using Airbox.Entities;
using Microsoft.Extensions.Configuration;
using System.Net.Http;

namespace AirboxClient
{
    public class LocationClient : RestClient
    {
        public LocationClient(IConfiguration config) : base(config)
        {
        }

        public Location GetLocationByName(string name)
        {
            var requestUri = $"api/Location/{name}";
            var request = new HttpRequestMessage(HttpMethod.Get, requestUri);

            return ExecuteRequest<Location>(request);
        }
    }
}
