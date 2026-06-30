using Kodehode_Assignment_4.Models;


namespace Kodehode_Assignment_4.UI;
public static class Printer
{
    public static void PrintDigimon(Digimon digimon)
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine($"#{digimon.Number}");
        Console.WriteLine($"Name       : {digimon.Name}");
        Console.WriteLine($"Stage      : {digimon.Stage}");
        Console.WriteLine($"Type       : {digimon.Type}");
        Console.WriteLine($"Attribute  : {digimon.Attribute}");
        Console.WriteLine($"Memory     : {digimon.Memory}");
        Console.WriteLine($"Equip Slots: {digimon.EquipSlots}");
    }

    public static void PrintDigimonList(IEnumerable<Digimon> digimons)
    {
        if (!digimons.Any())
        {
            Console.WriteLine("No Digimon found.");
            return;
        }

        foreach (var digimon in digimons)
        {
            PrintDigimon(digimon);
        }
    }

    public static void PrintStatistics(Statistics statistics)
    {
        Console.WriteLine("========== DATABASE STATISTICS ==========\n");

        Console.WriteLine($"Total Digimon : {statistics.TotalDigimon}");
        Console.WriteLine($"Average Memory: {statistics.AverageMemory:F2}");
        Console.WriteLine($"Highest Memory: {statistics.HighestMemory}");
        Console.WriteLine($"Lowest Memory : {statistics.LowestMemory}");

        Console.WriteLine();

        Console.WriteLine("----- By Stage -----");

        foreach (var stage in statistics.StageCounts)
        {
            Console.WriteLine($"{stage.Key,-12} {stage.Value}");
        }

        Console.WriteLine();

        Console.WriteLine("----- By Attribute -----");

        foreach (var attribute in statistics.AttributeCounts)
        {
            Console.WriteLine($"{attribute.Key,-12} {attribute.Value}");
        }
    }

    public static void PrintHeader(string title)
    {
        Console.Clear();

        Console.WriteLine($"==== {title.ToUpper()} ====");
        Console.WriteLine();
    }

    public static void PrintMessage(string message)
    {
        Console.WriteLine(message);
    }

    public static void WaitForKey()
    {
        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
    }
}