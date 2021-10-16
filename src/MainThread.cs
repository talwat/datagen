using System; //For writing to the console.

namespace MainThread {
    class MainThread {
        static void Main(string[] args) {
            //Clearing the console and writing some text.
            Console.Clear();
            Console.WriteLine("DataGen [Version 0.2 DEV]");
            Console.WriteLine("Talwat. Open source on Github.\n");

            //Loading the language file.
            Lang.Lang.LoadLang();

            //Starting the loop to get commands.
            Commands.Commands.GetInput();
        }
    }
}
