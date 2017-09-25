using ConsoleDisplayExperiment.inputTransformer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDisplayExperiment
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input/pacmap.txt");
            string[] stretched = new string[lines.Length];
            for(int i = 0; i < lines.Length; i++)
            {
                var sb = new StringBuilder();
                foreach (char x in lines[i].ToCharArray())
                {
                    sb.Append(x).Append(x);
                }
                stretched[i] = sb.ToString();
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            var drawing = new BoxDrawingTransformer().Transform(stretched);
            foreach(var line in drawing)
            {
                Console.WriteLine(line);
            }

            Console.ReadLine();
        }
    }
}
