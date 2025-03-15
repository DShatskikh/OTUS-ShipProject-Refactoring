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
    public static class MoveAPI
    {
        ///Keys
        public const int Root = 1; // Transform
        public const int MoveSpeed = 2; // ReactiveVariable<float>
        public const int MoveDirection = 3; // IReactiveVariable<Vector3>


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Transform GetRoot(this IEntity obj) => obj.GetValue<Transform>(Root);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetRoot(this IEntity obj, out Transform value) => obj.TryGetValue(Root, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddRoot(this IEntity obj, Transform value) => obj.AddValue(Root, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasRoot(this IEntity obj) => obj.HasValue(Root);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelRoot(this IEntity obj) => obj.DelValue(Root);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetRoot(this IEntity obj, Transform value) => obj.SetValue(Root, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<float> GetMoveSpeed(this IEntity obj) => obj.GetValue<ReactiveVariable<float>>(MoveSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetMoveSpeed(this IEntity obj, out ReactiveVariable<float> value) => obj.TryGetValue(MoveSpeed, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddMoveSpeed(this IEntity obj, ReactiveVariable<float> value) => obj.AddValue(MoveSpeed, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasMoveSpeed(this IEntity obj) => obj.HasValue(MoveSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelMoveSpeed(this IEntity obj) => obj.DelValue(MoveSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetMoveSpeed(this IEntity obj, ReactiveVariable<float> value) => obj.SetValue(MoveSpeed, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IReactiveVariable<Vector3> GetMoveDirection(this IEntity obj) => obj.GetValue<IReactiveVariable<Vector3>>(MoveDirection);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetMoveDirection(this IEntity obj, out IReactiveVariable<Vector3> value) => obj.TryGetValue(MoveDirection, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddMoveDirection(this IEntity obj, IReactiveVariable<Vector3> value) => obj.AddValue(MoveDirection, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasMoveDirection(this IEntity obj) => obj.HasValue(MoveDirection);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelMoveDirection(this IEntity obj) => obj.DelValue(MoveDirection);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetMoveDirection(this IEntity obj, IReactiveVariable<Vector3> value) => obj.SetValue(MoveDirection, value);
    }
}
