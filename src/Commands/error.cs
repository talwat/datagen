//Throws an error for debugging

public class error_Command {
    public static void error(string[] inputFinal) {
        if(Variables.Variables.core) {
            throw new System.Exception();
        }
        else {
            Logging.Logging.Log(Lang.Lang.messages["coreOnly"], "error");
        }
    }
}