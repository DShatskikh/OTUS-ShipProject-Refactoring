using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "RandomEnemyDamageSkill", menuName = "Skills/RandomEnemyDamageSkill", order = 103)]
    public sealed class RandomEnemyDamageSkill : SkillBase
    {
        [SerializeField]
        [Range(0, 100)]
        private int _chance = 50;
        
        public override void Activate(UnitsManager manager, VisualPipeline visualPipeline, EventBus eventBus)
        {
            var enemyUnits = manager.GetTurnEnemyUnits;
            var enemyUnit = Random.Range(0, 100) <= _chance 
                ? manager.GetSelectEnemyUnit : enemyUnits[Random.Range(0, enemyUnits.Count)];
            manager.Turn(enemyUnit);
            
            visualPipeline.AddTask(
                new DamageVisualTask(manager.GetSelectUnit, enemyUnit, manager));
        }
    }
}