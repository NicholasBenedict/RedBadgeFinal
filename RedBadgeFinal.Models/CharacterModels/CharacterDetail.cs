using RedBadgeFinal.Data;
using RedBadgeFinal.Models.ItemModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Models
{
    public class CharacterDetail
    {
        public int CharaterId { get; set; }
        public string CharacterName { get; set; }
        public RaceType CharacterRace { get; set; }
        public ClassType CharacterClass { get; set; }
        public int Level { get; set; }
        public int HitPoints { get; set; }
        public BackgroundType CharacterBackground { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }

        public List<SpellList> Spells { get; set; }
        public List<ItemList> Inventory { get; set; }
    }
}
