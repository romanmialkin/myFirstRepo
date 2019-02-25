using System;

namespace CustomConversions
{
    public struct Rectangle
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Rectangle(int w, int h) : this()
        {
            Width = w;
            Height = h;
        }
        public void Draw()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.Write($"*");
                }
                Console.WriteLine();
            }
        }
        public override string ToString()
        {
            return $"[Width = {Width}, Height = {Height}]";
        }
    }
    public struct Square
    {
        public int Length { get; set; }
        public Square(int l) : this()
        {
            Length = l;
        }
        public void Draw()
        {
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    Console.Write($"*");
                }
                Console.WriteLine();
            }
        }
        public override string ToString()
        {
            return string.Format($"[Length = {Length}]");
        }
        public static explicit operator Square(Rectangle rect)
        {
            var s = new Square();
            s.Length = rect.Height;
            return s;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var rectangle = new Rectangle(15, 4);
            rectangle.DoNothing(5);
            Console.WriteLine();
            Console.WriteLine(rectangle.ToString());
            rectangle.Draw();
            Console.WriteLine();
            Square square = (Square)rectangle;
            Console.WriteLine(square.ToString());
            square.Draw();
            
            Console.ReadLine();
        }
    }
}
