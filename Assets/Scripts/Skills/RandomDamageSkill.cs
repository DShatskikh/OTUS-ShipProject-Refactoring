using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "RandomDamageSkill", menuName = "Skills/RandomDamageSkill", order = 104)]
    public sealed class RandomDamageSkill : SkillBase
    {
        public override void Activate(UnitsManager manager, VisualPipeline visualPipeline, EventBus eventBus)
        {
            var enemyUnits = manager.GetTurnEnemyUnits;
            var randomUnit = enemyUnits[Random.Range(0, enemyUnits.Count)];
            manager.Turn(randomUnit);
            
            visualPipeline.AddTask(
                new DamageVisualTask(manager.GetSelectUnit, randomUnit, manager));
        }
    }
}