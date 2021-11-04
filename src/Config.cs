using Tommy;
using static Logging.Logging;
using System.IO;

namespace Config {
    public class Config {
        public static TomlTable configTable;
        public static void LoadConfig() {
            if(File.Exists("config.toml")) {
                if(Variables.Variables.core) { Log("Loading config file..."); }
                StreamReader reader = File.OpenText("config.toml");
                configTable = TOML.Parse(reader);
                if(Variables.Variables.core) { Log("Done loading config file!", "success"); }
            }
            else {
                if(Variables.Variables.core) { 
                    Log("Config File not found", "error");
                    Log("Downloading latest config file from the internet...");
                    Download.Download.DownloadFile("https://raw.githubusercontent.com/talwat/datagen/master/src/configTemplate.toml", "config.toml");
                    Log("Downloaded latest config file!", "success");
                }
                else {
                    Download.Download.DownloadFile("https://raw.githubusercontent.com/talwat/datagen/master/src/configTemplate.toml", "config.toml", false, false);
                }
                LoadConfig();
            }
        }
    }
}
