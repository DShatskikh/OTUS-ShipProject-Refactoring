using System;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

namespace Lessons.Lesson19_EventBus
{
    public class TurnPipelineRunner : MonoBehaviour
    {
        [ShowInInspector]
        private TurnPipeline _turnPipeline;
        
        [Inject]
        public void Construct(TurnPipeline turnPipeline, IObjectResolver objectResolver)
        {
            _turnPipeline = turnPipeline;
            InstallPipeline(objectResolver);
            
            _turnPipeline.OnCompleted += OnPipelineCompleted;
        }

        private void Start()
        {
            RunPipeline();
        }

        private void OnPipelineCompleted()
        {
            RunPipeline();
        }

        private void InstallPipeline(IObjectResolver objectResolver)
        {
            _turnPipeline.AddTask(new StartTurnTask());

            var playerInputTask = new PlayerInputTask();
            objectResolver.Inject(playerInputTask);
            _turnPipeline.AddTask(playerInputTask);

            var startVisualPipelineTask = new VisualStartPipelineTask();
            objectResolver.Inject(startVisualPipelineTask);
            _turnPipeline.AddTask(startVisualPipelineTask);
            
            _turnPipeline.AddTask(new FinishTurnTask());
        }

        [Button]
        public void RunPipeline()
        {
            _turnPipeline.Reset();
            _turnPipeline.Run();
        }
    }
}