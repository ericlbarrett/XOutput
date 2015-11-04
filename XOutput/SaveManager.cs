using System;
using System.IO;

namespace XOutput
{
    static class SaveManager
    {
        static string[] names = new string[] {"button_a", "button_b", "button_x", "button_y",
            "dpad_up", "dpad_down", "dpad_left", "dpad_right",
            "left_trigger", "right_trigger", "left_bumper", "right_bumper", "left_axebutton", "right_axebutton",
            "home", "start", "back", "left_y", "left_x", "right_y", "right_x"};
        static private string fileName = @"XOutput.ini";


        public static byte[] Load(string _Guid)
        {
            TextReader mappingFile = null;
            if (File.Exists(fileName))
            {
                try
                {

                    mappingFile = new StreamReader(fileName);
                    string strLine = mappingFile.ReadLine();
                    while (strLine != null)
                    {
                        if (strLine != "")
                        {
                            strLine = strLine.Trim();
                            if (strLine.StartsWith("[") && strLine.EndsWith("]"))
                            {
                                string Guid = strLine.Substring(1, strLine.Length - 2);
                                if (Guid == _Guid)
                                {
                                    strLine = mappingFile.ReadLine();
                                    return Convert.FromBase64String(strLine);
                                }
                            }
                        }
                        strLine = mappingFile.ReadLine();
                    }
                    mappingFile.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                TextWriter tw = new StreamWriter(fileName);
                tw.Write("");
                tw.Close();
            }
            return null;
        }

        private static string generateSaveString(byte[] Mapping) {
            string[] typeString = new string[] { "btn{0}", "{1}axis{0}", "dpad{0}{2}" };
            string[] axesString = new string[] { "", "i", "h", "ih" };
            string[] dpadString = new string[] { "up", "down", "left", "right" };
            
            string saveString = "";
            for (int i = 0; i < 21; i++) {
                saveString += names[i] + "=";
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

        public static void Save(string _Guid, byte[] Mapping)
        {
            string saveString = generateSaveString(Mapping);
            Console.WriteLine(saveString);
            string s = "";
            if (File.Exists(fileName))
            {
                try
                {
                    string[] fl = File.ReadAllLines(fileName);
                    string strLine;
                    bool saved = false;


                    for (int i = 0; i < fl.Length; i++)
                    {
                        strLine = fl[i];
                        if (strLine != "")
                        {
                            strLine = strLine.Trim();
                            if (strLine.StartsWith("[") && strLine.EndsWith("]"))
                            {
                                string Guid = strLine.Substring(1, strLine.Length - 2);
                                if (Guid == _Guid)
                                {
                                    s += strLine + "\r\n";
                                    s += Convert.ToBase64String(Mapping) + "\r\n";
                                    saved = true;
                                    break;
                                }
                            }
                        }
                        s += strLine + "\r\n";
                    }

                    if (!saved)
                    {
                        s += ("[" + _Guid + "]" + "\r\n");
                        s += Convert.ToBase64String(Mapping) + "\r\n";
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                s += ("[" + _Guid + "]" + "\r\n");
                s += Convert.ToBase64String(Mapping) + "\r\n";
            }
            TextWriter tw = new StreamWriter(fileName, false);
            tw.Write(s);
            tw.Close();
        }

    }
}
