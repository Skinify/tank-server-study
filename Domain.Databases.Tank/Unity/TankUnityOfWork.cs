using Tank.Repositories;
using Tank.Repositories._Interface;

namespace Tank.Unity
{
    public class TankUnityOfWork
    {
        public TankUnityOfWork(TankContext tankContext) {
            ServerRepository = new ServerRepository(tankContext);
        }

        public void Commit() { }
        public void Rollback() { }

        public IServerRepository ServerRepository { get; internal set; }
        public ICharacterRepository CharacterRepository { get; internal set; }
    }
}
