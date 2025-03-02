using System.Collections;
using UnityEngine;

namespace Game
{
    public class PlayerInputTask : EventTask
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public PlayerInputTask(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        protected override void OnRun()
        {
            _coroutineRunner.StartCoroutine(WaitMove());
        }

        protected override void OnFinish()
        {
            
        }

        private IEnumerator WaitMove()
        {
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.D));
            //_eventBus.RaiseEvent(new ApplyDirectionEvent(_player, direction));
            Finish();
        }
        
        private void OnMovePreformed(Vector2Int direction)
        {
            
        }
    }
}