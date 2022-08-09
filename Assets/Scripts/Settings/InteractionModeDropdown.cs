using Player;
using SaveSystem;
using TMPro;
using UnityEngine;

namespace Settings
{
    [RequireComponent(typeof(TMP_Dropdown))]
    
    public class InteractionModeDropdown : MonoBehaviour
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
            LoadSavedMode();
        }

        private void OnEnable()
        {
            _dropdown.onValueChanged.AddListener(ChangeInteractionMode);
        }
        
        private void OnDisable()
        {
            _dropdown.onValueChanged.RemoveListener(ChangeInteractionMode);
        }

        private void LoadSavedMode()
        {
            var data = _saveSystem.LoadData();
            _dropdown.value = data.interactionModeIndex;
        }

        private void ChangeInteractionMode(int modeIndex)
        {
            _playerInteraction.ChangeInteractionMode(modeIndex);
            buttonModeElements.SetActive(modeIndex == 0);
            SaveNewMode(modeIndex);
        }

        private void SaveNewMode(int modeIndex)
        {
            var data = _saveSystem.LoadData();
            data.interactionModeIndex = modeIndex;
            _saveSystem.SaveData(data);
        }
    }
}