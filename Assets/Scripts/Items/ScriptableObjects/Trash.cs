using UnityEngine;

namespace Items.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Trash", menuName = "Item/Trash")]
    public class Trash : ItemData
    {
        public override void Use() { }
    }
}