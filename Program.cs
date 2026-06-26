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
    Console.WriteLine("3. Filter by Attribute");
    Console.WriteLine("4. Top 10 Memory");
    Console.WriteLine("5. Exit");
    
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

            Console.Write("Enter Attribute (Data, Vaccine, Virus, Free): ");

            string? attribute = Console.ReadLine();

            var attributeList = controller.GetByAttribute(attribute ?? "");

            foreach (var digimon in attributeList)
            {
                Console.WriteLine($"{digimon.Name} - {digimon.Attribute}");
            }

            break;

        case "4":

            var topMemory = controller.GetTopMemory(10);

            foreach (var digimon in topMemory)
            {
                Console.WriteLine($"{digimon.Name} - Memory: {digimon.Memory}");
            }

            break;

        case "5":

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