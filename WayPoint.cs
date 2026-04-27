using System;

namespace StarterCode_WayPoints
{
    // WayPoint class for one GPS waypoint, storing data for a waypoints from the provided CSV file.
    // Starting this class after looking at Week 3 Powerpoints and recalling previous lab session knowledge
    public class WayPoint
    {
        // private fields
        private string name;
        private string code;
        private string latitude;
        private string longitude;
        private int elevation; // measures the height in metres
        private string description;

        // Constructor, will setup a new waypoint when its created in the future
        public WayPoint(string name, string code, string latitude,
                        string longitude, int elevation, string description)
        {
            this.name = name;
            this.code = code;
            this.latitude = latitude;
            this.longitude = longitude;
            this.elevation = elevation;
            this.description = description;
        }

        // Getters and Setters
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        public string Latitude
        {
            get { return latitude; }
            set { latitude = value; }
        }

        public string Longitude
        {
            get { return longitude; }
            set { longitude = value; }
        }

        public int Elevation
        {
            get { return elevation; }
            set { elevation = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        // Display method, shows the waypoint in the format the client requested, as described in the assingment brief
        public void Display()
        {
            Console.WriteLine("{" + Name + ", " + Code +
                              ", pos[" + Longitude + "," + Latitude +
                              "], h:" + Elevation + "m " + Description + "}");
        }
    }
}