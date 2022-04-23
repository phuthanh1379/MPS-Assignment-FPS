using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Manager
{
    public class PopupManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> popups = new List<GameObject>();
        
        public void ShowPopup(string popupName)
        {
            foreach (var popup in popups)
            {
                if (popup.name == popupName)
                    popup.SetActive(true);
            }
        }

        public void HidePopup(string popupName)
        {
            foreach (var popup in popups)
            {
                if (popup.name == popupName)
                    popup.SetActive(false);
            }
        }
    }
}