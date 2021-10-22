using System; //For writing to the console.
using static Commands.Commands;
using System.Diagnostics;
using System.Management;
using Pastel;

namespace MainThread {
    class MainThread {
        static void Main(string[] args) {     
            Proccessing.AddPATH();

            //Loading the language file.
            Lang.Lang.LoadLang();

            if((args.Length == 0 && Proccessing.GetParentProcessName() == "explorer")) {
                //Clearing the console and writing some text.
                Console.Clear();
                Console.WriteLine("DataGen [Version 0.5 DEV]");
                Console.WriteLine("Talwat. Open source on Github.\n");

                //Starting the loop to get commands.
                Commands.Commands.GetInput();
            }
            else if(args.Length > 0) {
                if((args[0] == "debug")) {
                    //Clearing the console and writing some text.
                    Console.Clear();
                    Console.WriteLine("DataGen " + "DEBUG".Pastel(System.Drawing.Color.CadetBlue) + " [Version 0.4 DEV]");
                    Console.WriteLine("Talwat. Open source on Github.\n");

                    //Starting the loop to get commands.
                    Commands.Commands.GetInput();
                }
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
    public class Proccessing {
        public static void AddPATH() {
            var name = "PATH";
            var scope = EnvironmentVariableTarget.User; // or User
            var oldValue = Environment.GetEnvironmentVariable(name, scope);
            var newValue  = oldValue + @";" + Variables.Variables.path + @"\";
            if(System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows) && !Environment.GetEnvironmentVariable(name, scope).Contains(Variables.Variables.path)) {
                Logging.Logging.Log("Datagen wants to add a value to PATH in order to make datagen usable in the normal command prompt aswell.\nThis is not reccommended for computers that are not yours.", "info");
                Logging.Logging.Log("Do you want to add the value to PATH?", "input");
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
                    Logging.Logging.Log("Added value to PATH!", "success");
                }
                else {
                    Logging.Logging.Log("Not adding value to PATH.");
                }
            }
        }
        public static string GetParentProcessName() {
            if(System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows)) {
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
            else {
                return "explorer";
            }
        }
    }
}