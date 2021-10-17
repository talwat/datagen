using System.Collections.Generic;
using System;
using System.IO;

public class hatmaker_Command {
    public static void hatmaker(string[] finalInput) {
        hatmaker_extra.GetInputs(finalInput);
        hatmaker_extra.MakeFiles();
    }
}

public class hatmaker_extra {
    public static Dictionary<string, string> arguements = new Dictionary<string, string>();
    public static void GetInputs(string[] finalInput) {
        if(finalInput.Length < 9) {
            arguements = new Dictionary<string, string>();
            Console.WriteLine(Lang.Lang.messages["hatNameAsk"]);
            arguements.Add("name", Console.ReadLine());
            Console.WriteLine(Lang.Lang.messages["hatDisplayNameAsk"]);
            arguements.Add("displayName", Console.ReadLine());
            Console.WriteLine(Lang.Lang.messages["hatDisplayNameColorAsk"]);
            arguements.Add("displayNameColor", Console.ReadLine());
            Console.WriteLine(Lang.Lang.messages["hatHelmetItemAsk"]);
            arguements.Add("hatItem", Console.ReadLine());
            Console.WriteLine(Lang.Lang.messages["hatDisplayItemAsk"]);
            arguements.Add("displayItem", Console.ReadLine());
            Console.WriteLine(Lang.Lang.messages["hatHelmetItemCmdAsk"]);
            arguements.Add("hatCmd", Console.ReadLine());
            Console.WriteLine(Lang.Lang.messages["hatDisplayItemCmdAsk"]);
            arguements.Add("displayCmd", Console.ReadLine());
            Console.WriteLine(Lang.Lang.messages["hatNamespaceAsk"]);
            arguements.Add("namespace", Console.ReadLine());
        }
        else if(finalInput.Length >= 9) {
            arguements.Add("name", finalInput[1]);
            arguements.Add("displayName", finalInput[2]);
            arguements.Add("displayNameColor", finalInput[3]);
            arguements.Add("hatItem", finalInput[4]);
            arguements.Add("displayItem", finalInput[5]);
            arguements.Add("hatCmd", finalInput[6]);
            arguements.Add("displayCmd", finalInput[7]);
            arguements.Add("namespace", finalInput[8]);
        }
    }

