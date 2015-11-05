using System;
using System.IO;

namespace XOutput
{
    static class SaveManager {
        static string[] properties = new string[] {"button_a", "button_b", "button_x", "button_y",
            "dpad_up", "dpad_down", "dpad_left", "dpad_right",
            "left_trigger", "right_trigger", "left_bumper", "right_bumper", "left_axebutton", "right_axebutton",
            "home", "start", "back", "left_y", "left_x", "right_y", "right_x"};
        static private string dirName = @"configs";

        private static byte[] parseLine(string line) { //This needs better error hadnling
            int i; //The index of the control in the map array
            byte type = 255, subType = 255, num = 255;
            for (i = 0; i < 21; i++) { //find which button this is for
                if (line.StartsWith(properties[i])) {
                    break;
                }
                if (i == 20) {
                    Logger.Log("Error parsing: Could not identify property");
                    return new byte[] { 255, 255, 255};
                }
            }
            if (properties[i].Length + 1 > line.Length) {
                Logger.Log("Error parsing: No assignment");
                return new byte[] { 255, 255, 255 };
            }
            string val = line.Remove(0, properties[i].Length + 1); //remove up to the = sign
            if (val.StartsWith("btn")) {
                type = 0;
                subType = 0;
                num = byte.Parse(val.Remove(0, 3));
            } else if (val.Contains("axis")) {
                type = 1;
                if (val.StartsWith("ih")) {
                    num = byte.Parse(val.Remove(0, 6));
                    subType = 3;
                } else if (val.StartsWith("h")) {
                    subType = 2;
                    num = byte.Parse(val.Remove(0, 5));
                } else if (val.StartsWith("i")) {
                    subType = 1;
                    num = byte.Parse(val.Remove(0, 5));
                } else {
                    subType = 0;
                    num = byte.Parse(val.Remove(0, 4));
                }
            } else if (val.StartsWith("dpad")) {
                type = 2;
                val = val.Remove(0, 4);
                if (val.EndsWith("up")) {
                    subType = 0;
                    num = byte.Parse(val.Remove(val.Length - 2));
                } else if (val.EndsWith("down")) {
                    subType = 1;
                    num = byte.Parse(val.Remove(val.Length - 4));
                } else if (val.EndsWith("left")) {
                    subType = 2;
                    num = byte.Parse(val.Remove(val.Length - 4));
                } else if (val.EndsWith("right")) {
                    subType = 3;
                    num = byte.Parse(val.Remove(val.Length - 5));
                }
            } else if (val == "disabled") {
            } else {
                Logger.Log("Error parsing: Could not identify value");
                return new byte[] { 255, 255, 255 };
            }
            num -= 1;
            byte l = (byte)(type << 4 | subType);
            return new byte[] { (byte)(i * 2), l, num};
        }

        public static byte[] Load(string devName) {
            if (!Directory.Exists(dirName)) {
                Directory.CreateDirectory(dirName);
                return null;
            }
            string path = dirName + "\\" + devName + ".ini";
            if (!File.Exists(path)) {
                File.Create(path);
                return null;
            }
            byte[] mapping = new byte[42];
            string[] config = File.ReadAllLines(path);
            for (int i = 0; i < config.Length; i++) {
                byte[] data = parseLine(config[i]);
                Console.Write(data[0]);
                if (data[0] > 40) {
                    continue;
                }
                mapping[data[0]] = data[1];
                mapping[data[0] + 1] = data[2];
            }
            return mapping;
        }
        
        public static void Save(string devName, byte[] mapping) {
            if (!Directory.Exists(dirName)) {
                Directory.CreateDirectory(dirName);
            }
            string path = dirName + "\\" + devName + ".ini";
            if (!File.Exists(path)) {
                File.Create(path);
            }
            File.WriteAllText(path, generateSaveString(mapping));
        }

        private static string generateSaveString(byte[] Mapping) {
            string[] typeString = new string[] { "btn{0}", "{1}axis{0}", "dpad{0}{2}" };
            string[] axesString = new string[] { "", "i", "h", "ih" };
            string[] dpadString = new string[] { "up", "down", "left", "right" };

            string saveString = "";
            for (int i = 0; i < 21; i++) {
                saveString += properties[i] + "=";
                if (Mapping[i * 2] == 255) {
                    saveString += "disabled\r\n";
                    continue;
                }
                byte subType = (byte)(Mapping[i * 2] & 0x0F);
                byte type = (byte)((Mapping[i * 2] & 0xF0) >> 4);
                byte num = (byte)(Mapping[i * 2 + 1] + 1);
                saveString += string.Format(typeString[type], num, axesString[subType], dpadString[subType]) + "\r\n";
            }
            return saveString;
        }

    }
}
