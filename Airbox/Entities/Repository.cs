using Airbox.Entities;
using Airbox.Interfaces;
using System.Collections.Generic;

namespace Airbox.Controllers
{
    public class Repository: IRepository
    {
        private static readonly List<Location> _locations = new()
        {
            new Location { Name = "USA", Area = "North America"},
            new Location { Name = "UK", Area = "Europe" },
            new Location { Name = "Japan", Area = "Asia" },
            new Location { Name = "Australia", Area = "Oceania" },
            new Location { Name = "Brazil", Area = "South America" },
            new Location { Name = "Mexico", Area = "North America" },
            new Location { Name = "France", Area = "Europe" },
        };
        private static readonly List<User> _users = new()
        {
            new User { Name = "John" },
            new User { Name = "Mary" },
            new User { Name = "Paul" },
        };

        // Locations
        // ===================================================
        public IList<Location> Locations 
        {
            get { return _locations; }
        }

        public void AddLocation(Location location)
        {
            if (location != null)
            {
                var result = _locations.Find(l => l.Name == location.Name);
                if (result == null)
                    _locations.Add(location);
            }
        }

        public Location GetLocation(string name)
        {
            return _locations.Find(l => l.Name == name);
        }


        // Users 
        // ===================================================
        public IList<User> Users
        {
            get { return _users; }
        }

        public void AddUser(User user)
        {
            if (user != null)
            {
                var result = _users.Find(l => l.Name == user.Name);
                if (result == null)
                    _users.Add(user);
            }
        }

        public User GetUser(string name)
        {
            return _users.Find(l => l.Name == name);
        }


        // Users 
        // ===================================================
    }
}
