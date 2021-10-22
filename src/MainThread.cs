using System; //For writing to the console.
using static Commands.Commands;
using System.Diagnostics;
using System.Management;

namespace MainThread {
    class MainThread {
        static string GetParentProcessName() {
            var myId = Process.GetCurrentProcess().Id;
            var query = string.Format("SELECT ParentProcessId FROM Win32_Process WHERE ProcessId = {0}", myId);
            var search = new ManagementObjectSearcher("root\\CIMV2", query);
            var results = search.Get().GetEnumerator();
            results.MoveNext();
            var queryObj = results.Current;
            var parentId = (uint)queryObj["ParentProcessId"];
            var parent = Process.GetProcessById((int)parentId);
            return parent.ProcessName;
        }
        static void Main(string[] args) {
            var name = "PATH";
            var scope = EnvironmentVariableTarget.User; // or User
            var oldValue = Environment.GetEnvironmentVariable(name, scope);
            var newValue  = oldValue + @";" + Variables.Variables.path + @"\";
            if(!Environment.GetEnvironmentVariable(name, scope).Contains(Variables.Variables.path)) {
                Environment.SetEnvironmentVariable(name, newValue, scope);
            }       
            //Loading the language file.
            Lang.Lang.LoadLang();

            if((args.Length == 0 && GetParentProcessName() == "explorer") || (args[0] == "core")) {
                //Clearing the console and writing some text.
                Console.Clear();
                Console.WriteLine("DataGen [Version 0.4 DEV]");
                Console.WriteLine("Talwat. Open source on Github.\n");

                //Starting the loop to get commands.
                Commands.Commands.GetInput();
            }
            else if(args.Length > 0) {
                if(InvokeFromString(args[0] + "_Command", args[0], new object[] {args}) == 5) {
                    //Prints that the command is not found if the method returns "5".
                    Logging.Logging.Log("\'" + args[0] + "\' " + Lang.Lang.messages["commandNotFound"], "error");
                }
            }
            else if (args.Length == 0) {
                Logging.Logging.Log("No command inputted.", "fatal");
            }
        }
    }
}