using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    [RequireComponent(typeof(Image))]
    
    public class SlotItemView : MonoBehaviour
    {
        [SerializeField] private Image itemIcon;

        public void ChangeIcon(Sprite icon)
        {
            itemIcon.sprite = icon;
            gameObject.SetActive(icon != null);
        }
        
        public void ChangeTransparency(float value)
        {
            var color = itemIcon.color;
            color.a = value;
            itemIcon.color = color;
        }
    }
}