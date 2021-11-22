using RedBadgeFinal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Models.ItemModels
{
    public class ItemCreate
    {
        public string ItemName { get; set; }

        public string ItemDescription { get; set; }

        public int ItemWeight { get; set; }

        public int ItemValue { get; set; }

        public TypeOfItem Item { get; set; }
    }
}
