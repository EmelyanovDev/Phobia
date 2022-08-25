using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(fileName = "GhostSettings", menuName = "Settings")]
    
    public class GhostSettings : ScriptableObject
    {
        [SerializeField] private AnimationCurve attackCurve;
        [SerializeField] private AnimationCurve difficultCurve;
        [SerializeField] private float attackPeriod;
        [SerializeField] private float maximumAttackChance;
        [SerializeField] private float maximumDifficult;
        [SerializeField] private Vector2 standingTimeRange;

        public AnimationCurve AttackCurve => attackCurve;
        public AnimationCurve DifficultCurve => difficultCurve;
        public float AttackPeriod => attackPeriod;
        public float MaximumAttackChance => maximumAttackChance;
        public float MaximumDifficult => maximumDifficult;
        public Vector2 StandingTimeRange => standingTimeRange;
    }
}