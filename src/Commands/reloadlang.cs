//Reload Language Files
public class reloadlang_Command {
    public static void reloadlang(string[] finalInput) {
        System.Console.WriteLine("Are you sure you want to reload the language files?");
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
            System.Console.WriteLine(Lang.Lang.messages["langFilesReloaded"]);
        }
        else {
            return;
        }
    }
}