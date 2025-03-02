using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

namespace Game
{
    public class TurnPipelineRunner : MonoBehaviour
    {
        private TurnPipeline _pipeline;
        
        [Inject]
        public void Construct(TurnPipeline pipeline)
        {
            _pipeline = pipeline;
        }
        
        private void Start()
        {
            _pipeline.OnFinished += OnFinished;
            Run();
        }

        private void OnFinished()
        {
            _pipeline.Reset();
            _pipeline.RunNextTask();
        }

        [Button]
        public void Run()
        {
            _pipeline.RunNextTask();
        }
    }
}