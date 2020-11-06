using System;
using System.Collections.Generic;
using System.IO;

namespace XorGates
{
    class Program
    {
        private static readonly string filename = @"C:\Users\sasho\Documents\TextTestLocation\output.csv";
        private static readonly string title = "4 XOR gates variants";
        private static readonly string columns = "A,B,Method,Logic Gates,Result";

        static void Main(string[] args)
        {
            bool correctArguments = false;
            int a = 0, b = 0;

            if (args.Length < 2) Console.WriteLine("Arguments are not provided.");
            else
            {
                if (int.TryParse(args[0], out a) && int.TryParse(args[1], out b)) correctArguments = true;
                else Console.WriteLine("Please provide a whole decimal number.");
            }

            if (correctArguments) WriteToCsv(a, b, FirstXor(a, b), SecondXor(a, b), ThirdXor(a, b), FourthXor(a, b));
        }

        private static void WriteToCsv(int a, int b, int xor1, int xor2, int xor3, int xor4)
        {
            List<string> lines = new List<string>
            {
                title, columns,
                a.ToString() + "," + b.ToString() + ",XOR1,Not/And/Or," + xor1.ToString(),
                a.ToString() + "," + b.ToString() + ",XOR2,Nand," + xor2.ToString(),
                a.ToString() + "," + b.ToString() + ",XOR3,Or/And/Not," + xor3.ToString(),
                a.ToString() + "," + b.ToString() + ",XOR4,Not/Or/And," + xor4.ToString()
            };

            File.WriteAllLines(filename, lines);
        }
        private static int FirstXor(int a, int b) => ((~a) & (b)) | ((a) & (~b));
        private static int SecondXor(int a, int b) => ~(~(a & ~(a & b)) & ~(~(a & b) & b));
        private static int ThirdXor(int a, int b) => (a | b) & ~(a & b);
        private static int FourthXor(int a, int b) => (a | b) & (~a | ~b);
    }
}
