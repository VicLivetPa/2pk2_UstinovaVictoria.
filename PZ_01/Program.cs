using System;
namespace PZ_01
{
     class Program
    {
        static void Main(string[] args)
        {
            double a, b, c, num1, num2, num3, num4, result;
            Console.WriteLine("Введите число a (пи = pi)");
            string aInput = Console.ReadLine(); //ввод переменной a
            Console.WriteLine("Введите число b (пи = pi)");
            string bInput = Console.ReadLine(); //ввод переменной b
            Console.WriteLine("Введите число c (пи = pi)");
            string cInput = Console.ReadLine(); //ввод переменной c
            if (aInput.ToLower() == "pi") { a = Math.PI; }
            else { a = double.Parse(aInput); } //проверяем число a
            if (bInput.ToLower() == "pi") { b = Math.PI; }
            else { b = double.Parse(bInput); } //проверяем число b
            if (cInput.ToLower() == "pi") { c = Math.PI; }
            else { c = double.Parse(cInput); } //проверяем число c
            num1 = Convert.ToDouble(Math.Sqrt((a * b * c) / 2.4) - ((0.7 * a * b * c) / Math.Sin(b)));
            num2 = Convert.ToDouble(Math.Abs(Math.Cos(b)));
            num3 = Convert.ToDouble(Math.Pow(10, 4) * Math.Pow(num2, (1 / 5.0)));
            num4 = Convert.ToDouble(Math.Abs(b - a) / 7.5);
            result = num1 + num3 - num4;
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
