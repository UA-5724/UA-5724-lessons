using System;

namespace hw3
{
    struct RGB
    {
        public byte red;
        public byte green;
        public byte blue;

        public RGB(byte red, byte green, byte blue)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            RGB white = new RGB(255, 255, 255);
            RGB black = new RGB(0, 0, 0);

            Console.WriteLine($"White: ({white.red}, {white.green}, {white.blue})");
            Console.WriteLine($"Black: ({black.red}, {black.green}, {black.blue})");

            Console.ReadKey();
        }
    }
}