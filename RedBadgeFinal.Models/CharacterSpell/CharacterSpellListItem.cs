using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Models.CharacterSpell
{
    public class CharacterSpellListItem
    {
        public int CharacterSpellId { get; set; }
        public int CharacterId { get; set; }

        public int SpellId { get; set; }
    }
}
