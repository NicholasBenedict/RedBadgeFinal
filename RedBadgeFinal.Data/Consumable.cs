using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Data
{
    public class Consumable : ItemType
    {
        [Key]
        public int ConsumableId { get; set; }

        [ForeignKey(nameof(ItemType))]
        public int ItemIds { get; set; }


        public int Uses { get; set; }
    }
}
