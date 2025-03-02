using UnityEngine;

namespace Game
{
    public sealed class AttackHandler : BaseHandler<AttackEvent>
    {
        private readonly UnitsManager _unitsManager;
        private readonly VisualPipeline _visualPipeline;
        private readonly EventBus _eventBus;

        public AttackHandler(EventBus eventBus, UnitsManager unitsManager, VisualPipeline visualPipeline) : base(eventBus)
        {
            _eventBus = eventBus;
            _unitsManager = unitsManager;
            _visualPipeline = visualPipeline;
        }

        protected override void OnHandleEvent(AttackEvent evt)
        {
            Debug.Log("Attack Handler");
            
            var skills = _unitsManager.GetSelectUnit.GetSkills;

            if (skills == null || skills.Count != 0)
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
        }
    }
}