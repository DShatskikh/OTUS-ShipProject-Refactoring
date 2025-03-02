using System;

namespace Game
{
    public interface IEventHandlerCollection
    {
        void Subscribe<TEvent>(Action<TEvent> handler);
        void Unsubscribe<TEvent>(Action<TEvent> handler);
        void RaiseEvent<TEvent>(TEvent evt);
    }
}