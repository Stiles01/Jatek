using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jatek
{
    class Program
    {
        

        static string Betolt(string sor)
        {
            if (sor == "új")
            {
                return "false";
            }
            else
            {
                if (sor == "mentés")
                {
                    return "true";
                }
                else
                {
                    return "null";
                }
            }
        }

        static string Mentes()
        {
            
            return "";
        }

        static string Nemhelyes(string parancs)
        {
            
            return "";
        }

        static string Help()
        {
            
            return "A helyes utasítássorozat: \nmit csinálunk / mivel (nem kötelező) / mit használunk hozzá (nem kötelező)";
        }

        static void Main(string[] args)
        {
            //Készítette: Nagy Viktória
            //Játék neve: Szabaduló-szoba

            bool Keszvane = false;
            Parancs p;
            List<string> Leltar = new List<string>();
            List<string> Allohely = new List<string>();
            Targy Szekreny = new Targy();
            Targy Doboz = new Targy();
            Targy Kulcs = new Targy();
            Targy Ajto = new Targy();
            Targy Ablak = new Targy();
            Targy Furdokad = new Targy();
            Targy Feszitovas = new Targy();

            
            Console.WriteLine("Új játékot kezdesz vagy betöltöd a már meglevő mentésed?\núj/mentés");          
            string a = Betolt(Console.ReadLine());
            
            while (a == "null" || a == "false" || a == "true")
            {
                if (a == "false")
                {
                    Szekreny.Ertek("nappali", "nyisd;nézd;húzd", true, false);
                    Doboz.Ertek("nappali", "nyisd;nézd", false, false);
                    Kulcs.Ertek("nappali", "vedd fel;tedd le;nézd", false, true);
                    Ajto.Ertek("nappali", "nyisd;nézd", true, false);
                    Ablak.Ertek("nappali", "nézd;törd", false, false);
                    Furdokad.Ertek("fürdő", "nézd", false, false);
                    Feszitovas.Ertek("fürdő", "nézd;vedd fel;tedd le", false, true);
                    Allohely.Add("nappali");
                    break;
                }
                else
                {
                    if (a == "true")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("új vagy mentés?");
                        a = Betolt(Console.ReadLine());
                        continue;
                    }
                }
            }
            Console.WriteLine("Ha bármikor elakadnál nyomd meg a \"?\" billentyűt!");

            while (!Keszvane)
            {
                string parancs = Console.ReadLine().Trim();               
                string[] tobbparancs = parancs.Split(' ');
                switch (tobbparancs.Length)
                {
                    case 1: p = new Parancs(tobbparancs[0]);
                        switch (p.Mitcsinal)
                        {
                            case "nézd": break;
                            case "kelet":
                                if (Allohely.Last()=="fürdő")
                                {
                                    Allohely.Add("nappali");
                                    if (Ablak.LathatoE == false)
                                    {
                                        Console.WriteLine("A nappaliban vagy. Látsz egy szekrényt és egy ajtót nyugatra.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("A nappaliban vagy. Látsz egy szekrényt, egy ablakot északra és egy ajtót nyugatra.");
                                    }
                                    
                                }
                                else
                                {
                                    Console.WriteLine("Innen nem lehet keletre menni! (A nappaliban vagy)");
                                }
                                break;
                            case "nyugat":
                                if (Allohely.Last() == "nappali")
                                {
                                    if (Ajto.Elvegzette == true)
                                    {
                                        Allohely.Add("fürdő");
                                        if (Feszitovas.LathatoE == false)
                                        {
                                            Console.WriteLine("A fürdőben vagy. Látsz egy fürdőkádat és egy ajtót keletre.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("A fürdőben vagy. Látsz egy fürdőkádat, benne egy feszítővasat és egy ajtót nyugatra.");
                                        }
                                        
                                    }
                                    else
                                    {
                                        Console.WriteLine("Nyugatra egy zárt ajtó található.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Innen nem lehet nyugatra menni! (A fürdőben vagy)");
                                }
                                break;
                                
                            case "észak": break;
                            case "?": Console.WriteLine(Help()); break;
                            case "leltár": break;
                            case "mentés": break;
                            default:
                                Console.WriteLine("Helytelen parancs!");
                                break;
                        }
                         // nezd, kelet, nyugat, eszak, ?, leltar, mentes
                        break;
                    case 2: p = new Parancs(tobbparancs[0], tobbparancs[1]);
                        switch (p.Mitcsinal)
                        {
                            case "nézd": break;
                            case "vedd fel": break;
                            case "tedd le": break;
                            case "húzd": break;
                            case "nyisd": break;
                            default:
                                Console.WriteLine($"({Nemhelyes(parancs)})");
                                break;
                        }
                         // nezd, vedd fel, tedd le, huzd, nyisd
                        break;
                    case 3: p = new Parancs(tobbparancs[0], tobbparancs[1], tobbparancs[2]);
                        switch (p.Mitcsinal)
                        {
                            case "nyisd": break;
                            case "törd": break;
                            default:
                                Console.WriteLine($"({Nemhelyes(parancs)})");
                                break;
                        }
                         // nyisd, tord
                        break;
                    case 4: p = new Parancs(String.Join(" ",tobbparancs[0], tobbparancs[1]), tobbparancs[2], tobbparancs[3]);
                        switch (p.Mitcsinal)
                        {
                            case "nyisd": break;
                            case "törd": break;
                            default:
                                Console.WriteLine($"({Nemhelyes(parancs)})");
                                break;
                        }
                        // nyisd, tord
                        break;
                    default:
                        Console.WriteLine("Helytelen parancsot adtál meg:\nmit csinálsz / mivel (nem kötelező) / mit használsz hozzá (nem kötelező)");
                        
                        break;
                }
            }

            Console.ReadKey();
            

        }
    }
}
