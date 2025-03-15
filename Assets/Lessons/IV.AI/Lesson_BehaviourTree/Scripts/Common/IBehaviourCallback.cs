namespace Lessons.AI.LessonBehaviourTree
{
    public interface IBehaviourCallback
    {
        void OnComplete(BehaviourNode node, bool success);
    }
}