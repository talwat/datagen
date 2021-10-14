using System;

namespace Variables {
    class Variables {
        public static string path = AppDomain.CurrentDomain.BaseDirectory.Substring(0, AppDomain.CurrentDomain.BaseDirectory.Length - 1);
        public static string input;
        public static string[] commands = {"help", "cd"};
    }
}