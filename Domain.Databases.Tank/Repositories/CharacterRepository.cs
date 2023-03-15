using Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using Tank.Enums;
using Tank.Models.Entities.Character;
using Tank.Repositories._Interface;

namespace Tank.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly TankContext _tankContext;
        public CharacterRepository(TankContext tankContext)
        {
            _tankContext = tankContext;
        }

        public async Task<Characters?> GetCharacterById(int id)
        {
            return await _tankContext.Characters.FindAsync(id);
        }

        public Task<List<CharacterItems>> GetCharacterItemsByBagType(EBagTypes eBagTypes)
        {
            return _tankContext.CharacterItems
                .Include(r=>r.Item)
                .Include(r=>r.Character)
                .Where(r => r.Item.BagTypesId == (int)eBagTypes).ToListAsync();
        }
    }
}
