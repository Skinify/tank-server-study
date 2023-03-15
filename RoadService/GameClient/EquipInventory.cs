using RoadService.GameClient._Base;
using Tank.Unity;

namespace RoadService.GameClient
{
    public class EquipInventory : BaseInventory
    {
        public EquipInventory(TankUnityOfWork tankUnityOfWork) :base(tankUnityOfWork, 60, Tank.Enums.EBagTypes.EQUIP) { 
            
        }
    }
}
