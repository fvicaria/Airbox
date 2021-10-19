using Airbox.Entities;
using Airbox.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Airbox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private ILogger Logger { get; }
        private IConfiguration Config { get; }
        private IRepository Repository { get; }

        public LocationController(ILogger<LocationController> logger, IConfiguration config, IRepository repository)
        {
            Logger = logger;
            Config = config;
            Repository = repository;
        }

        // GET: api/<LocationController>
        /// <summary>
        /// Get All locations
        /// </summary>
        /// <returns>IEnumerable<ILocation></returns>
        [HttpGet]
        public ActionResult<IEnumerable<ILocation>> Get()
        {
            Logger.LogInformation($"LocationController:Get");
            return Ok(Repository.Locations);
        }

        // GET api/<LocationController>/USA
        /// <summary>
        /// Get a Location by its name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Location</returns>
        [HttpGet("{name}")]
        public ActionResult<ILocation> Get(string name)
        {
            Logger.LogInformation($"LocationController:Get{name}");
            return Ok(Repository.GetLocation(name));
        }

        // POST api/<LocationController>
        /// <summary>
        /// Add a new Location
        /// </summary>
        /// <param name="loc"></param>
        /// <returns>string</returns>
        [HttpPost]
        public ActionResult Post([FromBody] ILocation loc)
        {
            if (loc != null && !string.IsNullOrEmpty(loc.Name) && !string.IsNullOrEmpty(loc.Area))
            {
                if (Repository.GetLocation(loc.Name) == null)
                {
                    Repository.Locations.Add(loc);
                    Logger.LogInformation($"LocationController:Post{loc.Name} {loc.Area}");
                    return Ok();
                }
                Logger.LogWarning($"LocationController:Post Location already exists! {loc.Name} {loc.Area}");

                return Accepted("Location already exists!");
            }
            Logger.LogWarning($"LocationController: Null or empty Location");
            return BadRequest("Invalid location passed!");
        }

        // PUT api/<LocationController>/Japan
        /// <summary>
        /// Update a location area
        /// </summary>
        /// <param name="name"></param>
        /// <param name="area"></param>
        /// <returns>string</returns>
        [HttpPut("{name}")]
        public ActionResult Put(string name, [FromBody] string area)
        {
            if (!string.IsNullOrEmpty(area))
            {
                var loc = Repository.GetLocation(name);
                loc.Area = area;
                Logger.LogInformation($"LocationController:Put{name} {area} ");

                return Ok();
            }
            else
            {
                Logger.LogWarning($"LocationController:Put No Area! ");

                return BadRequest("Invalid area passed!");
            }
        }

        // DELETE api/<LocationController>/Japan
        /// <summary>
        /// Delete a location
        /// </summary>
        /// <param name="name"></param>
        /// <returns>string</returns>
        [HttpDelete("{name}")]
        public ActionResult Delete(string name)
        {
            ILocation loc = Repository.Locations.FirstOrDefault(u => u.Name == name);
            if (loc != null)
            {
                Repository.Locations.Remove(loc);
                return Ok();
            }
            Logger.LogWarning($"LocationController:Delete Not found! ");

            return BadRequest("Invalid location!");

        }
    }
}
