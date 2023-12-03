using System;
using System.IO;

namespace PZ_14
{
    internal class Program
    {
            static void Main()
            {
                string filePath = "C:\\Users\\опопппло\\source\\repos\\2pk2_UstinovaVictoria\\2\\2pk2_UstinovaVictoria\\PZ_14\\mmm.txt";

                string[] lines = File.ReadAllLines(filePath);   // Чтение файла
           
                 foreach (string line in lines)  // Вывод строк 
                 {
                     if (line.EndsWith("?") || line.EndsWith("!")) // оканчивающихся вопросительным или восклицательным знаком
                     {
                         Console.WriteLine(line);
                     }
                     if (line.EndsWith("."))
                     {
                        Console.WriteLine('0');
                     }
                     
                 }
            } 
            
    }
}