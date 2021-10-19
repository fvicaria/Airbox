using AirboxClient;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace AirboxIntergrationTest
{
    [TestClass]
    public class UserClientShould
    {
        private UserClient _userClient;

        [TestInitialize]
        public void Inititalisze()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();
            _userClient = new UserClient(config);
        }

        [TestMethod]
        public void GetUserByName()
        {
            var user = _userClient.GetUserByName("John");
            user.Should().NotBeNull();
            user.Name.Should().Be("John");

        }
        // TODO: all methods in User API
    }
}
