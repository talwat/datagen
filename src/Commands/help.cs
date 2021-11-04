//Help command.

public class help_Command {
    public static void help(string[] inputFinal) {
        if(Variables.Variables.core) {
            System.Console.WriteLine(Lang.Lang.help[0]);
        }
        else {
            System.Console.WriteLine(Lang.Lang.help[1]);
        }
    }
}