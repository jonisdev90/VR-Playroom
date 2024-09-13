using System;
using System.Threading.Tasks;
using Items.ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using Weapons;

namespace Agent
{
    public class WeaponController: MonoBehaviour
    {
        [SerializeField] private Weapon[] _weapons;
        [SerializeField] private GameObject _bullet;
        [SerializeField] private Transform _firePoint;
        [SerializeField] private GameObject _ammunitionUI;
        [SerializeField] private TextMeshProUGUI _ammunitionText;

        public ItemData GetAmmunitionItemData => _weapons[_currentWeapon].CurrentAmmunition < _weapons[_currentWeapon].ChargerSize ? _weapons[_currentWeapon].Ammunition : null;
        public int GetChargerSize => _weapons[_currentWeapon].ChargerSize - _weapons[_currentWeapon].CurrentAmmunition;
        
        private int _currentWeapon = 0;

        private bool _cooldown;

        private void Start()
        {
            _weapons[_currentWeapon].gameObject.SetActive(true);
        }

        public void SetAmmunition(int amount)
        {
            EventsServices.Instance.OnPlaySound?.Invoke(SoundType.Reload);
            
            _weapons[_currentWeapon].CurrentAmmunition += amount;

            _ammunitionText.text = _weapons[_currentWeapon].CurrentAmmunition.ToString();
        }

        public void ChangeWeapon(InputAction.CallbackContext obj)
        {
            _weapons[_currentWeapon].gameObject.SetActive(false);
            
            _currentWeapon = _currentWeapon + 1 < _weapons.Length ? _currentWeapon + 1 : 0;
            
            _weapons[_currentWeapon].gameObject.SetActive(true);

            _ammunitionUI.SetActive(_weapons[_currentWeapon].Ammunition != null);

            _ammunitionText.text = _weapons[_currentWeapon].CurrentAmmunition.ToString();
        }
        
        public async void Shoot(InputAction.CallbackContext callbackContext)
        {
            if (_weapons[_currentWeapon].CurrentAmmunition == 0 || _cooldown)
                return;
            
            _weapons[_currentWeapon].CurrentAmmunition--;
            
            _ammunitionText.text = _weapons[_currentWeapon].CurrentAmmunition.ToString();

            _cooldown = true;
            
            EventsServices.Instance.OnPlaySound?.Invoke(SoundType.Fire);

            var bullet = Instantiate(_bullet, _firePoint.position, _firePoint.rotation);
            bullet.GetComponent<Bullet>().Damage = _weapons[_currentWeapon].Damage;
            var rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(_firePoint.forward * 20f, ForceMode.Impulse);

            await Task.Delay(TimeSpan.FromSeconds(0.5f));

            _cooldown = false;
        }
    }
}