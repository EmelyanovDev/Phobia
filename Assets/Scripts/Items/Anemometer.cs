using Interaction.InteractiveObjects;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace Items
{
    public class Anemometer : Item
    {
        [SerializeField] private Color[] activityColors;
        [SerializeField] private float[] ghostDistances;
        [SerializeField] private Image activityDisplay;
        [SerializeField] private float actionDelay;
        
        [SerializeField] private Transform _ghost;
        
        private void Start()
        {
            activityDisplay.color = activityColors[0];
            InvokeRepeating(nameof(ChangeDisplay), actionDelay, actionDelay);
        }

        private void ChangeDisplay()
        {
            if (InHand == false) return;

            float distance = Vector3.Distance(transform.position, _ghost.transform.position);
            print(distance);
            int colorIndex = ArrayUtility.RangeIndex(distance, ghostDistances);
            activityDisplay.color = activityColors[colorIndex];
        }
    }
}