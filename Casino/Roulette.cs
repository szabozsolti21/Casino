using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    internal class Roulette
    {
        public static int Play()
        {
            Console.WriteLine("A rulettet választottad!");

            Console.WriteLine("Az egyenleged: " + Program.balance);


            //Felhasználó tippjeinek bekérése (Szám mezők)
            Dictionary<int, int> userBets = new Dictionary<int, int>();

            Console.WriteLine("Szeretnél számokra fogadni? (I/N)");
            String numbers = Console.ReadLine();
            if(numbers == "I")
            {
                do
                {
                    userBets = GetUserBets(Program.balance);
                }while(userBets == null);
            }
            

            //Felhasznéló tippjeinek bekérése (Egyéb mezők)
            Dictionary<String, int> userBetsOther = new Dictionary<String, int>();
            if (RemainingBalance(Program.balance, userBets) > 0)
            {
                do
                {
                    userBetsOther = GetUserOtherBets(RemainingBalance(Program.balance, userBets));
                } while (userBetsOther == null);
            }
            //Szám kipörgetése
            int r = GenerateNumber();


            //Szám tulajdonságainak meghatározása
            Number number = new Number(r);

            Console.WriteLine(number.ToFormattedString());

            //Nyeremény kiszámítása
            int prize = CalculatePrize(Program.balance, userBets, userBetsOther, number);


            Console.WriteLine("Az egyenleged a játék után: "+prize);

            return prize;

        }//rulett vége

        private static int RemainingBalance(int balance, Dictionary<int, int> userbets)
        {
            return (balance - userbets.Sum(x => x.Value));
        }

        //Rögzíti a felhasználó tétjeit
        private static Dictionary<int,int> GetUserBets(int balance)
        {
            Dictionary<int, int> userBets = new Dictionary<int, int>();
            int betsum = 0;

            Console.WriteLine("Add meg szóközzel elválasztva mely számokra (0-36) milyen összeget " +
                                    "szeretnél tenni! (Pl: 10-300 21-200 33-150)");

            String userBetsS = Console.ReadLine();
            String[] userNumbersA = userBetsS.Split(" ");

            foreach(String s in userNumbersA)
            {
                if (!s.Contains("-"))
                {
                    Console.WriteLine("Nem megfelelő formátumú bemenet!");
                    return null;
                }

                String[] splitted = s.Split("-");

                int num = int.Parse(splitted[0]);
                int bet = int.Parse(splitted[1]);

                if (num >= 0 && num < 37)
                {
                    if (!userBets.ContainsKey(num))
                    {
                        userBets.Add(num, bet);
                        betsum += bet;
                    }
                    else
                    {
                        Console.WriteLine("Egy számot csak egyszer adj meg!");
                        return null;
                    }
                }
                else
                {
                    Console.WriteLine("Az egyik szám kívül esik a megadott intervallumon! (0-36)");
                    return null;
                }

            }
            
            if(betsum > balance)
            {
                Console.WriteLine("A tétek összege meghaladja az egyenleged!");
                return null;
            }

            return userBets;
        }

        private static Dictionary<string, int> GetUserOtherBets(int balance)
        {

            Dictionary<String,int> r = new Dictionary<String,int>();

            int betsum = 0;

            int pValue = 0;
            int cValue = 0;
            int hValue = 0;
            int dValue = 0;
            int colorValue = 0;

            Console.WriteLine("A maradék felhasználható egyenleged: " + balance);

            //Parity
            Console.WriteLine("Ha szeretnél tenni a paritásra válassz:\n" +
                              "Páros: 0\n" +
                              "Páratlan: 1\n" +
                              "Ha nem szeretnél tenni: N");
            String p = "P"+Console.ReadLine();

            if (p != "PN")
            {
                Console.Write("Add meg mennyit szeretnél tenni rá: ");
                pValue = int.Parse(Console.ReadLine());
                betsum += pValue;
            }

            //Column
            Console.WriteLine("\nHa szeretnél tenni oszlopra válassz:\n" +
                              "Premier: P (Számok, melyek 3-mal osztva 1-et adnak maradékul)\n" +
                              "Moyen: M (Számok, melyek 3-mal osztva 2-őt adnak maradékul)\n" +
                              "Dernier: D (Számok, melyek 3-mal osztva 0-át adnak maradékul)\n" +
                              "Ha nem szeretnél tenni: N");
            String c = "C"+Console.ReadLine();
            
            if (c != "CN")
            {
                Console.Write("Add meg mennyit szeretnél tenni rá: ");
                cValue = int.Parse(Console.ReadLine());
                betsum += cValue;
            }


            //Half
            Console.WriteLine("\nHa szeretnél tenni félre válassz:\n" +
                              "Első fél: 1\n" +
                              "Második fél: 2\n" +
                              "Ha nem szeretnél tenni: N");
            
            String h = "H"+Console.ReadLine();

            if (h != "HN")
            {
                Console.Write("Add meg mennyit szeretnél tenni rá: ");
                hValue = int.Parse(Console.ReadLine());
                betsum += hValue;
            }


            //Dozen
            Console.WriteLine("\nHa szeretnél tenni tucatra válassz:\n" +
                              "Első: 1 (Számok, melyek 3-mal osztva 1-et adnak maradékul)\n" +
                              "Második: 2 (Számok, melyek 3-mal osztva 2-őt adnak maradékul)\n" +
                              "Harmadik: 3 (Számok, melyek 3-mal osztva 0-át adnak maradékul)\n" +
                              "Ha nem szeretnél tenni: N");
            String d = "D"+Console.ReadLine();

            if (d != "DN")
            {
                Console.Write("Add meg mennyit szeretnél tenni rá: ");
                dValue = int.Parse(Console.ReadLine());
                betsum += dValue;
            }


            //Color
            Console.WriteLine("\nHa szeretnél tenni színre válassz:\n" +
                              "Zöld: Z\n" +
                              "Fekete: F\n" +
                              "Piros: P\n" +
                              "Ha nem szeretnél tenni: N");
            String color = "Co"+Console.ReadLine();

            if (color != "CoN")
            {
                Console.Write("Add meg mennyit szeretnél tenni rá: ");
                colorValue = int.Parse(Console.ReadLine());
                betsum += colorValue;
            }

            if(betsum > balance)
            {
                Console.WriteLine("A tétek összege meghaladja az egyenleged!");
                return null;
            }

            r.Add(p, pValue);
            r.Add(c, cValue);
            r.Add(h, hValue);
            r.Add(d, dValue);
            r.Add(color, colorValue);

            return r;
        }

        //Random számot generál
        private static int GenerateNumber()
        {
            Random random = new Random();
            int r;
            r = random.Next(0, 37);

            return r;
        }

        //Kiszámolja a nyereményt
        private static int CalculatePrize(int balance, Dictionary<int, int> userBets, Dictionary<String, int> userBetsOther, Number number)
        {
            int newBalance = 0;

            int remaining = balance - userBets.Sum(x => x.Value) - userBetsOther.Sum(x => x.Value);

            /*Console.WriteLine("Ezekre fogadtál:");
            
            foreach(KeyValuePair<String, int> pair in userBetsOther)
            {
                Console.WriteLine("Key: "+pair.Key+" Value: "+pair.Value);
            }*/

            if(userBets.ContainsKey(number.Value)) newBalance += userBets[number.Value] * 36;

            if (userBetsOther.ContainsKey(number.Parity))
            {
                Console.WriteLine("Eltaláltad a paritást");
                newBalance += userBetsOther[number.Parity] * 2;
            }

            if (userBetsOther.ContainsKey(number.Column))
            {
                Console.WriteLine("Eltaláltad az oszlopot");
                newBalance += userBetsOther[number.Column] * 3;
            }

            if (userBetsOther.ContainsKey(number.Half))
            {
                Console.WriteLine("Eltaláltad a felet");
                newBalance += userBetsOther[number.Half] * 2;
            }

            if (userBetsOther.ContainsKey(number.Dozen))
            {
                Console.WriteLine("Eltaláltad a tucatot");
                newBalance += userBetsOther[number.Dozen] * 3;
            }

            if (userBetsOther.ContainsKey(number.Color))
            {
                Console.WriteLine("Eltaláltad a színt");
                newBalance += userBetsOther[number.Color] * 2;
            }


            Console.WriteLine("A nyereméyned: "+newBalance);

            newBalance += remaining;

            return newBalance;
        }


    }
}
