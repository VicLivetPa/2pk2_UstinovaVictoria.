namespace PZ_08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вывод массива с рандомными значениями");
            Random rnd = new Random();
            string[][] array = new string[5][];
            string[][] array2 = new string[5][];
            string[] LastElements = new string[5];  //запись последних элементов
            string[] maxElements = new string[5]; //массив для максимальных элементов 
            string[] FirstNum = new string[5]; //массив для 1-ых цифр каждой строки
            string max = ""; //для поиска максимального числа
            int maxCount = 0;
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new string[rnd.Next(3, 27)];
                for (int j = 0; j < array[i].Length; j++)
                {
                    array[i][j] = RandomString(rnd.Next(2, 8));
                    Console.Write(array[i][j] + " ");

                    if (array[i][j].Length >= maxCount)
                    {
                        maxCount = array[i][j].Length;
                        max = array[i][j];
                    }
                   
                    if (j == 0)  //запись 1-го числа каждой строки в массив
                    {
                        FirstNum[i] = array[i][j];
                    }
                }
                maxElements[i] = max;
                max = " ";
                
                LastElements[i] = array[i][array[i].Length - 1]; //поиск последних элементов
                Console.WriteLine();
            }
            
            string RandomString(int length)  //метод для рандомного заполнения строками массива 
            {
                const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
                Random Random = new Random();
                return new string(Enumerable.Repeat(chars, length)
                  .Select(s => s[rnd.Next(s.Length)]).ToArray());
            }
            
            Console.WriteLine("Последние элементы каждого массива: "); //создание повторного массива с этими же данными 
            
            foreach (string s in LastElements) //вывод
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();
           
            Console.WriteLine("Максимальные элементы каждого массива: "); //выводим максимальные элементы
            foreach (string g in maxElements)
            {
                Console.Write(g + " ");
            }
            Console.WriteLine();
            array2 = array;
             
            Console.WriteLine("Замена первых элементов максимальными числами");  //Замена 1-ых элементов максимальными числами  
            int forFirst = 0;
            int forMax = 0;
            for (int i = 0; i < array2.Length; i++)
            {
                for (int j = 0; j < array2[i].Length; j++)
                {
                    if (array2[i][j] == FirstNum[forFirst])
                    {
                        array2[i][j] = maxElements[forFirst];
                    }
                    else if (array2[i][j] == maxElements[forMax])
                    {
                        array2[i][j] = FirstNum[forMax];
                    }
                    Console.Write(array2[i][j] + " ");
                }
                forFirst++;
                forMax++;
                Console.WriteLine();
            }
            
            Console.WriteLine("Реверс массива"); //реверс массива 
            for (int i = 0; i < array2.Length; i++)
            {
                Array.Reverse(array2[i]);
                Console.WriteLine(String.Join(" ", array2[i]));
            }
            Console.WriteLine("Общее количество в строках символов каждой строки массива"); //вывод 
            for (int i = 0; i < array2.Length; i++)
            {
                Console.Write(array2[i].Length + " ");
            }
        }
    }
}