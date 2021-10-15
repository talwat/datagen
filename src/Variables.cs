using System;

namespace Variables {
    class Variables {
        //Getting the path that the program is being executed as the default.
        public static string path = AppDomain.CurrentDomain.BaseDirectory.Substring(0, AppDomain.CurrentDomain.BaseDirectory.Length - 1);
        //Variable for the raw input.
        public static string rawInput;
    }
}