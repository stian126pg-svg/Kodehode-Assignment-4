using DigimonDatabase.Controllers;
using DigimonDatabase.Services;

var reader = new CsvReader();

var digimons = reader.ReadDigimon(
    @"Data\DigiDB_digimonlist.csv");

var controller = new DigimonController(digimons);

var rookies = controller.GetRookies();

foreach (var rookie in rookies)
{
    Console.WriteLine(rookie.Name);
}