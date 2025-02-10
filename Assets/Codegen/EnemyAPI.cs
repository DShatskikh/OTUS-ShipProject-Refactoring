/**
* Code generation. Don't modify! 
**/

using UnityEngine;
using Atomic.Entities;
using System.Runtime.CompilerServices;
using Atomic.Elements;

namespace Atomic.Entities
{
    public static class EnemyAPI
    {
        ///Keys
        public const int Target = 6; // Transform


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Transform GetTarget(this IEntity obj) => obj.GetValue<Transform>(Target);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetTarget(this IEntity obj, out Transform value) => obj.TryGetValue(Target, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddTarget(this IEntity obj, Transform value) => obj.AddValue(Target, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasTarget(this IEntity obj) => obj.HasValue(Target);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelTarget(this IEntity obj) => obj.DelValue(Target);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetTarget(this IEntity obj, Transform value) => obj.SetValue(Target, value);
    }
}
