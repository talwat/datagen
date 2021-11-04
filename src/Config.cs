using Tommy;
using static Logging.Logging;
using System.IO;

namespace Config {
    public class Config {
        public static TomlTable configTable;
        public static void LoadConfig() {
            if(File.Exists("config.toml")) {
                if(Variables.Variables.core) { Log(Lang.Lang.messages["loadingConfig"]); }
                StreamReader reader = File.OpenText("config.toml");
                configTable = TOML.Parse(reader);
                if(Variables.Variables.core) { Log(Lang.Lang.messages["doneLoadingConfig"] + "\n", "success"); }
            }
            else {
                if(Variables.Variables.core) { 
                    Log(Lang.Lang.messages["configNotFound"], "error");
                    Log(Lang.Lang.messages["downloadingConfig"]);
                    Download.Download.DownloadFile("https://raw.githubusercontent.com/talwat/datagen/master/src/configTemplate.toml", "config.toml", false, false);
                    Log(Lang.Lang.messages["doneDownloadingConfig"] + "\n", "success");
                }
                else {
                    Download.Download.DownloadFile("https://raw.githubusercontent.com/talwat/datagen/master/src/configTemplate.toml", "config.toml", false, false);
                }
                StreamReader reader = File.OpenText("config.toml");
                configTable = TOML.Parse(reader);
            }
        }
    }
}
