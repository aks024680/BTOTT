using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace BTOTT
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Inventory/New Item")]
    //创建一个新的资源菜单，菜单项名为"Inventory"，子菜单项名为"New Item"，所创建的文件名默认为"New Item"

    public class Item : ScriptableObject
    {
            public string itemName;         //物品名称
            public Sprite itemImage;        //物品所使用的填充图片
            public int itemHeld;            //物品持有数量
            [TextArea]                      //文本域标签(使string在Inspector窗口的编辑区从一行变为一个文本框)
            public string itemInfo;         //物品信息(可能多行)
      


    }

}

