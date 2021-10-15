using System.IO; //For editing and making files.

namespace TextFile {
    class TextFile {
        public static void TextFileMake(string path, string text) {
            //Using Streamwriter to make a text file and then write to it.
            using (StreamWriter streamWriter = File.CreateText(path))
            streamWriter.WriteLine(text);
        }
    }
}