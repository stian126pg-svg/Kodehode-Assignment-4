// Main Program. Also container for Menu/UI!

using Kodehode_Assignment_4.Controllers;
using Kodehode_Assignment_4.Services;
using Kodehode_Assignment_4.UI;

var reader = new CsvReader();

var digimons = reader.ReadDigimon(@"Data\Digimonlist.csv");

var controller = new DigimonController(digimons);

var menu = new Menu(controller);

menu.Run();