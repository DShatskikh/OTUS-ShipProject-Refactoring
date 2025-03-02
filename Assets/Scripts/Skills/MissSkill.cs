using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "MissSkill", menuName = "Skills/MissSkill", order = 102)]
    public sealed class MissSkill : SkillBase
    {
        public override void Activate(UnitsManager manager, VisualPipeline visualPipeline, EventBus eventBus)
        {
            eventBus.RaiseEvent(new DamageEvent(manager.GetSelectEnemyUnit, manager.GetSelectUnit.GetAttack));
            
            visualPipeline.AddTask(
                new DamageVisualTask(manager.GetSelectUnit, manager.GetSelectEnemyUnit, manager));
        }
    }
}