using VContainer;
using VContainer.Unity;

namespace Game
{
    public sealed class TurnPipelineInstaller : IInitializable
    {
        private readonly TurnPipeline _turnPipeline;
        private readonly IObjectResolver _objectResolver;

        public TurnPipelineInstaller(TurnPipeline turnPipeline, IObjectResolver objectResolver)
        {
            _turnPipeline = turnPipeline;
            _objectResolver = objectResolver;
        }

        void IInitializable.Initialize()
        {
            _turnPipeline.AddTask(_objectResolver.CreateInstance<SelectUnitTask>());
            _turnPipeline.AddTask(_objectResolver.CreateInstance<SelectEnemyUnitTask>());
            _turnPipeline.AddTask(_objectResolver.CreateInstance<StartVisualPipelineTask>());
            _turnPipeline.AddTask(_objectResolver.CreateInstance<FinishTask>());
        }
    }
}