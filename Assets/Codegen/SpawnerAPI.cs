/**
* Code generation. Don't modify! 
**/

using UnityEngine;
using Atomic.Entities;
using System.Runtime.CompilerServices;
using Atomic.Elements;

namespace Atomic.Entities
{
    public static class SpawnerAPI
    {
        ///Keys
        public const int Prefab = 13; // SceneEntity
        public const int Points = 15; // Transform[]


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SceneEntity GetPrefab(this IEntity obj) => obj.GetValue<SceneEntity>(Prefab);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetPrefab(this IEntity obj, out SceneEntity value) => obj.TryGetValue(Prefab, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddPrefab(this IEntity obj, SceneEntity value) => obj.AddValue(Prefab, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasPrefab(this IEntity obj) => obj.HasValue(Prefab);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelPrefab(this IEntity obj) => obj.DelValue(Prefab);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetPrefab(this IEntity obj, SceneEntity value) => obj.SetValue(Prefab, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Transform[] GetPoints(this IEntity obj) => obj.GetValue<Transform[]>(Points);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetPoints(this IEntity obj, out Transform[] value) => obj.TryGetValue(Points, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddPoints(this IEntity obj, Transform[] value) => obj.AddValue(Points, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasPoints(this IEntity obj) => obj.HasValue(Points);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelPoints(this IEntity obj) => obj.DelValue(Points);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetPoints(this IEntity obj, Transform[] value) => obj.SetValue(Points, value);
    }
}
