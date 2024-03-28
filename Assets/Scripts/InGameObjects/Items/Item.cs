using UnityEngine;
using UnityEngine.UI;

namespace InGameObjects.Items
{
    public enum IsStackable
    {
        Stackable,
        NotStackable
    }

    public enum ItemType
    {
        Ammo,
        Equipment,
        
    }
    public abstract class Item : MonoBehaviour
    {
        [SerializeField]protected float id;
        [SerializeField]protected string itemName;
        [SerializeField]protected float amount;
        [SerializeField] protected Sprite sprite;

        public float GetAmount()
        {
            return amount;
        }
        public Sprite GetSprite()
        {
            return sprite;
        }
        
    }
}
