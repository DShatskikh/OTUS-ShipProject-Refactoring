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
    public static class LifeAPI
    {
        ///Keys
        public const int HitPoints = 10; // ReactiveInt
        public const int Damage = 11; // ReactiveInt
        public const int IsDead = 12; // ReactiveBool
        public const int TakeDamageAction = 13; // AtomicEvent<int>


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveInt GetHitPoints(this IEntity obj) => obj.GetValue<ReactiveInt>(HitPoints);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetHitPoints(this IEntity obj, out ReactiveInt value) => obj.TryGetValue(HitPoints, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddHitPoints(this IEntity obj, ReactiveInt value) => obj.AddValue(HitPoints, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasHitPoints(this IEntity obj) => obj.HasValue(HitPoints);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelHitPoints(this IEntity obj) => obj.DelValue(HitPoints);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetHitPoints(this IEntity obj, ReactiveInt value) => obj.SetValue(HitPoints, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveInt GetDamage(this IEntity obj) => obj.GetValue<ReactiveInt>(Damage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetDamage(this IEntity obj, out ReactiveInt value) => obj.TryGetValue(Damage, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddDamage(this IEntity obj, ReactiveInt value) => obj.AddValue(Damage, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasDamage(this IEntity obj) => obj.HasValue(Damage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelDamage(this IEntity obj) => obj.DelValue(Damage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetDamage(this IEntity obj, ReactiveInt value) => obj.SetValue(Damage, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveBool GetIsDead(this IEntity obj) => obj.GetValue<ReactiveBool>(IsDead);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetIsDead(this IEntity obj, out ReactiveBool value) => obj.TryGetValue(IsDead, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddIsDead(this IEntity obj, ReactiveBool value) => obj.AddValue(IsDead, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasIsDead(this IEntity obj) => obj.HasValue(IsDead);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelIsDead(this IEntity obj) => obj.DelValue(IsDead);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetIsDead(this IEntity obj, ReactiveBool value) => obj.SetValue(IsDead, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AtomicEvent<int> GetTakeDamageAction(this IEntity obj) => obj.GetValue<AtomicEvent<int>>(TakeDamageAction);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetTakeDamageAction(this IEntity obj, out AtomicEvent<int> value) => obj.TryGetValue(TakeDamageAction, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddTakeDamageAction(this IEntity obj, AtomicEvent<int> value) => obj.AddValue(TakeDamageAction, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasTakeDamageAction(this IEntity obj) => obj.HasValue(TakeDamageAction);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelTakeDamageAction(this IEntity obj) => obj.DelValue(TakeDamageAction);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetTakeDamageAction(this IEntity obj, AtomicEvent<int> value) => obj.SetValue(TakeDamageAction, value);
    }
}
