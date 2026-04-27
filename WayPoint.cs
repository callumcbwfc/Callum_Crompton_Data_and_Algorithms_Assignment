using System;

namespace StarterCode_WayPoints
{
    // WayPoint class for one GPS waypoint, storing data for a waypoints from the provided CSV file.
    // Starting this after looking at Week 3 Powerpoints and  recalling previous lab session knowledge
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

        // Getters and Setters will be added next
    }
}