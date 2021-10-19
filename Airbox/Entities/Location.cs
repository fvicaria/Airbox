
using Airbox.Interfaces;
using System;
using System.Collections.Generic;


namespace Airbox.Entities
{
    public class Location: ILocation
    {
        public string Name { get; set; }
        public string Area { get; set; }
    }
}
