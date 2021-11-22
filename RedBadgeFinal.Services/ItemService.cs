using RedBadgeFinal.Data;
using RedBadgeFinal.Models.ItemModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Services
{
    public class ItemService
    {
        public bool CreateItem(ItemCreate model)
        {
            var entity = new ItemTypes()
            {
                ItemName = model.ItemName,
                ItemDescription = model.ItemDescription,
                ItemWeight = model.ItemWeight,
                ItemValue = model.ItemValue,
                Item = model.Item
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Items.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ItemList> GetItems()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Items
                    .Select
                    (e => new ItemList
                    {
                        ItemId = e.ItemId,
                        ItemName = e.ItemName,
                        ItemDescription = e.ItemDescription,
                        Item = e.Item
                    });

                return query.ToArray();
            }
        }
        public ItemDetails GetItemById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Items
                    .Single(e => e.ItemId == id);
                return
                    new ItemDetails
                    {
                        ItemId = entity.ItemId,
                        ItemName = entity.ItemName,
                        ItemDescription = entity.ItemDescription,
                        ItemWeight = entity.ItemWeight,
                        ItemValue = entity.ItemValue,
                        Item = entity.Item
                    };
            }
        }

        public bool UpdateItem(ItemEdit Model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Items.Single(e => e.ItemId == Model.ItemId);
                entity.ItemName = Model.ItemName;
                entity.ItemDescription = Model.ItemDescription;
                entity.ItemValue = Model.ItemValue;
                entity.ItemWeight = Model.ItemWeight;
                entity.Item = Model.Item;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteItem(int itemId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Items.Single(e => e.ItemId == itemId);

                ctx.Items.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
