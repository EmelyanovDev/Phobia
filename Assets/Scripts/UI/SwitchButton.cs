using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class SwitchButton : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private GameObject switchableObject;
        [SerializeField] private bool disableAtStart;
        [SerializeField] private Vector3 onClickRotation;
        [SerializeField] private float rotationSpeed;

        private Vector3 _targetRotation;

        private void Start()
        {
            if(disableAtStart) switchableObject.SetActive(false);   
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            switchableObject.SetActive(!switchableObject.activeSelf);
            _targetRotation = transform.localEulerAngles + onClickRotation;
        }

        private void FixedUpdate()
        {
            if (transform.localEulerAngles == _targetRotation) return;
            var rotation = rotationSpeed * Time.fixedDeltaTime;
            transform.localEulerAngles = Vector3.MoveTowards(transform.localEulerAngles, _targetRotation, rotation);
        }
    }
}
