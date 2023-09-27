namespace PZ_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число i:");
            int i = int.Parse(Console.ReadLine());
            if (i <= 0 || i > 365) //проверка правильности ввода числа i
            {
                Console.WriteLine("Ввод невереный ! Число в диапозоне от 1 до 365.");
                return;
            }
            int x = (i % 7); //определение дня недели
            switch (x) //вывод дня недели
            {
                case 1:
                    Console.WriteLine("Понедельник");
                    break;
                case 2:
                    Console.WriteLine("Вторник");
                    break;
                case 3:
                    Console.WriteLine("Среда");
                    break;
                case 4:
                    Console.WriteLine("Четверг");
                    break;
                case 5:
                    Console.WriteLine("Пятница");
                    break;
                case 6:
                    Console.WriteLine("Суббота");
                    break;
                case 7:
                    Console.WriteLine("Воскресенье");
                    break;
            }
        }
    }
}