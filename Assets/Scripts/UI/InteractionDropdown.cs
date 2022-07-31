using System;
using Interaction;
using Player;
using SaveSystem;
using UnityEngine;

namespace UI
{
    public class InteractionDropdown : MonoBehaviour
    {
        [SerializeField] private GameObject interactionButton;
        [SerializeField] private GameObject interactionCursor;
        
        private PlayerInteraction _playerInteraction;

        private void Awake()
        {
            _playerInteraction = PlayerInteraction.Instance;
        }

        public void ChangeInteractionMode(int modeIndex)
        {
            InteractionMode newMode = InteractionMode.Button;
            switch (modeIndex)
            {
                case 0:
                    newMode = InteractionMode.Button;
                    break;
                case 1:
                    newMode = InteractionMode.ScreenTouch;
                    break;
            }
            _playerInteraction.ChangeInteractionMode(newMode);
            
            interactionButton.SetActive(newMode == InteractionMode.Button);
            interactionCursor.SetActive(newMode == InteractionMode.Button);
        }
    }
}