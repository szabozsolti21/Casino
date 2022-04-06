using System;

namespace Casino
{
    internal class Program
    {

        public static int balance = 10000 ;






        static void Main(string[] args)
        {
            Console.WriteLine("Add meg mit szeretnél játszani!");
            Console.WriteLine("Rulett : 1");
            Console.WriteLine("BlackJack : 2");
            var c = Console.ReadLine();
            if(c == "1")
            {
                Games.Roulette();
            }
            if(c == "2")
            {
                Games.BlackJack();
            }





        }
    }
}
