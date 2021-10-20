DataGen
===

## Info
**DataGen** is a tool used to generate certain elements of a minecraft [datapack]("https://minecraft.fandom.com/wiki/Data_pack").

It's just made for fun, and for personal use. *(AKA the code wont be the best thing in the world)*

The prompt is based on the **Microsoft command prompt**.

I might make a **bash** version in the future, for you linux fans out there.


## Use
Datagen is meant to be used with [minecraft](https://minecraft.net) java.

Usually, you need to put the generated folder in your datapacks `function` folder.

Then, in your `tick.json` file, you need to add `NAMESPACE:GENERATED_FOLDER/tick`. *(Replace the words in all caps)*

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

This will probably not work half of the time, so proceed with caution.

You will need:
* [Git](https://git-scm.com/)
* [DotNet](https://dotnet.microsoft.com/) *(Most Windows 10 PC's have it pre-installed)*

#### What to do
You first need to clone the repository. Do these commands in the terminal.
```sh
git clone https://github.com/talwat/datagen.git
cd <the place you cloned the repository in>/datagen
dotnet publish
```

Then, go to the place you cloned it in with the file explorer, and from there go to `\bin\Debug\net5.0\publish`.
Finally, you will see a few files. Click on the .exe file, and you have successfully launched datagen.

## Contributers
The **contributers** who have made this project are:

Creator of datagen.
* Talwat

If you would like to contribute, open an issue or pull request.