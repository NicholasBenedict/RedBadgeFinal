using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Data
{
    public class Weapon : ItemTypes
    {
        [Key]
        public int ArmorId { get; set; }
/*
        [ForeignKey(nameof(Data.ItemTypes))]
        public int ItemIds { get; set; }*/

        public int Damage { get; set; }

        public int Range { get; set; }
    }
}
