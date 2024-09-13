using Items.ScriptableObjects;
using UnityEngine;
using Weapons.ScriptableObjects;

namespace Weapons
{
    public class Weapon: MonoBehaviour
    {
        [SerializeField] private WeaponProperties _properties;

        public int Damage => _properties.WeaponDamage;
        public int ChargerSize => _properties.ChargerSize;
        public ItemData Ammunition => _properties.Ammunition;

        public int CurrentAmmunition = 0;
    }
}