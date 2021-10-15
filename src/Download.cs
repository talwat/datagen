using System; //For printing to the console
using System.Net; //For Downloading Files

namespace Download {
    class Download {
        //Main web client for downloading files.
        static WebClient webClient = new WebClient();
        public static int DownloadFile(string url, string destinationPath, bool langHardCoded = false) {
            //Saying that the function has been called.
            if(langHardCoded == false) {
                Console.WriteLine(Lang.Lang.messages["downloadingFile"] + url);
                try {
                    //Downloading file from the internet.
                    webClient.DownloadFile(url, destinationPath + "...");

                    //Printing that the download succeeded to the console and then returning 0.
                    Console.WriteLine(Lang.Lang.messages["downloadSucceeded"]);
                    return 0;
                }
                catch {
                    //If an error was thrown, it will say that the download failed and return 1.
                    Console.WriteLine(Lang.Lang.messages["downloadFailed"]);
                    return 1;
                }
            }
            else {
                Console.WriteLine("Downloading " + url);
                try {
                    //Downloading file from the internet.
                    webClient.DownloadFile(url, destinationPath + "...");

                    //Printing that the download succeeded to the console and then returning 0.
                    Console.WriteLine("Downloaded File Successfully!");
                    return 0;
                }
                catch {
                    //If an error was thrown, it will say that the download failed and return 1.
                    Console.WriteLine("Download Failed.");
                    return 1;
                }
            }
        }
    }
}