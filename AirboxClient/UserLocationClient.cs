using Airbox.Entities;
using Airbox.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace AirboxClient
{
    public class UserLocationClient : RestClient
    {
        public UserLocationClient(IConfiguration config) : base(config)
        {
        }

       
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<UserLocation> GetUserAllUserLocations()
        {
            var requestUri = $"api/UserLocation";
            var request = new HttpRequestMessage(HttpMethod.Get, requestUri);

            return ExecuteRequest<List<UserLocation>>(request);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>List<Location>></returns>
        public List<Location> UserLocationHistory(string userName)
        {
            var requestUri = $"api/UserLocation/{userName}/history";
            var request = new HttpRequestMessage(HttpMethod.Get, requestUri);

            return ExecuteRequest<List<Location>>(request);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>Location</returns>
        public Location UserLocation(string userName)
        {
            var requestUri = $"api/UserLocation/{userName}";
            var request = new HttpRequestMessage(HttpMethod.Get, requestUri);

            return ExecuteRequest<Location>(request);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>bool</returns>
        public string SetUserLocation(string userName, Location location)
        {
            var requestUri = $"api/UserLocation/{userName}";
            var request = new HttpRequestMessage(HttpMethod.Put, requestUri)
            {
                Content = new StringContent(
                    JsonConvert.SerializeObject(location),
                    Encoding.UTF8,
                    "application/json"
                )
            };
           var result =  ExecuteRequest(request);
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="area"></param>
        /// <returns>List<Location> </returns>
        public List<UserLocation> GetUserLocationsInArea(string area)
        {
            var requestUri = $"api/UserLocation/area/{area}";
            var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
           
            return ExecuteRequest<List<UserLocation>>(request);
        }
    }
}
