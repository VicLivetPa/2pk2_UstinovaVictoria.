namespace PZ_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = 2;
            int[] results = GetPowerResults(number);

            foreach (int result in results)
            {
                Console.WriteLine(result);
            }
        }

        static int[] GetPowerResults(int number)
        {
            int[] results = new int[4];
            results[0] = (int)Math.Pow(number, 2);
            results[1] = (int)Math.Pow(number, 3);
            results[2] = (int)Math.Pow(number, 4);
            results[3] = (int)Math.Pow(number, 5);

            return results;

        }
    }
}