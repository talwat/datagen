//Download Language Files
using static Lang.Lang;

public class downloadlang_Command {
    public static void downloadlang(string[] finalInput) {
        System.Console.WriteLine("Are you sure you want to download the latest language files?");
        string answer = System.Console.ReadLine().ToLower();
        if(
            answer == "yes" 
            || answer == "y" 
            || answer == "yeah" 
            || answer == "yep" 
            || answer == "mhm" 
            || answer == "absolutely"
        ) {
            if(System.IO.Directory.Exists("lang")) {
                System.IO.Directory.Delete("lang", true);
            }
            if(!System.IO.Directory.Exists("lang")) {
                System.IO.Directory.CreateDirectory("lang");
            }
            Download.Download.DownloadFile("https://raw.githubusercontent.com/talwat/datagen/master/src/lang/lang.txt", "lang/lang.txt", true, false);
            Download.Download.DownloadFile("https://raw.githubusercontent.com/talwat/datagen/master/src/lang/credits.txt", "lang/credits.txt", true, false);
            Download.Download.DownloadFile("https://raw.githubusercontent.com/talwat/datagen/master/src/lang/help.txt", "lang/help.txt", true, false);
            lines = System.IO.File.ReadAllLines(@"lang/lang.txt");
            help = System.IO.File.ReadAllText("lang/help.txt");
            credits = System.IO.File.ReadAllText("lang/credits.txt");
            Lang.Lang.LoadLang();
            System.Console.WriteLine(messages["langFilesDownloaded"]);
        }
        else {
            return;
        }
    }
}