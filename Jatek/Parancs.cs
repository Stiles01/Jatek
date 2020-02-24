using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jatek
{
    class Parancs
    {
        public string Mitcsinal { get; set; }
        public string Miaz { get; set; }
        public string Mithasznal { get; set; }
        string plusz;

        public Parancs(string mitcsinal)
        {
            Mitcsinal = mitcsinal;
        }

        public Parancs(string mitcsinal, string miaz)
        {
            Mitcsinal = mitcsinal;
            Miaz = miaz;
        }

        public Parancs(string mitcsinal, string miaz, string mithasznal)
        {
            Mitcsinal = mitcsinal;
            Miaz = miaz;
            Mithasznal = mithasznal;
        }

        


    }
}
