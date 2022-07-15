using Interaction.InteractiveObjects;
using UnityEngine;
using Utilities;

namespace Player
{
    public class PlayerHands : Singleton<PlayerHands>
    {
        [SerializeField] private Transform itemsSpawnPoint;

        private Item _takenItem;

        public void TakeItem(Item item)
        {
            _takenItem = Instantiate(item, itemsSpawnPoint.position, Quaternion.identity);
        }

        public void RemoveItem()
        {
            Destroy(_takenItem.gameObject);
        }
    }
}