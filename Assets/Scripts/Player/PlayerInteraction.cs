using Interaction;
using Interaction.Modes;
using Save;
using UnityEngine;
using Utilities;

namespace Player
{
    [RequireComponent(typeof(ButtonMode))]
    [RequireComponent(typeof(TouchScreenMode))]
    
    public class PlayerInteraction : Singleton<PlayerInteraction>
    {
        private InteractionMode _currentInteractionMode;
        
        private InteractionMode _buttonMode;
        private InteractionMode _touchScreenMode;
        
        public int InteractionModeIndex => 
            _currentInteractionMode == _buttonMode ? 0 : 1;

        private void Awake()
        {
            _buttonMode = GetComponent<ButtonMode>();
            _touchScreenMode = GetComponent<TouchScreenMode>();
            ChangeInteractionMode(JsonSave.LoadData().interactionModeIndex);
        }

        private void Update()
        {
            _currentInteractionMode.CheckInteractive();
        }

        public void ChangeInteractionMode(int modeIndex)
        {
            _currentInteractionMode = modeIndex switch
            {
                0 => _buttonMode,
                1 => _touchScreenMode,
                _ => _currentInteractionMode
            };
        }
    }
}

