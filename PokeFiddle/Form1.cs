using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;
using System.Windows.Forms;
using GMap.NET.WindowsForms;
using GMap.NET.MapProviders;
using GMap.NET;
using Google.Protobuf;
using PokemonGo.RocketAPI.Enums;
using PokemonGo.RocketAPI.Extensions;
using PokemonGo.RocketAPI.GeneratedCode;
using PokemonGo.RocketAPI;
using PokemonGo.RocketAPI.Helpers;
using PokemonGo.RocketAPI.Login;
using AllEnum;

namespace PokeFiddle
{
    public partial class Form1 : Form
    {
        double lat = 30.283813;
        double lon = -81.388572;
        GMapOverlay overlay;
        public List<Pokemon> mPokemon;
        public List<Pokestop> mPokestops;
        public List<Gym> mGyms;
        public List<WildPokemon> addedPokemon;
        Client client;
        GMap.NET.WindowsForms.Markers.GMarkerGoogle locationMarker;
        bool fetching = false;
        bool mapCreated = false;
        GeoCoordinateWatcher watcher;


        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < pokemonList.Items.Count; i++)
            {
                pokemonList.SetItemChecked(i, true);
            }

            mMap.MapProvider = GoogleMapProvider.Instance;
            mMap.Position = new PointLatLng(lat, lon);
            mMap.MinZoom = 3;
            mMap.MaxZoom = 17;
            mMap.Zoom = 17;
            mMap.Manager.Mode = GMap.NET.AccessMode.ServerOnly;
            overlay = new GMapOverlay();
            mPokemon = new List<Pokemon>();
            mPokestops = new List<Pokestop>();
            mGyms = new List<Gym>();
            addedPokemon = new List<WildPokemon>();
            

            

