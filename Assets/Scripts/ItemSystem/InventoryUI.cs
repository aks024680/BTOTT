using UnityEngine;

namespace BTOTT
{

    public class InventoryUI : MonoBehaviour
    {
        public ItemSlot[] ItemSlots;
        public Transform InventoryParent;

        private void Start()
        {
            InventoryManager.Instance.onInventoryCallBack += UpdateUI;
            ItemSlots = InventoryParent.GetComponentsInChildren<ItemSlot>();
        }

        public void UpdateUI()
        {
            for(int i = 0; i < ItemSlots.Length; i++)
            {
                if (i < InventoryManager.Instance.ItemList.Count)
                {
                    ItemSlots[i].AddItem(InventoryManager.Instance.ItemList[i]);
                }
                else
                {
                    ItemSlots[i].Clean();
                }
            }
        }
    }
}

