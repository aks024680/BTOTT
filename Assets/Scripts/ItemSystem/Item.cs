using UnityEngine;

namespace BTOTT
{
    [CreateAssetMenu(menuName = "ItemSystem/Item")]
    public class Item : ScriptableObject
    {
        public int ItemID;
        public string ItemName;
        public Sprite ItemImage;

        public virtual void UseItem()
        {
            //Method to use item
        }
    }
}

