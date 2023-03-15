using Tank.Enums;
using Tank.Models.Entities.Character;

namespace Tank.Repositories._Interface
{
    public interface ICharacterRepository
    {
        Task<Characters?> GetCharacterById(int id);
        Task<List<CharacterItems>> GetCharacterItemsByBagType(EBagTypes eBagTypes);
    }
}
