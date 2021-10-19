using Airbox.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Airbox.Entities
{
    public class User: IUser
    {
        private readonly List<Tuple<string, DateTime>> _history = new List<Tuple<string, DateTime>>();
        private Location _location;

        public string Name { get; set; }

        public Location Location 
        {
            get { return _location;  }

            set
            {
                if (_history.Count == 0)
                {
                    _location = value;
                    _history.Add(new Tuple<string, DateTime>(value.Name, DateTime.Now));
                }


                if (value != null && _history.Count > 0 && value.Name != _history.Last().Item1)
                {
                    _history.Add(new Tuple<string, DateTime>(value.Name, DateTime.Now));
                    _location = value;
                }
            }
        }
        public List<Tuple<string, DateTime>> History { get { return _history; } }

        public void Clear()
        {
            _history.Clear();
        }
    }
}
