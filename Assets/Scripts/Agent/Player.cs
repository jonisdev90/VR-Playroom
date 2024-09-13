using System;
using Items;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Agent
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Inventory _inventory;
        
        private WeaponController _weaponController;
        
        private PlayerInput _playerInput;

        private void Awake()
        {
            _playerInput = new PlayerInput();

            _weaponController = GetComponentInChildren<WeaponController>();
        }

        private void Start()
        {
            _playerInput.Player.ChangeWeapon.performed += _weaponController.ChangeWeapon;
            _playerInput.Player.ReloadAmmunition.performed += ReloadAmmunition;
            _playerInput.Player.Fire.performed += _weaponController.Shoot;
        }

        private void OnEnable()
        {
            _playerInput.Enable();
        }

        private void OnDisable()
        {
            _playerInput.Disable();
        }

        private void ReloadAmmunition(InputAction.CallbackContext callbackContext)
        {
            var itemData = _weaponController.GetAmmunitionItemData;
            var chargerSize = _weaponController.GetChargerSize;
            
            if (itemData == null)
                return;

            var ammunition = _inventory.GetAmmunition(itemData, chargerSize);
            
            _weaponController.SetAmmunition(ammunition);
        }
    }
}
