using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Lessons.Architecture.PM
{
    public static class ReactivePropertyExtensions {
        public static IDisposable SubscribeToText(this IObservable<string> source, TMP_Text text) {
            return source.SubscribeWithState(text, (x, t) => t.text = x);
        }

        public static IDisposable SubscribeToImage(this IReadOnlyReactiveProperty<Sprite> reactiveProperty, Image image)
        {
            return reactiveProperty.Subscribe(newSprite =>
            {
                if (newSprite != null)
                {
                    image.sprite = newSprite;
                }
            });
        }
        
        public static IDisposable SubscribeToReactiveProperty<T>(this IObservable<T> observable, ReactiveProperty<T> reactiveProperty) => 
            observable.Subscribe(value => reactiveProperty.Value = value);
    }
}