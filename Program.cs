using System.Text;

namespace StarterCode_WayPoints
{
    internal class Program
    {
        // Same as starter code provided. path to data files
        static string FILE_PATH = "..\\..\\..\\";
        static string fileName = "UK_waypoints.csv";

        static void Main(string[] args)
        {
            Console.WriteLine("=== Waypoints Assignment ===\n");

            string fullPath = FILE_PATH + fileName;

            // Counts the waypoints and creates the store
            int numWaypoints = CountWaypointsInFile(fullPath);
            WaypointStore myStore = new WaypointStore(numWaypoints);

            // Reads the csv file into the store
            ReadFileIntoStore(fullPath, myStore);

            // Display using the store
            myStore.DisplayAll();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        // Main method from the starter code
        // Reads the CSV file and displays each waypoint
        static void readDisplayFileWayPoints(string fileName)
        {
            string[] linesInFile = File.ReadAllLines(fileName);
            int lineNumber = 0;

            foreach (string line in linesInFile)
            {
                lineNumber++;
                if (lineNumber != 1 && line != "")   // skips header and empty lines
                {
                    string[] featuresInLine = line.Split(',');

                    string name = featuresInLine[0];
                    string code = featuresInLine[1];
                    string latitude = featuresInLine[3];
                    string longitude = featuresInLine[4];
                    int elevation = convertElevationToMeters(featuresInLine[5]);
                    string description = buildDescription(featuresInLine);

                    displayWayPoint(name, code, latitude, longitude, elevation, description);
                }
            }
        }

        // Method to display one waypoint
        static void displayWayPoint(string name, string code, string latitude, string longitude, int elevation, string description)
        {
            Console.Write("WayPoint: " + name + ",Code:" + code);
            Console.Write(",Position:[" + latitude + "," + longitude + "]");
            Console.WriteLine(",Elevation:" + elevation + "m");
            Console.WriteLine(description);
        }

        // Builds the description because it can contain commas
        static string buildDescription(string[] featuresInLine)
        {
            StringBuilder description = new StringBuilder();
            int arrayPosition = 11;   // description starts at position 11
            while (arrayPosition < featuresInLine.Length)
            {
                string part = featuresInLine[arrayPosition];
                if (isText(part))
                {
                    description.Append(part + ",");
                }
                arrayPosition++;
            }
            return description.ToString();
        }

        static Boolean isText(string str)
        {
            if (str == "" || str == " ")
                return false;
            return true;
        }

        // Converts feet to metres if necessary
        static int convertElevationToMeters(string elevationStr)
        {
            char[] unitChars = { 'f', 't', 'M', 'm' };
            if (elevationStr.ToLower().EndsWith("m"))
            {
                return (int)Double.Parse(elevationStr.TrimEnd(unitChars));
            }

            double elevationFeet = Double.Parse(elevationStr.TrimEnd(unitChars));
            return (int)(elevationFeet / 3.142);
        }
        // Counts how many waypoints are in the file
        static int CountWaypointsInFile(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);
            int count = 0;
            int lineNumber = 0;

            foreach (string line in lines)
            {
                lineNumber++;
                if (lineNumber != 1 && line != "")
                {
                    count++;
                }
            }
            return count;
        }
        // Reads the UK_Waypoints.csv file and add each waypoint to the store
        static void ReadFileIntoStore(string fileName, WaypointStore store)
        {
            string[] lines = File.ReadAllLines(fileName);
            int lineNumber = 0;

            foreach (string line in lines)
            {
                lineNumber++;
                if (lineNumber != 1 && line != "")
                {
                    string[] parts = line.Split(',');

                    string name = parts[0];
                    string code = parts[1];
                    string lat = parts[3];
                    string lon = parts[4];
                    int elev = convertElevationToMeters(parts[5]);
                    string desc = buildDescription(parts);

                    WayPoint wp = new WayPoint(name, code, lat, lon, elev, desc);
                    store.AddWaypoint(wp);
                }
            }
        }
    }
}
