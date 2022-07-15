using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class SlotItemView : MonoBehaviour
    {
        [SerializeField] private Image slotIcon;

        public void SetIcon(Sprite icon) => slotIcon.sprite = icon;
    }
}