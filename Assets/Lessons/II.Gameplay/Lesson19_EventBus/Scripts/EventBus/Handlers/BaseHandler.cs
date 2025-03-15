using System;
using VContainer.Unity;

namespace Lessons.Lesson19_EventBus
{
    public abstract class BaseHandler<T> : IInitializable, IDisposable
    {
        protected readonly EventBus _eventBus;

        protected BaseHandler(EventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public void Initialize()
        {
            _eventBus.Subscribe<T>(OnRaiseEvent);
        }

        public void Dispose()
        {
            _eventBus.Unsubscribe<T>(OnRaiseEvent);
        }

        protected abstract void OnRaiseEvent(T evt);
    }
}