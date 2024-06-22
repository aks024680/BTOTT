
using System.Collections.Generic;
using UnityEngine;

namespace BTOTT
{
    [CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/New Inventory")]
    public class Inventory : ScriptableObject
    {
       public List<Item> ItemList = new List<Item>();

    }
}

