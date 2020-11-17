using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Korcsolya
{
    class Program
    {
        static List<Versenyzo> rovidprogram = new List<Versenyzo>();
        static List<Versenyzo> donto = new List<Versenyzo>(); 
        static Dictionary<string, int> tovabbjutok = new Dictionary<string, int>();
        static void Beolvasas()
        {
            StreamReader olvas = new StreamReader("rovidprogram.csv");
            olvas.ReadLine();
            while (!olvas.EndOfStream)
            {
                string[] adat = olvas.ReadLine().Split(';');
                rovidprogram.Add(new Versenyzo(adat[0], adat[1], double.Parse(adat[2].Replace(".", ",")), double.Parse(adat[3].Replace(".", ",")), double.Parse(adat[4])));
            }
            olvas.Close();
            StreamReader sr = new StreamReader("donto.csv");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string[] adat = sr.ReadLine().Split(';');
                donto.Add(new Versenyzo(adat[0], adat[1], double.Parse(adat[2].Replace(".", ",")), double.Parse(adat[3].Replace(".", ",")), double.Parse(adat[4])));
            }
            sr.Close();
        }
        static void Masodik()
        {
            Console.WriteLine($"2. feladat \n \t A rövid programban {rovidprogram.Count} induló volt");
        }
        static void Harmadik()
        {
            bool bejutott = false;
            foreach (var i in donto)
            {
                if (i.Orszag=="HUN")
                {
                    bejutott = true;
                }
            }
            if (bejutott)
            {
                Console.WriteLine($"3. feladat \n \t A magyar versenyző bejutott a döntőbe");
            }
            else
            {
                Console.WriteLine($"3. feladat \n \t A magyar versenyző nem jutott be a döntőbe");
            }
        }
        static void OtHat()
        {
            Console.WriteLine();
            Console.Write("\tKérem a versenyző nevét: ");
            OsszPontszam(Console.ReadLine());
        }
        static void OsszPontszam(string nev)
        {
            //            Készítsen metódust OsszPontszam néven, amely egy versenyző összpontszámát adja meg,
            //azaz a rövidprogram pontszám és a döntőben elért pontszámának összegét!Ha nem jutott be
            //a döntőbe, akkor csak a rövidprogram pontszámát kell visszaadnia.Ha a megadott név nem
            //szerepel az adatok között, akkor pedig 0 - t adjon vissza!
            double ossz = 0;
            foreach (var i in rovidprogram)
            {
                foreach (var d in donto)
                {
                    if (i.Nev == nev)
                    {
                        ossz = i.Pont;
                    }
                    else if (d.Nev == nev)
                    {
                        ossz = d.Pont + i.Pont;
                    }
                    else if (!d.Nev.Contains(nev) && i.Nev.Contains(nev))
                    {
                        ossz = 0;
                    }
                }
            }
            if (ossz > 0)
            {
                Console.WriteLine("6. Feladat");
                Console.WriteLine($"\tA versenyző pontszáma: {ossz}");
            }
            else
            {
                Console.WriteLine("5. Feladat");
                Console.WriteLine("\tIlyen nevű versenyző nem volt");
            }
        }
        static void Hetes()
        {
            foreach (var i in donto)
            {
                //tovabbjutok.Add(i.Orszag, 0);
                if (!tovabbjutok.ContainsKey(i.Orszag))
                {
                    tovabbjutok.Add(i.Orszag, 0);
                }
            }
            foreach (var i in donto)
            {
                if (tovabbjutok.ContainsKey(i.Orszag))
                {
                    tovabbjutok[i.Orszag]++;
                }
            }
            Console.WriteLine("7. feladat");
            foreach (var i in tovabbjutok)
            {
                if (i.Value > 1)
                {
                    Console.WriteLine($"\t{i.Key}: {i.Value} versenyző");
                }              
            }
        }
        static void Nyolcas()
        {
            //há ez nem jött össze :'(
            List<string> eredmeny = new List<string>();
            StreamWriter iro = new StreamWriter("vegeredmeny.csv");
            double ossz = 0;
            foreach (var i in rovidprogram)
            {
                foreach (var d in donto)
                {
                    if (i.Nev.Contains(i.Nev))
                    {
                        ossz = i.Pont;
                       // eredmeny.Add();
                    }
                    else if (d.Nev == i.Nev)
                    {
                        ossz = d.Pont + i.Pont;
                    }
                }
            }
                    iro.Close();
        }
        static void Main(string[] args)
        {
            // Versenyzo Kati = new Versenyzo("Hosszú Katinka", "Magyarország", 4, 5, 1);
            // Console.WriteLine($"{Kati.Nev} {Kati.Orszag} {Kati.Pont}");
            Beolvasas();
            Masodik();
            Harmadik();
            OtHat();
            Hetes();
            Nyolcas();
            Console.ReadKey();
        }
    }
}
