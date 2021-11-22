using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Models.InventoryModels
{
    public class InventoryDetail
    {
        public int InventoryId { get; set; }
        public int CharacterId { get; set; }
        public string CharacterName { get; set; }

        public int ItemId { get; set; }

        public string ItemName { get; set; }
    }
}
