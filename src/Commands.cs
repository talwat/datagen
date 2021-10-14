using System;
using static Variables.Variables;

namespace Commands {
    class Commands {
        public static void GetInput() {
            Console.Write(Variables.Variables.path + ">");
            input = Console.ReadLine();
            string[] inputFinal = input.Split(" ");
            try {
                if(inputFinal[0] == commands[0]) { //help
                    help_Command.help();
                }
                else if(inputFinal[0] == commands[1]) { //cd
                    cd_Command.cd(inputFinal);
                }
                else {
                    Console.WriteLine("\"" + inputFinal[0] + "\" is not a command.");
                }
            }
            catch {
                Console.WriteLine(Lang.Lang.messages["error"]);
            }
            Console.WriteLine();
            GetInput();
        }
    }
}