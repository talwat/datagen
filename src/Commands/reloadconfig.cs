//Reload Language Files

public class reloadconfig_Command {
    public static void reloadconfig(string[] finalInput) {
        Logging.Logging.Log(Lang.Lang.messages["configReloadAsk"], "y/n");
        string answer = System.Console.ReadLine().ToLower();
        if(Input.Input.AnswerToBool(answer)) {
            Config.Config.LoadConfig();
            Logging.Logging.Log(Lang.Lang.messages["configReloaded"], "success");
        }
        else {
            return;
        }
    }
}