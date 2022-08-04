using Player;
using SaveSystem;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Slider))]
    
    public class SensitivitySlider : MonoBehaviour
    {
        private JsonSaveSystem _saveSystem;
        private PlayerRotation _playerRotation;
        private Slider _slider;

        private void Awake()
        {
            _saveSystem = new JsonSaveSystem();
            _slider = GetComponent<Slider>();
            _playerRotation = PlayerRotation.Instance;
        }

        private void Start()
        {
            var data = _saveSystem.LoadData();
            _slider.value = data.sensitivity;
        }

        private void OnEnable() => _slider.onValueChanged.AddListener(ChangeSensitivity);
        
        private void OnDisable() => _slider.onValueChanged.RemoveListener(ChangeSensitivity);

        private void ChangeSensitivity(float value)
        {
            _playerRotation.ChangeSensitivity(value);
            SaveSensitivity(value);
        }
        
        private void SaveSensitivity(float value)
        {
            var data = _saveSystem.LoadData();
            data.sensitivity = value;
            _saveSystem.SaveData(data);
        }
    }
}