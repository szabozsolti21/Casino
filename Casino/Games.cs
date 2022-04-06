using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    internal class Games
    {
        public static void Roulette()
        {
            Console.WriteLine("A rulettet választottad!");

            Random random = new Random();
            int computer;
            Console.WriteLine("Az egyenleged: "+Program.balance);
            Console.WriteLine("Add meg egy sorban, szóközzel elválasztva mely számokra szeretnél tenni");
            String usernumbers = Console.ReadLine();
            String[] userNumbersA = usernumbers.Split(" ");
            int[] userNumbersIntA = new int[36];

            int uCount = 0;

            foreach(String asd in userNumbersA)
            {
                userNumbersIntA[uCount] = int.Parse(asd);
                uCount ++;
            }

            for(int i=0; i < uCount; i++)
            {
                Console.WriteLine(userNumbersIntA[i]);   
            }


            computer = random.Next(0, 37);
            Console.WriteLine("A kipörgetett szám: "+computer);

            

            //tulajdonságok

            //paritás
            int p = -1;  // -1 : 0 , 0 : páros , 1 : páratlan 
            
            //harmadok
            int t = -1;
            
            //sorok
            int s = -1;
            int[] first  = { 3, 6, 9, 12, 15, 18, 21, 24, 27, 30, 33, 36 };
            int[] second = { 2, 5, 8, 11, 14, 17, 20, 23, 26, 29, 32, 35 };
            int[] third  = { 1, 4, 7, 10, 13, 16, 19, 22, 25, 28, 31, 34 };

            //szinek
            int c = -1;  // -1 : zöld , 0 : fekete , 1 : piros
            int[] green = {0};
            int[] black = { 15, 4, 2, 17, 6, 13, 11, 8, 10, 24, 33, 20, 31, 22, 29, 28, 35, 26 };
            int[] red   = { 32, 19, 21, 25, 34, 27, 36, 30, 23, 5, 16, 1, 14, 9, 18, 7, 12, 3 };

            //felek
            int h = -1;


            if (computer > 0)
            {

                //harmadok

                if (computer > 0 && computer < 13)
                {
                    t = 1;
                    Console.WriteLine("Első harmad");
                }
                if (computer > 12 && computer < 25)
                {
                    t = 2;
                    Console.WriteLine("Második harmad");
                }
                if (computer > 24 && computer <= 36)
                {
                    t = 3;
                    Console.WriteLine("Harmadik harmad");
                }

                //sorok

                if (first.Contains(computer))
                {
                s = 1;
                Console.WriteLine("Első sor");
                }
                if (second.Contains(computer))
                {
                s = 2;
                Console.WriteLine("Második sor");
                }
                if (third.Contains(computer))
                {
                s = 3;
                Console.WriteLine("Harmadik sor");
                }

                //paritás

                if(computer % 2 == 0)
                {
                    p = 0;
                    Console.WriteLine("Páros");
                }
                else
                {
                    p = 1;
                    Console.WriteLine("Páratlan");
                }

                //színek

                if (black.Contains(computer))
                {
                    c = 0;
                    Console.WriteLine("Fekete");
                }
                if(red.Contains(computer))
                {
                    c = 1;
                    Console.WriteLine("Piros");
                }

                //felek

                if (computer > 0 && computer <= 18)
                {
                    h = 1;
                    Console.WriteLine("Első fél");
                }
                if (computer > 18)
                {
                    h = 2;
                    Console.WriteLine("Második fél");
                }


            }
            else
            {
                Console.WriteLine("A szám 0, nem vonatkoznak rá a tulajdonságok");
                Console.WriteLine("A szám zöld");
            }

            Console.WriteLine("Szeretnél mégegyet játszani? (I/N)");

            string continuee = "";
            

            while (true)
            {
                continuee = Console.ReadLine();
                if (continuee == "I" || continuee == "N") break;
            }


            if(continuee == "I")
            {
                Roulette();
            }
            



        }//rulett vége

        public static void BlackJack()
        {
            Console.WriteLine("A BlackJacket választottad!");
        }



    }
}
