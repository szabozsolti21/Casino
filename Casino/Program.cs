using System;

namespace Casino
{
    internal class Program
    {

        public static int balance = 10000;


        static void Main(string[] args)
        {
            string c = "";
            do {
                if (c != "") Console.WriteLine("Kérlek a két lehetőség közül válassz!");

                Console.WriteLine("Add meg mit szeretnél játszani!");
                Console.WriteLine("Rulett : 1");
                Console.WriteLine("BlackJack : 2");
                c = Console.ReadLine();
                if (c == "1")
                {
                    balance = Roulette.Play();
                }
                if (c == "2")
                {
                    Console.WriteLine("Jelenleg nem elérhető");
                }
            }while (!(c == "1" || c == "2"));





        }
    }
}
