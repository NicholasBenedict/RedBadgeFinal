using RedBadgeFinal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Models.ItemModels
{
    public class ItemList
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }

        public string ItemDescription { get; set; }

        public TypeOfItem Item { get; set; }
    }
}
