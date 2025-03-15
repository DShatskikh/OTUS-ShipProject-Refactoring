/**
* Code generation. Don't modify! 
**/

using UnityEngine;
using Atomic.Contexts;
using System.Runtime.CompilerServices;
using Lessons.Lesson_AtomicFramework;

namespace Atomic.Contexts
{
	public static class GameAPI
	{
		///Keys
		public const int MoveController = 1; // Lessons.Lesson_AtomicFramework.MoveController


		///Extensions
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Lessons.Lesson_AtomicFramework.MoveController GetMoveController(this IContext obj) => obj.ResolveValue<Lessons.Lesson_AtomicFramework.MoveController>(MoveController);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveController(this IContext obj, out Lessons.Lesson_AtomicFramework.MoveController value) => obj.TryResolveValue(MoveController, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddMoveController(this IContext obj, Lessons.Lesson_AtomicFramework.MoveController value) => obj.AddValue(MoveController, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveController(this IContext obj) => obj.DelValue(MoveController);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveController(this IContext obj, Lessons.Lesson_AtomicFramework.MoveController value) => obj.SetValue(MoveController, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveController(this IContext obj) => obj.HasValue(MoveController);
    }
}
