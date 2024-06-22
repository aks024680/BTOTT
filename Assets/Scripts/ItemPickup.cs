using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine;


namespace BTOTT
{
    public class ItemPickup : MonoBehaviour
    {
        // 可以添加一个道具类型或数量的属性，根据游戏需求调整
        public string itemName;

        public GameObject animationObject;



        public Item thisItem;                   //素材所属的Item(物品配置文件)
        public Inventory thisInventory;			//素材所属的Inventory(背包配置文件)
        // 当其他对象进入触发器时调用此方法

        private void Start()
        {
            
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            // 检查碰撞的对象是否是玩家
            if (other.CompareTag("Player"))
            {
                // 在此处处理道具拾取逻辑，例如增加玩家的道具数量
                Debug.Log("Picked up: " + itemName);

                // 可以在此调用玩家脚本中的方法，例如:
                // other.GetComponent<PlayerInventory>().AddItem(itemName);

                

                Animator anim = animationObject.GetComponent<Animator>();
                if (anim != null)
                {
                    anim.SetTrigger("PickUp");
                    print(anim);
                }

                // 销毁道具对象
                Destroy(gameObject);
                print(gameObject + "破壞");

                AddNewItem();//将物品添加到指定物品栏
                

            }
        }
        public void AddNewItem()//将物品添加到指定物品栏
        {
           
            if (!thisInventory.ItemList.Contains(thisItem))//若指定物品栏中尚未存放该物品
            {
                thisInventory.ItemList.Add(thisItem);//在物品栏中添加物品
            }
            else
            {
                thisItem.itemHeld++;//物品持有数量增加
            }
            InventoryManager.RefreshItem();//直接通过数据更新的方式完成背包栏中图像的生成
        }



    }

}


