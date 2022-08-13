using Player;
using UnityEngine;

namespace UI
{
    public class ButtonModeElements : MonoBehaviour
    {
        private void Start()
        {
            if (PlayerInteraction.Instance.InteractionModeIndex == 1)
                gameObject.SetActive(false);
        }
    }
}