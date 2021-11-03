//Command to download the source code.

using System.IO; //For making directories and files.
using static Logging.Logging; //For logging to the console.

public class source_Command {
    public static void source(string[] inputFinal) {
        Log(Lang.Lang.messages["sourceWarning"], "warn");
        
        //Detecting if the directories needed already exist, and if they do then delete them.
        if(Directory.Exists(Variables.Variables.path + "\\sourceIn")) {
            Directory.Delete(Variables.Variables.path + "\\sourceIn", true);
        }
        if(Directory.Exists(Variables.Variables.path + "\\source")) {
            Directory.Delete(Variables.Variables.path + "\\source", true);
        }
        if(File.Exists(Variables.Variables.path + "\\sourceZip.zip")) {
            File.Delete(Variables.Variables.path + "\\sourceZip.zip");
        }

        //Downloading the source code from the github repository
        Log(Lang.Lang.messages["downloadingFrom"]);
        Download.Download.DownloadFile("https://github.com/talwat/datagen/archive/refs/heads/master.zip", Variables.Variables.path + "\\sourceZip.zip");
        
        //Unzipping the downloaded folder.
        Log(Lang.Lang.messages["deleting"]);
        System.IO.Compression.ZipFile.ExtractToDirectory(Variables.Variables.path + "\\sourceZip.zip", Variables.Variables.path + "\\sourceIn");
        
        //Moving the folder inside the unzipped folder outside, so you wont have to open two folders to get to the source code.
        Log(Lang.Lang.messages["moving"]);
        Directory.Move(Variables.Variables.path + "\\sourceIn\\datagen-master", Variables.Variables.path + "\\source");

        //Deleting the zipped folder and the one which the source was in.
        Log(Lang.Lang.messages["deletingExcess"]);
        Directory.Delete(Variables.Variables.path + "\\sourceIn");
        File.Delete(Variables.Variables.path + "\\sourceZip.zip");

        //Saying that the download has been complete.
        Log(Lang.Lang.messages["done"], "success");
    }
}