using Interaction.InteractiveObjects.Item;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    [RequireComponent(typeof(Image))]
    
    public class SlotItemView : MonoBehaviour
    {
        [SerializeField] private Image itemIcon;
        [SerializeField] private float takenItemTransparency;
        
        private float _defaultTransparency;

        public void ChangeIcon(Sprite icon)
        {
            itemIcon.sprite = icon;
            gameObject.SetActive(icon != null);
        }
        
        public void ChangeTransparency(ItemStatus itemStatus)
        {
            float transparency = itemStatus == ItemStatus.Taken ? _defaultTransparency : takenItemTransparency;
            var color = itemIcon.color;
            color.a = transparency;
            itemIcon.color = color;
        }
    }
}