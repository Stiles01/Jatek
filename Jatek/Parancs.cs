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
                    break;
                case 2:
                    Mitcsinal = seged[0];
                    Miaz = seged[1];
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

        //public string Miaparancs(string allohely, bool vaneilyenmi, bool vaneilyenmit, bool lathatoe)
        //{
        //    if (vaneilyenmi && vaneilyenmit)
        //    {
        //        switch (Mitcsinal)
        //        {
        //            case "nézd":
        //                if (allohely == "nappali")
        //                {
        //                    if (lathatoe == false)
        //                    {
        //                        return "A nappaliban vagy. Látsz egy szekrényt és egy ajtót nyugatra.\n";
        //                    }
        //                    else
        //                    {
        //                        return "A nappaliban vagy. Látsz egy szekrényt, egy ablakot északra és egy ajtót nyugatra.\n";
        //                    }
        //                }
        //                else
        //                {
        //                    if (allohely == "fürdő")
        //                    {
        //                        if (!Furdokad.Elvegzette)
        //                        {
        //                            if (!Leltar.Exists(x => x == "feszítővas"))
        //                            {
        //                                Console.WriteLine("A fürdőben vagy. Látsz egy fürdőkádat, benne egy feszítővasat és egy ajtót keletre.\n");
        //                            }
        //                            else
        //                            {
        //                                Console.WriteLine("A fürdőben vagy. Látsz egy fürdőkádat és egy ajtót keletre.\n");
        //                            }
        //                        }
        //                        else
        //                        {
        //                            if (!Leltar.Exists(x => x == "feszítővas"))
        //                            {
        //                                Console.WriteLine("A fürdőben vagy. Látsz egy fürdőkádat, benne egy feszítővasat és egy ajtót keletre.\n");
        //                            }
        //                            else
        //                            {
        //                                Console.WriteLine("A fürdőben vagy. Látsz egy fürdőkádat és egy ajtót keletre.\n");
        //                            }
        //                        }
        //                    }
        //                }
        //                break;
        //            case "":
        //                break;

        //            default:
        //                return "Nincs ilyen parancs! Nyomd le a \'? \' gombot, hogy megtudd milyen parancsokat használhatsz.";
        //                break;
        //        }
        //    }
            
        //}

    }
}
