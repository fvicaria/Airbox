namespace Airbox.Entities
{
    public interface IUserLocation
    {
        User User { get; set; }
        Location Location { get; set; }
    }
}