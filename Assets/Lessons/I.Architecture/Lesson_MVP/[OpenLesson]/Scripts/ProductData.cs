using System;
using UnityEngine;

namespace Lessons.I.Architecture.Lesson_MVP.OpenLesson
{
    [Serializable]
    public class ProductData
    {
        public string Description;
        public string Title;
        public int Price;
        public bool IsUnlock;
        public Sprite Icon;
    }
}