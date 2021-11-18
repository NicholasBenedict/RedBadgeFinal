using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Data
{
    public class Spell
    {
        [Key]
        public int SpellId { get; set; }

        public string SpellName { get; set; }

        public string SpellDescription { get; set; }
    }
}
