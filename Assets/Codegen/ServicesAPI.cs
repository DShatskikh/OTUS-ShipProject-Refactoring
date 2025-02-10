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
		public const int PlayerInput = 1; // PlayerInput
		public const int Player = 2; // SceneEntity


		///Extensions
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static PlayerInput GetPlayerInput(this IContext obj) => obj.ResolveValue<PlayerInput>(PlayerInput);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetPlayerInput(this IContext obj, out PlayerInput value) => obj.TryResolveValue(PlayerInput, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddPlayerInput(this IContext obj, PlayerInput value) => obj.AddValue(PlayerInput, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelPlayerInput(this IContext obj) => obj.DelValue(PlayerInput);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetPlayerInput(this IContext obj, PlayerInput value) => obj.SetValue(PlayerInput, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasPlayerInput(this IContext obj) => obj.HasValue(PlayerInput);

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
    }
}
