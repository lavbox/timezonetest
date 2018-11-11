using System;
using TimeZoneConverter;
using System.Linq;

namespace timezonetest
{
    class Program
    {
        static void Main1(string[] args)
        {
            Console.WriteLine(string.Format("{0,-40}{1,-45}{2,-45}","Id","DisplayName","StandardName"));
            Console.WriteLine(string.Format("{0,-40}{1,-45}{2,-45}","__","___________","____________"));
            Console.WriteLine("\n");
            foreach(var item in TimeZoneInfo.GetSystemTimeZones())
		    {	
                Console.WriteLine(string.Format("{0,-40}{1,-45}{2,-45}",item.Id,item.DisplayName,item.StandardName));
		    }	
            Console.WriteLine(string.Format("{0,-40}{1,-45}{2,-45}","__","___________","____________"));
            Console.WriteLine("\n");
        }

        static void Main(string[] args)
        {
           TimeZoneInfo info = null;
            foreach(var item in TimeZoneInfo.GetSystemTimeZones())
            {   
               if(TZConvert.TryGetTimeZoneInfo(item.DisplayName, out info))
               {
                   Console.WriteLine(item.DisplayName);
               }
            }
           
        }
    }
}
