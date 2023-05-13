using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BalatonCLI
{
    public class Program
    {   public static Dictionary<string,int> Adosav = new Dictionary<string,int>();
        //4
        public static int ado(string adosav, int alapterulet)
        {
            return (Adosav[adosav] * alapterulet>10000? Adosav[adosav] * alapterulet:0);
        }
        public static void Main(string[] args)
        {
            
            List<Epitmeny> epitmenylist = new List<Epitmeny>();
            StreamReader r = new StreamReader("utca.txt");
            string line = r.ReadLine();
            string[] splitted = line.Split(' ');
            Adosav.Add("A", int.Parse(splitted[0]));
            Adosav.Add("B", int.Parse(splitted[1]));
            Adosav.Add("C", int.Parse(splitted[2]));
            while (!r.EndOfStream)
            {
                epitmenylist.Add(new Epitmeny(r.ReadLine()));
            }
            r.Close();
            //2
            Console.WriteLine($"2. feladat. A mintában {epitmenylist.Count()} telek szerepel.");
            //3, 5, 6
            Console.Write("3. feladat. Egy tulajdonos adószáma: ");
            int adoszam =int.Parse(Console.ReadLine());
            bool talalat = false;
            int A_sav_db = 0;
            int B_sav_db = 0;
            int C_sav_db = 0;
            int A_sav_ado = 0;
            int B_sav_ado = 0;
            int C_sav_ado = 0;
            StreamWriter w = new StreamWriter("teljes.txt");
            foreach (var epitmeny in epitmenylist)
            {
                if (epitmeny.adoszam == adoszam)
                {
                    talalat = true;
                    Console.WriteLine(epitmeny.utca + " " + epitmeny.hazszam);
                };
                int epitmenyado = ado(epitmeny.adosav, epitmeny.alapterulet);
                if (epitmeny.adosav == "A")
                {
                    A_sav_db++;
                    A_sav_ado += epitmenyado;
                }
                else if (epitmeny.adosav == "B")
                {
                    B_sav_db++;
                    B_sav_ado += epitmenyado;
                }
                else
                {
                    C_sav_db++;
                    C_sav_ado += epitmenyado;
                }
                w.WriteLine($"{epitmeny.adoszam} {epitmeny.utca} {epitmeny.hazszam} {epitmeny.adosav} {epitmeny.alapterulet} {epitmenyado}");
            }
            w.Close();
            if (!talalat)
            {
                Console.WriteLine("Nem szerepel az adatállományban.");
            }
            Console.WriteLine($"5. feladat\nA sávba {A_sav_db} telek esik, az adó {A_sav_ado} Ft.\nB sávba {B_sav_db} telek esik, az adó {B_sav_ado} Ft.\nC sávba {C_sav_db} telek esik, az adó {C_sav_ado} Ft.");
            Console.ReadKey();
        }
    }
}
