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
        
            // Build the full path to the CSV file
            string fullPath = FILE_PATH + fileName;

            // Call the original method to read and display all waypoints
            readDisplayFileWayPoints(fullPath);

            Console.WriteLine("\n=== End of waypoints display ===");
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
    }
}