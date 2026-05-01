using System;

namespace StarterCode_WayPoints
{
    // WaypointStore, holds all of the waypoints in an array
    //Client asked for something compact for the large list of waypoints in the csv file
    public class WaypointStore
    {
        private WayPoint[] waypoints; //the actual array that holds the waypoints
        private int count;   // how many waypoints added so far

        // Constructor - creates the array of any given size
        //arrays are a fixed size so knowing the size is necessary first
        public WaypointStore(int maxSize)
        {
            waypoints = new WayPoint[maxSize];
            count = 0; //nothing added yet
        }

        // AddWaypoint method, adds a waypoint to the next available space in the array.
        // from week 4's Stack and Queue examples from lecture and labs. 
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
        //DisplayAll, loops through the array and displays every waypoint in csv file
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
            return null!; // not found           // '!' added to remove warning, ! tells VS that it cannot be null at this stage
        }
        // SearchByHeight method finds waypoints under a given height
        // Another extra feature for Distinction marks
        public void SearchByHeight(int maxHeight)
        {
            Console.WriteLine("=== Waypoints under " + maxHeight + "m ===");

            for (int i = 0; i < count; i++)
            {
                if (waypoints[i].Elevation <= maxHeight)
                {
                    waypoints[i].Display();
                }
            }

            Console.WriteLine("=== End of height search ===\n");
        }
    }
}