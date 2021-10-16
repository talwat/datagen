using System.Collections.Generic;

namespace Lang {
    class Lang {
        //Dictionary to store strings from lang.txt
        public static Dictionary<string, string> messages = new Dictionary<string, string>();
        //Variable to store the raw lines from lang.txt
        public static string[] lines;
        public static void LoadLang() {
            //Checking if lang.txt exists, and if it does then it reads from it.
            if(System.IO.File.Exists(@"lang.txt")) {
                lines = System.IO.File.ReadAllLines(@"lang.txt");
            }

            //If it doesn't, then it will ask to download it from the github repository.
            else {
                //Getting the answer.
                System.Console.WriteLine("The language file can't be found.");
                System.Console.WriteLine("Would you like to download the latest language file from the github repository? (y/n)");
                string answer = System.Console.ReadLine();
                
                //Checking the answer.
                if(answer == "y") {
                    //Downloading lang.txt and then reading from it.
                    Download.Download.DownloadFile("https://raw.githubusercontent.com/talwat/datagen/master/src/lang.txt", "lang.txt", true);
                    lines = System.IO.File.ReadAllLines(@"lang.txt");
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