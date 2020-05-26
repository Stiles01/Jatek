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
        public Dictionary<string, bool> Tulajdonsagok = new Dictionary<string, bool>();

        public Targy(string sor)
        {
            string[] seged = sor.Split(';');
            Szoba = seged[0];
            Tulajdonsagok.Add("lathatoe", bool.Parse(seged[1]));
            Tulajdonsagok.Add("hasznalhatoe", bool.Parse(seged[2]));
            Tulajdonsagok.Add("elvegzette", bool.Parse(seged[3]));
        }


        public string Menteshez()
        {
            return String.Join(";", Szoba, Tulajdonsagok.Values);
        }

        

    }
}
