namespace Noesis.WeatherMap.API.Models
{
    public class UserFavViewModel
    {
        public int Id { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int UserId { get; set; }
    }
}
