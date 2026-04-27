using System;

namespace StarterCode_WayPoints
{
    // WaypointStore, holds all of the waypoints in an array
    // Based on array-backed Stack and Queue examples from week 3 lecture powerpoint and lab session
    public class WaypointStore
    {
        private WayPoint[] waypoints;
        private int count;   // how many waypoints added so far

        // Constructor - creates the array of any given size
        public WaypointStore(int maxSize)
        {
            waypoints = new WayPoint[maxSize];
            count = 0;
        }

        // AddWaypoint method will be added next
    }
} 