//Reload Language Files
public class reloadlang_Command {
    public static void reloadlang(string[] finalInput) {
        Logging.Logging.Log("Are you sure you want to reload the language files?", "input");
        string answer = System.Console.ReadLine().ToLower();
        if(
            answer == "yes" 
            || answer == "y" 
            || answer == "yeah" 
            || answer == "yep" 
            || answer == "mhm" 
            || answer == "absolutely"
        ) {
            Lang.Lang.LoadLang();
            Logging.Logging.Log(Lang.Lang.messages["langFilesReloaded"], "success");
        }
        else {
            return;
        }
    }
}