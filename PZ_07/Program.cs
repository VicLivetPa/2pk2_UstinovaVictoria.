namespace PZ_07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            
                int[,] array = new int[7, 7];
                Random random = new Random();

                for (int i = 0; i < 7; i++)  // заполняем массив рандомными числами
                {
                    for (int j = 0; j < 7; j++)
                    {
                        array[i, j] = random.Next(-50, 51);
                    }
                }

                Console.WriteLine("Побочная диагональ массива:");  // выводим побочную диагональ массива
                for (int i = 0; i < 7; i++)
                {
                    Console.Write(array[i, 6 - i] + " ");
                }
                Console.WriteLine();

                int negativeCount = 0;  // считаем количество отрицательных элементов на побочной диагонали
                for (int i = 0; i < 7; i++)
                {
                    if (array[i, 6 - i] < 0)
                    {
                        negativeCount++;
                    }
                }

                Console.WriteLine("Количество отрицательных элементов на побочной диагонали: " + negativeCount);
            
        }
 
    }

}