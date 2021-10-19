using System.Collections.Generic;

namespace Lang {
    class Lang {
        //Dictionary to store strings from lang.txt
        public static Dictionary<string, string> messages = new Dictionary<string, string>();
        public static string credits = "";
        public static string help = "";
        //Variable to store the raw lines from lang.txt
        public static string[] lines;
        public static void LoadLang() {
            //Resseting messages hashmap.
            messages = new Dictionary<string, string>();

            //Trying to read from the language files.
            if(
                   System.IO.File.Exists(@"lang/lang.txt")
                && System.IO.File.Exists(@"lang/help.txt")
                && System.IO.File.Exists(@"lang/credits.txt")
            ) {
                lines = System.IO.File.ReadAllLines(@"lang/lang.txt");
                help = System.IO.File.ReadAllText("lang/help.txt");
                credits = System.IO.File.ReadAllText("lang/credits.txt");
            }

            //If it fails, then it will ask to download it from the github repository.
            else {
                //Deleting the language directory. (To avoid having multiple of the same file)
                if(System.IO.Directory.Exists("lang")) {
                    System.IO.Directory.Delete("lang", true);
                }

                //Getting the answer.
                System.Console.WriteLine("The language files can't be found.");
                System.Console.WriteLine("Would you like to download the latest language files from the github repository? (y/n)");
                string answer = System.Console.ReadLine();
                
                //Checking the answer.
                if(answer == "y") {
                    //Downloading the language files and then reading from them.
                    if(!System.IO.Directory.Exists("lang")) {
                        System.IO.Directory.CreateDirectory("lang");
                    }
                    Download.Download.DownloadFile("https://raw.githubusercontent.com/talwat/datagen/master/src/lang/lang.txt", "lang/lang.txt", true, false);
                    Download.Download.DownloadFile("https://raw.githubusercontent.com/talwat/datagen/master/src/lang/credits.txt", "lang/credits.txt", true, false);
                    Download.Download.DownloadFile("https://raw.githubusercontent.com/talwat/datagen/master/src/lang/help.txt", "lang/help.txt", true, false);
                    lines = System.IO.File.ReadAllLines(@"lang/lang.txt");
                    help = System.IO.File.ReadAllText("lang/help.txt");
                    credits = System.IO.File.ReadAllText("lang/credits.txt");
                }
                else {
                    //Closing the program.
                    System.Environment.Exit(0);
                }
            }

            //Inserting the raw lines into the dictionary.
            foreach(string line in lines) {
                //Checking if the line should be read. (If it isn't nothing and it doesn't start with '#')
                if(!Commands.Commands.OnlyContains(line, ' ') && !line.StartsWith("#") && !Commands.Commands.OnlyContains(line, ' ') ) {
                    //Getting the first and second part of the line, and adding it to the dictionary.
                    messages.Add(
                        line.Substring(0, line.IndexOf(":")), //Getting the first part.
                        line.Substring(line.IndexOf(":") + 2, (line.Length - 1) - line.IndexOf(":") - 1) //Getting the second part.
                    );
                }
            }
            
            //Removing the raw lines from ram.
            lines = new string[] {};
        }
    } 
}