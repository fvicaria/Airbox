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
    public class UserLocationClientShould
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
        public void GetUserLocationsApiIsNotNull()
        {
            // test we can call the api
            var locations = _useLocationClient.GetUserAllUserLocations();
            locations.Should().NotBeNull();
        }
        [TestMethod]
        public void UserLocationsHistoryApiIsNotNull()
        {
            // test we can call the api
            // first make sure user has some history
            // test we can call the api
            var location = new Location() { Name = "England", Area = "Europe" };
            var result = _useLocationClient.SetUserLocation("John", location);
            result.Should().Be("");

            var locations = _useLocationClient.UserLocationHistory("John");
            locations.Should().NotBeNull();
        }
        [TestMethod]
        public void UserLocationsApiIsNotNull()
        {
            // test we can call the api
            var location = _useLocationClient.UserLocation("John");
            location.Should().NotBeNull();
        }
        [TestMethod]
        public void SetUserLocationsSucceeds()
        {
            // test we can call the api
            var  location = new Location() { Name="England", Area="Europe"};
            var result = _useLocationClient.SetUserLocation("John", location);
            result.Should().Be("");
        }
        [TestMethod]
        public void GetUsersInArea()
        {
            // test we can call the api
            var uloc = _useLocationClient.GetUserLocationsInArea("Europe");
            uloc.Should().NotBeNull();
            uloc.FirstOrDefault().User.Name.Should().Be("John");
        }
    }
}
