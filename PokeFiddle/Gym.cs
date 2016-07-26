using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllEnum;

namespace PokeFiddle
{
    public class Gym
    {
        public double latitude, longitude;
        public string name;
        public TeamColor ownedTeam;
        public GMap.NET.WindowsForms.Markers.GMarkerGoogle marker;

        public Gym(double lat, double lon, string n, TeamColor c, GMap.NET.WindowsForms.Markers.GMarkerGoogle m)
        {
            latitude = lat;
            longitude = lon;
            name = n;
            ownedTeam = c;
            marker = m;
        }
    }
}
