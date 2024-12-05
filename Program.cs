

class TicketSystemApp
{
    static List<Concert> concerts = new List<Concert>();
    static string filePath = "concerts.txt";
    static void Main(string[] args)
    {
        LoadConcerts();
        InitializeConcerts();
        bool running = true;
        while (running)
        {
            DisplayMenu();
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddConcert();
                    break;
                    case "2":
                    ListConcerts();
                    break;
                    case "3":
                    EditConcert();
                    break;
                    case "4":
                    DeleteConcert();
                    break;
                    case "5":
                        running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option! Please try again.");
                    break;
            }
        }
        SaveConcerts();

    }

    static void DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine("=== Concert Ticket System ===");
        Console.WriteLine("1. Add new concert");
        Console.WriteLine("2. List all concerts");
        Console.WriteLine("3. Edit a concert");
        Console.WriteLine("4. Delete a concert");
        Console.WriteLine("5. Exit");
        Console.Write("Please choose an option: ");
    }

    static void AddConcert()
    {
        Console.Clear();
        Console.Write("Enter concert name: ");
        string name = Console.ReadLine();
        Console.Write("Enter concert venue ");
        string venue = Console.ReadLine();
        Console.Write("Enter concert date (MM/dd/yyyy HH:mm): ");
        DateTime date;

        while (!DateTime.TryParse(Console.ReadLine(), out date))
        {
            Console.Write("Invalid date. Please enter the date in MM/dd/yyyy HH:mm format: ");
        }
        concerts.Add(new Concert(name, venue, date));
        Console.WriteLine("Concert added successfully!");
        Console.ReadLine();
    }
    static void ListConcerts()
    {
        Console.Clear();
        if (concerts.Count == 0)
        {
            Console.WriteLine("No concerts available.");
        }
        else
        {
            foreach (var concert in concerts)
            {
                concert.Display();
            }
        }
        Console.ReadLine();
    }
    static void EditConcert()      
    {
        Console.Clear();
        Console.Write("Enter the concert name to edit: ");
        string name = Console.ReadLine();

        var concert = concerts.Find(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (concert != null)
        {
            Console.WriteLine($"Editing concert: {concert.Name}");
            Console.Write("Enter new venue (leave blank to keep current): ");
            string venue = Console.ReadLine();
            if (!string.IsNullOrEmpty(venue)) concert.Venue = venue;

            Console.Write("Enter new date (leave blank to keep current): ");
            string dateInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(dateInput) && DateTime.TryParse(dateInput, out DateTime newDate))
            {
                concert.Date = newDate;
            }
            Console.WriteLine("Concert updated successfully!");
        }
        else
        {
            Console.WriteLine("Concert not found.");
        }
            Console.ReadLine();
        }
        static void DeleteConcert()
        {
            Console.Clear();
            Console.Write("Enter the concert name to delete; ");
            string name = Console.ReadLine();

            var concert = concerts.Find(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (concert != null)
            {
                concerts.Remove(concert);
                Console.WriteLine("Concerts deleted successfully!");
            }
            else
            {
                Console.WriteLine("Concert not found");
            }
            Console.ReadLine();
        }
        static void SaveConcerts()
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var concert in concerts)
                {
                    writer.WriteLine($"{concert.Name},{concert.Venue},{concert.Date.ToString("MM/dd/yyyy HH:mm")}");
                }
            }
         }
            static void LoadConcerts()
            {
                if (File.Exists(filePath))
                {
                    foreach (var line in File.ReadAllLines(filePath))
                    {
                        var parts = line.Split(',');
                        if (parts.Length == 3 && DateTime.TryParse(parts[2], out DateTime date))
                        {
                            concerts.Add(new Concert(parts[0], parts[1], date));
                        }
                    }
                }
            }
            static void InitializeConcerts()
            {
                concerts.Add(new Concert("Toto", "Göteborg", new DateTime(2025, 2, 26, 19, 30, 0)));
                concerts.Add(new Concert("Roxette", "Göteborg", new DateTime(2025, 7, 23, 19, 30, 0)));                
                concerts.Add(new Concert("Hans Zimmer", "Göteborg", new DateTime(2025, 3, 6, 19, 30, 0)));

                Console.WriteLine("My favorite concerts added!");
                Console.ReadLine();
            }
}