using Interaction;
using Player;
using SaveSystem;
using TMPro;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(TMP_Dropdown))]
    
    public class InteractionDropdown : MonoBehaviour
    {
        [SerializeField] private GameObject buttonModeElements;
        
        private PlayerInteraction _playerInteraction;
        private TMP_Dropdown _dropdown;
        private JsonSaveSystem _saveSystem;

        private void Awake()
        {
            _playerInteraction = PlayerInteraction.Instance;
            _dropdown = GetComponent<TMP_Dropdown>();
            _saveSystem = new JsonSaveSystem();
        }
        
        private void Start() => SetInteractionMode();

        private void SetInteractionMode()
        {
            var data = _saveSystem.LoadData();
            _dropdown.value = data.interactionMode;
            ChangeInteractionMode(_dropdown.value);
        }

        public void ChangeInteractionMode(int modeIndex)
        {
            var newMode = GetModeByIndex(modeIndex);
            _playerInteraction.ChangeInteractionMode(newMode);
            buttonModeElements.SetActive(newMode == InteractionMode.Button);
            SaveNewMode(modeIndex);
        }

        private void SaveNewMode(int modeIndex)
        {
            var data = _saveSystem.LoadData();
            data.interactionMode = modeIndex;
            _saveSystem.SaveData(data);
        }

        private InteractionMode GetModeByIndex(int index)
        {
            switch (index)
            {
                case 0:
                    return InteractionMode.Button;
                case 1:
                    return InteractionMode.ScreenTouch;
            }
            return InteractionMode.Button;
        }
    }
}