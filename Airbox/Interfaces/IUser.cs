using System.Collections.Generic;

namespace Airbox.Interfaces
{
    public interface IUser
    {
        ILocation Location { get; set; }
        string Name { get; set; }
        IList<ILocation> History { get; }

        void AddLocation(ILocation location);
    }
}