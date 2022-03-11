using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noesis.WeatherMap.Data.Entities
{
    public class Favorite
    {
        public int Id { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public User Users { get; set; }
    }
}
