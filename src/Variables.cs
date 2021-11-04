using System;

namespace Variables {
    class Variables {
        //Getting the path that the program is being executed as the default.
        public static string path = Environment.CurrentDirectory;
        //Getting the path that the core .exe is located.
        public static string corePath = AppDomain.CurrentDomain.BaseDirectory.Substring(0, AppDomain.CurrentDomain.BaseDirectory.Length - 1);
        //Variable for the raw input.
        public static string rawInput;
        //Universal Version Variable.
        public static string version = "0.5.1 DEV";
        //Core variable to tell the program if it is runned by the terminal or by normal means.
        public static bool core;
    }
}