using System;
using System.IO;

namespace XOutput
{
    static class SaveManager
    {

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


        public static void Save(string _Guid, byte[] Mapping)
        {
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
