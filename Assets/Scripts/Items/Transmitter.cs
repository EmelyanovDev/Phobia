using System.Collections;
using Interaction.InteractiveObjects;
using Interaction.InteractiveObjects.Item;
using UnityEngine;

namespace Items
{
    public class Transmitter : Item
    {
        [SerializeField] private Vector2 delayRange;
        [SerializeField] private AudioSource ghostVoice;

        private void Start() => StartCoroutine(Message());
        
        private IEnumerator Message()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(delayRange.x, delayRange.y));
                if(InHand == false) continue;
                ghostVoice.Play();
            }
        }
    }
}