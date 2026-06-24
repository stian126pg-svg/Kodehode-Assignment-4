using Kodehode_Assignment_4.Controllers;
using Kodehode_Assignment_4.Services;

var reader = new CsvReader();

Console.WriteLine(Environment.CurrentDirectory);

var digimons = reader.ReadDigimon(
    @"Data\Digimonlist.csv");

Console.WriteLine($"Loaded {digimons.Count} Digimon");

var controller = new DigimonController(digimons);

var rookies = controller.GetRookies();

foreach (var rookie in rookies)
{
    Console.WriteLine(rookie.Name);
}