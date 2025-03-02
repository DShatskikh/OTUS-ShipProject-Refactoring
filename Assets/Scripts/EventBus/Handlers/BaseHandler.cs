using System;
using VContainer.Unity;

namespace Game
{
    public abstract class BaseHandler<TEvent> : IInitializable, IDisposable
    {
        private readonly EventBus EventBus;

        protected BaseHandler(EventBus eventBus)
        {
            EventBus = eventBus;
        }

        public void Initialize()
        {
            EventBus.Subscribe<TEvent>(OnHandleEvent);
        }

        public void Dispose()
        {
            EventBus.Unsubscribe<TEvent>(OnHandleEvent);
        }

        protected abstract void OnHandleEvent(TEvent evt);
    }
}