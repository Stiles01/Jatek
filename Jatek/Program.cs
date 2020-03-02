using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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


        static string Mentes(List<string> leltar, Targy szekreny, Targy doboz, Targy kulcs, Targy ajto, Targy ablak, Targy furdokad, Targy feszitovas, string allohely)
        {
            string leltarok = String.Join(";", leltar);
            return String.Join("\n", leltarok, szekreny.Menteshez(), doboz.Menteshez(), kulcs.Menteshez(), ajto.Menteshez(), ablak.Menteshez(), furdokad.Menteshez(), feszitovas.Menteshez(), allohely);
        }
        

        static string Nemhelyes(string parancs)
        {           
            return $"Nem jól adtad meg a ({parancs}) parancsot. Nyomd le a ? billentyût segítségért!\n";
        }
        

        static string Help()
        {
            
            return "A helyes utasítássorozat: \nmit csinálunk / mivel (nem kötelezõ) / mit használunk hozzá (nem kötelezõ)\n\nParancsok:\t? (0) / leltár (0) / mentés (0)\nIrányok:\tkelet (0) / nyugat (0) / észak (0)\nCselekmények:\tnézd (0 vagy 1) / vedd fel (1) / tedd le (1) / nyisd (1 vagy 2) / húzd (1) / törd (2)\n\nnem kell utána paramétert írni: (0)\tegy paramétert lehet utána írni: (1)\tkét paramétert lehet utána írni: (2)\n";
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
            

            
            Console.WriteLine("Új játékot kezdesz vagy betöltöd a már meglevõ mentésed?\núj/mentés");          
            string a = Betolt(Console.ReadLine());
            

            while (a == "null" || a == "false" || a == "true")
            {
                if (a == "false")
                {
                    Szekreny.Ertek("nappali", true, false);                   
                    Doboz.Ertek("nappali", false, false);
                    Kulcs.Ertek("nappali", false, true);
                    Ajto.Ertek("nappali", true, false);
                    Ablak.Ertek("nappali", false, false);
                    Furdokad.Ertek("fürdõ", false, false);
                    Feszitovas.Ertek("fürdõ", false, true);
                    Allohely.Add("nappali");
                    Leltar.Clear();
                    break;
                }
                else
                {
                    if (a == "true")
                    {
                        StreamReader r = new StreamReader("mentes.sav", Encoding.UTF8);
                        string c = r.ReadLine();
                        if (c != "")
                        {
                            string[] seged = c.Split(';');
                            foreach (var item in seged)
                            {
                                Leltar.Add(item);
                            }
                        }
                        Szekreny.ErtekBetoltes(r.ReadLine());
                        Doboz.ErtekBetoltes(r.ReadLine());
                        Kulcs.ErtekBetoltes(r.ReadLine());
                        Ajto.ErtekBetoltes(r.ReadLine());
                        Ablak.ErtekBetoltes(r.ReadLine());
                        Furdokad.ErtekBetoltes(r.ReadLine());
                        Feszitovas.ErtekBetoltes(r.ReadLine());
                        Allohely.Add(r.ReadLine());
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
            Console.WriteLine("Ha bármikor elakadnál nyomd meg a \"?\" billentyût!");


            while (!Keszvane)
            {
                string parancs = Console.ReadLine().Trim();               
                string[] tobbparancs = parancs.Split(' ');
                if (tobbparancs[0] == "vedd" || tobbparancs[0] == "tedd")
                {
                    string vmi = String.Join(" ", tobbparancs[0], tobbparancs[1]);
                    string vmi2 = tobbparancs[2];
                    tobbparancs = new string[2];
                    tobbparancs[0] = vmi;
                    tobbparancs[1] = vmi2;
                }
                switch (tobbparancs.Length)
                {
                    case 1: p = new Parancs(tobbparancs[0]);
                        switch (p.Mitcsinal)
                        {
                            case "nézd":
                                    if (Allohely.Last()=="nappali")
                                    {                                    
                                        if (Ablak.LathatoE == false)
                                        {
                                            Console.WriteLine("A nappaliban vagy. Látsz egy szekrényt és egy ajtót nyugatra.\n");
                                        }
                                        else
                                        {
                                            Console.WriteLine("A nappaliban vagy. Látsz egy szekrényt, egy ablakot északra és egy ajtót nyugatra.\n");
                                        }
                                    }
                                    else
                                    {
                                        if (Allohely.Last() == "fürdõ")
                                        {
                                            if (!Furdokad.Elvegzette)
                                            {
                                                if (!Leltar.Exists(x => x == "feszítõvas"))
                                                {
                                                    Console.WriteLine("A fürdõben vagy. Látsz egy fürdõkádat, benne egy feszítõvasat és egy ajtót keletre.\n");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("A fürdõben vagy. Látsz egy fürdõkádat és egy ajtót keletre.\n");
                                                }
                                            }
                                            else
                                            {
                                                if (!Leltar.Exists(x => x == "feszítõvas"))
                                                {
                                                    Console.WriteLine("A fürdõben vagy. Látsz egy fürdõkádat, benne egy feszítõvasat és egy ajtót keletre.\n");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("A fürdõben vagy. Látsz egy fürdõkádat és egy ajtót keletre.\n");
                                                }
                                            }
                                        }    
                                    }
                                break;

                            case "kelet":
                                    if (Allohely.Last()=="fürdõ")
                                    {
                                        Allohely.Add("nappali");
                                        if (Ablak.LathatoE == false)
                                        {
                                            Console.WriteLine("A nappaliban vagy. Látsz egy szekrényt és egy ajtót nyugatra.\n");
                                        }
                                        else
                                        {
                                            Console.WriteLine("A nappaliban vagy. Látsz egy szekrényt, egy ablakot északra és egy ajtót nyugatra.\n");
                                        }
                                    
                                    }
                                    else
                                    {
                                        Console.WriteLine("Innen nem lehet keletre menni! (A nappaliban vagy)\n");
                                    }
                                break;

                            case "nyugat":
                                    if (Allohely.Last() == "nappali")
                                    {
                                        if (Ajto.Elvegzette == true)
                                        {   
                                            Allohely.Add("fürdõ");
                                            if (Feszitovas.LathatoE == false)
                                            {
                                                Console.WriteLine("A fürdõben vagy. Látsz egy fürdõkádat és egy ajtót keletre.\n");
                                            }
                                            else
                                            {
                                                Console.WriteLine("A fürdõben vagy. Látsz egy fürdõkádat, benne egy feszítõvasat és egy ajtót nyugatra.\n");
                                            }
                                        
                                        }
                                        else
                                        {
                                            Console.WriteLine("Nyugatra egy zárt ajtó található.\n");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Innen nem lehet nyugatra menni! (A fürdõben vagy)\n");
                                    }
                                break;
                                
                            case "észak":
                                    if (Allohely.Last() == "nappali")
                                    {
                                        Allohely.Add("nappali");
                                        if (Ablak.LathatoE)
                                        {
                                            if (Ablak.Elvegzette == false)
                                            {
                                                Console.WriteLine("Északon egy zárt ablakot látsz.\n");
                                            }
                                            else
                                            {
                                                Keszvane = true;
                                                Console.WriteLine("Gratulálok! Sikerült kijutnod a szobából. :)\n");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Innen nem lehet északra menni.\n");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Innen nem lehet északra menni!\n");
                                    }
                                break; 
                                
                            case "?":
                                    Console.WriteLine(Help());
                                break;

                            case "leltár":
                                    Console.WriteLine($"Leltár: {String.Join("; ", Leltar)}\n");
                                break;

                            case "mentés":
                                    File.Delete("mentes.sav");
                                    StreamWriter w = new StreamWriter("mentes.sav");                               
                                    w.Write(Mentes(Leltar, Szekreny, Doboz, Kulcs, Ajto, Ablak, Furdokad, Feszitovas, Allohely.Last()));
                                    w.Close();
                                    Console.WriteLine("Sikeresen elmentetted!\n");
                                break;

                            default:
                                    Console.WriteLine($"{Nemhelyes(parancs)}\n");
                                break;
                        }
                         // nezd, kelet, nyugat, eszak, ?, leltar, mentes   //KESZ
                        break;


                    case 2: p = new Parancs(tobbparancs[0], tobbparancs[1]);
                        switch (p.Mitcsinal)
                        {
                            case "nézd":                                                                       
                                    switch (p.Miaz)
                                    {
                                        case "feszítõvas":
                                            if (!Ablak.Elvegzette)
                                            {
                                                Console.WriteLine("Használd fel a feszítõvasat valamire.\n");
                                            }
                                            else
                                            {
                                                Console.WriteLine("A feszítõvast már nem tudod mire használni.\n");
                                            }
                                        break;

                                        case "doboz":
                                            if (Doboz.Elvegzette)
                                            {
                                                Console.WriteLine("Nem tudsz már mit csinálni a dobozzal.\n");
                                            }
                                            else
                                            {
                                                Console.WriteLine("A doboz zárva van.\n");
                                            }
                                        break;

                                        case "kulcs":
                                            if (Ajto.Elvegzette)
                                            {
                                                Console.WriteLine("Nem tudsz már mit csinálni a kulccsal.\n");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Használd fel a kulcsot valamire.\n");
                                            }
                                        break;

                                        default:
                                                if (Allohely.Last() == "nappali")
                                                {
                                                    switch (p.Miaz)
                                                    {
                                                        case "ablak":
                                                                if (Ablak.LathatoE)
                                                                {
                                                                    if (!Ablak.Elvegzette)
                                                                    {
                                                                        Console.WriteLine("Az ablak zárva van.\n");
                                                                    }
                                                                    else
                                                                    {
                                                                        Console.WriteLine("Az ablak nyitva van.\n");
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine("Nem látsz ablakot.\n");
                                                                }
                                                            break;

                                                        case "ajtó":
                                                                if (!Ajto.Elvegzette)
                                                                {
                                                                    Console.WriteLine("Az ajtó zárva van.\n");
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine("Az ajtó nyitva van.\n");
                                                                }
                                                            break;

                                                        case "szekrény":
                                                                if (!Szekreny.Elvegzette)
                                                                {
                                                                    Console.WriteLine("A szekrény ajtaja résnyire nyitva van. Próbálj meg egy másik parancsot.\n");
                                                                }
                                                                else
                                                                {
                                                                    if (Doboz.LathatoE)
                                                                    {
                                                                        Console.WriteLine("A szekrény nyitva van és látsz benne egy dobozt.\n");
                                                                    }
                                                                    else
                                                                    {
                                                                        Console.WriteLine("A szekrény nyitva van és a dobozt már felvetted.\n");
                                                                    }
                                                                }
                                                            break;

                                                        default:
                                                            break;
                                                    }
                                                }
                                                else
                                                {
                                                    if (p.Miaz == "fürdõkád")
                                                    {
                                                        if (!Feszitovas.LathatoE)
                                                        {
                                                            Console.WriteLine("A fürdõkádban egy feszítõvasat látsz.\n");
                                                            Feszitovas.LathatoE = true;
                                                            Furdokad.Elvegzette = true;
                                                        }
                                                        else
                                                        {
                                                            if (Feszitovas.Elvegzette)
                                                            {
                                                                Console.WriteLine("A fürdõkád üres.\n");
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("A fürdõkádban egy feszítõvas található.\n");
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (p.Miaz == "ajtó")
                                                        {
                                                            Console.WriteLine("Keletre egy nyitott ajtót látsz.\n");
                                                        }
                                                    }
                                                }
                                            break;
                                    }                                   
                                break;

                            case "húzd":
                                    if (Allohely.Last()=="nappali")
                                    {
                                        if (p.Miaz=="szekrény")
                                        {
                                            if (!Ablak.LathatoE)
                                            {
                                                Console.WriteLine("Elhúztad a szekrényt, most látsz valamit mögötte. Írd be a 'nézd' parancsot, hogy megtudd mi az.\n");
                                                Ablak.LathatoE = true;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Elhúztad már a szekrényt!\n");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine($"Nem tudod elhúzni a/az {p.Miaz}-t, próbálj meg valami mást.\n");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Nem tudod elhúzni a/az {p.Miaz}-t, próbálj meg valami mást.\n");
                                    }
                                break;

                            case "nyisd":                                    
                                    if (p.Miaz == "doboz")
                                    {
                                        if (Leltar.Exists(x => x == "doboz"))
                                        {
                                            Kulcs.LathatoE = true;
                                            Console.WriteLine("A dobozt kinyitottad, egy kulcsot látsz.\n");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Még nem vetted fel a dobozt.\n");
                                        }
                                    }
                                    else
                                    {
                                        if (Allohely.Last() == "nappali")
                                        {
                                            if (p.Miaz == "szekrény")
                                            {
                                                if (!Szekreny.Elvegzette)
                                                {
                                                    Szekreny.Elvegzette = true;
                                                    Doboz.LathatoE = true;
                                                    Console.WriteLine("Kinyitottad a szekrényt, látsz benne egy dobozt.\n");
                                                }
                                                else
                                                {
                                                    if (!Doboz.Elvegzette)
                                                    {
                                                        Console.WriteLine("A szekrényt már kinyitottad, látsz benne egy dobozt.\n");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("A szekrényt már kinyitottad és a dobozt már felvetted.\n");
                                                    }

                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine($"A {p.Miaz} tárgy nem nyitható. Próbálj meg mást.\n");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine($"A {p.Miaz} tárgy nem nyitható. Próbálj meg mást.\n");
                                        }
                                    }                                                                      
                                break;

                            case "vedd fel":
                                    switch (p.Miaz)
                                    {
                                        case "kulcs":
                                                if (Kulcs.LathatoE)
                                                {
                                                    Kulcs.Elvegzette = true;
                                                    Console.WriteLine("Felvetted a kulcsot.\n");
                                                    Leltar.Add(p.Miaz);  
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Nem látsz kulcsot.\n");
                                                }
                                            break;
                                        case "doboz":
                                                if (Allohely.Last() == "nappali")
                                                {
                                                    if (Doboz.LathatoE)
                                                    {
                                                        Doboz.Elvegzette = true;
                                                        Leltar.Add(p.Miaz);
                                                        Console.WriteLine("Felvetted a dobozt.\n");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Nem látsz dobozt.\n");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Nem látsz dobozt.\n");
                                                }
                                            break;
                                        case "feszítõvas":
                                                if (Allohely.Last() == "fürdõ")
                                                {
                                                    if (Feszitovas.LathatoE)
                                                    {
                                                        Feszitovas.Elvegzette = true;
                                                        Leltar.Add(p.Miaz);
                                                        Console.WriteLine("Felvetted a feszítõvasat.\n");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Nem látsz feszítõvasat.\n");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Nem látsz feszítõvasat.\n");
                                                }
                                            break;
                                        default:
                                                Console.WriteLine($"Nem lehet felvenni a/az {p.Miaz}-t.\n");
                                            break;
                                    }
                                break;

                            case "tedd le":
                                    if (Leltar.Exists(x=>x == p.Miaz))
                                    {
                                        Console.Write("Ha leteszel egy tárgyat utána már nem tudod újra felvenni, biztos leteszed?\nigen/nem\n");
                                        string sege = Console.ReadLine();
                                        if (sege == "igen")
                                        {
                                            Console.WriteLine($"Letetted a/az {p.Miaz}-t.\n");
                                            Leltar.Remove(p.Miaz);
                                        }
                                        else
                                        {
                                            if (sege == "nem")
                                            {
                                                Console.WriteLine($"Nem tetted le a/az {p.Miaz}-t.\n");
                                            }
                                            else
                                            {
                                                Console.WriteLine($"Hibásan írtad be, nem tettél le semmit.\n");
                                            }
                                        }                                       
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Nem található a leltáradban {p.Miaz}.\n");
                                    }
                                break;

                            default:
                                Console.WriteLine($"{Nemhelyes(parancs)}\n");
                                break;
                        }
                        // nezd, huzd, nyisd, vedd fel, tedd le
                        break;


                    case 3: p = new Parancs(tobbparancs[0], tobbparancs[1], tobbparancs[2]);                        
                        switch (p.Mitcsinal)
                        {
                            case "nyisd":
                                    if (Allohely.Last() == "nappali")
                                    {
                                        if (p.Miaz == "ajtó")
                                        {
                                            if (!Ajto.Elvegzette)
                                            {
                                                if (Kulcs.Elvegzette)
                                                {
                                                    Ajto.Elvegzette = true;
                                                    Console.WriteLine("Az ajtót kinyitottad.\n");
                                                }
                                                else
                                                {
                                                    Console.WriteLine($"Nem tudod {p.Mithasznal}-val/vel kinyitni az ajtót. Keress mást hozzá!\n");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Az ajtó már nyitva van.\n");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine($"Nem tudod {p.Miaz}-t kinyitni {p.Mithasznal}-val/vel.\n");
                                        }                                    
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Nem tudod {p.Miaz}-t kinyitni {p.Mithasznal}-val/vel.\n");
                                    }
                                break;
                            case "törd":
                                    if (Allohely.Last() == "nappali")
                                    {
                                        if (p.Miaz == "ablak")
                                        {
                                            if (Ablak.LathatoE)
                                            {
                                                if (Feszitovas.Elvegzette)
                                                {
                                                    Console.WriteLine("Az ablakot betörted.\n");
                                                    Ablak.Elvegzette = true;
                                                }
                                                else
                                                {
                                                    Console.WriteLine($"Nem tudod {p.Mithasznal}-val/vel betörni az ablakot.\n");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine($"Nem látsz ablakot, amit betörhetnél.\n");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine($"Nem tudod {p.Mithasznal}-val/vel betörni a/az {p.Miaz}-t.\n");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Nem tudod {p.Mithasznal}-val/vel betörni a/az {p.Miaz}-t.\n");
                                    }
                                break;
                            default:
                                Console.WriteLine($"{Nemhelyes(parancs)}\n");
                                break;
                        }
                         // nyisd, tord
                        break;


                    default:
                        Console.WriteLine("Helytelen parancsot adtál meg:\nmit csinálsz / mivel (nem kötelezõ) / mit használsz hozzá (nem kötelezõ)\n");                       
                        break;
                }
            }

            Console.ReadKey();
            

        }
    }
}
