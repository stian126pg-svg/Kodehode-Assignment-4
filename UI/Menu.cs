using Kodehode_Assignment_4.Controllers;
using Kodehode_Assignment_4.Models;

namespace Kodehode_Assignment_4.UI;

public class Menu
{
    private readonly DigimonController _controller;

    public Menu(DigimonController controller)
    {
        _controller = controller;
    }

    public void Run()
    {
        bool running = true;

        while (running)
        {
            ShowMainMenu();

            switch (Console.ReadLine())
            {
                case "1":
                    ShowRookies();
                    break;

                case "2":
                    SearchByName();
                    break;

                case "3":
                    AdvancedSearch();
                    break;

                case "4":
                    FilterByAttribute();
                    break;

                case "5":
                    ShowTopMemory();
                    break;

                case "6":
                    ShowStatistics();
                    break;

                case "7":
                    running = false;
                    break;

                default:
                    Printer.PrintMessage("Invalid choice.");
                    Printer.WaitForKey();
                    break;
            }
        }
    }

    private void ShowMainMenu()
    {
        Printer.PrintHeader("Digimon Database");

        Console.WriteLine("1. Show all Rookies");
        Console.WriteLine("2. Search by Name");
        Console.WriteLine("3. Advanced Search");
        Console.WriteLine("4. Filter by Attribute");
        Console.WriteLine("5. Top 10 Memory");
        Console.WriteLine("6. Show Statistics");
        Console.WriteLine("7. Exit");

        Console.WriteLine();

        Console.Write("Choose an option: ");
    }

    private void ShowRookies()
    {
        Printer.PrintHeader("Rookies");

        var rookies = _controller.GetRookies();

        Printer.PrintDigimonList(rookies);

        Printer.WaitForKey();
    }

    private void SearchByName()
    {
        Printer.PrintHeader("Search By Name");

        Console.Write("Enter name: ");

        string search = Console.ReadLine() ?? "";

        var results = _controller.SearchByName(search);

        Printer.PrintDigimonList(results);

        Printer.WaitForKey();
    }

    private void FilterByAttribute()
    {
        Printer.PrintHeader("Filter By Attribute");

        Console.Write("Enter Attribute: ");

        string attribute = Console.ReadLine() ?? "";

        var results = _controller.GetByAttribute(attribute);

        Printer.PrintDigimonList(results);

        Printer.WaitForKey();
    }

    private void ShowTopMemory()
    {
        Printer.PrintHeader("Top 10 Memory");

        var results = _controller.GetTopMemory(10);

        Printer.PrintDigimonList(results);

        Printer.WaitForKey();
    }

    private void ShowStatistics()
    {
        Printer.PrintHeader("Statistics");

        var statistics = _controller.GetStatistics();

        Printer.PrintStatistics(statistics);

        Printer.WaitForKey();
    }

    private void AdvancedSearch()
    {
        Printer.PrintHeader("Advanced Search");

        Console.Write("Stage (leave blank to ignore): ");

        string? stageInput = Console.ReadLine();

        Stage? stage = ParseStage(stageInput);

        Console.Write("Attribute (leave blank to ignore): ");

        string? attribute = Console.ReadLine();

        Console.Write("Minimum Memory (leave blank to ignore): ");

        string? memoryInput = Console.ReadLine();

        int? minimumMemory = null;

        if (int.TryParse(memoryInput, out int memory))
        {
            minimumMemory = memory;
        }

        var results = _controller.AdvancedSearch(
            stage,
            attribute,
            minimumMemory);

        Printer.PrintDigimonList(results);

        Printer.WaitForKey();
    }

    private Stage? ParseStage(string? input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return null;

        return input.Trim().ToLower() switch
        {
            "baby" => Stage.Baby,
            "in-training" => Stage.InTraining,
            "intraining" => Stage.InTraining,
            "rookie" => Stage.Rookie,
            "champion" => Stage.Champion,
            "ultimate" => Stage.Ultimate,
            "mega" => Stage.Mega,
            "ultra" => Stage.Ultra,
            "armor" => Stage.Armor,
            _ => null
        };
    }
}