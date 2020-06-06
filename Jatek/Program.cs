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


        static string Mentes(HashSet<string> leltar, List<Targy> targyak, string allohely)
        {
            string leltarok = String.Join(";", leltar);
            List<string> mentestargyak = new List<string>();
            foreach (var item in targyak)
            {
                mentestargyak.Add(item.Menteshez());
            }
            return String.Join("\n", leltarok, mentestargyak, allohely);
        }


        static string Szamok(string kod)
        {
            string[] seged = kod.Split(';');

            switch (seged[0])
            {
                case "1":
                    switch (seged[1])
                    {                        
                        case "szekrény":
                            switch (seged[2])
                            {
                                case "nézd": return "Az elhúzott szekrény résnyire nyitva van. Egy ablakot látsz mögötte.";
                                case "húzd": return "A szekrényt már elhúztad.";
                                case "nyisd": return "A szekrényt sikeresen kinyitottad, egy dobozt látsz benne.+2+3";
                                default: return "Nem használhatod ezt a parancsot ezen a tárgyon.";                                    
                            }
                        case "doboz":
                            switch (seged[2])
                            {
                                case "vedd fel": return "A dobozt felvetted.+0+1+2+4";
                                default: return "Nem használhatod ezt a parancsot ezen a tárgyon.";
                            }
                        case "ajtó":
                            switch (seged[2])
                            {
                                case "nézd": return "Egy zárt ajtót látsz nyugatra.";
                                default: return "Nem használhatod ezt a parancsot ezen a tárgyon.";                                   
                            }
                        case "ablak":
                            switch (seged[2])
                            {
                                case "nézd": return "Az ablak zárva van.";
                                default: return "Nem használhatod ezt a parancsot ezen a tárgyon.";
                            }
                        case "fürdõkád":
                            switch (seged[2])
                            {
                                case "nézd": return "A fürdõkádban egy feszítõvasat látsz.+3";
                                default: return "Nem használhatod ezt a parancsot ezen a tárgyon."; 
                            }
                        case "kulcs":
                            switch (seged[2])
                            {
                                case "vedd fel": return "A kulcsot felvetted.+0+1+2+4";
                                default: return "Nem használhatod ezt a parancsot ezen a tárgyon.";
                            }
                        case "feszítõvas":
                            switch (seged[2])
                            {
                                case "vedd fel": return "A feszítõvasat felvetted.+0+1+2+4";
                                default: return "Nem használhatod ezt a parancsot ezen a tárgyon.";
                            }

                        default: return "";
                    }
                    
                case "2":
                    switch (seged[1])
                    {
                        case "szekrény":
                            switch (seged[2])
                            {
                                case "nézd": return "Az elhúzott szekrény nyitva van.+5";
                                case "húzd": return "A szekrényt már elhúztad.";
                                case "nyisd": return "a szekrényt már kinyitottad.";
                                default: return "Nem használhatod ezt a parancsot ezen a tárgyon.";
                            }
                        case "ajtó":
                            switch (seged[2])
                            {
                                case "nézd": return "az ajtó nyitva van.+5";
                                default: return "Nem használhatod ezt a parancsot ezen a tárgyon.";
                            }
                        case "ablak":
                            switch (seged[2])
                            {
                                case "nézd": return "Az ablak nyitva van.";
                                default: return "Nem használhatod ezt a parancsot ezen a tárgyon.";
                            }
                        case "fürdõkád":
                            switch (seged[2])
                            {
                                case "nézd": return "A fürdõkád üres.";
                                default: return "Nem használhatod ezt a parancsot ezen a tárgyon.";
                            }
                        
                        default: return "";
                    }

                case "3":
                    switch (seged[1])
                    {
                        case "szekrény":
                            switch (seged[2])
                            {
                                case "nézd": return "A szekrény résnyire nyitva van.";
                                case "húzd": return "A szekrényt elhúztad, egy ablak van mögötte.+1+3";
                                case "nyisd": return "A szekrényt sikeresen kinyitottad, egy dobozt látsz benne.+2+3";
                                default: return "Nem használhatod ezt a parancsot ezen a tárgyon.";
                            }                        
                        default: return "";
                    }

                case "4":
                    switch (seged[1])
                    {
                        case "szekrény":
                            switch (seged[2])
                            {
                                case "nézd": return "A szekrény nyitva van.+5";
                                case "húzd": return "A szekrényt elhúztad, egy ablak van mögötte.+1+3";
                                case "nyisd": return "A szekrényt már kinyitottad.+5";
                                default: return "Nem használhatod ezt a parancsot ezen a tárgyon.";
                            }
                        case "doboz":
                            switch (seged[2])
                            {
                                case "tedd le": return "Ha leteszed többé nem tudod felvenni. Biztos eltávolítod a leltáradból?+6";
                                case "nyisd": return "A dobozt kinyitottad, egy kulcsot látsz benne.+1+3";
                                default: return "Nem használhatod ezt a parancsot ezen a tárgyon.";
                            }
                        case "ajtó":                            
                            switch (seged[2])
                            {
                                case "nyisd": return "Az ajtót kinyitottad, így a \'nyugat\' paranccsal átmehetsz a másik szobába.+2+3";
                                default: return "Nem használhatod ezt a parancsot ezen a tárgyon.";
                            }
                        case "ablak":
                            switch (seged[2])
                            {
                                case "törd": return "Az ablakot betörted az észak paranccsal juthasz ki.+2+3";
                                default: return "Nem használhatod ezt a parancsot ezen a tárgyon.";
                            }
                        case "kulcs":
                            switch (seged[2])
                            {
                                case "tedd le": return "Ha leteszed többé nem tudod felvenni. Biztos eltávolítod a leltáradból?+6";
                                default: return "Nem használhatod ezt a parancsot ezen a tárgyon.";
                            }
                        case "feszítõvas":
                            switch (seged[2])
                            {
                                case "tedd le": return "Ha leteszed többé nem tudod felvenni. Biztos eltávolítod a leltáradból?+6";
                                default: return "Nem használhatod ezt a parancsot ezen a tárgyon.";
                            }

                        default: return "";
                    }


                default: return "Nincs itt ilyen tárgy vagy még nem látható!";
            }

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

            HashSet<string> Leltar = new HashSet<string>();
            List<string> Allohely = new List<string>();
            List<Targy> targyak = new List<Targy>();

            

            
            Console.WriteLine("Új játékot kezdesz vagy betöltöd a már meglevõ mentésed?\núj/mentés");          
            string a = Betolt(Console.ReadLine());
            

            while (a == "null" || a == "false" || a == "true")
            {
                if (a == "false")
                {
                    targyak.Add(new Targy("szekrény;nappali;true;true;false"));
                    targyak.Add(new Targy("doboz;nappali;false;false;false"));
                    targyak.Add(new Targy("kulcs;nappali;false;false;false"));
                    targyak.Add(new Targy("ajtó;nappali;true;false;false"));
                    targyak.Add(new Targy("ablak;nappali;false;false;false"));
                    targyak.Add(new Targy("fürdõkád;fürdõ;false;false;false"));
                    targyak.Add(new Targy("feszítõvas;fürdõ;false;false;false"));
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
                        while (!r.EndOfStream)
                        {
                            targyak.Add(new Targy(r.ReadLine()));
                        }
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
                p = new Parancs(parancs);
                
                while (!p.Helyes())
                {
                    if (p.Mitcsinal != "?")
                    {

                        Console.WriteLine($"Nem jól adtad meg a ({parancs}) parancsot. Nyomd le a ? billentyût segítségért!\n");
                        string seged = Console.ReadLine();
                        p = new Parancs(seged);
                    }
                    else
                    {
                        Console.WriteLine(Help());
                    }                                     
                }
                if ((p.Miaz =="feszítõvas" || p.Miaz == "kulcs") && p.Mithasznal!="")
                {
                    p.Csere();
                }

                if (p.Miaz=="")
                {
                    switch (p.Mitcsinal)
                    {
                        case "nézd":
                            if (Allohely.Last() == "nappali")
                            {
                                if (!targyak.Find(x => x.Nev == "ablak").Tulajdonsagok["lathatoe"])
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
                                    if (!targyak.Find(x => x.Nev == "fürdõkád").Tulajdonsagok["elvegzette"])
                                    {
                                        Console.WriteLine("A fürdõben vagy. Látsz egy fürdõkádat, benne egy feszítõvasat és egy ajtót keletre.\n");
                                    }
                                    else
                                    {                                        
                                        Console.WriteLine("A fürdõben vagy. Látsz egy fürdõkádat és egy ajtót keletre.\n");
                                    }
                                }
                            }
                            break;
                        case "kelet":
                            if (Allohely.Last() == "fürdõ")
                            {
                                Allohely.Add("nappali");
                                if (!targyak.Find(x => x.Nev == "ablak").Tulajdonsagok["lathatoe"])
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
                                if (targyak.Find(x => x.Nev == "ajtó").Tulajdonsagok["elvegzette"])
                                {
                                    Allohely.Add("fürdõ");
                                    if (!targyak.Find(x => x.Nev == "feszítõvas").Tulajdonsagok["lathatoe"])
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
                                if (targyak.Find(x => x.Nev == "ablak").Tulajdonsagok["lathatoe"])
                                {
                                    if (!targyak.Find(x => x.Nev == "feszítõvas").Tulajdonsagok["elvegzette"])
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
                        case "?":   Console.WriteLine(Help());
                            break;
                        case "mentés":
                            File.Delete("mentes.sav");
                            StreamWriter w = new StreamWriter("mentes.sav");
                            w.Write(Mentes(Leltar, targyak, Allohely.Last()));
                            w.Close();
                            Console.WriteLine("Sikeresen elmentetted!\n");
                            break;
                        case "leltár":  Console.WriteLine($"Leltár: {String.Join("; ", Leltar)}\n");
                            break;
                        default:    Console.WriteLine($"Nem helyes parancsot adtál meg: {parancs}\n");
                            break;
                    }
                }
                else
                {
                    bool leheteilyen = p.Leheteilyen();
                    string szoba = targyak.Find(x => x.Nev == p.Miaz).Szoba.ToString();
                    string nev = targyak.Find(x => x.Nev == p.Miaz).Nev.ToString();
                    bool lathatoe = targyak.Find(x => x.Nev == p.Miaz).Tulajdonsagok["lathatoe"];
                    bool hasznalhato = targyak.Find(x => x.Nev == p.Miaz).Tulajdonsagok["hasznalhatoe"];
                    bool elvegzette = targyak.Find(x => x.Nev == p.Miaz).Tulajdonsagok["elvegzette"];

                    if (p.Ellenorzes(Allohely.Last(), szoba, leheteilyen) || p.Mitcsinal == "tedd le")
                    {
                        if (p.Mithasznal == "")
                        {
                            string kod = p.Targyasparancs(nev, lathatoe, hasznalhato, elvegzette);
                            string szoveg = Szamok(kod);
                            if (szoveg != "")
                            {
                                string[] szovegseged = szoveg.Split('+');
                                if (szovegseged.Length == 1)
                                {
                                    Console.WriteLine(szoveg + "\n");
                                }
                                else
                                {
                                    if (szovegseged[1] == "6")
                                    {
                                        Console.WriteLine(szovegseged[0] + " Igen/Nem\n");
                                        string melyik = Console.ReadLine();                                  
                                        if (melyik == "Igen" && Leltar.Contains(p.Miaz))
                                        {
                                            Leltar.Remove(p.Miaz);
                                            Console.WriteLine($"Letetted a/az {p.Miaz} tárgyat.\n");
                                        }
                                    }
                                    else
                                    {
                                        for (int i = 1; i < szovegseged.Length; i++)
                                        {
                                            switch (szovegseged[i])
                                            {
                                                case "0": targyak.Find(x => x.Nev == p.Miaz).Lathatosag(); break;
                                                case "1": targyak.Find(x => x.Nev == p.Miaz).Hasznalat(); break;
                                                case "2": targyak.Find(x => x.Nev == p.Miaz).Elvegzett(); break;
                                                case "3":
                                                    switch (p.Miaz)
                                                    {
                                                        case "fürdõkád":
                                                            targyak.Find(x => x.Nev == "feszítõvas").Tulajdonsagok["lathatoe"] = true;
                                                            targyak.Find(x => x.Nev == "fürdõkád").Tulajdonsagok["elvegzette"] = true;
                                                            break;
                                                        case "szekrény":
                                                            if (p.Mitcsinal == "húzd")
                                                            {
                                                                targyak.Find(x => x.Nev == "ablak").Tulajdonsagok["lathatoe"] = true; break;
                                                            }
                                                            if (p.Mitcsinal == "nyisd")
                                                            {
                                                                targyak.Find(x => x.Nev == "doboz").Tulajdonsagok["lathatoe"] = true; break;
                                                            }
                                                            break;
                                                        case "ablak":
                                                            Console.WriteLine(szovegseged[0] + "\n");
                                                            string vege = Console.ReadLine();
                                                            if (vege == "észak")
                                                            {
                                                                Keszvane = true;
                                                            }
                                                            break;
                                                        case "ajtó": targyak.Find(x => x.Nev == "fürdõkád").Tulajdonsagok["lathatoe"] = true; break;
                                                        case "doboz": targyak.Find(x => x.Nev == "kulcs").Tulajdonsagok["lathatoe"] = true; break;
                                                    }
                                                    break;
                                                case "4": Leltar.Add(p.Miaz); break;
                                                case "5":
                                                    switch (p.Miaz)
                                                    {
                                                        case "ajtó":
                                                            if (Allohely.Last() == "nappali")
                                                            {
                                                                Console.Write("Nyugatra ");
                                                            }
                                                            else
                                                            {
                                                                Console.Write("Keletre  ");
                                                            }
                                                            break;
                                                        case "szekrény":
                                                            if (targyak.Find(x => x.Nev == "doboz").Tulajdonsagok["lathatoe"])
                                                            {
                                                                Console.WriteLine(" Egy dobozt látsz benne, vedd fel.");
                                                            }                                                           
                                                            break;
                                                        default:
                                                            break;
                                                    }
                                                    break;
                                            }
                                        }
                                        Console.WriteLine(szovegseged[0] + "\n");
                                    }

                                }

                            }

                        }
                        else
                        {
                            string kod = p.Tobbparancs(p.Miaz, p.Mithasznal, targyak.Find(x => x.Nev == p.Miaz).Tulajdonsagok["lathatoe"], Leltar.Contains(p.Mithasznal), targyak.Find(x => x.Nev == p.Mithasznal).Tulajdonsagok["hasznalhatoe"], targyak.Find(x => x.Nev == p.Mithasznal).Tulajdonsagok["elvegzette"]);
                            string szoveg = Szamok(kod);
                            
                            if (szoveg!="")
                            {
                                string[] szovegseged = szoveg.Split('+');
                                if (szovegseged.Length == 1)
                                {
                                    Console.WriteLine(szoveg + "\n");
                                }
                                else
                                {
                                    if (szovegseged[1] == "6")
                                    {
                                        string melyik;
                                        do
                                        {
                                            Console.WriteLine(szovegseged[0] + " Igen/Nem\n");
                                            melyik = Console.ReadLine();
                                        } while (melyik != "Igen" || melyik != "Nem");
                                        if (melyik == "Igen" && Leltar.Contains(p.Miaz))
                                        {
                                            Leltar.Remove(p.Miaz);
                                        }
                                    }
                                    else
                                    {
                                        for (int i = 1; i < szovegseged.Length; i++)
                                        {
                                            switch (szovegseged[i])
                                            {
                                                case "0": targyak.Find(x => x.Nev == p.Miaz).Lathatosag(); break;
                                                case "1": targyak.Find(x => x.Nev == p.Miaz).Hasznalat(); break;
                                                case "2": targyak.Find(x => x.Nev == p.Miaz).Elvegzett(); break;
                                                case "3":
                                                    switch (p.Miaz)
                                                    {
                                                        case "szekrény":
                                                            if (p.Mitcsinal == "húzd")
                                                            {
                                                                targyak.Find(x => x.Nev == "ablak").Tulajdonsagok["lathatoe"] = true; break;
                                                            }
                                                            if (p.Mitcsinal == "nyisd")
                                                            {
                                                                targyak.Find(x => x.Nev == "doboz").Tulajdonsagok["lathatoe"] = true; break;
                                                            }
                                                            break;
                                                        case "ablak":
                                                            Console.WriteLine(szovegseged[0] + "\n");
                                                            string vege = Console.ReadLine();
                                                            if (vege == "észak")
                                                            {
                                                                Keszvane = true;
                                                                Console.WriteLine("Gratulálok! Sikerült kijutnod a szobából. :)\n");
                                                            }
                                                            break;
                                                        case "ajtó": targyak.Find(x => x.Nev == "fürdõkád").Tulajdonsagok["lathatoe"] = true; break;
                                                        case "doboz": targyak.Find(x => x.Nev == "kulcs").Tulajdonsagok["lathatoe"] = true; break;
                                                    }
                                                    break;
                                                case "4": Leltar.Add(p.Miaz); break;
                                                case "5":
                                                    switch (p.Miaz)
                                                    {
                                                        case "ajtó":
                                                            if (Allohely.Last() == "nappali")
                                                            {
                                                                Console.WriteLine("Nyugatra " + szovegseged[0]);
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Keletre  " + szovegseged[0]);
                                                            }
                                                            break;
                                                        case "szekrény":
                                                            if (targyak.Find(x => x.Nev == "doboz").Tulajdonsagok["lathatoe"])
                                                            {
                                                                Console.WriteLine(szovegseged[0] + " Egy dobozt látsz benne, vedd fel.");
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine(szovegseged[0]);
                                                            }
                                                            break;
                                                        default:
                                                            break;
                                                    }
                                                    break;
                                            }
                                        }
                                        Console.WriteLine(szovegseged[0] + "\n");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {                        
                        Console.WriteLine($"Nem jó a parancs, amit megadtál! Nem lehet ebben a szobában ({Allohely.Last()}) vagy ebben a helyzetben használni. Ellenõrizd, amit beírtál!\n");
                    }
                }
                          
            }

            Console.ReadKey();

        }
    }
}
