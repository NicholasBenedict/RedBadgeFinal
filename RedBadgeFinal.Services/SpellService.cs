using RedBadgeFinal.Data;
using RedBadgeFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Services
{
    public class SpellService
    {
        public bool CreateSpell(SpellCreate model)
        {
            var entity = new Spell()
            {
                SpellName = model.SpellName,
                SpellDescription = model.SpellDescription
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Spells.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SpellList> GetSpells()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Spells
                    .Select
                    (e => new SpellList
                    {
                        SpellId = e.SpellId,
                        SpellName = e.SpellName
                    });

                return query.ToArray();
            }
        }
        public SpellDetails GetSpellById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Spells
                    .Single(e => e.SpellId == id);
                return
                    new SpellDetails
                    {
                        SpellId = entity.SpellId,
                        SpellName = entity.SpellName,
                        SpellDescription = entity.SpellDescription
                    };
            }
        }

        public bool UpdateSpell(SpellEdit Model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Spells.Single(e => e.SpellId == Model.SpellId);
                entity.SpellName = Model.SpellName;
                entity.SpellDescription = Model.SpellDescription;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteSpell(int spellId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Spells.Single(e => e.SpellId == spellId); ;

                ctx.Spells.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
