using RedBadgeFinal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Models
{
    public class CharacterListItem
    {
        public string CharacterName { get; set; }

        public RaceType ChracterRace { get; set; }

        public ClassType CharacterClass { get; set; }

        public int Level { get; set; }
    }
}
