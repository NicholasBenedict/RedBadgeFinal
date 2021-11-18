using RedBadgeFinal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Models
{
    public class CharacterCreate
    {
        public string ChracterName { get; set; }
        public RaceType CharacterRace { get; set; }
        public ClassType CharacterClass { get; set; }
        public int Level { get; set; }
        public int HitPoints { get; set; }
        public BackgroundType ChracterBackground { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
    }
}
