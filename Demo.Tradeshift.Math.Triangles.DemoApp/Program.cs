using System;
using Demo.Tradeshift.Math.Triangles.Enums;

namespace Demo.Tradeshift.Math.Triangles.DemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 3 || args.Length == 2 && args[1]?.ToLower() == "help")
            {
                WriteHelp();
                return;
            }

            if (double.TryParse(args[0], out var a)
                && double.TryParse(args[1], out var b)
                && double.TryParse(args[2], out var c))
            {
                try
                {
                    TriangleClassification classification = TriangleClassificator.ClassifyBySides(a, b, c);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Triangle with sides ({a}, {b}, {c}) is {classification}");
                    Console.ResetColor();
                }
                catch (ArgumentException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: {e.Message}");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Incorrect input:");
                WriteHelp();
                Console.ResetColor();
            }
        }

        private static void WriteHelp()
        {
            Console.WriteLine("Please enter lengths of triangle sides");
            Console.WriteLine("Example: Demo.Tradeshift.Math.Triangles.DemoApp 3.0 4.0 5.0");
        }
    }
}