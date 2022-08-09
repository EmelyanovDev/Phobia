using Interaction;
using Interaction.InteractionModes;
using SaveSystem;
using UnityEngine;
using Utilities;

namespace Player
{
    [RequireComponent(typeof(ButtonMode))]
    [RequireComponent(typeof(TouchScreenMode))]
    
    public class PlayerInteraction : Singleton<PlayerInteraction>
    {
        private InteractionMode _currentInteractionMode;

        private ButtonMode _buttonMode;
        private TouchScreenMode _touchScreenMode;
        
        public int ModeIndex => 
            _currentInteractionMode == _buttonMode ? 0 : 1;

        private void Awake()
        {
            _buttonMode = GetComponent<ButtonMode>();
            _touchScreenMode = GetComponent<TouchScreenMode>();
            
            LoadSavedMode();
        }
        
        private void LoadSavedMode()
        {
            var saveSystem = new JsonSaveSystem();
            SaveData data = saveSystem.LoadData();
            ChangeInteractionMode(data.interactionModeIndex);
        }

        private void Update()
        {
            _currentInteractionMode.CheckInteractive();
        }

        public void ChangeInteractionMode(int modeIndex)
        {
            if (modeIndex == 0)
                _currentInteractionMode = _buttonMode;
            else if (modeIndex == 1)
                _currentInteractionMode = _touchScreenMode;
        }
    }
}

