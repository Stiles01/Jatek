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

        public Targy(string szoba, string mitlehetsor, bool lathatoe)
        {
            Szoba = szoba;
            string[] seged = mitlehetsor.Split(';');
            foreach (var item in seged)
            {
                MitLehet.Add(item, false);
            }
            LathatoE = lathatoe;
        }

        
    }
}
