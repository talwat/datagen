using System;
using System.IO;

namespace TextFile {
    class TextFile {
        public static void TextFileMake(string path, string text) {
            using (StreamWriter streamWriter = File.CreateText(path))
            streamWriter.WriteLine(text);
        }
    }
}