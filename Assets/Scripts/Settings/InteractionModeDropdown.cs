using Player;
using Save;
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

        private void Awake()
        {
            _playerInteraction = PlayerInteraction.Instance;
            _dropdown = GetComponent<TMP_Dropdown>();
            _dropdown.value = JsonSave.LoadData().interactionModeIndex;
        }

        private void OnEnable()
        {
            _dropdown.onValueChanged.AddListener(ChangeInteractionMode);
        }
        
        private void OnDisable()
        {
            _dropdown.onValueChanged.RemoveListener(ChangeInteractionMode);
        }
        
        private void ChangeInteractionMode(int modeIndex)
        {
            _playerInteraction.ChangeInteractionMode(modeIndex);
            buttonModeElements.SetActive(modeIndex == 0);
            SaveMode(modeIndex);
        }

        private void SaveMode(int modeIndex)
        {
            var data = JsonSave.LoadData();
            data.interactionModeIndex = modeIndex;
            JsonSave.SaveData(data);
        }
    }
}