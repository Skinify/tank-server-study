using Tank.Enums;
using Tank.Models.Entities.Character;
using Tank.Unity;

namespace RoadService.GameClient._Base
{
    public abstract class BaseInventory
    {
        private readonly TankUnityOfWork _tankUnityOfWork;

        protected object Lock { get; private set; }
        protected int Capacity { get; private set; }
        protected EBagTypes BagType { get; private set; }        
        protected int BeginSlot { get; private set; }
        protected bool AutoStack { get; set; }
        protected IList<CharacterItems> Items { get; private set; }

        protected BaseInventory(TankUnityOfWork tankUnityOfWork, int invetoryCapacity, EBagTypes eBagTypes) {
            _tankUnityOfWork = tankUnityOfWork;
            Lock = new object();
            Capacity = invetoryCapacity;
            BagType = eBagTypes;
            Items = new List<CharacterItems>();
            ReloadItems().RunSynchronously();
        }

        protected virtual async Task ReloadItems()
        {
            Items.Clear();

            var items = await _tankUnityOfWork.CharacterRepository.GetCharacterItemsByBagType(BagType);
            var added = 0;
            
            items.ForEach(item =>
            {
                if (added == Capacity)
                    return;

                Items.Add(item);
                added++;
            });
        }

        protected virtual CharacterItems? GetItemAt(int slot)
        {
            if (slot < 0 || slot >= Capacity) return null;
            return Items[slot];
        }

        protected int FindFirstEmptySlot(int minSlot)
        {
            if (minSlot >= Capacity) return -1;

            lock (Lock)
            {
                for (int i = minSlot; i < Capacity; i++)
                    if (Items[i] == null)
                        return i;

                return -1;
            }
        }

        protected virtual CharacterItems? GetItemByCategoryID(EItemsCategoriesTypes categoryID, int property)
        {
            lock (Lock)
            {
                for (int i = 0; i < Capacity; i++)
                {
                    if (Items[i] != null && Items[i].Item.ItemsCategoryId == (int)categoryID)
                        return Items[i];
                }
                return null;
            }
        }

        protected virtual CharacterItems? GetItemByID(int itemID)
        {
            lock (Lock)
            {
                for (int i = 0; i < Capacity; i++)
                {
                    if (Items[i] != null && Items[i].Id == itemID)
                        return Items[i];
                }
                return null;
            }
        }

        protected virtual int GetItemCount(int itemId)
        {
            int count = 0;
            lock (Lock)
            {
                for (int i = 0; i < Capacity; i++)
                    if (Items[i] != null && Items[i].Id == itemId)
                        count++;
            }
            return count;
        }

        protected virtual int GetEmptySlotsCount()
        {
            int count = 0;
            lock (Lock)
            {
                for (int i = 0; i < Capacity; i++)
                    if (Items[i] == null)
                        count++;
            }

            return count;
        }

        protected virtual void UpdateItem(CharacterItems item) {
            if (item.Item.BagTypesId != (int)BagType)
                return;
        }
    }
}
