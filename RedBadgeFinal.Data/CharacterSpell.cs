using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Data
{
    public class CharacterSpell
    {
        [Key, Column(Order = 0)]
        [ForeignKey(nameof(Character))]
        public int CharacterId { get; set; }
        public virtual Character Character { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey(nameof(Spell))]
        public int SpellId { get; set; }
        public virtual Spell Spell { get; set; }
    }
}
