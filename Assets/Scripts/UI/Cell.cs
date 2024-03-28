using InGameObjects.Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Cell : MonoBehaviour
    {
        [SerializeField] private GameObject _deleteBtn;
        [SerializeField] private Backpack _backpack; 
        [SerializeField] private int _id;
        private Item _item;
        
        public void GetItemInCell(Item item)
        {
            _item = item;
            transform.GetChild(0).GetComponent<Image>().sprite = item.GetSprite();
            if (item.GetAmount() > 1)
                transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "" + item.GetAmount();
            
        }

        public Item CheckForItem()
        {
            return _item;
        }

        public void DeleteItemFromCell()
        {
            _item = null;
            transform.GetChild(0).GetComponent<Image>().sprite = null;
            transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
            _deleteBtn.SetActive(false);
        }
        public void SendCellId()
        {
            _backpack.DeleteItem(_id);
        }

        public float GetCellId()
        {
            return _id;
        }
    }
}
