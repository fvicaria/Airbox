using Airbox.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Airbox.Entities
{
    public class User: IUser
    {
        private readonly List<(string, DateTime)> _history = new List<(string, DateTime)>();
        private ILocation _location;

        public string Name { get; set; }

        public ILocation Location 
        {
            get { return _location;  }

            set
            {
                if (_history.Count == 0)
                {
                    _location = value;
                    _history.Add((value.Name, DateTime.Now));
                }


                if (value != null && _history.Count > 0 && value.Name != _history.Last().Item1)
                {
                    _history.Add((value.Name, DateTime.Now));
                    _location = value;
                }
            }
        }
        public IList<(string, DateTime)> History { get { return _history; } }

        public void Clear()
        {
            _history.Clear();
        }
    }
}
