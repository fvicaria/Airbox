using System;

namespace Airbox.Interfaces

{
    public interface ILocation
    {
        string Name { get; set; }
        string Area { get; set; }
        DateTime? Date { get; set; }
    }
}