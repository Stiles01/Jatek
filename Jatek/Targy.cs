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
        public Dictionary<string, bool> MitLehet = new Dictionary<string, bool>();
        public bool Elvegzette { get; set; }

        public Targy()
        {
            Szoba = "";           
        }

        public void Ertek(string szoba, string mitlehetsor, bool lathatoe, bool elvegzette)
        {
            Szoba = szoba;
            string[] seged = mitlehetsor.Split(';');
            foreach (var item in seged)
            {
                MitLehet.Add(item, false);
            }
            LathatoE = lathatoe;
            Elvegzette = elvegzette;
            
        }

        public void ErtekBetoltes(string sor)
        {
            string[] seged = sor.Split(';');
            string[] seged2 = seged[2].Replace("[", "").Replace("]", "").Replace(" ", "").Split('-');
            Szoba = seged[0];            
            foreach (var item in seged2)
            {
                string[] seged3 = item.Split(',');
                MitLehet.Add(seged3[0], bool.Parse(seged3[1]));
            }
            LathatoE = bool.Parse(seged[1]);
            Elvegzette = bool.Parse(seged[3]);
        }

        public string Menteshez()
        {
            string a = String.Join("-", MitLehet);
            return String.Join(";", Szoba, LathatoE, a, Elvegzette);
        }

        

    }
}