    public static void MakeFiles() {
        Console.WriteLine(Lang.Lang.messages["hatMakingFiles"]);
        string path = Variables.Variables.path + "\\" + arguements["name"] + "\\";
        if(Directory.Exists(Variables.Variables.path + "\\" + arguements["name"])) {
            Directory.Delete(Variables.Variables.path + "\\" + arguements["name"], true);
        }
        Directory.CreateDirectory(Variables.Variables.path + "\\" + arguements["name"]);
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
                + arguements["displayCmd"] +
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
                "/replace" + "\n" +

                "execute as @e[type=item, nbt={Item:{id:\"minecraft:" + arguements["displayItem"] + "\", tag:{" + arguements["name"] + ":1b}}}] at @s run function " + arguements["namespace"] + ":" + arguements["name"] + "/entityreplace "
        );
        TextFile.TextFile.TextFileMake(
            path + "entityreplace.mcfunction",
            "data modify entity @s Item.tag." + arguements["name"] + " set value 0b" + "\n" +
            "data modify entity @s Item.tag." + arguements["name"] + "helm set value 1b" + "\n" +
            "data modify entity @s Item.id set value \"minecraft:" + arguements["hatItem"] + "\"" + "\n" +
            "data modify entity @s Item.tag.HideFlags set value 2" + "\n"
        );
        TextFile.TextFile.TextFileMake(
            path + "replace.mcfunction",
                "execute as @s if entity @s[nbt={Inventory:[{id:\"minecraft:" + arguements["displayItem"] + "\", tag:{" + arguements["name"] +":1b}, Slot:0b}]}] run item replace entity @s hotbar.0 with " + arguements["hatItem"] + "{display:{Name:'{\"text\":\"" + arguements["displayName"] + "\",\"color\":\"" + arguements["displayNameColor"] + "\",\"italic\":false}'},HideFlags:2,CustomModelData:" + arguements["hatCmd"] + "," + arguements["name"] + "helm:1b} 1" + "\n" +
                "execute as @s if entity @s[nbt={Inventory:[{id:\"minecraft:" + arguements["displayItem"] + "\", tag:{" + arguements["name"] +":1b}, Slot:1b}]}] run item replace entity @s hotbar.1 with " + arguements["hatItem"] + "{display:{Name:'{\"text\":\"" + arguements["displayName"] + "\",\"color\":\"" + arguements["displayNameColor"] + "\",\"italic\":false}'},HideFlags:2,CustomModelData:" + arguements["hatCmd"] + "," + arguements["name"] + "helm:1b} 1" + "\n" +
                "execute as @s if entity @s[nbt={Inventory:[{id:\"minecraft:" + arguements["displayItem"] + "\", tag:{" + arguements["name"] +":1b}, Slot:2b}]}] run item replace entity @s hotbar.2 with " + arguements["hatItem"] + "{display:{Name:'{\"text\":\"" + arguements["displayName"] + "\",\"color\":\"" + arguements["displayNameColor"] + "\",\"italic\":false}'},HideFlags:2,CustomModelData:" + arguements["hatCmd"] + "," + arguements["name"] + "helm:1b} 1" + "\n" +
                "execute as @s if entity @s[nbt={Inventory:[{id:\"minecraft:" + arguements["displayItem"] + "\", tag:{" + arguements["name"] +":1b}, Slot:3b}]}] run item replace entity @s hotbar.3 with " + arguements["hatItem"] + "{display:{Name:'{\"text\":\"" + arguements["displayName"] + "\",\"color\":\"" + arguements["displayNameColor"] + "\",\"italic\":false}'},HideFlags:2,CustomModelData:" + arguements["hatCmd"] + "," + arguements["name"] + "helm:1b} 1" + "\n" +
                "execute as @s if entity @s[nbt={Inventory:[{id:\"minecraft:" + arguements["displayItem"] + "\", tag:{" + arguements["name"] +":1b}, Slot:4b}]}] run item replace entity @s hotbar.4 with " + arguements["hatItem"] + "{display:{Name:'{\"text\":\"" + arguements["displayName"] + "\",\"color\":\"" + arguements["displayNameColor"] + "\",\"italic\":false}'},HideFlags:2,CustomModelData:" + arguements["hatCmd"] + "," + arguements["name"] + "helm:1b} 1" + "\n" +
                "execute as @s if entity @s[nbt={Inventory:[{id:\"minecraft:" + arguements["displayItem"] + "\", tag:{" + arguements["name"] +":1b}, Slot:5b}]}] run item replace entity @s hotbar.5 with " + arguements["hatItem"] + "{display:{Name:'{\"text\":\"" + arguements["displayName"] + "\",\"color\":\"" + arguements["displayNameColor"] + "\",\"italic\":false}'},HideFlags:2,CustomModelData:" + arguements["hatCmd"] + "," + arguements["name"] + "helm:1b} 1" + "\n" +
                "execute as @s if entity @s[nbt={Inventory:[{id:\"minecraft:" + arguements["displayItem"] + "\", tag:{" + arguements["name"] +":1b}, Slot:6b}]}] run item replace entity @s hotbar.6 with " + arguements["hatItem"] + "{display:{Name:'{\"text\":\"" + arguements["displayName"] + "\",\"color\":\"" + arguements["displayNameColor"] + "\",\"italic\":false}'},HideFlags:2,CustomModelData:" + arguements["hatCmd"] + "," + arguements["name"] + "helm:1b} 1" + "\n" +
                "execute as @s if entity @s[nbt={Inventory:[{id:\"minecraft:" + arguements["displayItem"] + "\", tag:{" + arguements["name"] +":1b}, Slot:7b}]}] run item replace entity @s hotbar.7 with " + arguements["hatItem"] + "{display:{Name:'{\"text\":\"" + arguements["displayName"] + "\",\"color\":\"" + arguements["displayNameColor"] + "\",\"italic\":false}'},HideFlags:2,CustomModelData:" + arguements["hatCmd"] + "," + arguements["name"] + "helm:1b} 1" + "\n" +
                "execute as @s if entity @s[nbt={Inventory:[{id:\"minecraft:" + arguements["displayItem"] + "\", tag:{" + arguements["name"] +":1b}, Slot:8b}]}] run item replace entity @s hotbar.8 with " + arguements["hatItem"] + "{display:{Name:'{\"text\":\"" + arguements["displayName"] + "\",\"color\":\"" + arguements["displayNameColor"] + "\",\"italic\":false}'},HideFlags:2,CustomModelData:" + arguements["hatCmd"] + "," + arguements["name"] + "helm:1b} 1" + "\n" +
                "execute as @s if entity @s[nbt={Inventory:[{id:\"minecraft:" + arguements["displayItem"] + "\", tag:{" + arguements["name"] +":1b}, Slot:9b}]}] run item replace entity @s inventory.0 with " + arguements["hatItem"] + "{display:{Name:'{\"text\":\"" + arguements["displayName"] + "\",\"color\":\"" + arguements["displayNameColor"] + "\",\"italic\":false}'},HideFlags:2,CustomModelData:" + arguements["hatCmd"] + "," + arguements["name"] + "helm:1b} " + "\n" +
                "execute as @s if entity @s[nbt={Inventory:[{id:\"minecraft:" + arguements["displayItem"] + "\", tag:{" + arguements["name"] +":1b}, Slot:10b}]}] run item replace entity @s inventory.1 with " + arguements["hatItem"] + "{display:{Name:'{\"text\":\"" + arguements["displayName"] + "\",\"color\":\"" + arguements["displayNameColor"] + "\",\"italic\":false}'},HideFlags:2,CustomModelData:" + arguements["hatCmd"] + "," + arguements["name"] + "helm:1b} 1" + "\n" +
                "execute as @s if entity @s[nbt={Inventory:[{id:\"minecraft:" + arguements["displayItem"] + "\", tag:{" + arguements["name"] +":1b}, Slot:11b}]}] run item replace entity @s inventory.2 with " + arguements["hatItem"] + "{display:{Name:'{\"text\":\"" + arguements["displayName"] + "\",\"color\":\"" + arguements["displayNameColor"] + "\",\"italic\":false}'},HideFlags:2,CustomModelData:" + arguements["hatCmd"] + "," + arguements["name"] + "helm:1b} 1" + "\n" +
                "execute as @s if entity @s[nbt={Inventory:[{id:\"minecraft:" + arguements["displayItem"] + "\", tag:{" + arguements["name"] +":1b}, Slot:12b}]}] run item replace entity @s inventory.3 with " + arguements["hatItem"] + "{display:{Name:'{\"text\":\"" + arguements["displayName"] + "\",\"color\":\"" + arguements["displayNameColor"] + "\",\"italic\":false}'},HideFlags:2,CustomModelData:" + arguements["hatCmd"] + "," + arguements["name"] + "helm:1b} 1" + "\n" +
                "execute as @s if entity @s[nbt={Inventory:[{id:\"minecraft:" + arguements["displayItem"] + "\", tag:{" + arguements["name"] +":1b}, Slot:13b}]}] run item replace entity @s inventory.4 with " + arguements["hatItem"] + "{display:{Name:'{\"text\":\"" + arguements["displayName"] + "\",\"color\":\"" + arguements["displayNameColor"] + "\",\"italic\":false}'},HideFlags:2,CustomModelData:" + arguements["hatCmd"] + "," + arguements["name"] + "helm:1b} 1" + "\n" +
                "execute as @s if entity @s[nbt={Inventory:[{id:\"minecraft:" + arguements["displayItem"] + "\", tag:{" + arguements["name"] +":1b}, Slot:14b}]}] run item replace entity @s inventory.5 with " + arguements["hatItem"] + "{display:{Name:'{\"text\":\"" + arguements["displayName"] + "\",\"color\":\"" + arguements["displayNameColor"] + "\",\"italic\":false}'},HideFlags:2,CustomModelData:" + arguements["hatCmd"] + "," + arguements["name"] + "helm:1b} 1" + "\n" +
                "execute as @s if entity @s[nbt={Inventory:[{id:\"minecraft:" + arguements["displayItem"] + "\", tag:{" + arguements["name"] +":1b}, Slot:15b}]}] run item replace entity @s inventory.6 with " + arguements["hatItem"] + "{display:{Name:'{\"text\":\"" + arguements["displayName"] + "\",\"color\":\"" + arguements["displayNameColor"] + "\",\"italic\":false}'},HideFlags:2,CustomModelData:" + arguements["hatCmd"] + "," + arguements["name"] + "helm:1b} 1" + "\n" +
                "execute as @s if entity @s[nbt={Inventory:[{id:\"minecraft:" + arguements["displayItem"] + "\", tag:{" + arguements["name"] +":1b}, Slot:16b}]}] run item replace entity @s inventory.7 with " + arguements["hatItem"] + "{display:{Name:'{\"text\":\"" + arguements["displayName"] + "\",\"color\":\"" + arguements["displayNameColor"] + "\",\"italic\":false}'},HideFlags:2,CustomModelData:" + arguements["hatCmd"] + "," + arguements["name"] + "helm:1b} 1" + "\n" +
                "execute as @s if entity @s[nbt={Inventory:[{id:\"minecraft:" + arguements["displayItem"] + "\", tag:{" + arguements["name"] +":1b}, Slot:17b}]}] run item replace entity @s inventory.8 with " + arguements["hatItem"] + "{display:{Name:'{\"text\":\"" + arguements["displayName"] + "\",\"color\":\"" + arguements["displayNameColor"] + "\",\"italic\":false}'},HideFlags:2,CustomModelData:" + arguements["hatCmd"] + "," + arguements["name"] + "helm:1b} 1" + "\n" +
                "execute as @s if entity @s[nbt={Inventory:[{id:\"minecraft:" + arguements["displayItem"] + "\", tag:{" + arguements["name"] +":1b}, Slot:18b}]}] run item replace entity @s inventory.9 with " + arguements["hatItem"] + "{display:{Name:'{\"text\":\"" + arguements["displayName"] + "\",\"color\":\"" + arguements["displayNameColor"] + "\",\"italic\":false}'},HideFlags:2,CustomModelData:" + arguements["hatCmd"] + "," + arguements["name"] + "helm:1b} 1" + "\n" +
                "execute as @s if entity @s[nbt={Inventory:[{id:\"minecraft:" + arguements["displayItem"] + "\", tag:{" + arguements["name"] +":1b}, Slot:19b}]}] run item replace entity @s inventory.10 with " + arguements["hatItem"] + "{display:{Name:'{\"text\":\"" + arguements["displayName"] + "\",\"color\":\"" + arguements["displayNameColor"] + "\",\"italic\":false}'},HideFlags:2,CustomModelData:" + arguements["hatCmd"] + "," + arguements["name"] + "helm:1b} 1" + "\n" +
                "execute as @s if entity @s[nbt={Inventory:[{id:\"minecraft:" + arguements["displayItem"] + "\", tag:{" + arguements["name"] +":1b}, Slot:20b}]}] run item replace entity @s inventory.11 with " + arguements["hatItem"] + "{display:{Name:'{\"text\":\"" + arguements["displayName"] + "\",\"color\":\"" + arguements["displayNameColor"] + "\",\"italic\":false}'},HideFlags:2,CustomModelData:" + arguements["hatCmd"] + "," + arguements["name"] + "helm:1b} 1" + "\n" +
                "execute as @s if entity @s[nbt={Inventory:[{id:\"minecraft:" + arguements["displayItem"] + "\", tag:{" + arguements["name"] +":1b}, Slot:21b}]}] run item replace entity @s inventory.12 with " + arguements["hatItem"] + "{display:{Name:'{\"text\":\"" + arguements["displayName"] + "\",\"color\":\"" + arguements["displayNameColor"] + "\",\"italic\":false}'},HideFlags:2,CustomModelData:" + arguements["hatCmd"] + "," + arguements["name"] + "helm:1b} 1" + "\n" +
                "execute as @s if entity @s[nbt={Inventory:[{id:\"minecraft:" + arguements["displayItem"] + "\", tag:{" + arguements["name"] +":1b}, Slot:22b}]}] run item replace entity @s inventory.13 with " + arguements["hatItem"] + "{display:{Name:'{\"text\":\"" + arguements["displayName"] + "\",\"color\":\"" + arguements["displayNameColor"] + "\",\"italic\":false}'},HideFlags:2,CustomModelData:" + arguements["hatCmd"] + "," + arguements["name"] + "helm:1b} 1" + "\n" +
                "execute as @s if entity @s[nbt={Inventory:[{id:\"minecraft:" + arguements["displayItem"] + "\", tag:{" + arguements["name"] +":1b}, Slot:23b}]}] run item replace entity @s inventory.14 with " + arguements["hatItem"] + "{display:{Name:'{\"text\":\"" + arguements["displayName"] + "\",\"color\":\"" + arguements["displayNameColor"] + "\",\"italic\":false}'},HideFlags:2,CustomModelData:" + arguements["hatCmd"] + "," + arguements["name"] + "helm:1b} 1" + "\n" +
                "execute as @s if entity @s[nbt={Inventory:[{id:\"minecraft:" + arguements["displayItem"] + "\", tag:{" + arguements["name"] +":1b}, Slot:24b}]}] run item replace entity @s inventory.15 with " + arguements["hatItem"] + "{display:{Name:'{\"text\":\"" + arguements["displayName"] + "\",\"color\":\"" + arguements["displayNameColor"] + "\",\"italic\":false}'},HideFlags:2,CustomModelData:" + arguements["hatCmd"] + "," + arguements["name"] + "helm:1b} 1" + "\n" +
                "execute as @s if entity @s[nbt={Inventory:[{id:\"minecraft:" + arguements["displayItem"] + "\", tag:{" + arguements["name"] +":1b}, Slot:25b}]}] run item replace entity @s inventory.16 with " + arguements["hatItem"] + "{display:{Name:'{\"text\":\"" + arguements["displayName"] + "\",\"color\":\"" + arguements["displayNameColor"] + "\",\"italic\":false}'},HideFlags:2,CustomModelData:" + arguements["hatCmd"] + "," + arguements["name"] + "helm:1b} 1" + "\n" +
                "execute as @s if entity @s[nbt={Inventory:[{id:\"minecraft:" + arguements["displayItem"] + "\", tag:{" + arguements["name"] +":1b}, Slot:26b}]}] run item replace entity @s inventory.17 with " + arguements["hatItem"] + "{display:{Name:'{\"text\":\"" + arguements["displayName"] + "\",\"color\":\"" + arguements["displayNameColor"] + "\",\"italic\":false}'},HideFlags:2,CustomModelData:" + arguements["hatCmd"] + "," + arguements["name"] + "helm:1b} 1" + "\n" +
                "execute as @s if entity @s[nbt={Inventory:[{id:\"minecraft:" + arguements["displayItem"] + "\", tag:{" + arguements["name"] +":1b}, Slot:27b}]}] run item replace entity @s inventory.18 with " + arguements["hatItem"] + "{display:{Name:'{\"text\":\"" + arguements["displayName"] + "\",\"color\":\"" + arguements["displayNameColor"] + "\",\"italic\":false}'},HideFlags:2,CustomModelData:" + arguements["hatCmd"] + "," + arguements["name"] + "helm:1b} 1" + "\n" +
                "execute as @s if entity @s[nbt={Inventory:[{id:\"minecraft:" + arguements["displayItem"] + "\", tag:{" + arguements["name"] +":1b}, Slot:28b}]}] run item replace entity @s inventory.19 with " + arguements["hatItem"] + "{display:{Name:'{\"text\":\"" + arguements["displayName"] + "\",\"color\":\"" + arguements["displayNameColor"] + "\",\"italic\":false}'},HideFlags:2,CustomModelData:" + arguements["hatCmd"] + "," + arguements["name"] + "helm:1b} 1" + "\n" +
                "execute as @s if entity @s[nbt={Inventory:[{id:\"minecraft:" + arguements["displayItem"] + "\", tag:{" + arguements["name"] +":1b}, Slot:29b}]}] run item replace entity @s inventory.20 with " + arguements["hatItem"] + "{display:{Name:'{\"text\":\"" + arguements["displayName"] + "\",\"color\":\"" + arguements["displayNameColor"] + "\",\"italic\":false}'},HideFlags:2,CustomModelData:" + arguements["hatCmd"] + "," + arguements["name"] + "helm:1b} 1" + "\n" +
                "execute as @s if entity @s[nbt={Inventory:[{id:\"minecraft:" + arguements["displayItem"] + "\", tag:{" + arguements["name"] +":1b}, Slot:30b}]}] run item replace entity @s inventory.21 with " + arguements["hatItem"] + "{display:{Name:'{\"text\":\"" + arguements["displayName"] + "\",\"color\":\"" + arguements["displayNameColor"] + "\",\"italic\":false}'},HideFlags:2,CustomModelData:" + arguements["hatCmd"] + "," + arguements["name"] + "helm:1b} 1" + "\n" +
                "execute as @s if entity @s[nbt={Inventory:[{id:\"minecraft:" + arguements["displayItem"] + "\", tag:{" + arguements["name"] +":1b}, Slot:31b}]}] run item replace entity @s inventory.22 with " + arguements["hatItem"] + "{display:{Name:'{\"text\":\"" + arguements["displayName"] + "\",\"color\":\"" + arguements["displayNameColor"] + "\",\"italic\":false}'},HideFlags:2,CustomModelData:" + arguements["hatCmd"] + "," + arguements["name"] + "helm:1b} 1" + "\n" +
                "execute as @s if entity @s[nbt={Inventory:[{id:\"minecraft:" + arguements["displayItem"] + "\", tag:{" + arguements["name"] +":1b}, Slot:32b}]}] run item replace entity @s inventory.23 with " + arguements["hatItem"] + "{display:{Name:'{\"text\":\"" + arguements["displayName"] + "\",\"color\":\"" + arguements["displayNameColor"] + "\",\"italic\":false}'},HideFlags:2,CustomModelData:" + arguements["hatCmd"] + "," + arguements["name"] + "helm:1b} 1" + "\n" +
                "execute as @s if entity @s[nbt={Inventory:[{id:\"minecraft:" + arguements["displayItem"] + "\", tag:{" + arguements["name"] +":1b}, Slot:33b}]}] run item replace entity @s inventory.24 with " + arguements["hatItem"] + "{display:{Name:'{\"text\":\"" + arguements["displayName"] + "\",\"color\":\"" + arguements["displayNameColor"] + "\",\"italic\":false}'},HideFlags:2,CustomModelData:" + arguements["hatCmd"] + "," + arguements["name"] + "helm:1b} 1" + "\n" +
                "execute as @s if entity @s[nbt={Inventory:[{id:\"minecraft:" + arguements["displayItem"] + "\", tag:{" + arguements["name"] +":1b}, Slot:34b}]}] run item replace entity @s inventory.25 with " + arguements["hatItem"] + "{display:{Name:'{\"text\":\"" + arguements["displayName"] + "\",\"color\":\"" + arguements["displayNameColor"] + "\",\"italic\":false}'},HideFlags:2,CustomModelData:" + arguements["hatCmd"] + "," + arguements["name"] + "helm:1b} 1" + "\n" +
                "execute as @s if entity @s[nbt={Inventory:[{id:\"minecraft:" + arguements["displayItem"] + "\", tag:{" + arguements["name"] +":1b}, Slot:35b}]}] run item replace entity @s inventory.26 with " + arguements["hatItem"] + "{display:{Name:'{\"text\":\"" + arguements["displayName"] + "\",\"color\":\"" + arguements["displayNameColor"] + "\",\"italic\":false}'},HideFlags:2,CustomModelData:" + arguements["hatCmd"] + "," + arguements["name"] + "helm:1b} 1" + "\n" +
                "execute as @s if entity @s[nbt={Inventory:[{id:\"minecraft:" + arguements["displayItem"] + "\", tag:{" + arguements["name"] +":1b}, Slot:-106b}]}] run item replace entity @s weapon.offhand with " + arguements["hatItem"] + "{display:{Name:'{\"text\":\"" + arguements["displayName"] + "\",\"color\":\"" + arguements["displayNameColor"] + "\",\"italic\":false}'},HideFlags:2,CustomModelData:" + arguements["hatCmd"] + "," + arguements["name"] + "helm:1b} 1"
        );
        Console.WriteLine(Lang.Lang.messages["hatDone"]);
    }
}