using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Data
{
    public class Inventory
    {
        /*        [Key]
         *        public int InventoryId { get; set; }*/
        [Key, Column(Order = 0)]
        [ForeignKey(nameof(Character))]
        public int CharacterId { get; set; }
        public virtual Character Character { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey(nameof(Items))]
        public int ItemId { get; set; }
        public virtual ItemTypes Items { get; set; }

        //public int Weight { get; set; }

    }
}
