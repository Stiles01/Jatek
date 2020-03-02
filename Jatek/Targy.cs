using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jatek
{
    class Targy
    {
        public string Szoba { get; set; }
        public bool LathatoE { get; set; }
        public bool Elvegzette { get; set; }

        public Targy()
        {
            Szoba = "";           
        }

        public void Ertek(string szoba, bool lathatoe, bool elvegzette)
        {
            Szoba = szoba;           
            LathatoE = lathatoe;
            Elvegzette = elvegzette;
            
        }

        public void ErtekBetoltes(string sor)
        {
            string[] seged = sor.Split(';');            
            Szoba = seged[0];                       
            LathatoE = bool.Parse(seged[1]);
            Elvegzette = bool.Parse(seged[2]);
        }

        public string Menteshez()
        {
            return String.Join(";", Szoba, LathatoE, Elvegzette);
        }

        

    }
}
