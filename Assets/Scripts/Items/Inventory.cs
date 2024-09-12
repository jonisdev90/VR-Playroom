using System;
using System.Collections.Generic;
using System.Linq;
using Items.ScriptableObjects;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Items
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private int _inventorySize = 3;
        [SerializeField] private Transform _slotContainer;
        [SerializeField] private GameObject _itemSlotButton;
        [SerializeField] private GameObject _menu;
        [SerializeField] private Trash _trash;
        
        private readonly List<ItemSlot> _inventorySlots = new();

        private PlayerInput _playerInput;

        private void Awake()
        {
            _playerInput = new PlayerInput();
        }

        private void Start()
        {
            _playerInput.UI.Menu.performed += ChangeMenuState;
        }

        private void OnEnable()
        {
            _playerInput.Enable();
            
            EventsServices.Instance.OnAddItem += AddItem;
        }

        private void OnDisable()
        {
            _playerInput.Disable();
            
            EventsServices.Instance.OnAddItem -= AddItem;
        }

        private void AddItem(ItemData itemData)
        {
            Debug.Log("Add Item" + itemData.ItemName);

            var itemSlot = _inventorySlots.FirstOrDefault(x => x.ItemData.ItemName == itemData.ItemName);
            
            if (itemSlot != null && itemSlot.ItemData.IsStackable)
                itemSlot.UpdateAmount(itemData.Amount);

            else if (_inventorySlots.Count < _inventorySize)
                CreateSlot(itemData);

            else
            {
                Debug.Log("No space Available");
            }
        }

        private void CreateSlot(ItemData itemData)
        {
            var itemSlot = Instantiate(_itemSlotButton, _slotContainer).GetComponent<ItemSlot>();
            itemSlot.Configure(this, itemData);
            _inventorySlots.Add(itemSlot);
        }

        public void DeleteSlot(ItemSlot itemSlot) => _inventorySlots.Remove(itemSlot);

        public void AddTrash() => AddItem(_trash);

        private void ChangeMenuState(InputAction.CallbackContext obj) => _menu.SetActive(!_menu.activeInHierarchy);
    }
}