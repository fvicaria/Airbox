using System;
using System.Collections.Generic;

namespace Airbox.Entities
{
    public interface IUser
    {
        public string Name { get; set; }

        public Location Location { get; set; }
        public List<Tuple<string, DateTime>> History { get; }

        public void Clear();
    }
}