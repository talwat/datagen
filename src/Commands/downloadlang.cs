//Download Language Files

using static Lang.Lang; //For accessing language variables.
using System.IO; //For editing directories.
using static Download.Download; //For downloading files.

public class downloadlang_Command {
    public static void downloadlang(string[] finalInput) {
        //Asking if the user wants to download the language files and checking the answer.
        Logging.Logging.Log("Are you sure you want to download the latest language files?", "y/n");
        string answer = System.Console.ReadLine().ToLower();
        if(Input.Input.AnswerToBool(answer)) {
            if(Directory.Exists("lang")) {
                Directory.Delete("lang", true);
            }
            Directory.CreateDirectory("lang");

            //Downloading files
            DownloadFile("https://raw.githubusercontent.com/talwat/datagen/master/src/lang/lang.txt", "lang/lang.txt", true, false);
            DownloadFile("https://raw.githubusercontent.com/talwat/datagen/master/src/lang/credits.txt", "lang/credits.txt", true, false);
            DownloadFile("https://raw.githubusercontent.com/talwat/datagen/master/src/lang/help.txt", "lang/help.txt", true, false);

            //Loading files into variables.
            lines = File.ReadAllLines("lang/lang.txt");
            help = File.ReadAllText("lang/help.txt").Split("\n\n\n");
            credits = File.ReadAllText("lang/credits.txt");

            //Loading files.
            LoadLang();
            Logging.Logging.Log(messages["langFilesDownloaded"], "success");
        }
        else {
            return;
        }
    }
}