using Items.ScriptableObjects;
using UnityEngine;

namespace Weapons.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Weapon")]
    public class WeaponProperties: ScriptableObject
    {
        [SerializeField] private string _weaponName;
        public string WeaponName => _weaponName;
        
        [SerializeField] private int _chargerSize = 1;
        public int ChargerSize => _chargerSize;

        [SerializeField] private int _weaponDamage;
        public int WeaponDamage => _weaponDamage;

        [SerializeField] private ItemData _ammunition;
        public ItemData Ammunition => _ammunition;
    }
}