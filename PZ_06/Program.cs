using System;

namespace PZ_06
{
    internal class Program
    {
        static void Main(string[] args)
        {

            double[] array = new double[20];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Math.Pow(2, i) / 2;
            }

            Array.Reverse(array);

            foreach (double element in array)
            {
                Console.WriteLine(element);
            }

        }
    }
}
       
        

