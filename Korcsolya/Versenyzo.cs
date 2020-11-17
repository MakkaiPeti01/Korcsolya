using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Korcsolya
{
    class Versenyzo
    {
        private string nev;

        public string Nev
        {
            get { return nev; }
        }
        private string orszag;

        public string Orszag
        {
            get { return orszag; }
        }
        private double tech;

        public double Tech
        {
            get { return tech; }
        }

        private double komp;

        public double Komp
        {
            get { return komp; }
        }

        private double hiba;

        public double Hiba
        {
            get { return hiba; }
        }

        private double pont;

        public double Pont
        {
            get { return pont; }
        }

        public Versenyzo(string nev, string orszag, double tech, double komp, double hiba)
        {
            this.nev = nev;
            this.orszag = orszag;
            this.tech = tech;
            this.komp = komp;
            this.hiba = hiba;
            pont = komp + tech - hiba;        }
    }
}
