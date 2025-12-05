using ConsoleApp_Groep5_Restaurant.Classes;

namespace ConsoleApp_Groep5_Restaurant
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MENU");
            Console.WriteLine("1. Reserveren Diner");
            Console.WriteLine("2. LunchPakket Bestellen");
            Console.WriteLine("3. OnbijtBuffet");


            string menuKeuze = Console.ReadLine();


            switch(menuKeuze)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Wat is de naam voor de reservering:");
                    string naam_gast = Console.ReadLine();
                    Console.WriteLine("Wat het telfoonnummer voor de reservering:");
                    string telefoon_nummer = Console.ReadLine();

                    Gast gast = new Gast(naam_gast,telefoon_nummer);

                    





                    break;
            }
        }
    }
}
