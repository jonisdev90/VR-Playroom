using Items.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Items
{
    public class ItemSlot: MonoBehaviour
    {
        [SerializeField] private Text _itemName;
        [SerializeField] private Text _amountText;
        [SerializeField] private Button _itemButton;
        [SerializeField] private Button _deleteButton;

        private int _amount = 0;

        private Inventory _inventory;
        [HideInInspector] public ItemData ItemData;
        
        public void Configure(Inventory inventory, ItemData itemData)
        {
            _inventory = inventory;
            ItemData = itemData;
            
            _itemName.text = itemData.ItemName;
            
            UpdateAmount(itemData.Amount);
            
            _itemButton.onClick.AddListener(Use);
            _deleteButton.onClick.AddListener(Delete);
        }

        private void Use()
        {
            ItemData.Use();

            if (!ItemData.IsConsumable) 
                return;
            
            Delete();
            _inventory.AddTrash();
        }

        private void Delete()
        {
            _inventory.DeleteSlot(this);
            Destroy(gameObject);
        }

        public void UpdateAmount(int amountPlus)
        {
            _amount += amountPlus;
            _amountText.text = _amount.ToString();
        }
    }
}