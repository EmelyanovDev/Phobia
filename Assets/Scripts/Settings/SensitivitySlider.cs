using Player;
using Save;
using UnityEngine;
using UnityEngine.UI;

namespace Settings
{
    [RequireComponent(typeof(Slider))]
    
    public class SensitivitySlider : MonoBehaviour
    {
        private Slider _slider;
        private PlayerRotation _playerRotation;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
            _playerRotation = PlayerRotation.Instance;
            LoadSensitivity();
        }
        
        private void OnEnable() => _slider.onValueChanged.AddListener(ChangeSensitivity);

        private void OnDisable() => _slider.onValueChanged.RemoveListener(ChangeSensitivity);

        private void LoadSensitivity()
        {
            float sensitivity = JsonSave.LoadData().sensitivity;
            _slider.value = sensitivity;
            _playerRotation.ChangeSensitivity(sensitivity);
        }

        private void ChangeSensitivity(float value)
        {
            _playerRotation.ChangeSensitivity(value);
            SaveSensitivity(value);
        }
        
        private void SaveSensitivity(float value)
        {
            var data = JsonSave.LoadData();
            data.sensitivity = value;
            JsonSave.SaveData(data);
        }
    }
}