using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Models.CharacterSpell
{
    public class CharacterSpellDetails
    {
        public int CharacterSpellId { get; set; }
        public int CharacterId { get; set; }

        public int SpellId { get; set; }

        public string CharacterName { get; set; }

        public string SpellName { get; set; }
    }
}
