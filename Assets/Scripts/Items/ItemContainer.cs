using System;
using Items.ScriptableObjects;
using UnityEngine;

namespace Items
{
    public class ItemContainer : MonoBehaviour
    {
        [SerializeField] private ItemData _itemData;

        public static event Action<ItemData> OnAddItem;
        
        public void AddItemToInventory()
        {
            OnAddItem?.Invoke(_itemData);
        }
    }
}