using System;
using Items.ScriptableObjects;
using UnityEngine;

namespace Items
{
    public class ItemContainer : MonoBehaviour
    {
        [SerializeField] private ItemData _itemData;
        
        public void AddItemToInventory()
        {
            EventsServices.Instance.OnAddItem?.Invoke(_itemData);
        }
    }
}