public class cd_Command {
    public static void cd(string[] inputFinal) {
        if(inputFinal.Length == 1 || inputFinal[1] == " ") {
            System.Console.WriteLine(Variables.Variables.path);
        }
        else if(System.IO.Directory.Exists(inputFinal[1])) {
            if(inputFinal[1].Length == 2) {
                inputFinal[1] += "\\";
            }
            Variables.Variables.path = inputFinal[1];
        }
        else {
            System.Console.WriteLine(Lang.Lang.messages["filePathError"]);
        }
    }
}