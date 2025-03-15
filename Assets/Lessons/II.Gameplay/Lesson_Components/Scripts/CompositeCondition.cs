using System;
using System.Collections.Generic;

namespace Lessons.Lesson_Components
{
    public class CompositeCondition : ICondition
    {
        private List<Func<bool>> _conditions = new();

        public void AppendCondition(Func<bool> condition)
        {
            _conditions.Add(condition);
        }

        public void RemoveCondition(Func<bool> condition)
        {
            _conditions.Remove(condition);
        }
        
        //условие && условие && условие && условие && ... 
        public bool Invoke()
        {
            for (int i = _conditions.Count - 1; i >= 0; i--)
            {
                if (_conditions[i].Invoke() == false)
                {
                    return false;
                }
            }

            return true;
        }
    }
}