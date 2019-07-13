﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Process.Start(@"chrome.exe", "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");
        }
    }
}