using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Groep5_Restaurant.Classes
{
    public class Gast
    {
        public string Naam { get; set; }

        public string TelefoonNummer {get; set; }

        public Gast(string naam, string telefoonNummer)
        {
            Naam = naam;
            TelefoonNummer = telefoonNummer;
        }
    }
}
