using Airbox.Entities;
using Airbox.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AirboxClient
{
    public class UserClient: RestClient    
    {
        public UserClient(IConfiguration config) : base(config)
        {
        }

        public User GetUserByName(string name)
        {
            var requestUri = $"api/User/{name}";
            var request = new HttpRequestMessage(HttpMethod.Get, requestUri);

            return ExecuteRequest<User>(request);
        }
    }
}
