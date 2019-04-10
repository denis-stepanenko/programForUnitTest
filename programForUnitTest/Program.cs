using System;

namespace programForUnitTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            Deposit deposit = new Deposit("Mr. Bryan Walton", 0, 5);
            deposit.Put(100);
            deposit.ChargeInterest();
            Console.WriteLine(deposit.Balance);
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
