using UnityEngine;

namespace Game
{
    public class AttackEnemyTask : EventTask
    {
        private readonly UnitsManager _unitsManager;
        private readonly VisualPipeline _visualPipeline;
        private readonly EventBus _eventBus;

        public AttackEnemyTask(UnitsManager unitsManager, VisualPipeline visualPipeline, EventBus eventBus)
        {
            _unitsManager = unitsManager;
            _visualPipeline = visualPipeline;
            _eventBus = eventBus;
        }
        
        protected override void OnRun()
        {
            Debug.Log("Атака");

            var skills = _unitsManager.GetSelectUnit.GetSkills;

            if (skills.Count == 0)
            {
                _unitsManager.Turn();
                _visualPipeline.AddTask(
                    new DamageVisualTask(_unitsManager.GetSelectUnit, _unitsManager.GetSelectEnemyUnit, _unitsManager));
            }
            else
            {
                foreach (var skill in skills) 
                    skill.Activate(_unitsManager, _visualPipeline, _eventBus);
            }
            
            Finish();
        }

        protected override void OnFinish()
        {
            Debug.Log("Смена стороны");
        }
    }
}