            mMap.Overlays.Add(overlay);

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            FetchAll();
        }

        private void ClearMap()
        {
            overlay.Markers.Clear();
            overlay.Markers.Add(locationMarker);
            mPokemon.Clear();
            mGyms.Clear();
            mPokestops.Clear();
        }

        public async void FetchAll()
        {
            if (mapCreated)
                ClearMap();

            if (latText.Text == String.Empty || longText.Text == String.Empty)
            {
                MessageBox.Show("Click the map to set your location.");
                return;
            }

            
            fetching = true;
            btnLogin.Enabled = false;
            cbGyms.Enabled = false;
            cbPokemon.Enabled = false;
            cbPokestops.Enabled = false;

            int iterations = (int)nudIterations.Value;
            double precision = (double)numericUpDown1.Value;

            

            lat = Convert.ToDouble(latText.Text);
            lon = Convert.ToDouble(longText.Text);

            client = new Client(lat, lon);


            await client.DoPtcLogin(txtUser.Text, txtPassword.Text);


            await client.SetServer();

            System.Console.WriteLine("Server Fetched");
            var profile = await client.GetProfile();
            System.Console.WriteLine("Profile Fetched");
            var settings = await client.GetSettings();
            System.Console.WriteLine("Settings Fetched");
            var mapObjects = await client.GetMapObjects();
            System.Console.WriteLine("Objects Fetched");
            var inventory = await client.GetInventory();
            System.Console.WriteLine("Inventory Fetched");
            List<WildPokemon> pkmn = new List<WildPokemon>();
            List<FortData> pkstp = new List<FortData>();
            List<FortData> gym = new List<FortData>();


            var pk = mapObjects.MapCells.SelectMany(i => i.WildPokemons);
            var ps = mapObjects.MapCells.SelectMany(i => i.Forts).Where(i => i.Type == FortType.Checkpoint);
            var gy = mapObjects.MapCells.SelectMany(i => i.Forts).Where(i => i.Type == FortType.Gym);

            foreach (var pokemon in pk)
                pkmn.Add(pokemon);

            foreach (var pokestop in ps)
                pkstp.Add(pokestop);

            foreach (var _gym in gy)
                gym.Add(_gym);

            int val = 0;

            for(int x = 0; x < iterations + 1; x++)
            {
                val += 2;
                for(int d = 0; d < 2; d++)
                {
                    for (int y = 1; y < (iterations + 1) - x; y++)
                        val += 1;
                    for (int l = 1; l < (iterations + 1) - x; l++)
                        val += 1;
                }
                
            }

            //MessageBox.Show(val.ToString());
            progressBar.Maximum = val;
            progressBar.Value = 0;
            int value = 0;
            //Down
            for (int a = 0; a < iterations + 1; a++)
            {
                double newLat = lat - (precision * a);
                await client.UpdatePlayerLocation(newLat, lon);
                mapObjects = await client.GetMapObjects();

                //GMap.NET.WindowsForms.Markers.GMarkerGoogle marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(new PointLatLng(newLat, lon), GMap.NET.WindowsForms.Markers.GMarkerGoogleType.arrow);
                //marker.ToolTipText = newLat + "," + lon + ": #" + a;
                //Console.WriteLine(marker.ToolTipText);
                //overlay.Markers.Add(marker);

                var pokemons = mapObjects.MapCells.SelectMany(i => i.WildPokemons);
                foreach (var pokemon in pokemons)
                {
                    if(!pkmn.Contains(pokemon))
                    pkmn.Add(pokemon);
                }

                var pokeStops = mapObjects.MapCells.SelectMany(i => i.Forts).Where(i => i.Type == FortType.Checkpoint);
                foreach(var pokestop in pokeStops)
                {
                    if(!pkstp.Contains(pokestop))
                    pkstp.Add(pokestop);
                }

                var gyms = mapObjects.MapCells.SelectMany(i => i.Forts).Where(i => i.Type == FortType.Gym);
                foreach(var Gym in gyms)
                {
                    gym.Add(Gym);
                }

                AddPokemonLoop(pkmn);
                AddPokestopLoop(pkstp);
                AddGymsLoop(gym);

                progressBar.Value += 1;
                value += 1;
                //Left
                for (int b = 1; b < (iterations + 1) - a; b++)
                {
                    double newLon = lon - (precision * b);
                    await client.UpdatePlayerLocation(newLat, newLon);
                    mapObjects = await client.GetMapObjects();

                    // GMap.NET.WindowsForms.Markers.GMarkerGoogle marker1 = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(new PointLatLng(newLat, newLon), GMap.NET.WindowsForms.Markers.GMarkerGoogleType.arrow);
                    // marker1.ToolTipText = lat + "," + newLon + ": #" + a;
                    //Console.WriteLine(marker1.ToolTipText);
                    // overlay.Markers.Add(marker1);

                    var pokemons1 = mapObjects.MapCells.SelectMany(i => i.WildPokemons);
                    foreach (var pokemon in pokemons1)
                    {
                        if (!pkmn.Contains(pokemon))
                            pkmn.Add(pokemon);
                    }

                    var pokeStops1 = mapObjects.MapCells.SelectMany(i => i.Forts).Where(i => i.Type == FortType.Checkpoint);
                    foreach (var pokestop in pokeStops1)
                    {
                        if (!pkstp.Contains(pokestop))
                            pkstp.Add(pokestop);
                    }

                    var gyms1 = mapObjects.MapCells.SelectMany(i => i.Forts).Where(i => i.Type == FortType.Gym);
                    foreach (var Gym in gyms1)
                    {
                        gym.Add(Gym);
                    }

                    AddPokemonLoop(pkmn);
                    AddPokestopLoop(pkstp);
                    AddGymsLoop(gym);

                    progressBar.Value += 1;
                    value += 1;
                }

                //Right
                for (int c = 1; c < (iterations + 1) - a; c++)
                {
                    double newLon = lon + (precision * c);
                    await client.UpdatePlayerLocation(newLat, newLon);
                    mapObjects = await client.GetMapObjects();

                    //GMap.NET.WindowsForms.Markers.GMarkerGoogle marker2 = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(new PointLatLng(newLat, newLon), GMap.NET.WindowsForms.Markers.GMarkerGoogleType.arrow);
                    // marker2.ToolTipText = lat + "," + newLon + ": #" + a;
                    //Console.WriteLine(marker.ToolTipText);
                    // overlay.Markers.Add(marker2);

                    var pokemons2 = mapObjects.MapCells.SelectMany(i => i.WildPokemons);
                    foreach (var pokemon in pokemons2)
                    {
                        if (!pkmn.Contains(pokemon))
                            pkmn.Add(pokemon);
                    }

                    var pokeStops2 = mapObjects.MapCells.SelectMany(i => i.Forts).Where(i => i.Type == FortType.Checkpoint);
                    foreach (var pokestop in pokeStops2)
                    {
                        if (!pkstp.Contains(pokestop))
                            pkstp.Add(pokestop);
                    }

                    var gyms2 = mapObjects.MapCells.SelectMany(i => i.Forts).Where(i => i.Type == FortType.Gym);
                    foreach (var Gym in gyms2)
                    {
                        gym.Add(Gym);
                    }

                    AddPokemonLoop(pkmn);
                    AddPokestopLoop(pkstp);
                    AddGymsLoop(gym);

                    progressBar.Value += 1;
                    value += 1;
                }
            }

            //Up
            for(int a = 0; a <  iterations + 1; a++)
            {
                double newLat = lat + (precision * a);
                await client.UpdatePlayerLocation(newLat, lon);
                mapObjects = await client.GetMapObjects();

                // GMap.NET.WindowsForms.Markers.GMarkerGoogle marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(new PointLatLng(newLat, lon), GMap.NET.WindowsForms.Markers.GMarkerGoogleType.arrow);
                // marker.ToolTipText = newLat + "," + lon + ": #" + a;
                //Console.WriteLine(marker.ToolTipText);
                //overlay.Markers.Add(marker);

                var pokemons = mapObjects.MapCells.SelectMany(i => i.WildPokemons);
                foreach (var pokemon in pokemons)
                {
                    if (!pkmn.Contains(pokemon))
                        pkmn.Add(pokemon);
                }

                var pokeStops = mapObjects.MapCells.SelectMany(i => i.Forts).Where(i => i.Type == FortType.Checkpoint);
                foreach (var pokestop in pokeStops)
                {
                    if (!pkstp.Contains(pokestop))
                        pkstp.Add(pokestop);
                }

                var gyms = mapObjects.MapCells.SelectMany(i => i.Forts).Where(i => i.Type == FortType.Gym);
                foreach (var Gym in gyms)
                {
                    gym.Add(Gym);
                }

                AddPokemonLoop(pkmn);
                AddPokestopLoop(pkstp);
                AddGymsLoop(gym);

                progressBar.Value += 1;
                value += 1;
                //Left
                for (int b = 1; b < (iterations + 1) - a; b++)
                {
                    double newLon = lon - (precision * b);
                    await client.UpdatePlayerLocation(newLat, newLon);
                    mapObjects = await client.GetMapObjects();

                    // GMap.NET.WindowsForms.Markers.GMarkerGoogle marker1 = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(new PointLatLng(newLat, newLon), GMap.NET.WindowsForms.Markers.GMarkerGoogleType.arrow);
                    // marker1.ToolTipText = lat + "," + newLon + ": #" + a;
                    //Console.WriteLine(marker1.ToolTipText);
                    //overlay.Markers.Add(marker1);

                    var pokemons1 = mapObjects.MapCells.SelectMany(i => i.WildPokemons);
                    foreach (var pokemon in pokemons1)
                    {
                        if (!pkmn.Contains(pokemon))
                            pkmn.Add(pokemon);
                    }

                    var pokeStops1 = mapObjects.MapCells.SelectMany(i => i.Forts).Where(i => i.Type == FortType.Checkpoint);
                    foreach (var pokestop in pokeStops1)
                    {
                        if (!pkstp.Contains(pokestop))
                            pkstp.Add(pokestop);
                    }

                    var gyms1 = mapObjects.MapCells.SelectMany(i => i.Forts).Where(i => i.Type == FortType.Gym);
                    foreach (var Gym in gyms1)
                    {
                        gym.Add(Gym);
                    }

                    AddPokemonLoop(pkmn);
                    AddPokestopLoop(pkstp);
                    AddGymsLoop(gym);
                    progressBar.Value += 1;
                    value += 1;
                }

                //Right
                for (int c = 1; c < (iterations + 1) - a; c++)
                {
                    double newLon = lon + (precision * c);
                    await client.UpdatePlayerLocation(newLat, newLon);
                    mapObjects = await client.GetMapObjects();

                    //GMap.NET.WindowsForms.Markers.GMarkerGoogle marker2 = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(new PointLatLng(newLat, newLon), GMap.NET.WindowsForms.Markers.GMarkerGoogleType.arrow);
                    //marker2.ToolTipText = lat + "," + newLon + ": #" + a;
                    //Console.WriteLine(marker.ToolTipText);
                    //overlay.Markers.Add(marker2);

                    var pokemons2 = mapObjects.MapCells.SelectMany(i => i.WildPokemons);
                    foreach (var pokemon in pokemons2)
                    {
                        if (!pkmn.Contains(pokemon))
                            pkmn.Add(pokemon);
                    }

                    var pokeStops2 = mapObjects.MapCells.SelectMany(i => i.Forts).Where(i => i.Type == FortType.Checkpoint);
                    foreach (var pokestop in pokeStops2)
                    {
                        if (!pkstp.Contains(pokestop))
                            pkstp.Add(pokestop);
                    }

                    var gyms2 = mapObjects.MapCells.SelectMany(i => i.Forts).Where(i => i.Type == FortType.Gym);
                    foreach (var Gym in gyms2)
                    {
                        gym.Add(Gym);
                    }

                    AddPokemonLoop(pkmn);
                    AddPokestopLoop(pkstp);
                    AddGymsLoop(gym);
                    progressBar.Value += 1;
                    value += 1;

                }
            }

            //MessageBox.Show(value.ToString());
            mapCreated = true;
            fetching = false;
            btnLogin.Enabled = true;
            cbGyms.Enabled = true;
            cbPokemon.Enabled = true;
            cbPokestops.Enabled = true;
        }

        private async void AddGymsLoop(List<FortData> gys)
        {
            foreach (FortData gym in gys.ToList<FortData>())
            {

                if (GymOnMap(gym))
                    continue;

                double latitude = gym.Latitude;
                double longitude = gym.Longitude;

                GMap.NET.WindowsForms.Markers.GMarkerGoogle marker;

                if (gym.OwnedByTeam == TeamColor.Blue)
                    marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(new PointLatLng(latitude, longitude), GMap.NET.WindowsForms.Markers.GMarkerGoogleType.blue);
                else if (gym.OwnedByTeam == TeamColor.Red)
                    marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(new PointLatLng(latitude, longitude), GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red);
                else if (gym.OwnedByTeam == TeamColor.Yellow)
                    marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(new PointLatLng(latitude, longitude), GMap.NET.WindowsForms.Markers.GMarkerGoogleType.yellow);
                else
                    marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(new PointLatLng(latitude, longitude), GMap.NET.WindowsForms.Markers.GMarkerGoogleType.gray_small);

                var info = await client.GetFort(gym.Id, latitude, longitude);

                marker.ToolTipText = info.Name + "\n" + gym.GymPoints.ToString() + "\n" + Convert.ToString(gym.GuardPokemonId) + " - " + gym.GuardPokemonCp.ToString();

                if(redCheckBox.Checked && gym.OwnedByTeam == TeamColor.Red)
                    overlay.Markers.Add(marker);

                if(blueCheckBox.Checked && gym.OwnedByTeam == TeamColor.Blue)
                    overlay.Markers.Add(marker);

                if (yellowCheckBox.Checked && gym.OwnedByTeam == TeamColor.Yellow)
                    overlay.Markers.Add(marker);

                if(gym.OwnedByTeam == TeamColor.Neutral)
                    overlay.Markers.Add(marker);


                mGyms.Add(new Gym(latitude, longitude, info.Name, gym.OwnedByTeam, marker));
            }
        }

        bool GymOnMap(FortData gym)
        {
            foreach (GMap.NET.WindowsForms.Markers.GMarkerGoogle marker in overlay.Markers)
            {
                if (marker.Position.Lat == gym.Latitude && marker.Position.Lng == gym.Longitude)
                    return true;
            }

            return false;
        }

        private async void AddPokestopLoop(List<FortData> pkstp)
        {
            //if (pkstp.Count == 0) return;
            try
            {
                foreach (FortData pokestop in pkstp.ToList<FortData>())
                {
                    double latitude = pokestop.Latitude;
                    double longitude = pokestop.Longitude;

                    if (PokestopOnMap(pokestop))
                        continue;

                    var info = await client.GetFort(pokestop.Id, pokestop.Latitude, pokestop.Longitude);
                    //string playerName;
                    GMap.NET.WindowsForms.Markers.GMarkerGoogle marker;

                    bool lure = false;

                    if (info.Modifiers.Count > 0)
                    {
                        lure = true;
                        marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(new PointLatLng(latitude, longitude), GMap.NET.WindowsForms.Markers.GMarkerGoogleType.purple);
                    }
                    else
                    {
                        lure = false;
                        marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(new PointLatLng(latitude, longitude), GMap.NET.WindowsForms.Markers.GMarkerGoogleType.lightblue);
                    }


                    string name = "";
                    if(!lure)
                        name = info.Name;
                    else
                    {
                        //MessageBox.Show(info.Modifiers[0].ExpirationTimestampMs.ToString());
                        TimeSpan t = new TimeSpan(0, 0, 0, 0, (int)pokestop.LureInfo.LureExpiresTimestampMs);
                        string formatted = string.Format("{0:D2}:{1:D2}",
                        t.Minutes,
                        t.Seconds);
                        name = info.Name + "\n" + info.Modifiers[0].DeployerPlayerCodename + "\n" + formatted;
                    }
                        
                    marker.ToolTipText = name;


                    mPokestops.Add(new Pokestop(latitude, longitude, name, lure, marker));

                    if (checkBox1.Checked && lure)
                        overlay.Markers.Add(marker);
                    else if(!checkBox1.Checked)
                        overlay.Markers.Add(marker);
                }
            }
            catch(System.Reflection.TargetInvocationException ex)
            {
                MessageBox.Show(ex.ToString() + "\n" + ex.InnerException.ToString());
            }
            catch(InvalidOperationException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        bool PokestopOnMap(FortData pokestop)
        {
            foreach (GMap.NET.WindowsForms.Markers.GMarkerGoogle marker in overlay.Markers)
            {
                if (marker.Position.Lat == pokestop.Latitude && marker.Position.Lng == pokestop.Longitude)
                    return true;
            }

            return false;
        }

        private void AddPokemonLoop(List<WildPokemon> pkmn)
        {
            foreach (WildPokemon pokemon in pkmn)
            {
                if (PokemonOnMap(pokemon))
                    continue;
                string name = Convert.ToString(pokemon.PokemonData.PokemonId);

                


                addedPokemon.Add(pokemon);
                
                double latitude = pokemon.Latitude;
                double longitude = pokemon.Longitude;
                
                int cp = pokemon.PokemonData.Cp;
                //double timeLeft = Convert.ToDouble(pokemon.TimeTillHiddenMs);
                TimeSpan t = new TimeSpan(0, 0, 0, 0, pokemon.TimeTillHiddenMs);
                string formatted = string.Format("{0:D2}:{1:D2}",
                        t.Minutes,
                        t.Seconds);


                GMap.NET.WindowsForms.Markers.GMarkerGoogle marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(new PointLatLng(latitude, longitude), GMap.NET.WindowsForms.Markers.GMarkerGoogleType.green);
                marker.ToolTipText = name + "\n" + formatted;

                if(PokemonIsChecked(name))
                overlay.Markers.Add(marker);

                mPokemon.Add(new Pokemon(latitude, longitude, name, cp, marker));

                //SetPokemonMarkers();
            }
        }

        bool PokemonOnMap(WildPokemon pokemon)
        {
            foreach(GMap.NET.WindowsForms.Markers.GMarkerGoogle marker  in overlay.Markers)
            {
                if (marker.Position.Lat == pokemon.Latitude && marker.Position.Lng == pokemon.Longitude)
                    return true;
            }

            return false;
        }

        private void SetPokemonMarkers()
        {
            foreach(Pokemon p in mPokemon)
            {
                if (!PokemonIsChecked(p.name))
                    continue;

                if(!overlay.Markers.Contains(p.marker))
                {
                    overlay.Markers.Add(p.marker);
                }
                
            }
        }

        private void RemovePokemonMarkers()
        {
            foreach(Pokemon p in mPokemon)
            {
                overlay.Markers.Remove(p.marker);
            }
        }

        private void SetPokestopMarkers()
        {
            foreach(Pokestop p in mPokestops)
            {
                if (checkBox1.Checked && p.hasLure == false)
                    continue;

                if (!overlay.Markers.Contains(p.marker))
                    overlay.Markers.Add(p.marker);
            }
        }

        private void RemovePokestopMarkers()
        {
            foreach(Pokestop p in mPokestops)
            {
                overlay.Markers.Remove(p.marker);
            }
        }

        private void SetGymMarkers()
        {
            foreach(Gym g in mGyms)
            {
                //MessageBox.Show(g.ownedTeam.ToString());

                if (redCheckBox.Checked && g.ownedTeam == TeamColor.Red)
                    if (!overlay.Markers.Contains(g.marker))
                        overlay.Markers.Add(g.marker);

                if (blueCheckBox.Checked && g.ownedTeam == TeamColor.Blue)
                    if (!overlay.Markers.Contains(g.marker))
                        overlay.Markers.Add(g.marker);

                if (yellowCheckBox.Checked && g.ownedTeam == TeamColor.Yellow)
                    if (!overlay.Markers.Contains(g.marker))
                        overlay.Markers.Add(g.marker);
            }
        }

        private void RemoveGymMarkers()
        {
            foreach(Gym g in mGyms)
            {
                overlay.Markers.Remove(g.marker);
            }
        }

        private void cbPokemon_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPokemon.Checked == true)
                SetPokemonMarkers();
            else
                RemovePokemonMarkers();
        }

        private void cbPokestops_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPokestops.Checked == true)
                SetPokestopMarkers();
            else
                RemovePokestopMarkers();
        }

        private void cbGyms_CheckedChanged(object sender, EventArgs e)
        {
            if (cbGyms.Checked == true)
                SetGymMarkers();
            else
                RemoveGymMarkers();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value == 0.0m)
                numericUpDown1.Value = 0.001m;
        }

        private void nudIterations_ValueChanged(object sender, EventArgs e)
        {
            if (nudIterations.Value == 0m)
                nudIterations.Value = 1.0m;
        }

        private void mMap_MouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);

            double X = mMap.FromLocalToLatLng(e.X, e.Y).Lng;
            double Y = mMap.FromLocalToLatLng(e.X, e.Y).Lat;

            string longitude = X.ToString();
            string latitude = Y.ToString();
            currentLatLabel.Text = latitude;
            currentLonLabel.Text = longitude;
        }

        private void currentLonLabel_Click(object sender, EventArgs e)
        {
            
        }

        private void mMap_Click(object sender, EventArgs e)
        {
            //base.OnMouseMove(e);

            
        }

        private void mMap_MouseClick(object sender, MouseEventArgs e)
        {
            if (fetching)
                return;

            if (e.Button != System.Windows.Forms.MouseButtons.Left)
                return;

            if (locationMarker != null)
                overlay.Markers.Remove(locationMarker);

            double X = mMap.FromLocalToLatLng(e.X, e.Y).Lng;
            double Y = mMap.FromLocalToLatLng(e.X, e.Y).Lat;

            string longitude = X.ToString();
            string latitude = Y.ToString();

            latText.Text = latitude;
            longText.Text = longitude;

            lat = Y;
            lon = X;

            locationMarker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(new PointLatLng(lat, lon), GMap.NET.WindowsForms.Markers.GMarkerGoogleType.arrow);
            locationMarker.ToolTipText = "Current Location";
            overlay.Markers.Add(locationMarker);
        }

        private void locateBtn_Click(object sender, EventArgs e)
        {
            watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);

            watcher.PositionChanged += delegate { UpdateMap(watcher.Position); };
            watcher.Start();
        }

        private void UpdateMap(GeoPosition<GeoCoordinate> coord)
        {
            watcher.Stop();


            if (locationMarker != null)
                overlay.Markers.Remove(locationMarker);
            lat = coord.Location.Latitude;
            lon = coord.Location.Longitude;

            latText.Text = lat.ToString();
            longText.Text = lon.ToString();

            mMap.Position = new PointLatLng(coord.Location.Latitude, coord.Location.Longitude);

            locationMarker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(new PointLatLng(lat, lon), GMap.NET.WindowsForms.Markers.GMarkerGoogleType.arrow);
            locationMarker.ToolTipText = "Current Location";
            overlay.Markers.Add(locationMarker);

            
        }

        private void selectAllLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for(int i = 0; i < pokemonList.Items.Count; i++)
            {
                pokemonList.SetItemChecked(i, true);
            }

           
                SetPokemonMarkers();
        }

        private void deselectLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for (int i = 0; i < pokemonList.Items.Count; i++)
            {
                pokemonList.SetItemChecked(i, false);
            }

            
                RemovePokemonMarkers();
        }

        bool PokemonIsChecked(string name)
        {
            foreach(var item in pokemonList.CheckedItems)
            {
                if (name == item.ToString())
                    return true;
            }

            return false;
        }

        private void pokemonList_SelectedValueChanged(object sender, EventArgs e)
        {
            RemovePokemonMarkers();

            SetPokemonMarkers();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            RemovePokestopMarkers();

            SetPokestopMarkers();
        }

        private void DoCheckGym()
        {
            RemoveGymMarkers();

            SetGymMarkers();
        }

        private void redCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            DoCheckGym();
        }

        private void blueCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            DoCheckGym();
        }

        private void yellowCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            DoCheckGym();
        }
    }
}
