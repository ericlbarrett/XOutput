using System;
using System.IO;


namespace XOutput {
    static class Logger {
        static private string fileName = @"XOutput.log";

        public static void Log(string s) {
            Console.WriteLine(s);
            if (File.Exists(fileName)) {
                string l = File.ReadAllText(fileName);
                l += "\r\n" + s;
                File.WriteAllText(fileName, l);
            } else {
                File.Create(fileName); // If the file doesn't exist create it
            }
        }
    }
}
