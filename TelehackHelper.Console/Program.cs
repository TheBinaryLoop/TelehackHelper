using System;
using TelehackHelper.Core;
using CL = System.Console;

namespace TelehackHelper.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            CL.Write("Creating database...");
            Database db = new Database();
            CL.WriteLine("Done");

            CL.ReadLine();
        }
    }
}
