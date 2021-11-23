using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RedBadgeFinal.Models.CharacterModels
{
    public class CharacterSpellCreate
    {
        public int CharacterId { get; set; }

        public int SpellId { get; set; }

        public List<SelectListItem> Spells { get; set; }
    }
}
