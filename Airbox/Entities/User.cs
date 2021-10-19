using Airbox.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Airbox.Entities
{
    public class User : IUser
    {
        private readonly List<ILocation> _history = new List<ILocation>();

        public string Name { get; set; }

        public ILocation Location
        { 
            get 
            {
                if (_history.Count > 0)
                    return _history.Last();
                else
                    return null;
            }
            set { _history.Add(value); }
        }
        public IList<ILocation> History { get { return _history; } }

        public void AddLocation(ILocation location)
        {
            if (location != null && _history.Count > 0 && location.Name != _history.Last().Name)
                _history.Add(location);
        }

        public void Clear()
        {
            _history.Clear();
        }
    }
}
