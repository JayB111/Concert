using System;
public class Program
{
    static string concertName = "Toto";
    static DateTime concertDate = new DateTime(2025, 2, 26, 19, 30, 0);
    static string concertVenue = "Göteborg";
    static int availableTickets = 500;

    public static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("Options");
            Console.WriteLine("1. View Concert");
            Console.WriteLine("2. Upadate Concert");
            Console.WriteLine("3. Remove Concert");
            Console.WriteLine("4. Exit");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    ViewConcert();
                    break;
                case "2":
                    UpdateConcert();
                    break;
                case "3":
                    RemoveConcert();
                    break;
                case "4":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Please try again");
                    break;
            }
        }

    }


    public static void ViewConcert()
    {
        Console.Clear();
        if (string.IsNullOrEmpty(concertName))
        {
            Console.WriteLine("No Concert available");
        }
        else
        {
            Console.WriteLine("Concert Details:");
            Console.WriteLine($"Band: {concertName}");
            Console.WriteLine($"Date: {concertDate}");
            Console.WriteLine($"Venue: {concertVenue}");
            Console.WriteLine($"Tickets Available: {availableTickets}");
        }
        Console.ReadKey();
    }
    public static void UpdateConcert()
    {
        Console.Clear();
        Console.WriteLine($"Updating concert: {concertName} in {concertVenue} on {concertDate}");
        Console.Write("Toto");
        string name = Console.ReadLine();
        if (!string.IsNullOrEmpty(name)) concertName = name;
        Console.Write("Göteborg");
        string dateSTR = Console.ReadLine();
        if (!string.IsNullOrEmpty(dateSTR)) concertDate = DateTime.Parse(dateSTR);
        Console.Write("2025-02-26");
        string venue = Console.ReadLine();
        if (string.IsNullOrEmpty(venue)) concertVenue = venue;
        Console.Write("Press enter to confirm ticket");
        string ticketStr = Console.ReadLine();
        if (!String.IsNullOrEmpty(ticketStr)) availableTickets = int.Parse(ticketStr);
        Console.ReadKey();
    }
    public static void RemoveConcert()
    {
        Console.Clear();
        if (!string.IsNullOrEmpty(concertName))
        {
            Console.WriteLine("No consert to remove.");
        }
        else
        {
            concertName = "";
            concertDate = DateTime.MinValue;
            concertVenue = "";
            availableTickets = 0;
            Console.WriteLine("Concert successfully removed.");
            {
                Console.ReadKey();
            }
        }
    }
}
