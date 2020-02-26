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
            MitLehet.Add("", false);
            LathatoE = true;
        }

        public void Ertek(string szoba, string mitlehetsor, bool lathatoe, bool elvegzette)
        {
            Szoba = szoba;
            string[] seged = mitlehetsor.Split(';');
            MitLehet.Clear();
            foreach (var item in seged)
            {
                MitLehet.Add(item, false);
            }
            LathatoE = lathatoe;
            if (!elvegzette)
            {
                Elvegzette = elvegzette;
            }
            
        }

    }
}
