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
    public static class RotateAPI
    {
        ///Keys
        public const int RotateDirection = 4; // ReactiveVariable<Vector3>
        public const int RotateSpeed = 5; // ReactiveVariable<float>
        public const int VIsualRoot = 6; // Transform


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<Vector3> GetRotateDirection(this IEntity obj) => obj.GetValue<ReactiveVariable<Vector3>>(RotateDirection);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetRotateDirection(this IEntity obj, out ReactiveVariable<Vector3> value) => obj.TryGetValue(RotateDirection, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddRotateDirection(this IEntity obj, ReactiveVariable<Vector3> value) => obj.AddValue(RotateDirection, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasRotateDirection(this IEntity obj) => obj.HasValue(RotateDirection);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelRotateDirection(this IEntity obj) => obj.DelValue(RotateDirection);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetRotateDirection(this IEntity obj, ReactiveVariable<Vector3> value) => obj.SetValue(RotateDirection, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<float> GetRotateSpeed(this IEntity obj) => obj.GetValue<ReactiveVariable<float>>(RotateSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetRotateSpeed(this IEntity obj, out ReactiveVariable<float> value) => obj.TryGetValue(RotateSpeed, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddRotateSpeed(this IEntity obj, ReactiveVariable<float> value) => obj.AddValue(RotateSpeed, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasRotateSpeed(this IEntity obj) => obj.HasValue(RotateSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelRotateSpeed(this IEntity obj) => obj.DelValue(RotateSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetRotateSpeed(this IEntity obj, ReactiveVariable<float> value) => obj.SetValue(RotateSpeed, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Transform GetVIsualRoot(this IEntity obj) => obj.GetValue<Transform>(VIsualRoot);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetVIsualRoot(this IEntity obj, out Transform value) => obj.TryGetValue(VIsualRoot, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddVIsualRoot(this IEntity obj, Transform value) => obj.AddValue(VIsualRoot, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasVIsualRoot(this IEntity obj) => obj.HasValue(VIsualRoot);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelVIsualRoot(this IEntity obj) => obj.DelValue(VIsualRoot);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetVIsualRoot(this IEntity obj, Transform value) => obj.SetValue(VIsualRoot, value);
    }
}
