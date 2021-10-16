//Command to switch the output path.

public class cd_Command {
    public static void cd(string[] inputFinal) {
        //Checking if the command is only "cd" to just display the path.
        if(inputFinal.Length == 1 || inputFinal[1] == " ") {
            System.Console.WriteLine(Variables.Variables.path);
        }

        //Checking if the directory the user wants to switch to exists.
        else if(System.IO.Directory.Exists(inputFinal[1])) {
            //Checking if the last character of the input path is a '\', in which case it will be removed.
            if(inputFinal[1].Substring(inputFinal[1].Length - 1) == "\\") {
                inputFinal[1] = inputFinal[1].Substring(0, inputFinal[1].Length - 1);
            }
            
            //Checking if the argument length is two, in which case it will append a '\'.
            if(inputFinal[1].Length == 2) {
                inputFinal[1] += "\\";
            }

            //Setting the path to the first argument. 
            Variables.Variables.path = inputFinal[1];
        }

        //If the file path doesn't exist, then it will write that the program can't find it.
        else {
            System.Console.WriteLine(Lang.Lang.messages["filePathError"]);
        }
    }
}