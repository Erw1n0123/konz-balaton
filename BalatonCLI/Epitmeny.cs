using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalatonCLI
{
    public class Epitmeny
    {
        public int adoszam { get;}
        public string utca { get; }
        public string hazszam { get; }
        public string adosav { get; }
        public int alapterulet { get; }

        public Epitmeny(string sor)
        {
            string[] splitted = sor.Split(' ');
            this.adoszam = int.Parse(splitted[0]);
            this.utca = splitted[1];
            this.hazszam = splitted[2];
            this.adosav = splitted[3];
            this.alapterulet = int.Parse(splitted[4]);
        }
    }
}
