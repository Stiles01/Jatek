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
                    if (seged[0]=="vedd" || seged[0]=="tedd")
                    {
                        Mitcsinal = seged[0]+" "+ seged[1];
                        Miaz = seged[2];
                        Mithasznal = "";
                    }
                    else
                    {
                        Mitcsinal = seged[0];
                        Miaz = seged[1];
                        Mithasznal = seged[2];
                    }                    
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

        public void Csere()
        {
            string seged1 = Miaz;
            string seged2 = Mithasznal;
            Miaz = seged2;
            Mithasznal = seged1;
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
            switch (Miaz)
            {
                case "szekrény":
                case "doboz":
                case "fürdőkád":
                case "kulcs":
                case "feszítővas":
                case "": return true;
                case "ajtó":
                    if (Mithasznal == "kulcs" || Mithasznal == "")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case "ablak":
                    if (Mithasznal == "feszítővas" || Mithasznal == "")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default: return false;
            }
            
        }

        public string Targyasparancs(string nev, bool lathatoe, bool hasznalhato, bool elvegzette)
        {
            if (lathatoe)
            {
                if (!elvegzette)
                {
                    if (hasznalhato)
                    {
                        return String.Join(";", 3, nev, Mitcsinal);
                    }
                    else
                    {
                        return String.Join(";", 1, nev, Mitcsinal);                      
                    }                   
                }
                else
                {
                    if (hasznalhato)
                    {
                        return String.Join(";", 4, nev, Mitcsinal);
                    }
                    else
                    {
                        if (nev == "doboz")
                        {
                            return String.Join(";", 4, nev, Mitcsinal);
                        }
                        else
                        {
                            return String.Join(";", 2, nev, Mitcsinal);
                        }                        
                    }                   
                }
                
            }
            else
            {
                if (nev == "doboz" || nev == "feszítővas" || nev == "kulcs")
                {
                    return String.Join(";", 4, nev, Mitcsinal);
                }
                else
                {
                    return "0";
                }
            }
        }

        public string Tobbparancs(string mi, string mit, bool lathatoemi, bool leltarbanvane, bool hasznalmit, bool elvegzettmit)
        {
            if (leltarbanvane && lathatoemi && hasznalmit && elvegzettmit)
            {
                if (mi == "kulcs" || mi == "feszítővas")
                {
                    return String.Join(";", 4, mit, Mitcsinal);
                }
                else
                {
                    return String.Join(";", 4, mi, Mitcsinal);
                }
            }
            else
            {
                return "0";
            }
        }
    }
}
