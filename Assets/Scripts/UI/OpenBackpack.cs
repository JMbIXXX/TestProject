using UnityEngine;

namespace UI
{
    public class OpenBackpack : MonoBehaviour
    {
        [SerializeField] private GameObject _backpackPanel;
        public void OpenAndClose()
        {
            if (!_backpackPanel.activeSelf)
                _backpackPanel.SetActive(true);
            else
                _backpackPanel.SetActive(false);
            
            
        }
    }
}
