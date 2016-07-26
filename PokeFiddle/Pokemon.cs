using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeFiddle
{
    public class Pokemon
    {
        public double latitude, longitude;
        public string name;
        public int cp;
        public GMap.NET.WindowsForms.Markers.GMarkerGoogle marker;

        public Pokemon(double lat, double lon, string n, int _cp, GMap.NET.WindowsForms.Markers.GMarkerGoogle m)
        {
            latitude = lat;
            longitude = lon;
            name = n;
            cp = _cp;
            marker = m;
        }
    }
}
