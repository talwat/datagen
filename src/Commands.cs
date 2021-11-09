using System; //For printing to the console and using GetType().
using static Logging.Logging; //For logging to the console.
using static Variables.Variables; //For accessing some of the global variables.
using System.Reflection; //For invoking a function based on strings.

namespace Commands {
    public class Commands {
        //Checks if a string only contains a particular character.
        public static bool OnlyContains(string input, char contains) {
            if(input == "") {
                return true;
            }
            else {
                foreach(char character in input) {
                    if(character != contains) {
                        return false;
                    }
                }
                return true;
            }
        }
        public static void GetInput() {
            //Writes the path and ">"
            Console.Write(path + ">");

            //Gets the raw input and splits it to get the arguments and main command.
            rawInput = Console.ReadLine();
            string[] inputFinal = rawInput.Split(" ");
            inputFinal[0] = inputFinal[0].ToLower();

            //Invokes a method from the input
            if(InvokeFromString(inputFinal[0] + "_Command", inputFinal[0], new object[] {inputFinal}, inputFinal) == 5) {
                //Prints that the command is not found if the method returns "5".
                Log("\'" + inputFinal[0] + "\' " + Lang.Lang.messages["commandNotFound"], "error");
            }
            Console.WriteLine();
            //Repeats function to get another command.
            GetInput();
        }
        public static int InvokeFromString(string classInput, string methodInput, object[] args, string[] inputFinal) {
            try {
                //Checks if the class doesn't exist, if it doesn't, then return 5.
                if(Type.GetType(classInput) == null) {
                    return 5;
                }
                else {
                    //Gets the class based on the string input.
                    Type t = Type.GetType(classInput);

                    //Gets the function based on the other string input.
                    MethodInfo method = t.GetMethod(methodInput, BindingFlags.Static | BindingFlags.Public);

                    //Invokes the method, and returns 0.
                    method.Invoke(null, args);
                    return 0;
                }
            }
            catch(Exception error) {
                //Prints out an error message if an error occured.
                if(error.InnerException is System.Collections.Generic.KeyNotFoundException) {
                    Log("A language error occured.\nRun 'downloadlang' to download the latest language files.", "error");
                }
                else {
                    Log(Lang.Lang.messages["error"], "fatal");
                    if(Config.Config.configTable["errors"]["showExeptions"] && windows) { Console.WriteLine(Convert.ToString(error.GetBaseException())); }
                    //Checks if the option "logErrors" is true.

                    if(!windows) {
                        LogFile(inputFinal, error);
                        return 0;
                    }
                    if(Convert.ToBoolean(Config.Config.configTable["errors"]["logErrors"].ToString())) {
                        LogFile(inputFinal, error);
                        return 0;
                    }
                }
                return 1;
            }
        }

        public static void LogFile(string[] inputFinal, Exception error) {
            //Creating a log with the name as the date of the error.
            if(!System.IO.Directory.Exists("logs")) {
                System.IO.Directory.CreateDirectory("logs");   
            }
            string date = DateTime.Now.ToString("yyyy.M.dd");
            string time = DateTime.Now.ToString("hh.mm tt");
            TextFile.TextFile.TextFileMake("logs/error " + date + " " + time + ".txt", date + " " + time + "\nHappened while executing command: " + inputFinal[0] + "\n\n" + Convert.ToString(error.GetBaseException()));
        }
    }
}