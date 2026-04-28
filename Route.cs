using System;

namespace StarterCode_WayPoints
{
    // Route class - this holds an ordered list of waypoints as a linked list
    public class Route
    {
        private RouteLink head; // points to first waypoint in the route
        private string routeName; // name of route, e.g. "DaltonBuilding"

        // Constructor creates a new empty route with a name
        public Route(string name)
        {
            routeName = name;
            head = null; // route starts empty
        }

        // AddWaypoint, adds a waypoint to the end of the route
        public void AddWaypoint(WayPoint wp)
        {
            RouteLink newLink = new RouteLink(wp);

            if (head == null)
            {
                head = newLink;      // first waypoint in the route
            }
            else
            {
                RouteLink current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newLink;
            }
        }

        // Inner class for each link in the route
        //routelink holds a waypoint and points to the next link
        private class RouteLink
        {
            public WayPoint Data { get; set; }
            public RouteLink Next { get; set; }

            public RouteLink(WayPoint wp)
            {
                Data = wp;
                Next = null;
            }
        }        // DisplayRoute shows the name and all waypoints in the route
        public void DisplayRoute()
        {
            Console.WriteLine("Route :" + routeName + ":");

            RouteLink current = head;
            while (current != null)
            {
                current.Data.Display();
                current = current.Next;
            }

            Console.WriteLine("End of route.\n");
        }
    }
}