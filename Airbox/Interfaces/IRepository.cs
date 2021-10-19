using Airbox.Entities;
using System.Collections.Generic;

namespace Airbox.Interfaces
{
    public interface IRepository
    {
        IList<Location> Locations { get; }
        IList<User> Users { get; }
        void AddLocation(Location location);
        void AddUser(User user);
        Location GetLocation(string name);
        User GetUser(string name);
    }
}