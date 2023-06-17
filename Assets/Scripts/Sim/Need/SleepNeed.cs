using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Sim.Need
{
    public class SleepNeed : SimNeed
    {
        public override NeedType NeedType => NeedType.Sleep;
        
        public override void Resolve()
        {
            var closestSource = FindClosestSource();
            simController.InvokeSimNeed(NeedType, closestSource);
        }
    }
}