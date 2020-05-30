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
            return String.Join(";", Szoba, Tulajdonsagok.Values);
        }

        public bool Leheteilyenmi(string miaz)
        {
            
            switch (miaz)
            {
                case "szekrény":
                case "doboz":
                case "ajtó":
                case "ablak":
                case "fürdőkád": return true;
                    
                default: return false;                   
            }
        }
        public bool Leheteilyenmit(string mithasznal)
        {

            switch (mithasznal)
            {
                case "kulcs":
                case "feszítővas": return true;

                default: return false;
            }
        }
    }
}
