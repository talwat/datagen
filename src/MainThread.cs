using System;

namespace MainThread {
    class MainThread {
        static void Main(string[] args) {
            Console.Clear();
            Console.WriteLine("DataGen [Version 0.1 DEV]");
            Console.WriteLine("Talwat. Open source on Github.\n");
            Lang.Lang.LoadLang();
            Commands.Commands.GetInput();
        }
    }
}
