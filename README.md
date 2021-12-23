DataGen
===
# DO NOT USE DATAGEN
Datagen is not maintained anymore, and is very, very buggy.
It was a great learning tool, but now its pretty much dead, so please do not use it.
It also has a lot of issues on linux, and crashes every two seconds.

## Info
**DataGen** is a tool used to generate certain elements of a minecraft [datapack]("https://minecraft.fandom.com/wiki/Data_pack").

It's just made for fun, and for personal use. *(AKA the code wont be the best thing in the world)*

The **core** version of the prompt is based on the **Microsoft command prompt**.

I might make a **bash** version in the future, for you linux fans out there.


## Use
There are two ways to use datagen commands.

1. You can launch the .exe file from the explorer to access a very limited version of the Windows CLI with only the datagen commands.

2. You can use `datagen <command>` in the normal command prompt for easy access. **ONLY WORKS ON WINDOWS FOR NOW**

*(You have to use **1** after the program has been downloaded/moved for **2** to work.)*

Datagen is meant to be used with [minecraft](https://minecraft.net) java.

Usually, you need to put the generated folder in your datapacks `function` folder.

Then, in your `tick.json` file, you need to add `"NAMESPACE:GENERATED_FOLDER/tick"`. *(Replace the words in all caps)*

If the program asks for nbt, and you want to add some, always put it in **curly brackets** (`{}`)

The `help` command goes over all of the commands.

You can look at the commands to see which one is useful for you.

Right now it has:
* Hatmaker
* Drop recipe maker

## Download
### Release
*(Recommended)*

Unfortunately, there isn't a finished release yet. You will need to use the other method.

### Compiling from source
*(Not recommended)*

You will need:
* [Git](https://git-scm.com/)
* [DotNet](https://dotnet.microsoft.com/) *(Most Windows 10 PC's have it pre-installed)*

#### What to do
**WINDOWS**

You first need to clone the repository. Do these commands in the terminal.
```sh
git clone https://github.com/talwat/datagen.git
cd <the place you cloned the repository in>/datagen
scripts/release.bat
```

After, to run the program, do
```sh
release/Datagen
```

**MACOS & LINUX**

While it is possible to run datagen on these, it isn't very stable whatsoever for now.

There are shell scripts for macOS and linux. *(Linux: `scripts/release.sh` MacOS: `scripts/release_macOS.sh`)*

Downloading files from the internet is very, very buggy.

## Libraries
The libraries used in datagen are:
* [Pastel](https://github.com/silkfire/Pastel)
* [Tommy](https://github.com/dezhidki/Tommy)

## Contributers
The **contributers** who have made this project are:

Creator of datagen.
* Talwat

If you would like to contribute, open an issue or pull request.
