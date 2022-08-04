using SaveSystem;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Slider))]
    
    public class SensitivitySlider : MonoBehaviour
    {
        private JsonSaveSystem _saveSystem;
        private Slider _slider;

        private void Awake()
        {
            _saveSystem = new JsonSaveSystem();
            _slider = GetComponent<Slider>();
        }

        private void Start()
        {
            var data = _saveSystem.LoadData();
            _slider.value = data.sensitivity;
        }

        private void OnEnable() => _slider.onValueChanged.AddListener(OnSensitivityChanged);
        
        private void OnDisable() => _slider.onValueChanged.RemoveListener(OnSensitivityChanged);

        private void OnSensitivityChanged(float value)
        {
            var data = _saveSystem.LoadData();
            data.sensitivity = value;
            _saveSystem.SaveData(data);
        }
    }
}