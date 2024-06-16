using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    // 可以添加一个道具类型或数量的属性，根据游戏需求调整
    public string itemName;

    public GameObject animationObject;

    // 当其他对象进入触发器时调用此方法
    void OnTriggerEnter2D(Collider2D other)
    {
        // 检查碰撞的对象是否是玩家
        if (other.CompareTag("Player"))
        {
            // 在此处处理道具拾取逻辑，例如增加玩家的道具数量
            Debug.Log("Picked up: " + itemName);

            // 可以在此调用玩家脚本中的方法，例如:
            // other.GetComponent<PlayerInventory>().AddItem(itemName);
            other.GetComponent<PlayerInventory>().AddItem(itemName);

            Animator anim = animationObject.GetComponent<Animator>();
            if (anim != null)
            {
                anim.SetTrigger("PickUp");
                print(anim);
            }

            // 销毁道具对象
            Destroy(gameObject);
            
        }
    }
}

