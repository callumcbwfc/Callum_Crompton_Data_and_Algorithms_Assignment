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

        // AddWaypoint method, adds a waypoint to the next available space in the array. from week 4's Stack and Queue examples from lecture and labs.
        public void AddWaypoint(WayPoint wp)
        {
            if (count < waypoints.Length)
            {
                waypoints[count] = wp;
                count = count + 1;
            }
            else
            {
                Console.WriteLine("Store is full!");
            }
            // DisplayAll method, loops through the array and displays every waypoint
            {
                Console.WriteLine("=== All Waypoints (" + count + " total) ===");

                for (int i = 0; i < count; i++)
                {
                    waypoints[i].Display();
                }

                Console.WriteLine("=== End of waypoints ===\n");
            }
        }
        //DisplayAll, goes through the array and displays every waypoint
        public void DisplayAll()
        {
            Console.WriteLine("=== All Waypoints (" + count + " total) ===");

            for (int i = 0; i < count; i++)
            {
                waypoints[i].Display();
            }

            Console.WriteLine("=== End of waypoints ===\n");
        }
        // SearchByName method searches for a waypoint by name. Search feature in the marking criteria
        // Returns the first match or null if not found
        public WayPoint SearchByName(string nameToFind)
        {
            for (int i = 0; i < count; i++)
            {
                if (waypoints[i].Name.Equals(nameToFind))
                {
                    return waypoints[i];
                }
            }
            return null; // not found
        }
    }
}