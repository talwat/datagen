using static Logging.Logging; //For logging to the console
using System.Net; //For Downloading Files

namespace Download {
    class Download {
        //Main web client for downloading files.
        static WebClient webClient = new WebClient();
        public static int DownloadFile(string url, string destinationPath, bool langHardCoded = false, bool log = true) {
            //Saying that the function has been called.
            if(langHardCoded == false) {
                if(log == true) { Log(Lang.Lang.messages["downloadingFile"] + url); }
                try {
                    //Downloading file from the internet.
                    webClient.DownloadFile(url, destinationPath + "...");

                    //Printing that the download succeeded to the console and then returning 0.
                    if(log == true) { Log(Lang.Lang.messages["downloadSucceeded"], "success"); }
                    return 0;
                }
                catch {
                    //If an error was thrown, it will say that the download failed and return 1.
                    if(log == true) { Log(Lang.Lang.messages["downloadFailed"], "fatal"); }
                    return 1;
                }
            }
            else {
                if(log == true) { Log("Downloading " + url); }
                try {
                    //Downloading file from the internet.
                    webClient.DownloadFile(url, destinationPath + "...");

                    //Printing that the download succeeded to the console and then returning 0.
                    if(log == true) { Log("Downloaded File Successfully!", "success"); }
                    return 0;
                }
                catch {
                    //If an error was thrown, it will say that the download failed and return 1.
                    if(log == true) { Log("Download Failed.", "fatal"); }
                    return 1;
                }
            }
        }
    }
}