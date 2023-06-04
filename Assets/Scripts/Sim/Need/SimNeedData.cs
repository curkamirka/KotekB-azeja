using UnityEngine;

namespace Sim.Need
{
    [CreateAssetMenu(menuName = "Data/Sim Need Data")]
    public class SimNeedData : ScriptableObject
    {
        [SerializeField] private NeedType needType;
        [SerializeField] private float maxValue;
        [SerializeField] private float decrementValue;
        [SerializeField] private float reactionValue;

        public NeedType NeedType => needType;
        public float MaxValue => maxValue;
        public float DecrementValue => decrementValue;
        public float ReactionValue => reactionValue;
    }
}