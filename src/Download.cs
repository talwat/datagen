using System;
using System.Net;

namespace Download {
    class Download {
        static WebClient webClient = new WebClient();
        public static int DownloadFile(string url, string destinationPath) {
            Console.WriteLine("Downloading " + url);
            try {
                webClient.DownloadFile(url, destinationPath);
                Console.WriteLine("Downloaded File Successfully!");
                return 0;
            }
            catch {
                Console.WriteLine("Download Failed.");
                return 1;
            }
        }
    }
}