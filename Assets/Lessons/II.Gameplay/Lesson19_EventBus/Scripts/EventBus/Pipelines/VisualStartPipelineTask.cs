using UnityEngine;
using VContainer;

namespace Lessons.Lesson19_EventBus
{
    public class VisualStartPipelineTask : EventTask
    {
        private VisualPipeline _visualPipeline;

        [Inject]
        public void Construct(VisualPipeline visualPipeline)
        {
            _visualPipeline = visualPipeline;
        }
        
        protected override void OnStart()
        {
            Debug.Log("Start visual pipeline task");
            _visualPipeline.OnCompleted += OnPipelineCompleted;
            _visualPipeline.Reset();
            _visualPipeline.Run();
        }

        private void OnPipelineCompleted()
        {
            _visualPipeline.OnCompleted -= OnPipelineCompleted;
            _visualPipeline.ClearTasks();
            Complete();
        }
    }
}