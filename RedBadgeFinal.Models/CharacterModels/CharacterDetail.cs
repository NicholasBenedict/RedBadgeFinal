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
        public int Str { get; set; }
        public int Dex { get; set; }
        public int Con { get; set; }
        public int Int { get; set; }
        public int Wis { get; set; }
        public int Cha { get; set; }

        public List<SpellDetails> Spells { get; set; }
        public List<ItemList> Inventory { get; set; }

    }
}
