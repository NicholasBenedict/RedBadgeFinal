using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Data
{
    public class ItemTypes
    {
        [Key]
        public int ItemId { get; set; }
        public string ItemName { get; set; }

        public string ItemDescription { get; set; }

        public int ItemWeight { get; set; }

        public int ItemValue { get; set; }

        public TypeOfItem Item { get; set; }
    }

    public enum TypeOfItem
    {
        Weapon = 1, Armor, Consumable
    }

}
