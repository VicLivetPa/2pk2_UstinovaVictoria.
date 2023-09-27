namespace PZ_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start = 10;
            int end = 50;
            int step = 6;

            for (int a = start; a <= end; a += step)
            {
                Console.WriteLine(a);
            }

            //задание 2

            char startChar = 'м'; // символ "м" (русская "м" или "М")

            for (int n = 0; n < 6; n++)
            {
                Console.Write(startChar);
                startChar++; // увеличиваем символ на единицу
            }

            Console.WriteLine();

            //задание 3 

            int rows = 10; // Количество строк
            int columns = 8; // Количество знаков в строке

            for (int c = 0; c < rows; c++)
            {
                for (int x = 0; x < columns; x++)
                {
                    Console.Write('#'); // Выводим '#'
                }
                Console.WriteLine(); // Переходим на новую строку после вывода 8 знаков
            }

            Console.ReadKey();

            //задание 4

            int count = 0;

            for (int p = -50; p <= 50; p++)
            {
                if (p % 20 == 0)
                {
                    Console.Write(p + " ");
                    count++;
                }
            }

            Console.WriteLine("\nКоличество чисел, кратных 20: " + count);
            //задание 5 
            int i = 0;
            int j = 40;

            while (Math.Abs(i - j) > 10)
            {
                Console.WriteLine("i: " + i + " j: " + j);
                i++;
                j--;
            }

        }
       
    }
}


