using System;
using System.Collections.Generic;
using InGameObjects.Items;
using UnityEngine;

namespace UI
{
    public class Backpack : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _cells = new List<GameObject>();

        

        public void GetItemInBackpack(Item item)
        {
            SetItemInCell(item);
        }

        private void SetItemInCell(Item item)
        {
            foreach (var cell in _cells)
            {
                var itemInCell = cell.GetComponent<Cell>();
                if (itemInCell.CheckForItem() == null)
                {
                    itemInCell.GetItemInCell(item);
                    return;
                }
            }
        }
        
        public void DeleteItem(float id)
        {
            foreach (var cell in _cells)
            {
                var itemInCell = cell.GetComponent<Cell>();
                if (itemInCell.GetCellId() == id)
                {
                    itemInCell.DeleteItemFromCell();
                }
            }
        }

        public void DeleteAllItems()
        {
            foreach (var cell in _cells)
            {
                var itemInCell = cell.GetComponent<Cell>();
                itemInCell.DeleteItemFromCell();
            }
        }

        
        
    }

    
}
