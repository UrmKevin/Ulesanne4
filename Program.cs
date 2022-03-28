using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ulesanne4
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Dictionary<string, string> dict = new Dictionary<string, string>();

            List<string> konnad = new List<string> { "Pärnumaa", "Harjumaa", "Tartumaa", "Valgamaa", "Viljandimaa" };
            List<string> pealinn = new List<string> { "Pärnu", "Tallinn", "Tartu", "Valga", "Viljandi" };
            int randInt = 0;
            double score = 0;

            for (int i = 0; i < konnad.Count; i++)
            {
                //Console.WriteLine(i);
                dict.Add(konnad[i], pealinn[i]);
                dict.Add(pealinn[i], konnad[i]);
            }
            while (true)
            {

                Console.WriteLine("\nLeidke riik või pealinn - 1\nMäng - 2");
                int answer = int.Parse(Console.ReadLine());
                if (answer == 1)
                {
                    Console.Write("Sisestage pealinn või maakond:");
                    string input = Console.ReadLine();
                    if (dict.ContainsKey(input))
                    {
                        Console.WriteLine("Paari " + input + " ja " + dict[input]);
                    }
                    else if (!dict.ContainsKey(input))
                    {
                        Console.WriteLine("Vabandust, selles sõnastikus pole sellist sõna. Kas soovite lisada uusi sõnu? jah - 1, ei - 2");
                        answer = int.Parse(Console.ReadLine());
                        if (answer == 1)
                        {
                            Console.WriteLine("Palun sisestage uus maakond");
                            string new1 = Console.ReadLine();

                            Console.WriteLine("Palun sisestage uus pealinn");
                            string new2 = Console.ReadLine();
                            dict.Add(new1, new2);
                            dict.Add(new2, new1);
                        }
                    }
                }
                else if (answer == 2)
                {
                    score = 0;
                    for (int i = 0; i < konnad.Count; i++)
                    {
                        randInt = rnd.Next(1, 3);
                        int b = rnd.Next(1, konnad.Count);
                        if (randInt == 1)
                        {
                            Console.WriteLine("Paari - " + konnad[b]);
                            string userInput = Console.ReadLine();
                            if (pealinn.IndexOf(userInput) == konnad.IndexOf(konnad[b]))
                            {
                                Console.WriteLine("Väga hea!");
                                score++;
                            }
                        }
                        else if (randInt == 2)
                        {
                            Console.WriteLine("Paari - " + pealinn[b]);
                            string userInput = Console.ReadLine();
                            if (konnad.IndexOf(userInput) == pealinn.IndexOf(pealinn[b]))
                            {
                                Console.WriteLine("Väga hea");
                                score++;
                            }
                        }
                    }
                    Console.WriteLine(score / konnad.Count * 100 + "%");
                }
            }
        }
    }
}
