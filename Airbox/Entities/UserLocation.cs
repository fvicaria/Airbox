using Airbox.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Airbox.Entities
{
    // DTO 
    [Serializable]
    public class UserLocation: IUserLocation
    {
        public User User { get; set; }
        public Location Location { get; set; }
    }
}
