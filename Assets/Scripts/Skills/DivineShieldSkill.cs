using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "DivineShieldSkill", menuName = "Skills/DivineShieldSkill", order = 100)]
    public sealed class DivineShieldSkill : SkillBase
    {
        public override void Activate(UnitsManager manager, VisualPipeline visualPipeline, EventBus eventBus)
        {
            eventBus.RaiseEvent(new DamageEvent(manager.GetSelectEnemyUnit, manager.GetSelectUnit.GetAttack));
            manager.GetSelectEnemyUnit.RemoveSkill();
            
            visualPipeline.AddTask(
                new DamageVisualTask(manager.GetSelectUnit, manager.GetSelectEnemyUnit, manager));
        }
    }
}