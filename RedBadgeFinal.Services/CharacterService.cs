using RedBadgeFinal.Data;
using RedBadgeFinal.Models;
using RedBadgeFinal.Models.CharacterSpell;
using RedBadgeFinal.Models.InventoryModels;
using RedBadgeFinal.Models.ItemModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Services
{
    public class CharacterService
    {
        public bool CreateCharacter(CharacterCreate model)
        {
            var entity = new Character()
            {
                CharacterName = model.CharacterName,
                CharacterRace = model.CharacterRace,
                CharacterClass = model.CharacterClass,
                Level = model.Level,
                HitPoints = model.HitPoints,
                CharacterBackground = model.ChracterBackground,
                Strength = model.Strength,
                Dexterity = model.Dexterity,
                Constitution = model.Constitution,
                Intelligence = model.Intelligence,
                Wisdom = model.Wisdom,
                Charisma = model.Charisma
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Characters.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CharacterListItem> GetCharacters()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Characters
                    .Select
                    (e => new CharacterListItem
                    {
                        CharacterId = e.CharacterId,
                        CharacterName = e.CharacterName,
                        CharacterRace = e.CharacterRace,
                        CharacterClass = e.CharacterClass,
                        Level = e.Level
                    });

                return query.ToArray();
            }
        }

        public CharacterDetail GetCharacterById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Characters
                    .Single(e => e.CharacterId == id);
                return
                    new CharacterDetail
                    {
                        CharaterId = entity.CharacterId,
                        CharacterName = entity.CharacterName,
                        CharacterRace = entity.CharacterRace,
                        CharacterClass = entity.CharacterClass,
                        Level = entity.Level,
                        HitPoints = entity.HitPoints,
                        CharacterBackground = entity.CharacterBackground,
                        Str = entity.Strength,
                        Dex = entity.Dexterity,
                        Con = entity.Constitution,
                        Int = entity.Intelligence,
                        Wis = entity.Wisdom,
                        Cha = entity.Charisma,
                        Spells = entity.Spells.Select(e => new SpellDetails { SpellId = e.Spell.SpellId, SpellName = e.Spell.SpellName, SpellDescription = e.Spell.SpellDescription }).ToList(),
                        Inventory = entity.Inventories.Select(e => new ItemList { ItemId = e.Items.ItemId, ItemName = e.Items.ItemName, ItemDescription = e.Items.ItemDescription }).ToList(),
                        InventoryDetails = entity.Inventories.Select(e => new InventoryDetail { InventoryId = e.InventoryId }).ToList(),
                        CharacterSpellDetails = entity.Spells.Select(e => new CharacterSpellDetails { CharacterSpellId = e.CharacterSpellId}).ToList()
                    };
            }
        }

        public bool UpdateCharacter(CharacterEdit Model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Characters.Single(e => e.CharacterId == Model.CharacterId);

                entity.CharacterName = Model.CharacterName;
                entity.CharacterRace = Model.CharacterRace;
                entity.CharacterClass = Model.CharacterClass;
                entity.Level = Model.Level;
                entity.HitPoints = Model.HitPoints;
                entity.CharacterBackground = Model.CharacterBackground;
                entity.Strength = Model.Strength;
                entity.Dexterity = Model.Dexterity;
                entity.Constitution = Model.Constitution;
                entity.Intelligence = Model.Intelligence;
                entity.Wisdom = Model.Wisdom;
                entity.Charisma = Model.Charisma;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCharacter(int characterId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Characters.Single(e => e.CharacterId == characterId);

                ctx.Characters.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
