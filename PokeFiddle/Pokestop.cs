using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeFiddle
{
    public class Pokestop
    {
        public double latitude, longitude;
        public string name;
        public bool hasLure = false;
        public GMap.NET.WindowsForms.Markers.GMarkerGoogle marker;

        public Pokestop(double lat, double lon, string n, bool lure, GMap.NET.WindowsForms.Markers.GMarkerGoogle m)
        {
            latitude = lat;
            longitude = lon;
            name = n;
            hasLure = lure;
            marker = m;
        }
    }
}
