public class source_Command {
    public static void source(string[] inputFinal) {
        if(System.IO.Directory.Exists(Variables.Variables.path + "\\sourceIn")) {
            System.IO.Directory.Delete(Variables.Variables.path + "\\sourceIn", true);
        }
        if(System.IO.Directory.Exists(Variables.Variables.path + "\\source")) {
            System.IO.Directory.Delete(Variables.Variables.path + "\\source", true);
        }
        if(System.IO.File.Exists(Variables.Variables.path + "\\sourceZip.zip")) {
            System.IO.File.Delete(Variables.Variables.path + "\\sourceZip.zip");
        }
        System.Console.WriteLine("Downloading Source Code From Github...");
        Download.Download.DownloadFile("https://github.com/talwat/datagen/archive/refs/heads/master.zip", Variables.Variables.path + "\\sourceZip.zip");
        System.Console.WriteLine("Unzipping...");
        System.IO.Compression.ZipFile.ExtractToDirectory(Variables.Variables.path + "\\sourceZip.zip", Variables.Variables.path + "\\sourceIn");
        System.Console.WriteLine("Moving...");
        System.IO.Directory.Move(Variables.Variables.path + "\\sourceIn\\datagen-master", Variables.Variables.path + "\\source");
        System.Console.WriteLine("Deleting excess files...");
        System.IO.Directory.Delete(Variables.Variables.path + "\\sourceIn");
        System.IO.File.Delete(Variables.Variables.path + "\\sourceZip.zip");
        System.Console.WriteLine("Done!");
    }
}