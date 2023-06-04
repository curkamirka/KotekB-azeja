using System;
using System.Collections.Generic;
using Sim.Need;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Sim
{
    public class SimController : MonoBehaviour
    {
        private enum SimState
        {
            Idle,
            Walking,
            Eating,
            Sleeping,
            LookingAt
        }

        [Serializable]
        private class SimNeedContainer
        {
            [SerializeField] private Slider slider;
            [SerializeField] private SimNeedData needData;

            public Slider Slider => slider;
            public SimNeedData NeedData => needData;
        }
        
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private Animator animator;
        [SerializeField] private List<SimNeedContainer> simNeedsData;

        private List<SimNeed> simNeeds;

        private Transform target;
        private SimState currentState;
        private SimState nextState;
        
        public void SetTarget(Transform target)
        {
            this.target = target;
            agent.SetDestination(target.position);
        }
        
        private void Start()
        {
            simNeeds = new List<SimNeed>();
            
            foreach (var needData in simNeedsData)
            {
                InitializeSimNeed(needData);
            }
        }

        private void InitializeSimNeed(SimNeedContainer needData)
        {
            var simNeed = CreateSimNeed(needData.NeedData.NeedType);
            simNeeds.Add(simNeed);
            
            simNeed.Initialize(needData.NeedData, needData.Slider, this);

            SimNeed CreateSimNeed(NeedType needType)
            {
                return needType switch
                {
                    NeedType.Food => new FoodNeed(),
                    NeedType.Sleep => new SleepNeed(),
                    NeedType.LookAtOwner => new LookAtOwnerNed(),
                    _ => throw new ArgumentOutOfRangeException(nameof(needType), needType, null)
                };
            }
        }

        private void Update()
        {
            foreach (var need in simNeeds)
            {
                need.Update();

                if (need.NeedsResolving)
                    need.Resolve();
            }

            HandleCurrentState();
        }

        private void HandleCurrentState()
        {
            switch (currentState)
            {
                case SimState.Walking:
                    if (DoWalk())
                    {
                        
                    }
                    
                    break;
            }
        }

        private bool DoWalk()
        {
            if (!agent.pathPending && agent.pathStatus == NavMeshPathStatus.PathComplete)
            {
                return agent.remainingDistance <= agent.stoppingDistance;
            }

            return false;
        }
    }
}
