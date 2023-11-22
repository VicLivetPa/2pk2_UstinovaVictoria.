namespace PZ_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
             Console.WriteLine("Введите текст:");
        string text = Console.ReadLine();

        string newText = RemoveContentInBrackets(text);
        Console.WriteLine("Обновленный текст:");
        Console.WriteLine(newText);
    }

    static string RemoveContentInBrackets(string text)
    {
        int startIndex;
        while ((startIndex = text.IndexOf('(')) != -1)
        {
            int endIndex = text.IndexOf(')', startIndex);
            if (endIndex != -1)
            {
                text = text.Remove(startIndex, endIndex - startIndex + 1);
            }
        }
               return text;
        }
    }
}