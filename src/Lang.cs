using System.Collections.Generic; //For using lists.
using System.IO; //For managing files and directories.
using static Logging.Logging; //For logging to the console.
using static Download.Download; //For downloading files.
using static Internet.Internet; //For viewing files from the internet.
namespace Lang {
    class Lang {
        //Dictionary to store strings from lang.txt
        public static Dictionary<string, string> messages = new Dictionary<string, string>();
        //Credits and help vars.
        public static string credits = "";
        public static string[] help = new string[] {"", ""};
        //Variable to store the raw lines from lang.txt
        public static string[] lines;
        public static void LoadLang(bool readFromFile = true, bool loadAgain = false) {
            //Resseting messages hashmap.
            messages = new Dictionary<string, string>();

            //Checking if the language files exist to read from them.
            if(
                   File.Exists(@"lang/lang.txt")
                && File.Exists(@"lang/help.txt")
                && File.Exists(@"lang/credits.txt")
                && readFromFile == true
            ) {
                lines = File.ReadAllLines(@"lang/lang.txt");
                help = File.ReadAllText("lang/help.txt").Split("\n\n\n");
                credits = File.ReadAllText("lang/credits.txt");
                
            }
            else if(readFromFile == false) {
                lines = View("https://raw.githubusercontent.com/talwat/datagen/master/src/lang/lang.txt").Split("\n");
                help = View("https://raw.githubusercontent.com/talwat/datagen/master/src/lang/help.txt").Split("\n\n\n");
                credits = View("https://raw.githubusercontent.com/talwat/datagen/master/src/lang/credits.txt");
            }

            //If they dont, then it will ask to download it from the github repository.
            else {
                //Deleting the language directory. (To avoid having multiple of the same file)
                if(Directory.Exists("lang")) {
                    Directory.Delete("lang", true);
                }

                //Answer Variable
                string answer = "";

                if(Variables.Variables.windows) {
                    //Getting the config file.
                    string configLang = Config.Config.configTable["lang"]["read"].ToString().ToLower();
                    
                    //Checking the config file.
                    switch(configLang) {
                        case "a":
                        case "ask":
                            //Getting the answer from the user if the config option is 'ask'.
                            Log("The language files can't be found.", "error");
                            Log("Would you like to download the latest language files, or would you like to read them from the internet? (d/i)", "input");
                            answer = System.Console.ReadLine();
                        break;
                        case "i":
                        case "internet":
                            answer = "i";
                        break;
                        case "d":
                        case "download":
                            answer = "d";
                        break;
                    }
                }
                else {
                    answer = "i";
                }
                
                //Checking the answer.
                if(answer == "d" || answer == "download") {
                    //Downloading the language files and then reading from them.

                    //Checking if the directory lang doesn't exist, and if it doesn't then it will make it.
                    if(!Directory.Exists("lang")) {
                        Directory.CreateDirectory("lang");
                    }

                    //Downloading files..
                    DownloadFile("https://raw.githubusercontent.com/talwat/datagen/master/src/lang/lang.txt", "lang/lang.txt", true, false);
                    DownloadFile("https://raw.githubusercontent.com/talwat/datagen/master/src/lang/credits.txt", "lang/credits.txt", true, false);
                    DownloadFile("https://raw.githubusercontent.com/talwat/datagen/master/src/lang/help.txt", "lang/help.txt", true, false);
                    
                    //Loading files...
                    LoadLang(true, true);
                    Log(Lang.messages["langFilesDownloaded"], "success");
                    Log(Lang.messages["langFilesReadFile"], "success");
                    System.Console.WriteLine();
                }
                else if(answer == "i" || answer == "internet") {
                    LoadLang(false, true);
                    Log(Lang.messages["langFilesReadInternet"], "success");
                    System.Console.WriteLine();
                }
                else {
                    //Closing the program.
                    System.Environment.Exit(0);
                }
            }
            
            //Loading Message
            if(!loadAgain && Variables.Variables.core) { Log("Loading lang files..."); }
            
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
            
            //Done Loading Message
            if(!loadAgain && Variables.Variables.core) { Log("Done loading lang files!\n", "success"); }

            //Removing the raw lines from ram.
            lines = new string[] {};
        }
    } 
}