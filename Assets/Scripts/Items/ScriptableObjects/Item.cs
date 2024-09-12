using System;
using UnityEngine;

namespace Items.ScriptableObjects
{
    public abstract class ItemData : ScriptableObject, IEquatable<ItemData>
    {
        [SerializeField] private string _itemName;
        public string ItemName => _itemName;
        
        [SerializeField] private int _amount = 1;
        public int Amount => _amount;

        [SerializeField] private bool _isStackable;
        public bool IsStackable => _isStackable;

        [SerializeField] private bool _isConsumable;
        public bool IsConsumable => _isConsumable;

        public bool Equals(ItemData other)
        {
            return other != null && _itemName == other.ItemName;
        }

        public abstract void Use();
    }
}
