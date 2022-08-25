using UnityEngine;

namespace Interaction.InteractiveObjects
{
    public class GhostFacesButton : MonoBehaviour, IInteractive
    {
        [SerializeField] private SpriteRenderer ghostFace;
        [SerializeField] private Sprite stepaFace;

        private int _clicksCount;
        
        public void Interact()
        {
            if (_clicksCount == 0)
                ghostFace.gameObject.SetActive(true);
            else if (_clicksCount == 1)
                ghostFace.sprite = stepaFace;
            _clicksCount++; 
        }
    }
}