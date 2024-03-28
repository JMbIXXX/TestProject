using UnityEngine;

namespace UI
{
    public class EnableDeleteBtn : MonoBehaviour
    {
        [SerializeField] private GameObject _deleteBtn;
        [SerializeField] private Cell _cell;

        public void EnableDeleteButton()
        {
            if (_cell.CheckForItem())
            {
                if (!_deleteBtn.activeSelf)
                    _deleteBtn.SetActive(true);
                else
                    _deleteBtn.SetActive(false);
            }
            
        }
    }
}
