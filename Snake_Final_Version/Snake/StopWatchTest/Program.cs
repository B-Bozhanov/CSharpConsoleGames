using System;
using System.Diagnostics;
using System.Numerics;

namespace StopWatchTest
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal number = 0;

            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (decimal i = 1; i <= 10000000000000000; i++)
            {
                number += i;
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            Console.WriteLine(number);
        }
    }
}
