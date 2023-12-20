using System;
using System.IO;
namespace PZ_15
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите полный путь к каталогу: ");
            string directoryPath = Console.ReadLine();

            if (Directory.Exists(directoryPath))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
                DirectoryInfo[] subdirectories = directoryInfo.GetDirectories();

                var sortedSubdirectories = subdirectories.OrderByDescending(subdir => GetDirectorySize(subdir));

                Console.WriteLine("Имена каталогов в порядке убывания по размеру: ");

                foreach (var subdir in sortedSubdirectories)
                {
                    Console.WriteLine(subdir.Name);
                }
            }
            else
            {
                Console.WriteLine("Указанный каталог не существует...");
            }

            Console.ReadKey();
        }

        static long GetDirectorySize(DirectoryInfo directoryInfo)
        {
            long size = 0;

            FileInfo[] files = directoryInfo.GetFiles();
            foreach (var file in files)
            {
                size += file.Length;
            }

            DirectoryInfo[] subdirectories = directoryInfo.GetDirectories();
            foreach (var subdir in subdirectories)
            {
                size += GetDirectorySize(subdir);
            }
            return size;
        }
    }
}