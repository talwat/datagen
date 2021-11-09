using Tommy; //For reading from the config file.
using static Logging.Logging; //For logging to the console.
using System.IO; //For checking if the config file exists.
using static Download.Download; //For downloading the config file.

namespace Config {
    public class Config {
        public static TomlTable configTable;
        public static void LoadConfig(bool hardCodeLang = false) {
            if(File.Exists("config.toml")) {
                if(hardCodeLang && Variables.Variables.core) { Log("Loading config file..."); }
                else if(Variables.Variables.core) { Log(Lang.Lang.messages["loadingConfig"]); }
                StreamReader reader = File.OpenText("config.toml");
                configTable = TOML.Parse(reader);
                if(hardCodeLang && Variables.Variables.core) { Log("Done loading config file!\n", "success"); }
                else if(Variables.Variables.core) { Log(Lang.Lang.messages["doneLoadingConfig"] + "\n", "success"); }
            }
            else if(Variables.Variables.windows) {
                if(hardCodeLang && Variables.Variables.core) {
                    Log("Config File not found.", "error");
                    Log("Downloading latest config file from the internet...");
                    DownloadFile("https://raw.githubusercontent.com/talwat/datagen/master/src/configTemplate.toml", "config.toml", false, false);
                    Log("Downloaded latest config file!\n", "success");
                }
                else if(Variables.Variables.core) { 
                    Log(Lang.Lang.messages["configNotFound"], "error");
                    Log(Lang.Lang.messages["downloadingConfig"]);
                    DownloadFile("https://raw.githubusercontent.com/talwat/datagen/master/src/configTemplate.toml", "config.toml", false, false);
                    Log(Lang.Lang.messages["doneDownloadingConfig"] + "\n", "success");
                }
                else {
                    DownloadFile("https://raw.githubusercontent.com/talwat/datagen/master/src/configTemplate.toml", "config.toml", false, false);
                }
                StreamReader reader = File.OpenText("config.toml");
                configTable = TOML.Parse(reader);
            }
        }
    }
}
