/**
* Code generation. Don't modify! 
**/

using UnityEngine;
using Atomic.Contexts;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem;
using Atomic.Entities;

namespace Atomic.Contexts
{
	public static class ServicesAPI
	{
		///Keys
		public const int Player = 2; // SceneEntity
		public const int IsPlaying = 1; // BoolSerialize


		///Extensions
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SceneEntity GetPlayer(this IContext obj) => obj.ResolveValue<SceneEntity>(Player);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetPlayer(this IContext obj, out SceneEntity value) => obj.TryResolveValue(Player, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddPlayer(this IContext obj, SceneEntity value) => obj.AddValue(Player, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelPlayer(this IContext obj) => obj.DelValue(Player);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetPlayer(this IContext obj, SceneEntity value) => obj.SetValue(Player, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasPlayer(this IContext obj) => obj.HasValue(Player);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static BoolSerialize GetIsPlaying(this IContext obj) => obj.ResolveValue<BoolSerialize>(IsPlaying);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetIsPlaying(this IContext obj, out BoolSerialize value) => obj.TryResolveValue(IsPlaying, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddIsPlaying(this IContext obj, BoolSerialize value) => obj.AddValue(IsPlaying, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelIsPlaying(this IContext obj) => obj.DelValue(IsPlaying);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetIsPlaying(this IContext obj, BoolSerialize value) => obj.SetValue(IsPlaying, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasIsPlaying(this IContext obj) => obj.HasValue(IsPlaying);
    }
}
