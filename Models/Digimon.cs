// Overall set-up tab.

namespace Kodehode_Assignment_4.Models;

public class Digimon
{
    public int Number { get; init; }

    public string Name { get; init; } = string.Empty;

    public Stage Stage { get; init; }

    public string Type { get; init; } = string.Empty;

    public string Attribute { get; init; } = string.Empty;

    public int Memory { get; init; }

    public int EquipSlots { get; init; }
}