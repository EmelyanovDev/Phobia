using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class SwitchButton : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private GameObject switchableObject;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            switchableObject.SetActive(!switchableObject.activeSelf);
        }
    }
}
