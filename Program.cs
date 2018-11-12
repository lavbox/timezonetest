using System;
using TimeZoneConverter;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace timezonetest
{
    class Program
    {
        static void Main(string[] args)
        {
            string environment = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "Windows" : "Linux";
            var content = new StringBuilder("");
            var names = new Dictionary<string, string>();
            foreach (var item in TimeZoneInfo.GetSystemTimeZones().OrderBy(p=>p.StandardName))
            {
                if (!names.ContainsKey(item.StandardName))
                {
                    names.Add(item.StandardName, "");
                    content.Append(item.StandardName);
                    content.Append(Environment.NewLine);
                }
            }
            Console.Write(content.ToString());
            System.IO.File.WriteAllText(string.Format("../../../{0}.StandardName.txt",environment), content.ToString());
        }

        static void Main2(string[] args)
        {
            Console.WriteLine(string.Format("{0,-40}{1,-45}{2,-45}", "Id", "DisplayName", "StandardName"));
            Console.WriteLine(string.Format("{0,-40}{1,-45}{2,-45}", "__", "___________", "____________"));
            Console.WriteLine("\n");
            foreach (var item in TimeZoneInfo.GetSystemTimeZones())
            {
                Console.WriteLine(string.Format("{0,-40}{1,-45}{2,-45}", item.Id, item.DisplayName, item.StandardName));
            }
            Console.WriteLine(string.Format("{0,-40}{1,-45}{2,-45}", "__", "___________", "____________"));
            Console.WriteLine("\n");
        }

        static void Main1(string[] args)
        {
            TimeZoneInfo info = null;
            foreach (var item in TimeZoneInfo.GetSystemTimeZones())
            {
                if (TZConvert.TryGetTimeZoneInfo(item.DisplayName, out info))
                {
                    Console.WriteLine(item.DisplayName);
                }
            }

        }
    }
}
