using Tank.Models.Entities.Character;

namespace Tank.Repositories._Interface
{
    public interface ICharacterRepository
    {
        Task<Characters?> GetCharacterById(int id);
    }
}
