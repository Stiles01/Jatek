using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jatek
{
    class Program
    {
        static void Betolt(string sor)
        {
            if (sor == "új")
            {
                Targy Szekreny = new Targy("nappali", "nyisd;nézd;húzd", true);
                Targy Doboz = new Targy("nappali", "nyisd;nézd", false);
                Targy Kulcs = new Targy("nappali", "vedd fel;tedd le;nézd", false);
                Targy Ajto = new Targy("nappali", "nyisd;nézd", true);
                Targy Ablak = new Targy("nappali", "nézd;törd", false);
                Targy Furdokad = new Targy("furdo", "nézd", false);
                Targy Feszitovas = new Targy("furdo", "nézd;vedd fel;tedd le", false);
                
            }
            else
            {
                if (sor == "mentés")
                {

                }
                else
                {
                    Console.WriteLine("új vagy mentés?");
                    Betolt(Console.ReadLine());
                }
            }
        }

        static string Mentes()
        {
            string a;
            return a = "";
        }

        
        static void Main(string[] args)
        {
            //Készítette: Nagy Viktória
            //Játék neve: Szabaduló-szoba

            bool Keszvane = false;

            Console.WriteLine("Új játékot kezdesz vagy betöltöd a már meglevő mentésed?\núj/mentés");          
            Betolt(Console.ReadLine());
            Console.WriteLine("Ha bármikor elakadnál nyomd meg a \"?\" billentyűt!");
            while (!Keszvane)
            {
                string parancs = Console.ReadLine().Trim();
                string[] tobbparancs = parancs.Split(' ');
            }

            Console.ReadKey();
            

        }
    }
}
