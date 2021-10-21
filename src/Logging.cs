using System;
using System.Collections.Generic;
using Pastel;

namespace Logging {
    class Logging {
        private static Dictionary<string, string> logTypes = new Dictionary<string, string>() {
            {"success", "[" + "Success".Pastel(System.Drawing.Color.Green) + "]"},
            {"info", "[" + "Info".Pastel(System.Drawing.Color.CornflowerBlue) + "]"},
            {"input", "[" + "Input".Pastel(System.Drawing.Color.Cyan) + "]"},
            {"warn", "[" + "Warn".Pastel(System.Drawing.Color.Orange) + "]"},
            {"error", "[" + "Error".Pastel(System.Drawing.Color.Red) + "]"},
            {"fatal", "[" + "Fatal".Pastel(System.Drawing.Color.DarkRed) + "]"}
        };
        public static void Log(string message, string type = "info") {
            Console.WriteLine(logTypes[type] + " 》 " + message);
        }
    }
}