using System.Collections.Generic;
using AFSInterview.Items.Inventory.Items.ItemsSO;
using Sirenix.OdinInspector;
using UnityEngine;

namespace AFSInterview.Items.Inventory.Items
{
    public class ItemsContainer : MonoBehaviour
    {
        [SerializeField, InlineEditor] private List<Item> items = new List<Item>();

        public Item GetRandomItem()
        {
            if (items == null) return null;
            
            int rand = Random.Range(0, items.Count);

            return items[rand];
        }
    }
}
