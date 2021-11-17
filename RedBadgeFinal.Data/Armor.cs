using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Data
{
    public class Armor : ItemType
    {
        [Key]
        public int ArmorId { get; set; }

        [ForeignKey(nameof(ItemType))]
        public int ItemIds { get; set; }

        public TypeOfArmor ArmorType { get; set; }
        public int ArmorClass { get; set; }
    }

    public enum TypeOfArmor
    {
        Light=1, Medium, Heavy
    }
}
