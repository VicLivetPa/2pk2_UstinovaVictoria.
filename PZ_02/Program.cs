namespace PZ_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число m: ");
            int m = Convert.ToInt32(Console.ReadLine()); //целое число
            double  n, x, y, z; // действительные числа
            Console.WriteLine("Введите число n: ");
            n = double.Parse(Console.ReadLine());
            m = (int)double.Parse(Console.ReadLine());  
            if (m > 5)
            {
                x = Math.Sin(m + n);
            }
            else
            {
                x = (n + 5 * Math.Sqrt(m + Math.Pow(n, 2) - 2.1 * n));
            }
            if (x > 0)
            {
                y = Math.Cos(m + n) * Math.Sin(n * x);
            }
            else
            {
                y = (Math.Log(m * n + x));
            }
            z = (2 * x + 3 * y) / (Math.Pow(m, 2) + 5);
            Console.WriteLine("Ответ:" + z); // показ ответа
        }
    }
}