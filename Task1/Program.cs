using System;
using System.Collections.Generic;

namespace Task1
{
    internal class Program
    {
        private static void Main()
        {
            var inputLines = new List<string>
            {
                "1 Line 1",
                "2 Line2",
                "",
                "3 Line 3"
            };

            try
            {
                foreach (var arg in inputLines) 
                {
                    Console.WriteLine(arg[0]);
                }
            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}