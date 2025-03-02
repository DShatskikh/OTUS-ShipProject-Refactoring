using System.Collections;

namespace Game
{
    public interface ICoroutineRunner
    {
        void StartCoroutine(IEnumerator coroutine);
    }
}