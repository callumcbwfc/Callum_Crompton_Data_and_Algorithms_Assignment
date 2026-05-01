using System;

namespace StarterCode_WayPoints
{
    // Route class - this holds an ordered list of waypoints as a linked list
    public class Route

    { // '?' added to RouteLink totell visual studio it can be null, warning removed
        private RouteLink? head; // points to first waypoint in the route
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
            public RouteLink? Next { get; set; } // '?' added to RouteLink totell VS it can be null, warning removed

            public RouteLink(WayPoint wp)
            {
                Data = wp;
                Next = null;
            }
        } // DisplayRoute shows the name and all waypoints in the route, follows the requirements set by the client
        public void DisplayRoute()
        {
            Console.WriteLine("Route :" + routeName + ":");

            RouteLink? current = head; // '?' added, since head has been declared as null from our previous '?', current must be also be declared null
            while (current != null)
            {
                current.Data.Display();
                current = current.Next;
            }

            Console.WriteLine("End of route.\n");
        }
        //Insert method inserts a waypoint at a specific position
        // Position 1=front, too large=end
        //used in report for line by line analysis, added in code for additional marks
        public void InsertWaypoint(WayPoint wp, int position)
        {
            if (position <= 1)
            {
                // Is added to the front
                RouteLink newLink = new RouteLink(wp);
                newLink.Next = head;
                head = newLink;
                return;
            }

            RouteLink current = head!; // '!' tells VS this cannot be null at this point in the code
            int currentPos = 1;

            while (current != null && currentPos < position - 1)
            {
                current = current.Next!; // '!' added to remove warning, ! tells VS that it cannot be null at this stage
                currentPos++;
            }

            if (current == null)
            {
                // Position too large=theyre added to the end
                AddWaypoint(wp);
            }
            else
            {
                RouteLink newLink = new RouteLink(wp);
                newLink.Next = current.Next;
                current.Next = newLink;
            }
        }
        // RemoveWaypoint removes a waypoint from the route by its name, in case the route needs to change due to weather changes or safety issues.
        // Removes the first match found, used here as its in the marksheet for a higher grade percentage
        public void RemoveWaypoint(string waypointName)
        {
            if (head == null)
            {
                // if the route is empty/nothing to remove
                return;
            }

            // Checks if the first waypoint is the one that needs removing
            if (head.Data.Name.Equals(waypointName))
            {
                head = head.Next;   // removes the first link
                return;
            }

            // Looks through the rest of the route
            RouteLink current = head!; // '!' tells VS this cannot be null at this point in the code
            while (current.Next != null)
            {
                if (current.Next!.Data.Name.Equals(waypointName))
                {
                    current.Next = current.Next.Next;   // skips over the one that needs removing
                    return;
                }
                current = current.Next;
            }
        }
        //Reverse the route/reverses the order of waypoints
        //Additional feature for Distinction marks
        public void ReverseRoute()
        {
            if (head == null || head.Next == null)
                return;   // nothing to reverse

            RouteLink previous = null!; // '!' added to remove warning, ! tells VS that it cannot be null at this stage
            RouteLink current = head;
            RouteLink next = null!; // '!' added to remove warning, ! tells VS that it cannot be null at this stage

            while (current != null)
            {
                next = current.Next!;
                current.Next = previous;
                previous = current;
                current = next;
            }

            head = previous;
        }
    }
}