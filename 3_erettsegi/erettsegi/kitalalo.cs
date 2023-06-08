using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kitalalo
{
    internal class kitalalo
    {
        static void Main(string[] args)
        {
            string s = "fuvola csirke adatok asztal fogoly bicska farkas almafa babona gerinc dervis bagoly ecetes angyal boglya";
            string[] szavak = s.Split();
            Random r = new Random();
            string rejtett, tipp, eredmeny ="";
            int tippcount = 0;

            rejtett = szavak[r.Next(0,szavak.Length)];

            do
            {
                Console.Write("Kérem a tippet: ");
                tipp = Console.ReadLine();

                if(tipp != "stop")
                {
                    for (int i = 0; i < 6; i++)
                        if (tipp[i] == rejtett[i])
                            eredmeny += rejtett[i];
                        else
                            eredmeny += ".";

                    Console.WriteLine($"Az eredmény: {eredmeny}\n");
                    tippcount++;
                    eredmeny = "";
                }

            } while (tipp != "stop" && tipp != rejtett);
            
            if (tipp != "stop")
                Console.WriteLine($"{tippcount} tippeléssel sikerült kitalálni.");
            Console.ReadLine();
        }
    }
}