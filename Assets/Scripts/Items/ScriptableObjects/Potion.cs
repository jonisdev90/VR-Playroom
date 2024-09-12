using System;
using UnityEngine;

namespace Items.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Potion", menuName = "Item/Potion")]
    public class Potion : ItemData
    {
        [SerializeField] private int _healthRecovery;
        public int HealthRecovery => _healthRecovery;
        
        public override void Use()
        {
            Debug.Log("Use " + ItemName);
            
            EventsServices.Instance.OnGetHealth?.Invoke(_healthRecovery);
        }
    }
}