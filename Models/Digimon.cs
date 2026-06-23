// Overall set-up tab. I am still looking into making this potentially be a bit less... "String-y"

namespace DigimonDatabase.Models
{
    public class Digimon
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string Stage { get; set; }
        public string Type { get; set; }
        public string Attribute { get; set; }
        public int Memory { get; set; }
        public int EquipSlots { get; set; }
    }
}