using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    internal class BlackJack
    {
        public static int Play()
        {

            int prize = Program.balance;

            List<String> decks = new List<String>();
            
            String[] deckarray = {"CA" , "DA" , "HA" , "SA" ,
                              "CK" , "DK" , "HK" , "SK" ,
                              "CQ" , "DQ" , "HQ" , "SQ" ,
                              "CJ" , "DJ" , "HJ" , "SJ" ,
                              "C10" , "D10" , "H10" , "S10" ,
                              "C9" , "D9" , "H9" , "S9" ,
                              "C8" , "D8" , "H8" , "S8" ,
                              "C7" , "D7" , "H7" , "S7" ,
                              "C6" , "D6" , "H6" , "S6" ,
                              "C5" , "D5" , "H5" , "S5",
                              "C4" , "D4" , "H4" , "S4",
                              "C3" , "D3" , "H3" , "S3",
                              "C2" , "D2" , "H2" , "S2",
                              "CA" , "DA" , "HA" , "SA" ,
                              "CK" , "DK" , "HK" , "SK" ,
                              "CQ" , "DQ" , "HQ" , "SQ" ,
                              "CJ" , "DJ" , "HJ" , "SJ" ,
                              "C10" , "D10" , "H10" , "S10" ,
                              "C9" , "D9" , "H9" , "S9" ,
                              "C8" , "D8" , "H8" , "S8" ,
                              "C7" , "D7" , "H7" , "S7" ,
                              "C6" , "D6" , "H6" , "S6" ,
                              "C5" , "D5" , "H5" , "S5",
                              "C4" , "D4" , "H4" , "S4",
                              "C3" , "D3" , "H3" , "S3",
                              "C2" , "D2" , "H2" , "S2"
            };

            decks.AddRange(deckarray);



            List<String> userHand = new List<String>();

            List<String> dealerHand = new List<String>();

            int f = 0;

            while(true)
            {
                if (f != 0)
                {
                    Console.WriteLine("\nSzeretnél játszani még  egy kört?\n  (I: Igen / N: Nem)\n");
                    String nR = Console.ReadLine();
                    if (nR == "N")
                    {
                        Console.WriteLine("Viszlát!");
                        break;
                    }
                }

                f++;

                //Kezek kiürítése
                userHand.Clear();
                dealerHand.Clear();

                //Tét bekérése a felhasználótól
                
                Console.WriteLine("\n--Új kör kezdődött--\nAz egyenleged: " + prize);
                Console.WriteLine("Add meg a téted!");
                string betAsString = Console.ReadLine();
                int bet = int.Parse(betAsString);
                if(bet > prize)
                {
                    Console.WriteLine("A tét meghaladja az egyenleged!\n");
                    continue;
                }
                prize -= bet;

                //Alap lapleosztás
                userHand.Add(GetCard(decks));
                decks.Remove(userHand[0]);
                userHand.Add(GetCard(decks));
                decks.Remove(userHand[1]);
                dealerHand.Add(GetCard(decks));
                decks.Remove(dealerHand[0]);
                dealerHand.Add(GetCard(decks));
                decks.Remove(dealerHand[1]);


                Console.WriteLine("\nLapjaid: " + userHand[0] + " " + userHand[1] + "\n Érték: "+CalculateSum(userHand));

                String dealerHandValue = Char.IsLetter(dealerHand[0][1]) ? "10" : dealerHand[0].Substring(1);

                Console.WriteLine("\nOsztó lapjai: " + dealerHand[0] + " (Rejtett lap)\n Érték: " + dealerHandValue);

                String p;
                int bj = 0;

                //Ha blackjacket kap kézbe a játékos
                if (CalculateSum(userHand) == 21)
                {
                    Console.WriteLine("**BlackJacket kaptál!**");
                    p = "S";
                    bj = 1;
                }

                //Lehetséges lépések
                else
                {
                    Console.WriteLine("\nLehetsőségek:\n   D: Double (Duplázom a tétem)\n   H: Hit (Kérek még egy lapot)\n   S: Stand (Megállok)");
                    p = Console.ReadLine();
                }


                //Stand
                if (p == "S")
                {
                    if(bj == 0) Console.WriteLine("\nMegálltál");

                    Console.WriteLine("\nLapjaid: " + PrintHand(userHand) + "\n Érték: " + CalculateSum(userHand));
                    Console.WriteLine("\nOsztó lapjai: " + PrintHand(dealerHand) + "\n Érték: " + CalculateSum(dealerHand));

                    while(CalculateSum(dealerHand) < 17)
                    {
                        dealerHand.Add(GetCard(decks));
                        decks.Remove(dealerHand[dealerHand.Count-1]);
                        
                        Console.WriteLine("\nAz osztónak húznia kellett még egy lapot");
                        Console.WriteLine("\nLapjaid: " + PrintHand(userHand) + "\n Érték: " + CalculateSum(userHand));
                        Console.WriteLine("\nOsztó lapjai: " + PrintHand(dealerHand) + "\n Érték: " + CalculateSum(dealerHand));
                    }

                    if (CalculateSum(userHand) > 21)
                    {
                        Console.WriteLine("\nBust!\n  A veszteséged: " + bet);
                        Console.WriteLine("Az egyenleged a kör után: " + prize);
                        continue;
                    }
                    if (CalculateSum(dealerHand) > 21)
                    {
                        Console.WriteLine("\nDealer Bust!\n  A nyereményed: " + bet * 2);
                        prize += bet * 2;
                        Console.WriteLine("Az egyenleged a kör után: " + prize);
                        continue;
                    }
                    if (CalculateSum(userHand) > CalculateSum(dealerHand))
                    {
                        Console.WriteLine("\nNyertél!\n  A nyereményed: " + bet * 2);
                        prize += bet * 2;
                        Console.WriteLine("Az egyenleged a kör után: " + prize);
                        continue;
                    }
                    if (CalculateSum(userHand) == CalculateSum(dealerHand))
                    {
                        Console.WriteLine("\nPush!\n  A nyereményed: " + bet);
                        prize += bet;
                        Console.WriteLine("Az egyenleged a kör után: " + prize);
                        continue;
                    }
                    if (CalculateSum(userHand) < CalculateSum(dealerHand))
                    {
                        Console.WriteLine("\nVesztettél!\n  A veszteséged: " + bet);
                        continue;
                    }
                }//Stand vége


                //Double
                if (p == "D")
                {
                    Console.WriteLine("\nTét duplázva");

                    prize -= bet;
                    bet = bet * 2;
                    Console.WriteLine("  Új tét: "+bet);
                    userHand.Add(GetCard(decks));
                    decks.Remove(userHand[userHand.Count - 1]);

                    Console.WriteLine("\nLapjaid: " + PrintHand(userHand) + "\n Érték: " + CalculateSum(userHand));
                    Console.WriteLine("\nOsztó lapjai: " + PrintHand(dealerHand) + "\n Érték: " + CalculateSum(dealerHand));

                    if (CalculateSum(userHand) > 21)
                    {
                        Console.WriteLine("\nBust!\n  A veszteséged: " + bet);
                        Console.WriteLine("Az egyenleged a kör után: "+prize);
                        continue;
                    }

                    while (CalculateSum(dealerHand) < 17)
                    {
                        dealerHand.Add(GetCard(decks));
                        decks.Remove(dealerHand[dealerHand.Count - 1]);

                        Console.WriteLine("\nAz osztónak húznia kellett még egy lapot");
                        Console.WriteLine("\nLapjaid: " + PrintHand(userHand) + "\n Érték: " + CalculateSum(userHand));
                        Console.WriteLine("\nOsztó lapjai: " + PrintHand(dealerHand) + "\n Érték: " + CalculateSum(dealerHand));
                    }

                    if (CalculateSum(dealerHand) > 21)
                    {
                        Console.WriteLine("\nDealer Bust!\n  A nyereményed: " + bet * 2);
                        prize += bet * 2;
                        Console.WriteLine("Az egyenleged a kör után: " + prize);
                        continue;
                    }
                    if (CalculateSum(userHand) > CalculateSum(dealerHand))
                    {
                        Console.WriteLine("\nNyertél!\n  A nyereményed: " + bet*2);
                        prize += bet*2;
                        Console.WriteLine("Az egyenleged a kör után: " + prize);
                        continue;
                    }
                    if (CalculateSum(userHand) == CalculateSum(dealerHand))
                    {
                        Console.WriteLine("\nPush!\n  A nyereményed: " + bet);
                        prize += bet;
                        Console.WriteLine("Az egyenleged a kör után: " + prize);
                        continue;
                    }
                    if (CalculateSum(userHand) < CalculateSum(dealerHand))
                    {
                        Console.WriteLine("\nVesztettél!\n  A veszteséged: " + bet);
                        Console.WriteLine("Az egyenleged a kör után: " + prize);
                        continue;
                    }
                }//Double vége

                
                //Hit
                if (p == "H")
                {
                    while(CalculateSum(userHand) < 21 && p != "S")
                    {
                        Console.WriteLine("\nKértél még egy lapot");

                        userHand.Add(GetCard(decks));
                        decks.Remove(userHand[userHand.Count - 1]);

                        Console.WriteLine("\nLapjaid: " + PrintHand(userHand) + "\n Érték: " + CalculateSum(userHand));
                        Console.WriteLine("\nOsztó lapjai: " + dealerHand[0] + " (Rejtett lap)\n Érték: " + dealerHandValue);

                        if (CalculateSum(userHand) > 21)
                        {
                            Console.WriteLine("Bust! A veszteséged: " + bet);
                            Console.WriteLine("Az osztó lapjai: " + PrintHand(dealerHand) + "voltak.");
                            
                            break;
                        }

                        if(CalculateSum(userHand) == 21)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nSzeretnél még egy lapot?\n(H: Hit / S: Stand)");
                            p = Console.ReadLine();
                        }

                    }

                    if (CalculateSum(userHand) > 21) continue;

                    while (CalculateSum(dealerHand) < 17)
                    {
                        dealerHand.Add(GetCard(decks));
                        decks.Remove(dealerHand[dealerHand.Count - 1]);

                        Console.WriteLine("\nAz osztónak húznia kellett még egy lapot");
                        Console.WriteLine("\nLapjaid: " + PrintHand(userHand) + "\n Érték: " + CalculateSum(userHand));
                        Console.WriteLine("\nOsztó lapjai: " + PrintHand(dealerHand) + "\n Érték: " + CalculateSum(dealerHand));
                    }

                    if (CalculateSum(dealerHand) > 21)
                    {
                        Console.WriteLine("\nDealer Bust!\n  A nyereményed: " + bet * 2);
                        prize += bet * 2;
                        Console.WriteLine("Az egyenleged a kör után: " + prize);
                        continue;
                    }
                    if (CalculateSum(userHand) > CalculateSum(dealerHand))
                    {
                        Console.WriteLine("\nNyertél!\n  A nyereményed: " + bet * 2);
                        prize += bet * 2;
                        Console.WriteLine("Az egyenleged a kör után: " + prize);
                        continue;
                    }
                    if (CalculateSum(userHand) == CalculateSum(dealerHand))
                    {
                        Console.WriteLine("\nPush!\n  A nyereményed: " + bet);
                        prize += bet;
                        Console.WriteLine("Az egyenleged a kör után: " + prize);
                        continue;
                    }
                    if (CalculateSum(userHand) < CalculateSum(dealerHand))
                    {
                        Console.WriteLine("\nVesztettél!\n  A veszteséged: " + bet);
                        continue;
                    }

                }
                
                //Ha érvénytelen értéket ad meg a felhasználó
                if(!CheckIfValidP(p)){
                    Console.WriteLine("\nKérlek a három lehetőség közül válassz!");
                }

            }

            

            

            return prize;
        }

        private static string PrintHand(List<String> hand)
        {

            StringBuilder r = new StringBuilder();

            foreach (String card in hand)
            {
                r.Append(card+" ");
            }

            return r.ToString();
        }

        public static Boolean CheckIfValidP(String p)
        {


            if(p == "D" || p == "S" || p == "H") return true;

            return false;
        }

        private static int CalculateSum(List<String> hand)
        {
            int sum = 0;

            foreach(String card in hand)
            {
                if (Char.IsDigit(card[1]))
                {
                    sum+= int.Parse(card.Substring(1));
                }
                else
                {
                    if(sum == 10 && card[1] == 'A')
                    {
                        sum += 11;
                        break;
                    }
                    if(sum == 20 && card[1] == 'A')
                    {
                        sum++;
                        break;
                    }
                    sum += 10;
                }
            }

            return sum;
        }

        private static String GetCard(List<String> decks)
        {
            var rnd = new Random();
            return decks[rnd.Next(0,decks.Count)];
        }
    }
}
