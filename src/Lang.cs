using System.Collections.Generic;

namespace Lang {
    class Lang {
        public static Dictionary<string, string> messages = new Dictionary<string, string>();
        public static string[] lines;
        public static void LoadLang() {
            if(System.IO.Directory.Exists("@lang.txt")) {
                lines = System.IO.File.ReadAllLines(@"lang.txt");
            }
            else {
                System.Console.WriteLine("The language file can't be found.");
                System.Console.WriteLine("Would you like to download the latest language file from the github repository? (y/n)");
                string answer = System.Console.ReadLine();
                if(answer == "y") {
                    //Download Lang File
                }
                else {
                    System.Environment.Exit(0);
                }
            }
            foreach(string line in lines) {
                if(line != "" && !line.StartsWith("#")) {
                    messages.Add(line.Substring(0, line.IndexOf(":")), line.Substring(line.IndexOf(":") + 2, line.IndexOf("|") - 1 - line.IndexOf(":") - 1));
                }
            }
        }
    } 
}