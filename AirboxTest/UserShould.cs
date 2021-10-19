using Airbox.Controllers;
using Airbox.Interfaces;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AirboxTest
{
    [TestClass]
    public class UserShould
    {
        private IRepository _repository;
        [TestInitialize]
        public void TestInitialize()
        {
            _repository = new Repository();
        }


        [TestMethod]
        public void GetLocationById()
        {
            var location = _repository.GetLocation("Japan");
            location.Should().NotBeNull();
            location.Area.Should().Be("Asia");
        }
    }

}
