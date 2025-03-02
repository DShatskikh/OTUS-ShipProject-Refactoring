using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "VampirismSkill", menuName = "Skills/VampirismSkill", order = 105)]
    public sealed class VampirismSkill : SkillBase
    {
        [SerializeField]
        [Range(0, 100)]
        private int _chance = 50;
        
        public override void Activate(UnitsManager manager, VisualPipeline visualPipeline, EventBus eventBus)
        {
            var startHealth = manager.GetSelectUnit.GetHealth;
            manager.Turn();

            if (Random.Range(0, 100) <= _chance) 
                manager.GetSelectUnit.HealthAdd(manager.GetSelectEnemyUnit.GetAttack);

            visualPipeline.AddTask(
                new DamageVisualTask(manager.GetSelectUnit, manager.GetSelectEnemyUnit, manager));
        }
    }
}