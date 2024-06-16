using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    // 用于存储道具的列表
    private List<string> inventory = new List<string>();

    // 添加道具到库存中
    public void AddItem(string itemName)
    {
        inventory.Add(itemName);
        Debug.Log("Item added to inventory: " + itemName);
    }

    // 显示库存中的所有道具
    public void ShowInventory()
    {
        foreach (string item in inventory)
        {
            Debug.Log("Inventory item: " + item);
        }
    }
}

