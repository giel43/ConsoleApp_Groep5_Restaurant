using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Groep5_Restaurant.Classes
{
    public class AvondBestelling : Bestelling
    {
        public int Tafelnummer {  get; set; }

        public List<Gerecht> Gerechten {  get; set; }


        public AvondBestelling()
        {

        }
    }
}
