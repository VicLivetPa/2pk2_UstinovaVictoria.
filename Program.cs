namespace PZ_13
{
    internal class Program
    {
        //арифметическая прогрессия
        static void Main(string[] args)
        {
           
            Console.Write("Введите номер члена арифметической прогрессии: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int result = ArithmProgression(n);
            Console.WriteLine($"{n} член прогрессии = " + result);
        }
        static int ArithmProgression(int n)
        {
            if (n == 1)
                return -10;
            else
                return ArithmProgression(n - 1) - 2;
        }
        //геометрическая прогрессия
        static void Main(string[] args)
        {
            Console.Write("Введите номер члена геометрической прогрессии: ");
            int n_2 = Convert.ToInt32(Console.ReadLine());
            int result_2 = GeomProgression(n_2);
            Console.WriteLine($"{n_2} член прогрессии = " + result_2);
        }
        static int GeomProgression(int n)
        {
            if (n == 1) return 12;

            else return GeomProgression(n - 1) * (-2);
            

        }
        static void Main(string[] args)
        { 
            Console.Write("Введите число А: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите число B: ");
            int b = Convert.ToInt32(Console.ReadLine());
            if (a > b)
            {
                Console.WriteLine("Вывод чисел в порядке убывания: ");
                OutputNum(a, b);
            }
            else  if (a<b)
            {
                Console.WriteLine("Вывод чисел в порядке возрастания: ");
                OutputNumbers(a, b);
            }
           
            else 
                Console.WriteLine("Число А = В");
                Console.WriteLine(a);
             
            
           Console.Write("Введите число n: ");  //Использование рекурсии Summ(int x) для введенного числа 
           int n_3 = Convert.ToInt32(Console.ReadLine());
           int result_4 = Summ(n_3);
           Console.WriteLine($"Сумма чисел от 1 до {n} = {result_4}");
        }
       
        static void OutputNum(int A, int B)//метод в порядке убывания
        {
            if (A >= B)
            {
                Console.WriteLine(A);
                A--;
                OutputNum(A, B);
            }
        }
        static void OutputNumbers(int A, int B)//методв порядке возрастания
        {
            if (A <= B)
            {
                Console.WriteLine(A);
                A++;
                OutputNumbers(A, B);
            }
        }
        static int Summ(int n)//метод для вычисления суммы 
        {
            if (n == 1) return 1;
            else if (n < 1) return 0;
            else return n + Summ(n - 1);
        }
    }



}