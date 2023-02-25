using Tank.Repositories._Interface;

namespace TankTankTeste.Tests.DatabasesTests
{
    public class UserRepositoryTests
    {
        private readonly ICharacterRepository _userRepository;

        public UserRepositoryTests(ICharacterRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [Fact]
        public async void Test1()
        {
            //var _ = await _userRepository.GetAll();
            //Assert.True(_.Count() > 2, "");
        }
    }
}