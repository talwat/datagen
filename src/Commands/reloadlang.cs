//Reload Language Files
public class reloadlang_Command {
    public static void reloadlang(string[] finalInput) {
        Logging.Logging.Log(Lang.Lang.messages["langFilesReloadAsk"], "y/n");
        string answer = System.Console.ReadLine().ToLower();
        if(Input.Input.AnswerToBool(answer)) {
            Lang.Lang.LoadLang();
            Logging.Logging.Log(Lang.Lang.messages["langFilesReloaded"], "success");
        }
        else {
            return;
        }
    }
}