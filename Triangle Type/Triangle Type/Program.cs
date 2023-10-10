namespace Triangle_Type
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float a;
            float b;
            float c;

            Console.WriteLine("What is your first angle?");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("What is your second angle?");
            b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("What is your third angle?");
            c = Convert.ToInt32(Console.ReadLine());

            if ((a == b) & (b == c))
            {
                Console.WriteLine("Your triangle is an Equilateral triangle.");
            }

            else if (((a == b) & (b != c)) || ((a == c) & (c != b)) || ((b == c) & (c != a)))
            {
                Console.WriteLine("Your triangle is an Isosceles triangle.");
            }

            else if ((a != b) & (a != c) & (b != c) & (a+b+c == 180))
            {
                Console.WriteLine("Your triangle is a Scalene triangle.");
            }

            else 
            {
                Console.WriteLine("Your triangle cannot physically work.");
            }
        }
    }
}