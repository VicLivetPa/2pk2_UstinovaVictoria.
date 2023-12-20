namespace PZ_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int RootsCount(double A, double B, double C)
            {
                double discriminant = B * B - 4 * A * C;

                if (discriminant > 0)
                {
                    // Два различных корня
                    return 2;
                }
                else if (discriminant == 0)
                {
                    // Один корень
                    return 1;
                }
                else
                {
                    // Нет корней
                    return 0;
                }
            }
            // Пример использования 
            int eRoots = RootsCount(6, -6, 1);//2 корня
           
            Console.WriteLine("Уравнение.Кол-во корней: " + eRoots);
        }
    }
}