using System;

namespace Airbox.Interfaces

{
    public interface IUserLocation
    {
        IUser User { get; set; }
        ILocation Location { get; set; }
    }
}