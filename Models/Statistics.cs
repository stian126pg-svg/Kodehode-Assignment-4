namespace Kodehode_Assignment_4.Models;

public class Statistics
{
    public int TotalDigimon { get; init; }

    public Dictionary<Stage, int> StageCounts { get; init; } = new();

    public Dictionary<string, int> AttributeCounts { get; init; } = new();

    public double AverageMemory { get; init; }

    public int HighestMemory { get; init; }

    public int LowestMemory { get; init; }
}