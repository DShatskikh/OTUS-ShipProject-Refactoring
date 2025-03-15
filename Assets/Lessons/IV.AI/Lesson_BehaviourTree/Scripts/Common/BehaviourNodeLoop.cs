using UnityEngine;

namespace Lessons.AI.LessonBehaviourTree
{
    public sealed class BehaviourNodeLoop : BehaviourNode, IBehaviourCallback
    {
        [SerializeField]
        private BehaviourNode child;
        
        protected override void Run()
        {
            this.child.Run(callback: this);
        }

        void IBehaviourCallback.OnComplete(BehaviourNode node, bool success)
        {
            this.child.Run(callback: this);
        }

        protected override void OnAbort()
        {
            if (this.child.IsRunning)
            {
                this.child.Abort();
            }
        }
    }
}