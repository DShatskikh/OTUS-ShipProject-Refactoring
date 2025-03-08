using UnityEngine;

namespace Game
{
    public sealed class StartVisualPipelineTask : EventTask
    {
        private readonly VisualPipeline _visualPipeline;

        public StartVisualPipelineTask(VisualPipeline visualPipeline)
        {
            _visualPipeline = visualPipeline;
        }

        protected override void OnRun()
        {
            Debug.Log("Начало отрисовки");
            _visualPipeline.OnFinished += OnFinishedPipeline;
            _visualPipeline.RunNextTask();
        }

        protected override void OnFinish()
        {
            _visualPipeline.OnFinished -= OnFinishedPipeline;
        }

        private void OnFinishedPipeline()
        {
            Debug.Log("Конец отрисовки");
            _visualPipeline.ClearAll();
            Finish();
        }
    }
}