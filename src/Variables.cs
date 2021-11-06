using System; //For getting the core path and normal path.

namespace Variables {
    class Variables {
        //Getting the path that the program is being executed as the default.
        public static string path = Environment.CurrentDirectory;
        //Getting the path that the core .exe is located.
        public static string corePath = AppDomain.CurrentDomain.BaseDirectory.Substring(0, AppDomain.CurrentDomain.BaseDirectory.Length - 1);
        //Variable for the raw input.
        public static string rawInput;
        //Universal Version Variable.
        public static string version = "0.5.3 DEV";
        //Core variable to tell the program if it is runned by the terminal or by normal means.
        public static bool core;
        //Tells the program is the os is windows or not.
        public static bool windows = System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows);
    }
}