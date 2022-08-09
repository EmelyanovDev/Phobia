using Player;
using UnityEngine;

namespace UI
{
    public class ButtonModeElements : MonoBehaviour
    {
        private PlayerInteraction _interaction;

        private void Awake() => _interaction = PlayerInteraction.Instance;

        private void Start()
        {
            if (_interaction.ModeIndex == 1)
                gameObject.SetActive(false);
        }
    }
}