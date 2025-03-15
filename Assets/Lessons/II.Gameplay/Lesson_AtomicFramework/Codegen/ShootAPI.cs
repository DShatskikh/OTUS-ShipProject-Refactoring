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
    public static class ShootAPI
    {
        ///Keys
        public const int ShootAction = 7; // AtomicEvent
        public const int DetectRadius = 8; // ReactiveFloat
        public const int TargetPoint = 9; // ReactiveVariable<Transform>
        public const int ShootRequest = 15; // AtomicEvent
        public const int FirePoint = 17; // Transform


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AtomicEvent GetShootAction(this IEntity obj) => obj.GetValue<AtomicEvent>(ShootAction);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetShootAction(this IEntity obj, out AtomicEvent value) => obj.TryGetValue(ShootAction, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddShootAction(this IEntity obj, AtomicEvent value) => obj.AddValue(ShootAction, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasShootAction(this IEntity obj) => obj.HasValue(ShootAction);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelShootAction(this IEntity obj) => obj.DelValue(ShootAction);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetShootAction(this IEntity obj, AtomicEvent value) => obj.SetValue(ShootAction, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveFloat GetDetectRadius(this IEntity obj) => obj.GetValue<ReactiveFloat>(DetectRadius);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetDetectRadius(this IEntity obj, out ReactiveFloat value) => obj.TryGetValue(DetectRadius, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddDetectRadius(this IEntity obj, ReactiveFloat value) => obj.AddValue(DetectRadius, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasDetectRadius(this IEntity obj) => obj.HasValue(DetectRadius);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelDetectRadius(this IEntity obj) => obj.DelValue(DetectRadius);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetDetectRadius(this IEntity obj, ReactiveFloat value) => obj.SetValue(DetectRadius, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<Transform> GetTargetPoint(this IEntity obj) => obj.GetValue<ReactiveVariable<Transform>>(TargetPoint);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetTargetPoint(this IEntity obj, out ReactiveVariable<Transform> value) => obj.TryGetValue(TargetPoint, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddTargetPoint(this IEntity obj, ReactiveVariable<Transform> value) => obj.AddValue(TargetPoint, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasTargetPoint(this IEntity obj) => obj.HasValue(TargetPoint);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelTargetPoint(this IEntity obj) => obj.DelValue(TargetPoint);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetTargetPoint(this IEntity obj, ReactiveVariable<Transform> value) => obj.SetValue(TargetPoint, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AtomicEvent GetShootRequest(this IEntity obj) => obj.GetValue<AtomicEvent>(ShootRequest);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetShootRequest(this IEntity obj, out AtomicEvent value) => obj.TryGetValue(ShootRequest, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddShootRequest(this IEntity obj, AtomicEvent value) => obj.AddValue(ShootRequest, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasShootRequest(this IEntity obj) => obj.HasValue(ShootRequest);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelShootRequest(this IEntity obj) => obj.DelValue(ShootRequest);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetShootRequest(this IEntity obj, AtomicEvent value) => obj.SetValue(ShootRequest, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Transform GetFirePoint(this IEntity obj) => obj.GetValue<Transform>(FirePoint);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetFirePoint(this IEntity obj, out Transform value) => obj.TryGetValue(FirePoint, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddFirePoint(this IEntity obj, Transform value) => obj.AddValue(FirePoint, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasFirePoint(this IEntity obj) => obj.HasValue(FirePoint);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelFirePoint(this IEntity obj) => obj.DelValue(FirePoint);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetFirePoint(this IEntity obj, Transform value) => obj.SetValue(FirePoint, value);
    }
}
