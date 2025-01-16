using System;
using Atomic.Elements;
using Atomic.Entities;

namespace Lessons.Lesson_AtomicFramework
{
    [Serializable]
    public class EventInt_EntityInstaller : ValueEntityInstaller<BaseEvent<int>> { }
}