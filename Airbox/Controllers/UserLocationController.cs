using Airbox.Entities;
using Airbox.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Airbox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLocationController : ControllerBase
    {
        private ILogger Logger { get; }
        private IConfiguration Config { get; }
        private IRepository Repository { get; }

        public UserLocationController(ILogger<UserLocationController> logger, IConfiguration config, IRepository repository)
        {
            Logger = logger;
            Config = config;
            Repository = repository;
        }


        /// <summary>
        /// 1.	Receive a location update for a user)
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="loc"></param>
        /// <returns>bool</returns>
        [HttpPut("{userName}")]
        public ActionResult Put(string userName, [FromBody] Location loc)
        {
            Logger.LogInformation($"UserLocationController:Put {userName} {loc.Name}");
            var user = Repository.GetUser(userName);
            if (user == null)
                return NotFound();

            var location = Repository.GetLocation(loc.Name);
            if (location == null)
            {
                if (string.IsNullOrEmpty(loc.Name) || string.IsNullOrEmpty(loc.Area))
                {
                    Logger.LogWarning($"Location has no name and/or area.");
                    return BadRequest("Location must have name and area.");
                }
                Repository.AddLocation(loc);
                location = loc;
            }

            user.Location = location;

            return Ok();
        }


        /// <summary>
        /// 2.	Return the current location for a specified user)
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpGet("{userName}")]
        public ActionResult<Location> Get(string userName)
        {
            Logger.LogInformation($"UserLocationController:Get{userName}");

            var user = Repository.GetUser(userName);
            if (user == null)
            {
                Logger.LogWarning($"UserLocationController: GetHistory User { userName} not found");
                return NotFound($"User not found: {userName}");
            }

            return Ok(user.Location);
        }


        /// <summary>
        /// 3.	Return the location history for a specified user
        /// </summary>
        /// <param name="userName"></param>
        /// <returns> List[Location] </returns>
        [HttpGet("{userName}/history")]
        public ActionResult<List<Location>> GetHistory(string userName)
        {
            Logger.LogInformation($"UserLocationController:GetHistory {userName}");

            var user = Repository.GetUser(userName);
            if (user == null)
            {
                Logger.LogWarning($"UserLocationController:GetHistory User {userName} not found");
                return NotFound($"User not found: {userName}");
            }
            return Ok(user.History);
        }


        /// <summary>
        /// 4.	Return the current location for all users
        /// </summary>
        /// <returns>List[UserLocation]</returns>
        [HttpGet()]
        public ActionResult<List<UserLocation>> GetCurrentLocations()
        {
            Logger.LogInformation($"UserLocationController:GetCurrentLocations");

            var users = Repository.Users;
            var locs = new List<UserLocation>();

            foreach (var user in users)
            {
                if (user.Location != null)
                    locs.Add(new UserLocation { User = user, Location = user.Location });
            }

            return Ok(locs);
        }

        /// <summary>
        /// 5.	Return the current location for all users within a specified area
        /// </summary>
        /// <param name="areaName"></param>
        /// <returns>List[UserLocation]</returns>
        [HttpGet("area/{areaName}")]
        public ActionResult<List<UserLocation>> GetLocationsInArea(string areaName)
        {
            Logger.LogInformation($"UserLocationController:GetLocationsInArea {areaName}");

            var locs = new List<UserLocation>();

            foreach (var user in Repository.Users)
            {
                
                if (user.Location != null && user.Location.Area == areaName)
                    locs.Add(new UserLocation { User = user, Location = user.Location });
            }

            return Ok(locs);
        }
    }
}
