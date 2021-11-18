using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Data
{
    public class Character
    {
        [Key]
        public int CharacterId { get; set; }
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

        public virtual ICollection<CharacterSpell> Spells { get; set; } = new List<CharacterSpell>();

        public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();


    }

    public enum RaceType
    {
        Dragonborn=1, Dwarf, Elf, Gnome, HalfElf, Halfling, HalfOrc, Human, Tiefling 
    }

    public enum ClassType
    {
        Barbarian=1, Bard, Cleric, Druid, Fighter, Monk, Paladin, Ranger, Rogue, Sorcerer, Warlock, Wizard
    }

    public enum BackgroundType
    {
        Acolyte=1, Charlatan, Criminal, Entertainer, Folk_Hero, Guild_Artisan, Hermit, Noble, Outlander, Sage, Sailor, Soldier, Urchin
    }
}
