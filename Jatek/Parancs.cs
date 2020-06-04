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


        public Parancs(string sor)
        {
            string[] seged = sor.Split(' ');
            switch (seged.Length)
            {
                case 1:
                    Mitcsinal = seged[0];
                    Miaz = "";
                    Mithasznal = "";
                    break;
                case 2:
                    Mitcsinal = seged[0];
                    Miaz = seged[1];
                    Mithasznal = "";
                    break;
                case 3:
                    Mitcsinal = seged[0];
                    Miaz = seged[1];
                    Mithasznal = seged[2];
                    break;
                case 4:
                    Mitcsinal = seged[0] + seged[1];
                    Miaz = seged[2];
                    Mithasznal = seged[3];
                    break;
                default:
                    Mitcsinal = "";
                    Miaz = "";
                    Mithasznal = "";
                    break;
            }
        }

        public bool Helyes()
        {
            if (Mitcsinal == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool Ellenorzes(string allohely, string szoba, bool leheteilyen)
        {
            if (leheteilyen && allohely == szoba)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Leheteilyen()
        {
            bool seged1 = false, seged2 = false;
            switch (Miaz)
            {
                case "szekrény":
                case "doboz":
                case "fürdőkád":
                case "": seged1 = true; break;
                case "ajtó":
                    if (Mithasznal == "kulcs" || Mithasznal == "")
                    {
                        seged2 = true;
                    }
                    else
                    {
                        seged2 = false;
                    }
                    break;
                case "ablak":
                    if (Mithasznal == "feszítővas" || Mithasznal == "")
                    {
                        seged2 = true;
                    }
                    else
                    {
                        seged2 = false;
                    }
                    break;
                default: seged1 = false; break;
            }
            if (seged1)
            {
                if (seged2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public string Targyasparancs(string nev, string lathatoe, string hasznalhato, string elvegzette)
        {
            if (lathatoe=="true")
            {
                if (elvegzette=="false")
                {
                    if (hasznalhato=="true")
                    {
                        return String.Join(" ", 3, nev, Mitcsinal);
                    }
                    else
                    {
                        return String.Join(" ", 1, nev, Mitcsinal);
                    }                   
                }
                else
                {
                    if (hasznalhato == "true")
                    {
                        return String.Join(" ", 4, nev, Mitcsinal);
                    }
                    else
                    {
                        return String.Join(" ", 2, nev, Mitcsinal);
                    }                   
                }
            }
            else
            {
                if (nev == "doboz" || nev == "feszítővas" || nev == "kulcs")
                {
                    return String.Join(" ", 4, nev, Mitcsinal);
                }
                else
                {
                    return "0";
                }
            }
        }

        public string Tobbparancs(string mi, string mit, string lathatoemi, bool leltarbanvane, string hasznalmit, string elvegzettmit)
        {
            if (leltarbanvane && lathatoemi=="true" && hasznalmit == "true" && elvegzettmit == "true")
            {
                if (mi == "kulcs" || mi == "feszítővas")
                {
                    return String.Join(" ", 4, mit, Mitcsinal);
                }
                else
                {
                    return String.Join(" ", 4, mi, Mitcsinal);
                }
            }
            else
            {
                return "0";
            }
        }
    }
}
