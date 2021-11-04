using System.Collections.Generic;
using static Logging.Logging;
namespace Lang {
    class Lang {
        //Dictionary to store strings from lang.txt
        public static Dictionary<string, string> messages = new Dictionary<string, string>();
        //Credits and help vars.
        public static string credits = "";
        public static string[] help = new string[] {"", ""};
        //Variable to store the raw lines from lang.txt
        public static string[] lines;
        public static void LoadLang(bool readFromFile = true) {
            //Resseting messages hashmap.
            messages = new Dictionary<string, string>();

            //Checking if the language files exist to read from them.
            if(
                   System.IO.File.Exists(@"lang/lang.txt")
                && System.IO.File.Exists(@"lang/help.txt")
                && System.IO.File.Exists(@"lang/credits.txt")
                && readFromFile == true
            ) {
                lines = System.IO.File.ReadAllLines(@"lang/lang.txt");
                help = System.IO.File.ReadAllText("lang/help.txt").Split("\n\n\n");
                credits = System.IO.File.ReadAllText("lang/credits.txt");
                Log(Lang.messages["langFilesReadFile"], "success");
                System.Console.WriteLine();
            }
            else if(readFromFile == false) {
                lines = Internet.Internet.View("https://raw.githubusercontent.com/talwat/datagen/master/src/lang/lang.txt").Split("\n");
                help = Internet.Internet.View("https://raw.githubusercontent.com/talwat/datagen/master/src/lang/help.txt").Split("\n\n\n");
                credits = Internet.Internet.View("https://raw.githubusercontent.com/talwat/datagen/master/src/lang/credits.txt");
                Log(Lang.messages["langFilesReadInternet"], "success");
                System.Console.WriteLine();
            }

            //If they dont, then it will ask to download it from the github repository.
            else {
                //Deleting the language directory. (To avoid having multiple of the same file)
                if(System.IO.Directory.Exists("lang")) {
                    System.IO.Directory.Delete("lang", true);
                }

                //Getting the answer.
                Log("The language files can't be found.", "error");
                Log("Would you like to download the latest language files, or would you like to read them from the internet? (d/i)", "input");
                string answer = System.Console.ReadLine();
                
                //Checking the answer.
                if(answer == "d" || answer == "download") {
                    //Downloading the language files and then reading from them.

                    //Checking if the directory lang doesn't exist, and if it doesn't then it will make it.
                    if(!System.IO.Directory.Exists("lang")) {
                        System.IO.Directory.CreateDirectory("lang");
                    }

                    //Downloading files..
                    Download.Download.DownloadFile("https://raw.githubusercontent.com/talwat/datagen/master/src/lang/lang.txt", "lang/lang.txt", true, false);
                    Download.Download.DownloadFile("https://raw.githubusercontent.com/talwat/datagen/master/src/lang/credits.txt", "lang/credits.txt", true, false);
                    Download.Download.DownloadFile("https://raw.githubusercontent.com/talwat/datagen/master/src/lang/help.txt", "lang/help.txt", true, false);
                    
                    //Loading files...
                    LoadLang();
                    Log(Lang.messages["langFilesDownloaded"], "success");
                }
                else if(answer == "i" || answer == "internet") {
                    LoadLang(false);
                }
                else {
                    //Closing the program.
                    System.Environment.Exit(0);
                }
            }

            //Inserting the raw lines into the dictionary.
            foreach(string line in lines) {
                //Checking if the line should be read. (If it isn't nothing and it doesn't start with '#')
                if(!Commands.Commands.OnlyContains(line, ' ') && !line.StartsWith("#")) {
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