namespace PZ_05
{
    internal class Program
    {
        private static object start_celsius;
        private static object end_celsius;
        private static object step;

        static void Main(string[] args, object current_celsius)
        {
          Console.WriteLine("Программа для вывода таблицы соответствия температуры в градусах Цельсия и Фаренгейта");

            // Ввод диапазона изменения температуры в градусах Цельсия
            start_celsius = float(int("Введите начальное значение температуры в градусах Цельсия: "));
            end_celsius = float(int("Введите конечное значение температуры в градусах Цельсия: "));
            step = float(int("Введите шаг изменения температуры: "));

            Console.WriteLine("\nТаблица соответствия температуры в градусах Цельсия и Фаренгейта:");

            // Используем цикл while для вывода таблицы
            current_celsius = start_celsius;
              while current_celsius <= end_celsius ;
              fahrenheit = 9 / 5 * current_celsius + 32;
            Console.WriteLine(f"Цельсий: {current_celsius} °C\tФаренгейт: {fahrenheit} °F");
            current_celsius += step;

             Console.WriteLine("\nПрограмма завершена.");
        }
    }
}