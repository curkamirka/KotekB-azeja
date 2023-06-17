using Sim;
using UnityEngine;

namespace DefaultNamespace
{
    public class ActionResolverTargetController : MonoBehaviour
    {
        [SerializeField] private NeedType needType;

        public NeedType NeedType => needType;
    }
}