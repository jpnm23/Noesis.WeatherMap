namespace Noesis.WeatherMap.API.Models
{
    public class WeatherViewModel
    {
        public string Lon { get; set; }
        public string Lat { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Temp { get; set; }
        public int FeelsLike { get; set; }
        public int Humidity { get; set; }
        public double Wind { get; set; }


    }
}
