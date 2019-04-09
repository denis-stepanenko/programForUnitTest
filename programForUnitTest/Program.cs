using System;

namespace programForUnitTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount("Mr. Bryan Walton", 0, 5);
            account.Debit(100);
            account.ChargeInterest();
            Console.WriteLine(account.Balance);
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
