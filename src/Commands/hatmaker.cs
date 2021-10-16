using System.Collections.Generic;
using System;
using System.IO;

public class hatmaker_Command {
    public static void hatmaker(string[] finalInput) {
        hatmaker_extra.GetInputs();
        hatmaker_extra.MakeFiles();
    }
}

public class hatmaker_extra {
    public static Dictionary<string, string> arguements = new Dictionary<string, string>();
    public static void GetInputs() {
        arguements = new Dictionary<string, string>();
        Console.WriteLine("What is the hats name? (In code)");
        arguements.Add("name", Console.ReadLine());
        Console.WriteLine("What is the hats display name?");
        arguements.Add("displayName", Console.ReadLine());
        Console.WriteLine("What is the hats display name color?");
        arguements.Add("displayNameColor", Console.ReadLine());
        Console.WriteLine("What is the hat item? (Has to be a helmet)");
        arguements.Add("hatItem", Console.ReadLine());
        Console.WriteLine("What is the display item?");
        arguements.Add("displayItem", Console.ReadLine());
        Console.WriteLine("What is the hat item's CustomModelData?");
        arguements.Add("hatCmd", Console.ReadLine());
        Console.WriteLine("What is the display item's CustomModelData?");
        arguements.Add("displayCmd", Console.ReadLine());
        Console.WriteLine("What is the Datapack Namespace?");
        arguements.Add("namespace", Console.ReadLine());
    }

    public static void MakeFiles() {
        string path = Variables.Variables.path + "\\output\\";
        Directory.CreateDirectory(Variables.Variables.path + "\\output");
        TextFile.TextFile.TextFileMake(
            path + "give.mcfunction",
                "give @s "
                + arguements["hatItem"] +
                "{display:{Name:'{\"text\":\""
                + arguements["displayName"] +
                "\",\"color\":\""
                + arguements["displayNameColor"] +
                "\",\"italic\":false}'},HideFlags:2,CustomModelData:"
                + arguements["hatCmd"] +
                ","
                + arguements["name"] +
                "helm:1b} 1"
        );
        TextFile.TextFile.TextFileMake(
            path + "logic.mcfunction",
                "execute as @a[nbt={Inventory:[{id:\"minecraft:"
                + arguements["hatItem"] +
                "\", tag:{"
                + arguements["name"] +
                "helm:1b}, Slot:103b}]}] run item replace entity @s armor.head with "
                + arguements["displayItem"] +
                "{display:{Name:'{\"text\":\""
                + arguements["displayName"] +
                "\",\"color\":\""
                + arguements["displayNameColor"] +
                "\",\"italic\":false}'},CustomModelData:"
                + arguements["displayItemCmd"] +
                ","
                + arguements["name"] +
                ":1b} 1" + "\n" +

                
                "execute as @a[nbt={Inventory:[{id:\"minecraft:"
                + arguements["displayItem"] +
                "\", tag:{"
                + arguements["name"] +
                ":1b}}]}] run function "
                + arguements["namespace"] +
                ":"
                + arguements["name"] +
                "/replace"
        );
    }
}