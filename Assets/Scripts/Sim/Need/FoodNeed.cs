using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Sim.Need
{
    public class FoodNeed : SimNeed
    {
        public override NeedType NeedType => NeedType.Food;

        private List<Transform> foodSources;

        public override void Initialize(SimNeedData needData, Slider slider, SimController simController)
        {
            base.Initialize(needData, slider, simController);

            foodSources = new List<Transform>();
        }

        public override void Resolve()
        {
            var closestFoodSource = FindClosestFoodSource();
        }

        private Transform FindClosestFoodSource()
        {
            return foodSources.OrderBy(x => Vector3.Distance(x.position, simController.transform.position)).First();
        }
    }
}