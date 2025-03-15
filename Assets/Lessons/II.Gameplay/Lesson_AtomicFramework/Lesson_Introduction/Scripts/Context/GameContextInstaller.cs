using Atomic.Contexts;
using UnityEngine;

namespace Lessons.Lesson_AtomicFramework
{
    public class GameContextInstaller : SceneContextInstallerBase
    {
        [SerializeField] private MoveController _moveController;
        
        public override void Install(IContext context)
        {
            context.AddMoveController(_moveController);
            
            context.AddSystem(new MoveSystem());
        }
    }
    
    public class MoveSystem : IContextInit, IContextUpdate
    {
        void IContextInit.Init(IContext context)
        {
            Debug.Log("Init");
        }

        void IContextUpdate.Update(IContext context, float deltaTime)
        {
            Debug.Log("Update");
        }
    }
}