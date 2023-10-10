namespace Rectangle_Perimeter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float w;
            float l;
            float p;

            Console.WriteLine("Enter the width of your rectangle: ");
            w = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter the length of your rectangle: ");
            l = float.Parse(Console.ReadLine());

            p = ((w + l) * 2);
            Console.WriteLine("Your perimeter is "+p);
        }
    }
}