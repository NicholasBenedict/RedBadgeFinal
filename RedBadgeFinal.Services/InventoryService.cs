using RedBadgeFinal.Data;
using RedBadgeFinal.Models.InventoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Services
{
    public class InventoryService
    {
        public bool CreateCharacterInventory(InventoryCreate model)
        {
            var entity = new Inventory()
            {
                CharacterId = model.CharacterId,
                ItemId = model.ItemId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Inventory.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<InventoryListItem> GetCharacterInventory()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Inventory
                    .Select
                    (e => new InventoryListItem
                    {
                        InventoryId = e.InventoryId,
                        CharacterId = e.CharacterId,
                        CharacterName = e.Character.CharacterName,
                        ItemId = e.ItemId,
                        ItemName = e.Items.ItemName
                    });

                return query.ToArray();
            }
        }

        public InventoryDetail GetCharacterInventoryById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Inventory
                    .Single(e => e.InventoryId == id);
                return
                    new InventoryDetail
                    {
                        InventoryId = entity.InventoryId,
                        CharacterId = entity.CharacterId,
                        CharacterName = entity.Character.CharacterName,
                        ItemId = entity.ItemId,
                        ItemName = entity.Items.ItemName
                    };
            }
        }
        public bool DeleteItemFromInventory(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Inventory.Single(e => e.InventoryId == id);

                ctx.Inventory.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
