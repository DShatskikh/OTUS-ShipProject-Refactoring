namespace Lessons.Lesson19_EventBus
{
    public class MoveVisualHandler : BaseHandler<MoveEvent>
    {
        private readonly VisualPipeline _visualPipeline;
        private LevelMap _levelMap;

        public MoveVisualHandler(EventBus eventBus, VisualPipeline visualPipeline, LevelMap levelMap) : base(eventBus)
        {
            _visualPipeline = visualPipeline;
            _levelMap = levelMap;
        }

        protected override void OnRaiseEvent(MoveEvent evt)
        {
            var component = evt.Entity.Get<CoordinatesComponent>();
            var targetPosition = _levelMap.Tiles.CoordinatesToPosition(component.Value);

            // var coordinates = evt.Entity.Get<CoordinatesComponent>();
            // var targetCoordinates = coordinates.Value + evt.Direction;
            
            _visualPipeline.AddTask(new MoveVisualTask(evt.Entity, targetPosition));
        }
    }
}