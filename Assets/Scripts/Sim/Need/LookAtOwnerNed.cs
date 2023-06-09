﻿namespace Sim.Need
{
    public class LookAtOwnerNed : SimNeed
    {
        public override NeedType NeedType => NeedType.LookAtOwner;
        
        public override void Resolve()
        {
            var closestSource = FindClosestSource();
            simController.InvokeSimNeed(NeedType, closestSource);
        }
    }
}