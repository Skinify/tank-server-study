using Tank.Enums;
using Tank.Models.Entities.Character;
using Tank.Repositories._Interface;

namespace Tank.Repositories._Mocked
{
    public class MockedCharacterRepository : ICharacterRepository
    {
        private readonly IList<Characters> _users;
        public MockedCharacterRepository()
        {

        }

        public Task<Characters?> GetCharacterById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CharacterItems>> GetCharacterItemsByBagType(EBagTypes eBagTypes)
        {
            throw new NotImplementedException();
        }
    }
}
