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
            return _digimons.Where(d => d.Attribute == attribute);
        }

        public IEnumerable<Digimon> GetMemoryAbove(int value)
        {
            return _digimons.Where(d => d.Memory > value);
        }
    }
}