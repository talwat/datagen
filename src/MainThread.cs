using System; //For writing to the console.
using Pastel; //For coloring messages

namespace MainThread {
    class MainThread {
        static void Main(string[] args) {    
            //Loading the language file.
            Lang.Lang.LoadLang();

            if((args.Length == 0 && Proccessing.GetParentProcessName() == "explorer")) {
                Proccessing.AddPATH();
                
                //Clearing the console and writing some text.
                Console.Clear();
                Console.WriteLine("DataGen " + "CORE".Pastel(System.Drawing.Color.Crimson) + " [Version 0.5 DEV]");
                Console.WriteLine("Talwat. Open source on Github.\n");

                //Starting the loop to get commands.
                Commands.Commands.GetInput();
            }
            else if(args.Length > 0) {
                if((args[0] == "debug")) {
                    //Clearing the console and writing some text.
                    Console.Clear();
                    Console.WriteLine("DataGen " + "DEBUG".Pastel(System.Drawing.Color.CadetBlue) + " [Version 0.5 DEV]");
                    Console.WriteLine("Talwat. Open source on Github.\n");

                    //Starting the loop to get commands.
                    Commands.Commands.GetInput();
                }
                if(Commands.Commands.InvokeFromString(args[0] + "_Command", args[0], new object[] {args}, args) == 5) {
                    //Prints that the command is not found if the method returns "5".
                    Logging.Logging.Log("\'" + args[0] + "\' " + Lang.Lang.messages["commandNotFound"], "error");
                }
            }
            else if (args.Length == 0) {
                Logging.Logging.Log(Lang.Lang.messages["noCmdInput"], "fatal");
            }
        }
    }
    public class Proccessing {
        public static void AddPATH() {
            var name = "PATH";
            var scope = EnvironmentVariableTarget.User; // or User
            var oldValue = Environment.GetEnvironmentVariable(name, scope);
            var newValue  = oldValue + @";" + Variables.Variables.path + @"\";
            if(System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows) && !Environment.GetEnvironmentVariable(name, scope).Contains(Variables.Variables.path)) {
                Logging.Logging.Log(Lang.Lang.messages["addPathAsk"]); 
                Logging.Logging.Log(Lang.Lang.messages["addPathAskWarn"], "warn");
                Logging.Logging.Log(Lang.Lang.messages["addPathAskInput"], "y/n");
                string answer = Console.ReadLine();
                if(
                    answer == "yes" 
                    || answer == "y" 
                    || answer == "yeah" 
                    || answer == "yep" 
                    || answer == "mhm" 
                    || answer == "absolutely"
                ) {
                    Environment.SetEnvironmentVariable(name, newValue, scope);
                    Logging.Logging.Log(Lang.Lang.messages["addedPath"], "success");
                }
                else {
                    Logging.Logging.Log(Lang.Lang.messages["notAddingPath"]);
                }
            }
        }
        public static string GetParentProcessName() {
            if(System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows)) {
                var myId = System.Diagnostics.Process.GetCurrentProcess().Id;
                var query = string.Format("SELECT ParentProcessId FROM Win32_Process WHERE ProcessId = {0}", myId);
                var search = new System.Management.ManagementObjectSearcher("root\\CIMV2", query);
                var results = search.Get().GetEnumerator();
                results.MoveNext();
                var queryObj = results.Current;
                var parentId = (uint)queryObj["ParentProcessId"];
                var parent = System.Diagnostics.Process.GetProcessById((int)parentId);
                return parent.ProcessName;
            }
            else {
                return "explorer";
            }
        }
    }
}