using System;
using VContainer.Unity;

namespace Lessons.Lesson19_EventBus
{
    public abstract class BaseEventHandler<TEvent> : IStartable, IDisposable
    {
        protected readonly EventBus EventBus;

        protected BaseEventHandler(EventBus eventBus)
        {
            EventBus = eventBus;
        }

        void IStartable.Start()
        {
            EventBus.Subscribe<TEvent>(OnEventInvoked);
        }

        void IDisposable.Dispose()
        {
            EventBus.Unsubscribe<TEvent>(OnEventInvoked);
        }

        protected abstract void OnEventInvoked(TEvent evt);
    }
}