using RedBadgeFinal.Data;
using RedBadgeFinal.Models;
using RedBadgeFinal.Models.CharacterModels;
using RedBadgeFinal.Models.CharacterSpell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RedBadgeFinal.Services
{
    public class AddSpellToCharacter
    {
        public bool CreateCharacterSpell(CharacterSpellCreate model, int characterId)
        {
            var entity = new CharacterSpell()
            {
                CharacterId = model.CharacterId,
                SpellId = model.SpellId,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.CharacterSpells.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CharacterSpellListItem> GetCharacterSpells()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .CharacterSpells
                    .Select
                    (e => new CharacterSpellListItem
                    {
                        CharacterSpellId = e.CharacterSpellId,
                        CharacterId = e.CharacterId,
                        SpellId = e.SpellId
                    });

                return query.ToArray();
            }
        }

        public CharacterSpellDetails GetCharacterSpellById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .CharacterSpells
                    .Single(e => e.CharacterSpellId == id);
                return
                    new CharacterSpellDetails
                    {
                        CharacterSpellId = entity.CharacterSpellId,
                        CharacterId = entity.CharacterId,
                        CharacterName = entity.Character.CharacterName,
                        SpellId = entity.SpellId,
                        SpellName = entity.Spell.SpellName
                    };
            }
        }
        public bool DeleteCharacterSpell(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.CharacterSpells.Single(e => e.CharacterSpellId == id);

                ctx.CharacterSpells.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public List<SelectListItem> GetSpells()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.CharacterSpells.Select
                    (e => new SelectListItem
                    {
                        Value = e.SpellId.ToString(), Text = e.Spell.SpellName
                    });

                return query.ToList();
            }
        }

        public List<SelectListItem> GetCharacters()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.CharacterSpells.Select
                    (e => new SelectListItem
                    {
                        Value = e.CharacterId.ToString(),
                        Text = e.Character.CharacterName
                    });

                return query.ToList();
            }
        }
    }
}
