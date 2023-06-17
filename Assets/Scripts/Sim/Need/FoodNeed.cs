using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

namespace Sim.Need
{
    public class FoodNeed : SimNeed
    {
        public override NeedType NeedType => NeedType.Food;

        public override void Resolve()
        {
            var closestSource = FindClosestSource();
            simController.InvokeSimNeed(NeedType, closestSource);
        }
    }
}