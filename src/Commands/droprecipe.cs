using System;
using System.Collections.Generic;
using System.IO;
using static Logging.Logging;

public class droprecipe_Command {
    public static void droprecipe(string[] inputfinal) {
        droprecipe_Extra.GetInputs();
        droprecipe_Extra.MakeFiles();
    }
}
public class droprecipe_Extra {
    public static List<string[]> arguements = new List<string[]>() {};
    public static string datapackNamespace;
    public static string recipeName;
    public static string finalItem;
    public static string finalItemNbt;
    public static void GetInputs() {
        bool keepAsking = true;
        string item;
        string nbt;
        Log(Lang.Lang.messages["dropRecipeDatapackNamespaceAsk"], "input");
        datapackNamespace = Console.ReadLine();
        Log(Lang.Lang.messages["dropRecipeRecipeNameAsk"], "input");
        recipeName = Console.ReadLine();
        while(keepAsking) {
            Log(Lang.Lang.messages["dropRecipeItemAsk"] + "\n" + Lang.Lang.messages["dropRecipeDoneAsk"], "input");
            string answer = Console.ReadLine();
            if(answer == "done") {
                keepAsking = false;
            }
            else {
                item = answer;
                Log(Lang.Lang.messages["dropRecipeNbtAsk"], "input");
                nbt = Console.ReadLine();
                arguements.Add(new string[] {item, nbt});
            }
        }
        Log(Lang.Lang.messages["dropRecipeFinalItemAsk"], "input");
        finalItem = Console.ReadLine();
        Log(Lang.Lang.messages["dropRecipeFinalItemNbtAsk"], "input");
        finalItemNbt = Console.ReadLine();
    }
    public static void MakeFiles() {
        Log(Lang.Lang.messages["dropRecipeMakingFiles"]);

        string path = Variables.Variables.path + "\\" + recipeName + "\\";
        if(Directory.Exists(Variables.Variables.path + "\\" + recipeName)) {
            Directory.Delete(Variables.Variables.path + "\\" + recipeName, true);
        }
        Directory.CreateDirectory(Variables.Variables.path + "\\" + recipeName);

        string text = "execute as ";
        if(arguements[0][1] == "") {
            text += "@e[type=item, nbt={Item:{id:\"minecraft:" + arguements[0][0] + "\"}}] at @s";
        }
        else {
            text += "@e[type=item, nbt={Item:{id:\"minecraft:" + arguements[0][0] + "\", tag:" + arguements[0][1] + "}}] at @s";
        }
        foreach(string[] arguement in arguements) {
            if(arguement[1] == "") {
                text += " if entity @e[type=item, distance=..1, nbt={Item:{id:\"minecraft:" + arguement[0] + "\"}}]";
            }
            else {
                text += " if entity @e[type=item, distance=..1, nbt={Item:{id:\"minecraft:" + arguement[0] + "\", tag:" + arguement[1] + "}}]";
            }
        }
        string itemSummon = "";
        if(finalItemNbt == "") {
            itemSummon = "summon item ~ ~ ~ {Item:{id:\"minecraft:" + finalItem + "\", Count:1b}}\n";
        }
        else {
            itemSummon = "summon item ~ ~ ~ {Item:{id:\"minecraft:" + finalItem + "\", tag:" + finalItemNbt + ", Count:1b}}\n";
        }
        string text1 = itemSummon + "kill @s\n";
        foreach(string[] arguement in arguements) {
            if(arguement[1] == "") {
                text1 += "kill @e[type=item, distance=..1, nbt={Item:{id:\"minecraft:" + arguement[0] + "\"}}, limit=1] \n";
            }
            else {
                text1 += "kill @e[type=item, distance=..1, nbt={Item:{id:\"minecraft:" + arguement[0] + "\", tag:" + arguement[1] + "}}, limit=1] \n";
            }
        }

        TextFile.TextFile.TextFileMake(
            path + "crafted.mcfunction",
            text1
        );
        TextFile.TextFile.TextFileMake(
            path + "tick.mcfunction",
                text + " run function " + datapackNamespace + ":" + recipeName + "/crafted"
        );

        Log(Lang.Lang.messages["dropRecipeDone"], "success");
    }
}