using UnityEngine;

namespace Utilities
{
    public static class Randomizer
    {
        public static bool PlayLottery(float eventChance)
        {
            float random = Random.Range(0, 1);
            Debug.Log(eventChance + random);
            return random < eventChance;
        }
    }
}