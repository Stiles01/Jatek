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


        static string Mentes(List<string> leltar, Targy szekreny, Targy doboz, Targy kulcs, Targy ajto, Targy ablak, Targy furdokad, Targy feszitovas, string allohely)
        {
            string leltarok = String.Join(";", leltar);
            return String.Join("\n", leltarok, szekreny.Menteshez(), doboz.Menteshez(), kulcs.Menteshez(), ajto.Menteshez(), ablak.Menteshez(), furdokad.Menteshez(), feszitovas.Menteshez(), allohely);
        }
        

        static string Nemhelyes(string parancs)
        {           
            return $"Nem j�l adtad meg a ({parancs}) parancsot. Nyomd le a ? billenty�t seg�ts�g�rt!\n";
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

            List<string> Leltar = new List<string>();
            List<string> Allohely = new List<string>();
            Targy Szekreny = new Targy();
            Targy Doboz = new Targy();
            Targy Kulcs = new Targy();
            Targy Ajto = new Targy();
            Targy Ablak = new Targy();
            Targy Furdokad = new Targy();
            Targy Feszitovas = new Targy();
            

            
            Console.WriteLine("�j j�t�kot kezdesz vagy bet�lt�d a m�r meglev� ment�sed?\n�j/ment�s");          
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
                    Furdokad.Ertek("f�rd�", false, false);
                    Feszitovas.Ertek("f�rd�", false, true);
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
                            case "n�zd":
                                    if (Allohely.Last()=="nappali")
                                    {                                    
                                        if (Ablak.LathatoE == false)
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
                                            if (!Furdokad.Elvegzette)
                                            {
                                                if (!Leltar.Exists(x => x == "fesz�t�vas"))
                                                {
                                                    Console.WriteLine("A f�rd�ben vagy. L�tsz egy f�rd�k�dat, benne egy fesz�t�vasat �s egy ajt�t keletre.\n");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("A f�rd�ben vagy. L�tsz egy f�rd�k�dat �s egy ajt�t keletre.\n");
                                                }
                                            }
                                            else
                                            {
                                                if (!Leltar.Exists(x => x == "fesz�t�vas"))
                                                {
                                                    Console.WriteLine("A f�rd�ben vagy. L�tsz egy f�rd�k�dat, benne egy fesz�t�vasat �s egy ajt�t keletre.\n");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("A f�rd�ben vagy. L�tsz egy f�rd�k�dat �s egy ajt�t keletre.\n");
                                                }
                                            }
                                        }    
                                    }
                                break;

                            case "kelet":
                                    if (Allohely.Last()=="f�rd�")
                                    {
                                        Allohely.Add("nappali");
                                        if (Ablak.LathatoE == false)
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
                                        if (Ajto.Elvegzette == true)
                                        {   
                                            Allohely.Add("f�rd�");
                                            if (Feszitovas.LathatoE == false)
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
                                        if (Ablak.LathatoE)
                                        {
                                            if (Ablak.Elvegzette == false)
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
                                
                            case "?":
                                    Console.WriteLine(Help());
                                break;

                            case "lelt�r":
                                    Console.WriteLine($"Lelt�r: {String.Join("; ", Leltar)}\n");
                                break;

                            case "ment�s":
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
                            case "n�zd":                                                                       
                                    switch (p.Miaz)
                                    {
                                        case "fesz�t�vas":
                                            if (!Ablak.Elvegzette)
                                            {
                                                Console.WriteLine("Haszn�ld fel a fesz�t�vasat valamire.\n");
                                            }
                                            else
                                            {
                                                Console.WriteLine("A fesz�t�vast m�r nem tudod mire haszn�lni.\n");
                                            }
                                        break;

                                        case "doboz":
                                            if (Doboz.Elvegzette)
                                            {
                                                Console.WriteLine("Nem tudsz m�r mit csin�lni a dobozzal.\n");
                                            }
                                            else
                                            {
                                                Console.WriteLine("A doboz z�rva van.\n");
                                            }
                                        break;

                                        case "kulcs":
                                            if (Ajto.Elvegzette)
                                            {
                                                Console.WriteLine("Nem tudsz m�r mit csin�lni a kulccsal.\n");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Haszn�ld fel a kulcsot valamire.\n");
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
                                                                        Console.WriteLine("Az ablak z�rva van.\n");
                                                                    }
                                                                    else
                                                                    {
                                                                        Console.WriteLine("Az ablak nyitva van.\n");
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine("Nem l�tsz ablakot.\n");
                                                                }
                                                            break;

                                                        case "ajt�":
                                                                if (!Ajto.Elvegzette)
                                                                {
                                                                    Console.WriteLine("Az ajt� z�rva van.\n");
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine("Az ajt� nyitva van.\n");
                                                                }
                                                            break;

                                                        case "szekr�ny":
                                                                if (!Szekreny.Elvegzette)
                                                                {
                                                                    Console.WriteLine("A szekr�ny ajtaja r�snyire nyitva van. Pr�b�lj meg egy m�sik parancsot.\n");
                                                                }
                                                                else
                                                                {
                                                                    if (Doboz.LathatoE)
                                                                    {
                                                                        Console.WriteLine("A szekr�ny nyitva van �s l�tsz benne egy dobozt.\n");
                                                                    }
                                                                    else
                                                                    {
                                                                        Console.WriteLine("A szekr�ny nyitva van �s a dobozt m�r felvetted.\n");
                                                                    }
                                                                }
                                                            break;

                                                        default:
                                                            break;
                                                    }
                                                }
                                                else
                                                {
                                                    if (p.Miaz == "f�rd�k�d")
                                                    {
                                                        if (!Feszitovas.LathatoE)
                                                        {
                                                            Console.WriteLine("A f�rd�k�dban egy fesz�t�vasat l�tsz.\n");
                                                            Feszitovas.LathatoE = true;
                                                            Furdokad.Elvegzette = true;
                                                        }
                                                        else
                                                        {
                                                            if (Feszitovas.Elvegzette)
                                                            {
                                                                Console.WriteLine("A f�rd�k�d �res.\n");
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("A f�rd�k�dban egy fesz�t�vas tal�lhat�.\n");
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (p.Miaz == "ajt�")
                                                        {
                                                            Console.WriteLine("Keletre egy nyitott ajt�t l�tsz.\n");
                                                        }
                                                    }
                                                }
                                            break;
                                    }                                   
                                break;

                            case "h�zd":
                                    if (Allohely.Last()=="nappali")
                                    {
                                        if (p.Miaz=="szekr�ny")
                                        {
                                            if (!Ablak.LathatoE)
                                            {
                                                Console.WriteLine("Elh�ztad a szekr�nyt, most l�tsz valamit m�g�tte. �rd be a 'n�zd' parancsot, hogy megtudd mi az.\n");
                                                Ablak.LathatoE = true;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Elh�ztad m�r a szekr�nyt!\n");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine($"Nem tudod elh�zni a/az {p.Miaz}-t, pr�b�lj meg valami m�st.\n");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Nem tudod elh�zni a/az {p.Miaz}-t, pr�b�lj meg valami m�st.\n");
                                    }
                                break;

                            case "nyisd":                                    
                                    if (p.Miaz == "doboz")
                                    {
                                        if (Leltar.Exists(x => x == "doboz"))
                                        {
                                            Kulcs.LathatoE = true;
                                            Console.WriteLine("A dobozt kinyitottad, egy kulcsot l�tsz.\n");
                                        }
                                        else
                                        {
                                            Console.WriteLine("M�g nem vetted fel a dobozt.\n");
                                        }
                                    }
                                    else
                                    {
                                        if (Allohely.Last() == "nappali")
                                        {
                                            if (p.Miaz == "szekr�ny")
                                            {
                                                if (!Szekreny.Elvegzette)
                                                {
                                                    Szekreny.Elvegzette = true;
                                                    Doboz.LathatoE = true;
                                                    Console.WriteLine("Kinyitottad a szekr�nyt, l�tsz benne egy dobozt.\n");
                                                }
                                                else
                                                {
                                                    if (!Doboz.Elvegzette)
                                                    {
                                                        Console.WriteLine("A szekr�nyt m�r kinyitottad, l�tsz benne egy dobozt.\n");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("A szekr�nyt m�r kinyitottad �s a dobozt m�r felvetted.\n");
                                                    }

                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine($"A {p.Miaz} t�rgy nem nyithat�. Pr�b�lj meg m�st.\n");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine($"A {p.Miaz} t�rgy nem nyithat�. Pr�b�lj meg m�st.\n");
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
                                                    Console.WriteLine("Nem l�tsz kulcsot.\n");
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
                                                        Console.WriteLine("Nem l�tsz dobozt.\n");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Nem l�tsz dobozt.\n");
                                                }
                                            break;
                                        case "fesz�t�vas":
                                                if (Allohely.Last() == "f�rd�")
                                                {
                                                    if (Feszitovas.LathatoE)
                                                    {
                                                        Feszitovas.Elvegzette = true;
                                                        Leltar.Add(p.Miaz);
                                                        Console.WriteLine("Felvetted a fesz�t�vasat.\n");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Nem l�tsz fesz�t�vasat.\n");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Nem l�tsz fesz�t�vasat.\n");
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
                                        Console.Write("Ha leteszel egy t�rgyat ut�na m�r nem tudod �jra felvenni, biztos leteszed?\nigen/nem\n");
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
                                                Console.WriteLine($"Hib�san �rtad be, nem tett�l le semmit.\n");
                                            }
                                        }                                       
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Nem tal�lhat� a lelt�radban {p.Miaz}.\n");
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
                                        if (p.Miaz == "ajt�")
                                        {
                                            if (!Ajto.Elvegzette)
                                            {
                                                if (Kulcs.Elvegzette)
                                                {
                                                    Ajto.Elvegzette = true;
                                                    Console.WriteLine("Az ajt�t kinyitottad.\n");
                                                }
                                                else
                                                {
                                                    Console.WriteLine($"Nem tudod {p.Mithasznal}-val/vel kinyitni az ajt�t. Keress m�st hozz�!\n");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Az ajt� m�r nyitva van.\n");
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
                            case "t�rd":
                                    if (Allohely.Last() == "nappali")
                                    {
                                        if (p.Miaz == "ablak")
                                        {
                                            if (Ablak.LathatoE)
                                            {
                                                if (Feszitovas.Elvegzette)
                                                {
                                                    Console.WriteLine("Az ablakot bet�rted.\n");
                                                    Ablak.Elvegzette = true;
                                                }
                                                else
                                                {
                                                    Console.WriteLine($"Nem tudod {p.Mithasznal}-val/vel bet�rni az ablakot.\n");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine($"Nem l�tsz ablakot, amit bet�rhetn�l.\n");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine($"Nem tudod {p.Mithasznal}-val/vel bet�rni a/az {p.Miaz}-t.\n");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Nem tudod {p.Mithasznal}-val/vel bet�rni a/az {p.Miaz}-t.\n");
                                    }
                                break;
                            default:
                                Console.WriteLine($"{Nemhelyes(parancs)}\n");
                                break;
                        }
                         // nyisd, tord
                        break;


                    default:
                        Console.WriteLine("Helytelen parancsot adt�l meg:\nmit csin�lsz / mivel (nem k�telez�) / mit haszn�lsz hozz� (nem k�telez�)\n");                       
                        break;
                }
            }

            Console.ReadKey();
            

        }
    }
}
