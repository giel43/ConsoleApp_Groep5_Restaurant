using ConsoleApp_Groep5_Restaurant.Classes;
using ConsoleApp_Groep5_Restaurant.DattaAcces;
using Microsoft.Identity.Client;
namespace ConsoleApp_Groep5_Restaurant
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DAL _dal = new DAL();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("MENU");
                Console.WriteLine("1. Gast");
                Console.WriteLine("2. Medewerker");
                string persoonKeuze = Console.ReadLine();

                if (persoonKeuze == "1")
                {
                    bool running = true;
                    while (running)
                    {
                        Console.Clear();
                        Console.WriteLine("1. Reserveren Diner");
                        Console.WriteLine("2. LunchPakket Bestellen");
                        Console.WriteLine("3. OnbijtBuffet");
                        Console.WriteLine("4. Terug Naar Begin Menu");


                        string menuKeuze_gast = Console.ReadLine();


                        switch (menuKeuze_gast)
                        {
                            case "1":
                                Console.Clear();
                                Console.WriteLine("Wat is de naam voor de reservering:");
                                string naam_gast = Console.ReadLine();
                                Console.WriteLine("Wat het telfoonnummer voor de reservering:");
                                string telefoon_nummer = Console.ReadLine();

                                Gast gast = new Gast(naam_gast, telefoon_nummer);

                                Console.WriteLine("Voor hoeveel personen is de reservering:");
                                int HvlPersonen = int.Parse(Console.ReadLine());

                                Reservering reservering = new Reservering();
                                reservering.AantalPersonen = HvlPersonen;
                                reservering.DatumTijd = DateTime.Now;
                                reservering.gast = gast;
                                _dal.VoegGastToeAanDB(gast);
                                _dal.VoegReserveringToeAanDB(reservering);



                                break;
                            case "2":
                                break;
                            case "3":
                                break;
                            case "4":
                                running = false;
                                break;

                        }
                    }
                    
                }
                if (persoonKeuze == "2")
                {
                    Console.Clear();
                    Console.WriteLine("1. Reserveringen bekijken");
                    string werkNemerKeuse = Console.ReadLine();
                }
            }
        }
    }
}
