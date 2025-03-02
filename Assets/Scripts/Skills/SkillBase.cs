using UnityEngine;

namespace Game
{
    public abstract class SkillBase : ScriptableObject
    {
        public abstract void Activate(UnitsManager manager, VisualPipeline visualPipeline, EventBus eventBus);
    }
}