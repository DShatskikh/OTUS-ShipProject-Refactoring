using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "FreezeSkill", menuName = "Skills/FreezeSkill", order = 101)]
    public sealed class FreezeSkill : SkillBase
    {
        public override void Activate(UnitsManager manager, VisualPipeline visualPipeline, EventBus eventBus)
        {
            Debug.Log("FreezeSkill");
            
            manager.Turn();
            manager.GetSelectEnemyUnit.SetFreeze(true);
            
            visualPipeline.AddTask(
                new DamageVisualTask(manager.GetSelectUnit, manager.GetSelectEnemyUnit, manager));
        }
    }
}