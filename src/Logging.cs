using System; //For writing to the console.
using System.Collections.Generic; //For using a dictionary.
using Pastel; //For having colored text.

namespace Logging {
    class Logging {
        //Logtypes definition
        private static Dictionary<string, string> logTypes = new Dictionary<string, string>() {
            {"success", "[" + "Success".Pastel(System.Drawing.Color.Green) + "]"},
            {"info", "[" + "Info".Pastel(System.Drawing.Color.CornflowerBlue) + "]"},
            {"input", "[" + "Input".Pastel(System.Drawing.Color.Cyan) + "]"},
            {"warn", "[" + "Warn".Pastel(System.Drawing.Color.Orange) + "]"},
            {"error", "[" + "Error".Pastel(System.Drawing.Color.Red) + "]"},
            {"fatal", "[" + "Fatal".Pastel(System.Drawing.Color.DarkRed) + "]"},
            {"y/n", "[" + "Y".Pastel(System.Drawing.Color.LawnGreen) +  "/" + "N".Pastel(System.Drawing.Color.IndianRed) + "]"}
        };
        public static void Log(string message, string type = "info") {
            Console.WriteLine(logTypes[type] + " 》 " + message);
        }
    }
}