using System;
//Author Josko Radic
// Sep 2019
namespace projekt
{
    class Program
    {
        static void Main(string[] args)
        {
            int euro = 0;
            int centi = 0;

            Console.WriteLine("This program converts numerical representation of EUR and Cents to the Croatian words");

            while (true)
            {
                Console.Write("Enter EUR:");
                euro = Int32.Parse(Console.ReadLine());
                Console.Write("Enter Cents:");
                centi = Int32.Parse(Console.ReadLine());
                MoneyTextConverter money = new MoneyTextConverter(kune, centi);
                Console.WriteLine(money.ConvertedValueKune + " Eur and "+ money.ConvertedValuecenti + " Cents");
            }
        }
    }
}
