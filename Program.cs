// Main Program. Also container for Menu/UI!

using Kodehode_Assignment_4.Controllers;
using Kodehode_Assignment_4.Services;

var reader = new CsvReader();

var digimons = reader.ReadDigimon(@"Data\Digimonlist.csv");

var controller = new DigimonController(digimons);

bool running = true;

while (running)
{
    Console.Clear();

    Console.WriteLine("==== DIGIMON DATABASE ====");
    Console.WriteLine("1. Show all Rookies");
    Console.WriteLine("2. Search by Name");
    Console.WriteLine("3. Advanced Search");
    Console.WriteLine("4. Filter by Attribute");
    Console.WriteLine("5. Top 10 Memory");
    Console.WriteLine("6. Show Statistics");
    Console.WriteLine("7. Exit");
    
    Console.Write("\nChoose an option: ");

    string? choice = Console.ReadLine();

    Console.Clear();

    switch (choice)
    {
        case "1":

            var rookies = controller.GetRookies();

            foreach (var digimon in rookies)
            {
                Console.WriteLine($"{digimon.Name} - {digimon.Stage}");
            }

            break;

        case "2":

            Console.Write("Enter name: ");

            string? name = Console.ReadLine();

            var found = controller.FindByName(name ?? "");

            if (found != null)
            {
                Console.WriteLine($"{found.Name}");
                Console.WriteLine($"Stage: {found.Stage}");
                Console.WriteLine($"Attribute: {found.Attribute}");
                Console.WriteLine($"Memory: {found.Memory}");
            }
            else
            {
                Console.WriteLine("No Digimon found.");
            }

            break;

        case "3":

            Console.WriteLine("=== ADVANCED SEARCH ===");

            Console.Write("Stage (leave blank to ignore): ");
            string? stage = Console.ReadLine();

            Console.Write("Attribute (leave blank to ignore): ");
            string? attribute = Console.ReadLine();

            Console.Write("Minimum Memory (leave blank to ignore): ");

            string? memoryInput = Console.ReadLine();

            int? minimumMemory = null;

            if (int.TryParse(memoryInput, out int memory))
            {
                minimumMemory = memory;
            }

            var results = controller.AdvancedSearch(
                stage,
                attribute,
                minimumMemory);

            Console.WriteLine();

            if (!results.Any())
            {
                Console.WriteLine("No Digimon matched your search.");
            }
            else
            {
                foreach (var digimon in results)
                {
                    Console.WriteLine("------------------------------");
                    Console.WriteLine($"Name      : {digimon.Name}");
                    Console.WriteLine($"Stage     : {digimon.Stage}");
                    Console.WriteLine($"Attribute : {digimon.Attribute}");
                    Console.WriteLine($"Memory    : {digimon.Memory}");
                }
            }

            break;



        case "4":

            Console.Write("Enter Attribute (Data, Vaccine, Virus, Free): ");

            string? selectedAttribute = Console.ReadLine();

            var attributeList = controller.GetByAttribute(selectedAttribute ?? "");

            foreach (var digimon in attributeList)
            {
                Console.WriteLine($"{digimon.Name} - {digimon.Attribute}");
            }

            break;

        case "5":

            var topMemory = controller.GetTopMemory(10);

            foreach (var digimon in topMemory)
            {
                Console.WriteLine($"{digimon.Name} - Memory: {digimon.Memory}");
            }

            break;

        case "6":

            controller.ShowStatistics();
            break;

        case "7":

            running = false;
            break;

        default:

            Console.WriteLine("Invalid choice.");
            break;
    }

    if (running)
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}