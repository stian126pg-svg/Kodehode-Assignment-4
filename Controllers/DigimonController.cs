// Controller functions

using System.Linq;
using Kodehode_Assignment_4.Models;

namespace Kodehode_Assignment_4.Controllers
{
    public class DigimonController
    {
        private readonly List<Digimon> _digimons;

        public DigimonController(List<Digimon> digimons)
        {
            _digimons = digimons;
        }

        public void ShowStatistics()
        {
            Console.WriteLine($"Total Digimon: {_digimons.Count}");

            Console.WriteLine("\nBy Stage:");

            var stages = _digimons
                .GroupBy(d => d.Stage)
                .OrderBy(g => g.Key);

            foreach (var stage in stages)
            {
                Console.WriteLine($"{stage.Key}: {stage.Count()}");
            }
        }

        public IEnumerable<Digimon> GetRookies()
        {
            return _digimons.Where(d => d.Stage == "Rookie");
        }

        public IEnumerable<string> GetNames()
        {
            return _digimons.Select(d => d.Name);
        }

        public IEnumerable<Digimon> GetByAttribute(string attribute)
        {
            return _digimons.Where(d =>
                d.Attribute.Equals(attribute, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Digimon> GetMemoryAbove(int value)
        {
            return _digimons.Where(d => d.Memory > value);
        }

        public Digimon? FindByName(string name)
        {
            return _digimons.FirstOrDefault(d =>
                d.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Digimon> GetTopMemory(int amount)
        {
            return _digimons
                .OrderByDescending(d => d.Memory)
                .Take(amount);
        }
    }
}