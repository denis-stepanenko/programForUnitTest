using System;

namespace programForUnitTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write(min(5, 7, 1));
            Console.ReadLine();
        }

        public static int min(int a, int b, int c)
        {
            int result = a;

            if(result > b)
            {
                result = b;
            }

            if(result > c)
            {
                result = c;
            }

            return result;
        }
    }
}
