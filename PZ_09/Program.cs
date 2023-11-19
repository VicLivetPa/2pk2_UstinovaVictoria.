namespace PZ_09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            int g = 0;
            while (true)
            {
                Console.WriteLine("Введите строку: ");
                string str = Console.ReadLine();
                 //првоеряем строку на содержание только Букв
                if (str.All(char.IsLetter))
                {
                    list.Add(str);
                }
                 //првоеряем пустая ли строка
                if (String.IsNullOrEmpty(str))
                {
                    Console.WriteLine("Пустая строка");
                    Console.Write("Первая введеная строка которая не содержит циры: ");
                    Console.WriteLine(list[0]);
                    break;
                }
            }
        }
    }
}