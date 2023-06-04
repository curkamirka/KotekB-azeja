using System;
using Sim.Need;
using UnityEngine;
using UnityEngine.UI;

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
        }
        
        public virtual void Update()
        {
            currentValue -= needData.DecrementValue;
            
            UpdateSlider();
        }

        public abstract void Resolve();

        private void UpdateSlider()
        {
            slider.value = currentValue / needData.MaxValue;
        }
    }
}