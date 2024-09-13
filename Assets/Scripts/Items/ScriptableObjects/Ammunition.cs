using UnityEngine;

namespace Items.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Ammunition", menuName = "Item/Ammunition")]
    public class Ammunition : ItemData
    {
        public override void Use()
        { }
    }
}