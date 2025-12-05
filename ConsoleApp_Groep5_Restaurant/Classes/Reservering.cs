using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Groep5_Restaurant.Classes
{
    public class Reservering
    {
        public Gast gast {  get; set; }
        public DateTime DatumTijd {  get; set; }

        public int AantalPersonen { get; set; }

        public List<Bestelling> Bestellingen { get; set; }


        public string Status { get; set; }


        
    }
}
