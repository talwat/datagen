using System;
using static Variables.Variables;
using System.Reflection;
using System.Collections.Generic;

namespace Commands {
    class Commands {
        public static void GetInput() {
            Console.Write(Variables.Variables.path + ">");
            rawInput = Console.ReadLine();
            string[] inputFinal = rawInput.Split(" ");
            try {
                if(InvokeFromString(inputFinal[0] + "_Command", inputFinal[0], new object[] {inputFinal}) == 5) {
                    Console.WriteLine("\'{0}\' " + Lang.Lang.messages["commandNotFound"], inputFinal[0]);
                }
            }
            catch {
                Console.WriteLine(Lang.Lang.messages["error"]);
            }
            Console.WriteLine();
            GetInput();
        }
        public static int InvokeFromString(string classInput, string methodInput, object[] args) {
            if(Type.GetType(classInput) == null) {
                return 5;
            }
            else {
                Type t = Type.GetType(classInput);
                MethodInfo method = t.GetMethod(methodInput, BindingFlags.Static | BindingFlags.Public);
                method.Invoke(null, args);
                return 0;
            }
        }
    }
}