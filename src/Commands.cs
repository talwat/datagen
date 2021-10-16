using System; //For printing to the console and using GetType().
using static Variables.Variables; //For accessing some of the global variables.
using System.Reflection; //For invoking a function based on strings.

namespace Commands {
    class Commands {
        public static void GetInput() {
            //Writes the path and ">"
            Console.Write(Variables.Variables.path + ">");

            //Gets the raw input and splits it to get the arguments and main command.
            rawInput = Console.ReadLine();
            string[] inputFinal = rawInput.Split(" ");
            inputFinal[0] = inputFinal[0].ToLower();
            
            try {
                //Invokes a method from the input
                if(InvokeFromString(inputFinal[0] + "_Command", inputFinal[0], new object[] {inputFinal}) == 5) {
                    //Prints that the command is not found if the method returns "5".
                    Console.WriteLine("\'{0}\' " + Lang.Lang.messages["commandNotFound"], inputFinal[0]);
                }
            }
            catch {
                //Prints out an error message if an error occured.
                Console.WriteLine(Lang.Lang.messages["error"]);
            }
            Console.WriteLine();
            //Repeats function to get another command.
            GetInput();
        }
        public static int InvokeFromString(string classInput, string methodInput, object[] args) {
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
    }
}