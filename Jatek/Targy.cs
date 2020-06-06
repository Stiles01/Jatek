using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jatek
{
    class Targy
    {
        public string Nev { get; set; }
        public string Szoba { get; set; }
        public Dictionary<string, bool> Tulajdonsagok = new Dictionary<string, bool>();

        public Targy(string sor)
        {
            string[] seged = sor.Split(';');
            Nev = seged[0];
            Szoba = seged[1];
            Tulajdonsagok.Add("lathatoe", bool.Parse(seged[2]));
            Tulajdonsagok.Add("hasznalhatoe", bool.Parse(seged[3]));
            Tulajdonsagok.Add("elvegzette", bool.Parse(seged[4]));
        }


        public string Menteshez()
        {
            return String.Join(";", Szoba, Tulajdonsagok["lathatoe"], Tulajdonsagok["hasznalhatoe"], Tulajdonsagok["elvegzette"]);
        }

        public void Lathatosag()
        {
            if (Tulajdonsagok["lathatoe"])
            {
                Tulajdonsagok["lathatoe"] = false;
            }
            else
            {
                Tulajdonsagok["lathatoe"] = true;
            }
        }

        public void Hasznalat()
        {
            if (Tulajdonsagok["hasznalhatoe"])
            {
                Tulajdonsagok["hasznalhatoe"] = false;
            }
            else
            {
                Tulajdonsagok["hasznalhatoe"] = true;
            }
        }

        public void Elvegzett()
        {
            if (Tulajdonsagok["elvegzette"])
            {
                Tulajdonsagok["elvegzette"] = false;
            }
            else
            {
                Tulajdonsagok["elvegzette"] = true;
            }
        }

        
    }
}
