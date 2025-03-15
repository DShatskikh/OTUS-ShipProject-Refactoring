using System;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Lesson19_EventBus
{
    public class EventBus
    {
        private readonly Dictionary<Type, IEventHandlerCollection> _handlers = new();

        public void RaiseEvent<TEvent>(TEvent evt)
        {
            var key = evt.GetType();
            Debug.Log($"Raise event {key}");

            if (_handlers.TryGetValue(key, out var handlers))
            {
                handlers.RaiseEvent(evt);
            }
        }

        public void Subscribe<TEvent>(Action<TEvent> handler)
        {
            var key = typeof(TEvent);

            if (!_handlers.ContainsKey(key))
            {
                _handlers[key] = new EventHandlerCollection<TEvent>();
            }
            
            _handlers[key].Subscribe(handler);
        }

        public void Unsubscribe<TEvent>(Action<TEvent> handler)
        {
            var key = typeof(TEvent);
            
            if (_handlers.TryGetValue(key, out var handlers))
            {
                handlers.Unsubscribe(handler);
            }
        }
    }
    
    public class EventHandlerCollection<T> : IEventHandlerCollection
    {
        private readonly List<Delegate> _handlers = new();
        
        private int _currentIndex = -1;

        public void Subscribe<TEvent>(Action<TEvent> handler)
        {
            _handlers.Add(handler);
        }

        public void Unsubscribe<TEvent>(Action<TEvent> handler)
        {
            var index = _handlers.IndexOf(handler);

            if (index < _currentIndex)
            {
                _currentIndex--;
            }
                
            _handlers.RemoveAt(index);
        }

        public void RaiseEvent<TEvent>(TEvent evt)
        {
            if (evt is not T concreteEvent)
            {
                return;
            }
            
            for (_currentIndex = 0; _currentIndex < _handlers.Count; _currentIndex++)
            {
                var action = (Action<T>)_handlers[_currentIndex];
                action.Invoke(concreteEvent);
            }
            
            _currentIndex = -1;
        }
    }

    public interface IEventHandlerCollection
    {
        void Subscribe<TEvent>(Action<TEvent> handler);
        void Unsubscribe<TEvent>(Action<TEvent> handler);
        void RaiseEvent<TEvent>(TEvent evt);
    }
}