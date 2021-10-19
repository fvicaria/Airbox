using AirboxClient;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace AirboxIntergrationTest
{
    [TestClass]
    public class LocationClientClientShould
    {
        private LocationClient _locationClient;

        [TestInitialize]
        public void Inititalisze()
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();
            _locationClient = new LocationClient(config);
        }

        [TestMethod]
        public void GetUserByName()
        {
            var location = _locationClient.GetLocationByName("Japan");
            location.Should().NotBeNull();
            location.Name.Should().Be("Japan");
            location.Area.Should().Be("Asia");

        }
        // TODO: all methods in Location API
    }
}
