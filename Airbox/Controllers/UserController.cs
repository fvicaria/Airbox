using Airbox.Entities;
using Airbox.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Airbox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ILogger Logger { get; }
        private IConfiguration Config { get; }
        private IRepository Repository { get; }

        public UserController(ILogger<UserController> logger, IConfiguration config, IRepository repository)
        {
            Logger = logger;
            Config = config;
            Repository = repository;
        }

        // GET: api/<UserController>
        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>IEnumerable<User>> </returns>
        [HttpGet]
        public ActionResult<IEnumerable<IUser>> Get()
        {
            Logger.LogInformation($"UserController:Get");
            return Ok(Repository.Users);
        }

        // GET api/<UserController>/Jim
        /// <summary>
        /// Get a user by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>User</returns>

        [HttpGet("{name}")]
        public ActionResult<IUser> Get(string name)
        {
            IUser user = Repository.GetUser(name);
            Logger.LogInformation($"UserController:Get {name}");
            if (user == null)
            {
                Logger.LogWarning($"UserController:Get {name} Not Found");
                return NotFound($"User not found: {name}");
            }

            return Ok(user);
        }

        // POST api/<UserController>
        /// <summary>
        /// Add a new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>string</returns>
        [HttpPost]
        public ActionResult Post([FromBody] IUser user)
        {
            if (user != null && !string.IsNullOrEmpty(user.Name))
            {
                if (Repository.GetUser(user.Name) == null)
                {
                    Logger.LogInformation($"UserController:Post {user.Name}");

                    Repository.AddUser(user);
                    return Ok();
                }
                Logger.LogWarning($"UserController:Post {user.Name} User Exists");
                return Accepted("User already exists!");
            }

            return BadRequest("Invalid user passed.");
        }

        // DELETE api/<UserController>/John
        /// <summary>
        /// delete a user
        /// </summary>
        /// <param name="name"></param>
        /// <returns>string</returns>
        [HttpDelete("{name}")]
        public ActionResult Delete(string name)
        {
            var user = Repository.Users.FirstOrDefault(u => u.Name == name);
            if (user != null)
            {
                Repository.Users.Remove(user);
                Logger.LogInformation($"UserController:Delete {name}");
                return Ok();
            }
            else
            {
                Logger.LogWarning($"UserController:Delete {name} doesnt exist");
                return NotFound();

            }
        }
    }
}
