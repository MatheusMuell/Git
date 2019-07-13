using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName = Environment.UserName;
            string admin = Environment.UserDomainName;


            if (userName == "65869")
            {
                Process.Start(@"C:\WINDOWS\system32\rundll32.exe", "user32.dll,LockWorkStation");
            }
            else
            {
                Process.Start(@"chrome.exe", "https://www.youtube.com/");
            }
        }
    }
}
