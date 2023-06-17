using System;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using Sim.Need;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Sim
{
    public enum NeedType
    {
        Food,
        Sleep,
        LookAtOwner
    }
    
    [Serializable]
    public abstract class SimNeed
    {
        public abstract NeedType NeedType { get; }
        public bool NeedsResolving => currentValue <= needData.ReactionValue;

        private List<ActionResolverTargetController> actionResolverTargets;

        protected SimController simController;
        protected SimNeedData needData;
        protected Slider slider;
        protected float currentValue;

        public virtual void Initialize(SimNeedData needData, Slider slider, SimController simController)
        {
            this.simController = simController;
            this.needData = needData;
            this.slider = slider;
            
            currentValue = needData.MaxValue;
            UpdateSlider();

            actionResolverTargets = Object.FindObjectsOfType<ActionResolverTargetController>()
                .Where(x => x.NeedType == NeedType).ToList();

            simController.OnNeedFullfilled += SimController_OnNeedFullfilled;
        }

        private void SimController_OnNeedFullfilled(NeedType needType)
        {
            if (needType == NeedType)
                currentValue = needData.MaxValue;
        }

        public virtual void Update()
        {
            currentValue -= needData.DecrementValue;
            
            UpdateSlider();
        }

        public abstract void Resolve();

        protected Transform FindClosestSource()
        {
            return actionResolverTargets.OrderBy(x => Vector3.Distance(x.transform.position, simController.transform.position)).First().transform;
        }

        private void UpdateSlider()
        {
            slider.value = currentValue / needData.MaxValue;
        }
    }
}