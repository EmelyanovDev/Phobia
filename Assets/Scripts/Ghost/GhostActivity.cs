using UnityEngine;

namespace Ghost
{
    public class GhostActivity : MonoBehaviour
    {
        [SerializeField] private AnimationCurve activityCurve;
        [SerializeField] private float activityPeriod;
        [SerializeField] private float maximumActivity;

        private float _activityTime;

        private void Update() => CountTime();

        private void CountTime()
        {
            _activityTime += Time.deltaTime;
            if (_activityTime >= activityPeriod)
                _activityTime = 0;
        }

        public float GetActivity()
        {
            float curveValue = _activityTime / activityPeriod;
            return activityCurve.Evaluate(curveValue) * maximumActivity;
        }
    }
}   