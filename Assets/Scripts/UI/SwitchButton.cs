using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class SwitchButton : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private GameObject switchableObject;
        [SerializeField] private bool switchOffAtStart;

        private void Start()
        {
            if(switchOffAtStart)
                switchableObject.SetActive(false);   
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            switchableObject.SetActive(!switchableObject.activeSelf);
        }
    }
}
