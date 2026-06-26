// Overall set-up tab.

namespace Kodehode_Assignment_4.Models
{
    public class Digimon
    {
        public int Number { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Stage { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Attribute { get; set; } = string.Empty;
        public int Memory { get; set; }
        public int EquipSlots { get; set; }
    }
}