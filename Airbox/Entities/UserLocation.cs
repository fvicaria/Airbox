using Airbox.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Airbox.Entities
{
    // DTO 
    [Serializable]
    public class UserLocation
    {
        public IUser User { get; set; }
        public ILocation Location { get; set; }
    }
}
