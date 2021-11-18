using RedBadgeFinal.Data;
using RedBadgeFinal.Models;
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
                ChracterName = model.ChracterName,
                CharacterRace = model.CharacterRace,
                CharacterClass = model.CharacterClass,
                Level = model.Level,
                HitPoints = model.HitPoints,
                ChracterBackground = model.ChracterBackground,
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
    }
}
