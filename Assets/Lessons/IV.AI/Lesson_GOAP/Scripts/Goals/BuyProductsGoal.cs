using AI.GOAP;
using UnityEngine;

namespace Lessons.AI.Lesson_GOAP
{
    public sealed class BuyProductsGoal : Goal
    {
        [SerializeField]
        private int priority = 5;

        public override bool IsValid()
        {
            return true;
        }

        public override int EvaluatePriority()
        {
            return this.priority;
        }
    }
}