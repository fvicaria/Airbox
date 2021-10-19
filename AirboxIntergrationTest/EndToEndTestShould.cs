using Airbox.Entities;
using AirboxClient;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace AirboxIntergrationTest
{
    [TestClass]
    public class EndToEndTestsShould
    {
        private UserLocationClient _useLocationClient;

        [TestInitialize]
        public void Inititalise()
        {
            var builder = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();

            _useLocationClient = new UserLocationClient(config);
        }

        [TestMethod]
        public void PerformEndToEndTest()
        {
            // Add all clients...
            // Delete all data
            // Add users
            // Add locations
            // Move users around
            // Check users in area
            // etc...
        }   
    }
}
