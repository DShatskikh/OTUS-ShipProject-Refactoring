/**
* Code generation. Don't modify! 
**/

using UnityEngine;
using Atomic.Entities;
using System.Runtime.CompilerServices;
using Atomic.Elements;
using Lessons.Lesson_AtomicFramework;

namespace Atomic.Entities
{
    public static class VisualAPI
    {
        ///Keys
        public const int Animator = 14; // Animator
        public const int AnimationDispatcher = 16; // AnimationDispatcher


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Animator GetAnimator(this IEntity obj) => obj.GetValue<Animator>(Animator);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetAnimator(this IEntity obj, out Animator value) => obj.TryGetValue(Animator, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddAnimator(this IEntity obj, Animator value) => obj.AddValue(Animator, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasAnimator(this IEntity obj) => obj.HasValue(Animator);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelAnimator(this IEntity obj) => obj.DelValue(Animator);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetAnimator(this IEntity obj, Animator value) => obj.SetValue(Animator, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AnimationDispatcher GetAnimationDispatcher(this IEntity obj) => obj.GetValue<AnimationDispatcher>(AnimationDispatcher);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetAnimationDispatcher(this IEntity obj, out AnimationDispatcher value) => obj.TryGetValue(AnimationDispatcher, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddAnimationDispatcher(this IEntity obj, AnimationDispatcher value) => obj.AddValue(AnimationDispatcher, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasAnimationDispatcher(this IEntity obj) => obj.HasValue(AnimationDispatcher);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelAnimationDispatcher(this IEntity obj) => obj.DelValue(AnimationDispatcher);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetAnimationDispatcher(this IEntity obj, AnimationDispatcher value) => obj.SetValue(AnimationDispatcher, value);
    }
}
