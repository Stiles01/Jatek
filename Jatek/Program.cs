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
            if (sor == "�j")
            {
                return "false";
            }
            else
            {
                if (sor == "ment�s")
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
                        case "szekr�ny":
                            switch (seged[2])
                            {
                                case "n�zd": return "Az elh�zott szekr�ny r�snyire nyitva van. Egy ablakot l�tsz m�g�tte.";
                                case "h�zd": return "A szekr�nyt m�r elh�ztad.";
                                case "nyisd": return "A szekr�nyt sikeresen kinyitottad, egy dobozt l�tsz benne.+2+3";
                                default: return "Nem haszn�lhatod ezt a parancsot ezen a t�rgyon.";                                    
                            }
                        case "doboz":
                            switch (seged[2])
                            {
                                case "vedd fel": return "A dobozt felvetted.+0+1+2+4";
                                default: return "Nem haszn�lhatod ezt a parancsot ezen a t�rgyon.";
                            }
                        case "ajt�":
                            switch (seged[2])
                            {
                                case "n�zd": return "Egy z�rt ajt�t l�tsz nyugatra.";
                                default: return "Nem haszn�lhatod ezt a parancsot ezen a t�rgyon.";                                   
                            }
                        case "ablak":
                            switch (seged[2])
                            {
                                case "n�zd": return "Az ablak z�rva van.";
                                default: return "Nem haszn�lhatod ezt a parancsot ezen a t�rgyon.";
                            }
                        case "f�rd�k�d":
                            switch (seged[2])
                            {
                                case "n�zd": return "A f�rd�k�dban egy fesz�t�vasat l�tsz.+3";
                                default: return "Nem haszn�lhatod ezt a parancsot ezen a t�rgyon."; 
                            }
                        case "kulcs":
                            switch (seged[2])
                            {
                                case "vedd fel": return "A kulcsot felvetted.+0+1+2+4";
                                default: return "Nem haszn�lhatod ezt a parancsot ezen a t�rgyon.";
                            }
                        case "fesz�t�vas":
                            switch (seged[2])
                            {
                                case "vedd fel": return "A fesz�t�vasat felvetted.+0+1+2+4";
                                default: return "Nem haszn�lhatod ezt a parancsot ezen a t�rgyon.";
                            }

                        default: return "";
                    }
                    
                case "2":
                    switch (seged[1])
                    {
                        case "szekr�ny":
                            switch (seged[2])
                            {
                                case "n�zd": return "Az elh�zott szekr�ny nyitva van.+5";
                                case "h�zd": return "A szekr�nyt m�r elh�ztad.";
                                case "nyisd": return "a szekr�nyt m�r kinyitottad.";
                                default: return "Nem haszn�lhatod ezt a parancsot ezen a t�rgyon.";
                            }
                        case "ajt�":
                            switch (seged[2])
                            {
                                case "n�zd": return "az ajt� nyitva van.+5";
                                default: return "Nem haszn�lhatod ezt a parancsot ezen a t�rgyon.";
                            }
                        case "ablak":
                            switch (seged[2])
                            {
                                case "n�zd": return "Az ablak nyitva van.";
                                default: return "Nem haszn�lhatod ezt a parancsot ezen a t�rgyon.";
                            }
                        case "f�rd�k�d":
                            switch (seged[2])
                            {
                                case "n�zd": return "A f�rd�k�d �res.";
                                default: return "Nem haszn�lhatod ezt a parancsot ezen a t�rgyon.";
                            }
                        
                        default: return "";
                    }

                case "3":
                    switch (seged[1])
                    {
                        case "szekr�ny":
                            switch (seged[2])
                            {
                                case "n�zd": return "A szekr�ny r�snyire nyitva van.";
                                case "h�zd": return "A szekr�nyt elh�ztad, egy ablak van m�g�tte.+1+3";
                                case "nyisd": return "A szekr�nyt sikeresen kinyitottad, egy dobozt l�tsz benne.+2+3";
                                default: return "Nem haszn�lhatod ezt a parancsot ezen a t�rgyon.";
                            }                        
                        default: return "";
                    }

                case "4":
                    switch (seged[1])
                    {
                        case "szekr�ny":
                            switch (seged[2])
                            {
                                case "n�zd": return "A szekr�ny nyitva van.+5";
                                case "h�zd": return "A szekr�nyt elh�ztad, egy ablak van m�g�tte.+1+3";
                                case "nyisd": return "A szekr�nyt m�r kinyitottad.+5";
                                default: return "Nem haszn�lhatod ezt a parancsot ezen a t�rgyon.";
                            }
                        case "doboz":
                            switch (seged[2])
                            {
                                case "tedd le": return "Ha leteszed t�bb� nem tudod felvenni. Biztos elt�vol�tod a lelt�radb�l?+6";
                                case "nyisd": return "A dobozt kinyitottad, egy kulcsot l�tsz benne.+1+3";
                                default: return "Nem haszn�lhatod ezt a parancsot ezen a t�rgyon.";
                            }
                        case "ajt�":                            
                            switch (seged[2])
                            {
                                case "nyisd": return "Az ajt�t kinyitottad, �gy a \'nyugat\' paranccsal �tmehetsz a m�sik szob�ba.+2+3";
                                default: return "Nem haszn�lhatod ezt a parancsot ezen a t�rgyon.";
                            }
                        case "ablak":
                            switch (seged[2])
                            {
                                case "t�rd": return "Az ablakot bet�rted az �szak paranccsal juthasz ki.+2+3";
                                default: return "Nem haszn�lhatod ezt a parancsot ezen a t�rgyon.";
                            }
                        case "kulcs":
                            switch (seged[2])
                            {
                                case "tedd le": return "Ha leteszed t�bb� nem tudod felvenni. Biztos elt�vol�tod a lelt�radb�l?+6";
                                default: return "Nem haszn�lhatod ezt a parancsot ezen a t�rgyon.";
                            }
                        case "fesz�t�vas":
                            switch (seged[2])
                            {
                                case "tedd le": return "Ha leteszed t�bb� nem tudod felvenni. Biztos elt�vol�tod a lelt�radb�l?+6";
                                default: return "Nem haszn�lhatod ezt a parancsot ezen a t�rgyon.";
                            }

                        default: return "";
                    }


                default: return "Nincs itt ilyen t�rgy vagy m�g nem l�that�!";
            }

        }



        static string Help()
        {
            
            return "A helyes utas�t�ssorozat: \nmit csin�lunk / mivel (nem k�telez�) / mit haszn�lunk hozz� (nem k�telez�)\n\nParancsok:\t? (0) / lelt�r (0) / ment�s (0)\nIr�nyok:\tkelet (0) / nyugat (0) / �szak (0)\nCselekm�nyek:\tn�zd (0 vagy 1) / vedd fel (1) / tedd le (1) / nyisd (1 vagy 2) / h�zd (1) / t�rd (2)\n\nnem kell ut�na param�tert �rni: (0)\tegy param�tert lehet ut�na �rni: (1)\tk�t param�tert lehet ut�na �rni: (2)\n";
        }


        static void Main(string[] args)
        {
            //K�sz�tette: Nagy Vikt�ria
            //J�t�k neve: Szabadul�-szoba

            bool Keszvane = false;
            Parancs p;

            HashSet<string> Leltar = new HashSet<string>();
            List<string> Allohely = new List<string>();
            List<Targy> targyak = new List<Targy>();

            

            
            Console.WriteLine("�j j�t�kot kezdesz vagy bet�lt�d a m�r meglev� ment�sed?\n�j/ment�s");          
            string a = Betolt(Console.ReadLine());
            

            while (a == "null" || a == "false" || a == "true")
            {
                if (a == "false")
                {
                    targyak.Add(new Targy("szekr�ny;nappali;true;true;false"));
                    targyak.Add(new Targy("doboz;nappali;false;false;false"));
                    targyak.Add(new Targy("kulcs;nappali;false;false;false"));
                    targyak.Add(new Targy("ajt�;nappali;true;false;false"));
                    targyak.Add(new Targy("ablak;nappali;false;false;false"));
                    targyak.Add(new Targy("f�rd�k�d;f�rd�;false;false;false"));
                    targyak.Add(new Targy("fesz�t�vas;f�rd�;false;false;false"));
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
                        Console.WriteLine("�j vagy ment�s?");
                        a = Betolt(Console.ReadLine());
                        continue;
                    }
                }
            }
            Console.WriteLine("Ha b�rmikor elakadn�l nyomd meg a \"?\" billenty�t!");


            while (!Keszvane)
            {
                string parancs = Console.ReadLine().Trim();
                p = new Parancs(parancs);
                
                while (!p.Helyes())
                {
                    if (p.Mitcsinal != "?")
                    {

                        Console.WriteLine($"Nem j�l adtad meg a ({parancs}) parancsot. Nyomd le a ? billenty�t seg�ts�g�rt!\n");
                        string seged = Console.ReadLine();
                        p = new Parancs(seged);
                    }
                    else
                    {
                        Console.WriteLine(Help());
                    }                                     
                }
                if ((p.Miaz =="fesz�t�vas" || p.Miaz == "kulcs") && p.Mithasznal!="")
                {
                    p.Csere();
                }

                if (p.Miaz=="")
                {
                    switch (p.Mitcsinal)
                    {
                        case "n�zd":
                            if (Allohely.Last() == "nappali")
                            {
                                if (!targyak.Find(x => x.Nev == "ablak").Tulajdonsagok["lathatoe"])
                                {
                                    Console.WriteLine("A nappaliban vagy. L�tsz egy szekr�nyt �s egy ajt�t nyugatra.\n");
                                }
                                else
                                {
                                    Console.WriteLine("A nappaliban vagy. L�tsz egy szekr�nyt, egy ablakot �szakra �s egy ajt�t nyugatra.\n");
                                }
                            }
                            else
                            {
                                if (Allohely.Last() == "f�rd�")
                                {
                                    if (!targyak.Find(x => x.Nev == "f�rd�k�d").Tulajdonsagok["elvegzette"])
                                    {
                                        Console.WriteLine("A f�rd�ben vagy. L�tsz egy f�rd�k�dat, benne egy fesz�t�vasat �s egy ajt�t keletre.\n");
                                    }
                                    else
                                    {                                        
                                        Console.WriteLine("A f�rd�ben vagy. L�tsz egy f�rd�k�dat �s egy ajt�t keletre.\n");
                                    }
                                }
                            }
                            break;
                        case "kelet":
                            if (Allohely.Last() == "f�rd�")
                            {
                                Allohely.Add("nappali");
                                if (!targyak.Find(x => x.Nev == "ablak").Tulajdonsagok["lathatoe"])
                                {
                                    Console.WriteLine("A nappaliban vagy. L�tsz egy szekr�nyt �s egy ajt�t nyugatra.\n");
                                }
                                else
                                {
                                    Console.WriteLine("A nappaliban vagy. L�tsz egy szekr�nyt, egy ablakot �szakra �s egy ajt�t nyugatra.\n");
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
                                if (targyak.Find(x => x.Nev == "ajt�").Tulajdonsagok["elvegzette"])
                                {
                                    Allohely.Add("f�rd�");
                                    if (!targyak.Find(x => x.Nev == "fesz�t�vas").Tulajdonsagok["lathatoe"])
                                    {
                                        Console.WriteLine("A f�rd�ben vagy. L�tsz egy f�rd�k�dat �s egy ajt�t keletre.\n");
                                    }
                                    else
                                    {
                                        Console.WriteLine("A f�rd�ben vagy. L�tsz egy f�rd�k�dat, benne egy fesz�t�vasat �s egy ajt�t nyugatra.\n");
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("Nyugatra egy z�rt ajt� tal�lhat�.\n");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Innen nem lehet nyugatra menni! (A f�rd�ben vagy)\n");
                            }
                            break;
                        case "�szak":
                            if (Allohely.Last() == "nappali")
                            {
                                Allohely.Add("nappali");
                                if (targyak.Find(x => x.Nev == "ablak").Tulajdonsagok["lathatoe"])
                                {
                                    if (!targyak.Find(x => x.Nev == "fesz�t�vas").Tulajdonsagok["elvegzette"])
                                    {
                                        Console.WriteLine("�szakon egy z�rt ablakot l�tsz.\n");
                                    }
                                    else
                                    {
                                        Keszvane = true;
                                        Console.WriteLine("Gratul�lok! Siker�lt kijutnod a szob�b�l. :)\n");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Innen nem lehet �szakra menni.\n");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Innen nem lehet �szakra menni!\n");
                            }
                            break;
                        case "?":   Console.WriteLine(Help());
                            break;
                        case "ment�s":
                            File.Delete("mentes.sav");
                            StreamWriter w = new StreamWriter("mentes.sav");
                            w.Write(Mentes(Leltar, targyak, Allohely.Last()));
                            w.Close();
                            Console.WriteLine("Sikeresen elmentetted!\n");
                            break;
                        case "lelt�r":  Console.WriteLine($"Lelt�r: {String.Join("; ", Leltar)}\n");
                            break;
                        default:    Console.WriteLine($"Nem helyes parancsot adt�l meg: {parancs}\n");
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
                                            Console.WriteLine($"Letetted a/az {p.Miaz} t�rgyat.\n");
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
                                                        case "f�rd�k�d":
                                                            targyak.Find(x => x.Nev == "fesz�t�vas").Tulajdonsagok["lathatoe"] = true;
                                                            targyak.Find(x => x.Nev == "f�rd�k�d").Tulajdonsagok["elvegzette"] = true;
                                                            break;
                                                        case "szekr�ny":
                                                            if (p.Mitcsinal == "h�zd")
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
                                                            if (vege == "�szak")
                                                            {
                                                                Keszvane = true;
                                                            }
                                                            break;
                                                        case "ajt�": targyak.Find(x => x.Nev == "f�rd�k�d").Tulajdonsagok["lathatoe"] = true; break;
                                                        case "doboz": targyak.Find(x => x.Nev == "kulcs").Tulajdonsagok["lathatoe"] = true; break;
                                                    }
                                                    break;
                                                case "4": Leltar.Add(p.Miaz); break;
                                                case "5":
                                                    switch (p.Miaz)
                                                    {
                                                        case "ajt�":
                                                            if (Allohely.Last() == "nappali")
                                                            {
                                                                Console.Write("Nyugatra ");
                                                            }
                                                            else
                                                            {
                                                                Console.Write("Keletre  ");
                                                            }
                                                            break;
                                                        case "szekr�ny":
                                                            if (targyak.Find(x => x.Nev == "doboz").Tulajdonsagok["lathatoe"])
                                                            {
                                                                Console.WriteLine(" Egy dobozt l�tsz benne, vedd fel.");
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
                                                        case "szekr�ny":
                                                            if (p.Mitcsinal == "h�zd")
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
                                                            if (vege == "�szak")
                                                            {
                                                                Keszvane = true;
                                                                Console.WriteLine("Gratul�lok! Siker�lt kijutnod a szob�b�l. :)\n");
                                                            }
                                                            break;
                                                        case "ajt�": targyak.Find(x => x.Nev == "f�rd�k�d").Tulajdonsagok["lathatoe"] = true; break;
                                                        case "doboz": targyak.Find(x => x.Nev == "kulcs").Tulajdonsagok["lathatoe"] = true; break;
                                                    }
                                                    break;
                                                case "4": Leltar.Add(p.Miaz); break;
                                                case "5":
                                                    switch (p.Miaz)
                                                    {
                                                        case "ajt�":
                                                            if (Allohely.Last() == "nappali")
                                                            {
                                                                Console.WriteLine("Nyugatra " + szovegseged[0]);
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Keletre  " + szovegseged[0]);
                                                            }
                                                            break;
                                                        case "szekr�ny":
                                                            if (targyak.Find(x => x.Nev == "doboz").Tulajdonsagok["lathatoe"])
                                                            {
                                                                Console.WriteLine(szovegseged[0] + " Egy dobozt l�tsz benne, vedd fel.");
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
                        Console.WriteLine($"Nem j� a parancs, amit megadt�l! Nem lehet ebben a szob�ban ({Allohely.Last()}) vagy ebben a helyzetben haszn�lni. Ellen�rizd, amit be�rt�l!\n");
                    }
                }
                          
            }

            Console.ReadKey();

        }
    }
}
