using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jatek
{
    class Program
    {
        public static void Betolt(string sor)
        {
            if (sor == "új")
            {
                Targy Szekreny = new Targy("nappali", "nyisd;nézd;húzd", true);
                Targy Doboz = new Targy("nappali", "nyisd;nézd", false);
                Targy Kulcs = new Targy("nappali", "vedd fel;tedd le;nézd", false);
                Targy Ajto = new Targy("nappali", "nyisd;nézd", true);
                Targy Ablak = new Targy("nappali", "nyisd;nézd;húzd", false);
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
        static void Main(string[] args)
        {
            //Készítette: Nagy Viktória
            //Játék neve: Szabaduló-szoba
             

            Console.WriteLine("Új játékot kezdesz vagy betöltöd a már meglevő mentésed?\núj/mentés");
            Betolt(Console.ReadLine());
            
            

        }
    }
}
