using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace AqCameraModule
{
    public class IniFile
    {
        public static string IniFillFullPath;
        public IniFile(string INIPath)
        {
            IniFillFullPath = INIPath;
        }

        public static void WriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, IniFillFullPath);
        }

        public static string ReadValue(string Section, string Key, string Default)
        {
            StringBuilder buffer = new StringBuilder(255);
            GetPrivateProfileString(Section, Key, Default, buffer, 255, IniFillFullPath);
            return buffer.ToString();
        }

        public static void WriteValue(string Section, string Key, int Value)
        {
            WritePrivateProfileString(Section, Key, Value.ToString(), IniFillFullPath);
        }

        public static int ReadValue(string Section, string Key, int Default)
        {
            StringBuilder buffer = new StringBuilder(255);
            GetPrivateProfileString(Section, Key, Default.ToString(), buffer, 255, IniFillFullPath);
            int result = 0;
            if (int.TryParse(buffer.ToString(), out result))
            {
                return result;
            }
            else
            {
                return -9999;
            }
        }


        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,
            string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
            string key, string def, StringBuilder retVal, int size, string filePath);
    }
}
