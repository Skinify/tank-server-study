using Base.Interfaces;
using System.Collections.Specialized;
using Tank.Unity;

namespace CenterService.Services
{
    public class LoginService : IManager
    {
        private readonly TankUnityOfWork _tankUnityOfWork;
        protected readonly HybridDictionary _loggedPlayer;

        public LoginService(TankUnityOfWork tankUnityOfWork)
        {
            _tankUnityOfWork = tankUnityOfWork;
            _loggedPlayer = new HybridDictionary();
        }

        public async Task LoginPlayer(int charId)
        {
            var @char = await _tankUnityOfWork.CharacterRepository.GetCharacterById(charId);
            if (@char is null)
                throw new Exception("Character does not exists");

            //Atualizar informações do user, como ultima vez logado, log count e por ai vai
            
            lock (_loggedPlayer.SyncRoot)
            {
                _loggedPlayer.Add(@char.Id, @char);
            }

            //Se ja logado deslogar
        }

        public Task Start()
        {
            throw new NotImplementedException();
        }

        public Task Stop()
        {
            throw new NotImplementedException();
        }
    }
}
