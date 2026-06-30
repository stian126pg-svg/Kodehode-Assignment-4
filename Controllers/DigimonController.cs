// Controller functions

using System.Linq;
using Kodehode_Assignment_4.Models;

namespace Kodehode_Assignment_4.Controllers;

public class DigimonController
{
    private readonly List<Digimon> _digimons;

    public DigimonController(List<Digimon> digimons)
    {
        _digimons = digimons;
    }

    // Returns every Digimon
    public IEnumerable<Digimon> GetAll()
    {
        return _digimons;
    }

    // Returns every Rookie
    public IEnumerable<Digimon> GetRookies()
    {
        return GetByStage(Stage.Rookie);
    }

    // Returns every Digimon of a given stage
    public IEnumerable<Digimon> GetByStage(Stage stage)
    {
        return _digimons.Where(d => d.Stage == stage);
    }

    // Search by (partial) name
    public IEnumerable<Digimon> SearchByName(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return Enumerable.Empty<Digimon>();

        return _digimons.Where(d =>
            d.Name.Contains(searchTerm,
                StringComparison.OrdinalIgnoreCase));
    }

    // Filter by Attribute
    public IEnumerable<Digimon> GetByAttribute(string attribute)
    {
        if (string.IsNullOrWhiteSpace(attribute))
            return Enumerable.Empty<Digimon>();

        return _digimons.Where(d =>
            d.Attribute.Equals(attribute,
                StringComparison.OrdinalIgnoreCase));
    }

    // Filter by Type
    public IEnumerable<Digimon> GetByType(string type)
    {
        if (string.IsNullOrWhiteSpace(type))
            return Enumerable.Empty<Digimon>();

        return _digimons.Where(d =>
            d.Type.Equals(type,
                StringComparison.OrdinalIgnoreCase));
    }

    // Memory filter
    public IEnumerable<Digimon> GetMemoryAbove(int minimumMemory)
    {
        return _digimons.Where(d => d.Memory >= minimumMemory);
    }

    // Top Memory
    public IEnumerable<Digimon> GetTopMemory(int amount)
    {
        return _digimons
            .OrderByDescending(d => d.Memory)
            .Take(amount);
    }

    // Alphabetical list
    public IEnumerable<Digimon> GetAlphabetical()
    {
        return _digimons.OrderBy(d => d.Name);
    }

    // Number of Digimon
    public int Count()
    {
        return _digimons.Count;
    }

    // Advanced Search
    public IEnumerable<Digimon> AdvancedSearch(
        Stage? stage,
        string? attribute,
        int? minimumMemory)
    {
        IEnumerable<Digimon> query = _digimons;

        if (stage.HasValue)
        {
            query = query.Where(d => d.Stage == stage.Value);
        }

        if (!string.IsNullOrWhiteSpace(attribute))
        {
            query = query.Where(d =>
                d.Attribute.Equals(attribute,
                    StringComparison.OrdinalIgnoreCase));
        }

        if (minimumMemory.HasValue)
        {
            query = query.Where(d =>
                d.Memory >= minimumMemory.Value);
        }

        return query;
    }

    // Build statistics object
    public Statistics GetStatistics()
    {
        return new Statistics
        {
            TotalDigimon = _digimons.Count,

            StageCounts = _digimons
                .GroupBy(d => d.Stage)
                .OrderBy(g => g.Key)
                .ToDictionary(
                    g => g.Key,
                    g => g.Count()),

            AttributeCounts = _digimons
                .GroupBy(d => d.Attribute)
                .OrderBy(g => g.Key)
                .ToDictionary(
                    g => g.Key,
                    g => g.Count()),

            AverageMemory = _digimons.Average(d => d.Memory),

            HighestMemory = _digimons.Max(d => d.Memory),

            LowestMemory = _digimons.Min(d => d.Memory)
        };
    }
}