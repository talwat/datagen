//Command to close the program.

public class quit_Command {
    public static void quit(string[] inputFinal) {
        //Checking if the program is in core mode.
        if(Variables.Variables.core) {
            //Closing the program.
            System.Environment.Exit(0);
        }
        else {
            Logging.Logging.Log(Lang.Lang.messages["coreOnly"], "error");
        }
    }
}