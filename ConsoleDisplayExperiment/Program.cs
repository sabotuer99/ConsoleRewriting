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
            Console.OutputEncoding = Encoding.Unicode;
            Console.CursorVisible = false;
            int height = lines.Length;
            int width = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                var sb = new StringBuilder();
                foreach (char x in lines[i].ToCharArray())
                {
                    sb.Append(x).Append(x);
                }
                stretched[i] = sb.ToString();
                width = Math.Max(width, stretched[i].Length);
            }

            Console.WindowHeight = height;
            Console.WindowWidth = width+1;

            Console.ForegroundColor = ConsoleColor.Blue;
            var drawing = new BoxDrawingTransformer().Transform(stretched);
            foreach(var line in drawing)
            {
                Console.WriteLine(line);
            }

            //draw objects
            int ghosts = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                char[] x = lines[i].ToCharArray();
                for (int j = 0; j < x.Length; j++)
                {
                    if(x[j] == '.')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(j * 2, i);
                        Console.Write('╺');
                    }

                    if (x[j] == 'o')
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(j * 2, i);
                        Console.Write('●');
                    }

                    if(x[j] == 'G')
                    {
                        string ghost = "";
                        switch (ghosts % 4)
                        {
                            case 0:
                                Console.ForegroundColor = ConsoleColor.Red;
                                ghost = "▲";
                                break;
                            case 1:
                                Console.ForegroundColor = ConsoleColor.Green;
                                ghost = "▼";
                                break;
                            case 2:
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                ghost = "►";
                                break;
                            case 3:
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                ghost = "◄";
                                break;
                        }
                        ghosts++;
                        Console.SetCursorPosition(j * 2, i);
                        Console.Write(ghost);
                    }

                    if (x[j] == 'P')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(j * 2, i);
                        Console.Write(@"(<  >)  ()\/");
                    }

                    if (x[j] == 'O')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.SetCursorPosition(j * 2, i);
                        Console.Write("ὅ");
                    }

                    if (x[j] == 'C')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(j * 2, i);
                        Console.Write("ὡ");
                    }

                    if (x[j] == 'B')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(j * 2, i);
                        Console.Write("₼");
                    }

                    if (x[j] == 'A')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.SetCursorPosition(j * 2, i);
                        Console.Write("ʘ");
                    }

                    Console.SetCursorPosition(0, lines.Length);

                }
            }

            Console.ForegroundColor = ConsoleColor.White;
            while (true)
            {

                var key = Console.ReadKey();

                var pressed = key.Key;
                Console.SetCursorPosition(width - 10, height / 2 - 1);
                    
                    switch (pressed)
                    {
                        case ConsoleKey.UpArrow:
                            Console.Write("↑ ");
                            break;
                        case ConsoleKey.DownArrow:
                            Console.Write("↓ ");
                            break;
                        case ConsoleKey.LeftArrow:
                            Console.Write("← ");
                            break;
                        case ConsoleKey.RightArrow:
                            Console.Write("→ ");
                            break;
                        default:
                            Console.Write(pressed.ToString().PadRight(2).Substring(0,2));
                            break;
                    }

            }
            
        }
    }
}
