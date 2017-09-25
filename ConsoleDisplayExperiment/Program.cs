using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDisplayExperiment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("################################################################################");
            Console.WriteLine("#                                                                              #");
            Console.WriteLine("#                                                                              #");
            Console.WriteLine("#                                                                              #");
            Console.WriteLine("#                                                                              #");
            Console.WriteLine("#                                                                              #");
            Console.WriteLine("#                                                                              #");
            Console.WriteLine("#                                                                              #");
            Console.WriteLine("#                                                                              #");
            Console.WriteLine("#                                                                              #");
            Console.WriteLine("#                                                                              #");
            Console.WriteLine("#                                                                              #");
            Console.WriteLine("#                                                                              #");
            Console.WriteLine("#                                                                              #");
            Console.WriteLine("#                                                                              #");
            Console.WriteLine("#                                                                              #");
            Console.WriteLine("#                                                                              #");
            Console.WriteLine("#                                                                              #");
            Console.WriteLine("#                                                                              #");
            Console.WriteLine("################################################################################");

            Console.ForegroundColor = ConsoleColor.Yellow;
            var start = DateTime.Now.Ticks;
            var end = start;
            for(int i = 0; end - start < 10000000; i++)
            {
                Console.SetCursorPosition(35, 10);
                Console.Write(i);

                end = DateTime.Now.Ticks;
            }

            Console.ReadLine();
        }
    }
}
