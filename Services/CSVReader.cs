// CSV Reader Service

// This one has -one- responsibility, and it's to read the CSV file and return a list of Digimon objects.
using System.Linq;
using Kodehode_Assignment_4.Models;

namespace Kodehode_Assignment_4.Services
{
    public class CsvReader
    {
        public List<Digimon> ReadDigimon(string path)
        {
            var digimons = new List<Digimon>();

            Console.WriteLine(Path.GetFullPath(path));

            var lines = File.ReadAllLines(path);

            foreach (var line in lines.Skip(1))
            {
                var columns = line.Split(',');

                var digimon = new Digimon
                {
                    Number = int.Parse(columns[0]),
                    Name = columns[1],
                    Stage = columns[2],
                    Type = columns[3],
                    Attribute = columns[4],
                    Memory = int.Parse(columns[5]),
                    EquipSlots = int.Parse(columns[6])
                };

                digimons.Add(digimon);
            }

            return digimons;
        }
    }
}