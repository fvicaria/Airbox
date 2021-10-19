using Airbox.Entities;
using System.Collections.Generic;

namespace Airbox.Interfaces
{
    public interface IRepository
    {
        IList<ILocation> Locations { get; }
        IList<IUser> Users { get; }
        void AddLocation(ILocation location);
        void AddUser(IUser user);
        ILocation GetLocation(string name);
        IUser GetUser(string name);
    }
}