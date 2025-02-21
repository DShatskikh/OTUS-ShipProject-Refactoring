/**
* Code generation. Don't modify! 
**/

using UnityEngine;
using Atomic.Entities;
using System.Runtime.CompilerServices;
using Atomic.Elements;

namespace Atomic.Entities
{
    public static class PlayerAPI
    {
        ///Keys
        public const int InputDirection = 1; // Vector2
        public const int RootVisual = 2; // Transform
        public const int Root = 3; // Transform
        public const int MoveSpeed = 4; // float
        public const int RotationSpeed = 5; // float
        public const int Animator = 7; // Animator
        public const int IsShot = 8; // bool
        public const int AnimatorDispatcher = 9; // AnimatorDispatcher
        public const int Ammo = 10; // ReactiveInt
        public const int MaxAmmo = 11; // int
        public const int HitPoints = 12; // ReactiveInt
        public const int Kills = 14; // ReactiveInt
        public const int ShotCooldown = 16; // float
        public const int IsShotPress = 17; // ReactiveBool
        public const int SeePoint = 18; // Vector3
        public const int DamageRequest = 19; // BaseEvent<int>
        public const int DamageVFX = 20; // ParticleSystem
        public const int DamageSoundPlayer = 21; // AudioSource


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 GetInputDirection(this IEntity obj) => obj.GetValue<Vector2>(InputDirection);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetInputDirection(this IEntity obj, out Vector2 value) => obj.TryGetValue(InputDirection, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddInputDirection(this IEntity obj, Vector2 value) => obj.AddValue(InputDirection, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasInputDirection(this IEntity obj) => obj.HasValue(InputDirection);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelInputDirection(this IEntity obj) => obj.DelValue(InputDirection);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInputDirection(this IEntity obj, Vector2 value) => obj.SetValue(InputDirection, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Transform GetRootVisual(this IEntity obj) => obj.GetValue<Transform>(RootVisual);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetRootVisual(this IEntity obj, out Transform value) => obj.TryGetValue(RootVisual, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddRootVisual(this IEntity obj, Transform value) => obj.AddValue(RootVisual, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasRootVisual(this IEntity obj) => obj.HasValue(RootVisual);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelRootVisual(this IEntity obj) => obj.DelValue(RootVisual);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetRootVisual(this IEntity obj, Transform value) => obj.SetValue(RootVisual, value);

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
        public static float GetMoveSpeed(this IEntity obj) => obj.GetValue<float>(MoveSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetMoveSpeed(this IEntity obj, out float value) => obj.TryGetValue(MoveSpeed, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddMoveSpeed(this IEntity obj, float value) => obj.AddValue(MoveSpeed, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasMoveSpeed(this IEntity obj) => obj.HasValue(MoveSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelMoveSpeed(this IEntity obj) => obj.DelValue(MoveSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetMoveSpeed(this IEntity obj, float value) => obj.SetValue(MoveSpeed, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float GetRotationSpeed(this IEntity obj) => obj.GetValue<float>(RotationSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetRotationSpeed(this IEntity obj, out float value) => obj.TryGetValue(RotationSpeed, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddRotationSpeed(this IEntity obj, float value) => obj.AddValue(RotationSpeed, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasRotationSpeed(this IEntity obj) => obj.HasValue(RotationSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelRotationSpeed(this IEntity obj) => obj.DelValue(RotationSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetRotationSpeed(this IEntity obj, float value) => obj.SetValue(RotationSpeed, value);

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
        public static bool GetIsShot(this IEntity obj) => obj.GetValue<bool>(IsShot);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetIsShot(this IEntity obj, out bool value) => obj.TryGetValue(IsShot, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddIsShot(this IEntity obj, bool value) => obj.AddValue(IsShot, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasIsShot(this IEntity obj) => obj.HasValue(IsShot);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelIsShot(this IEntity obj) => obj.DelValue(IsShot);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetIsShot(this IEntity obj, bool value) => obj.SetValue(IsShot, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AnimatorDispatcher GetAnimatorDispatcher(this IEntity obj) => obj.GetValue<AnimatorDispatcher>(AnimatorDispatcher);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetAnimatorDispatcher(this IEntity obj, out AnimatorDispatcher value) => obj.TryGetValue(AnimatorDispatcher, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddAnimatorDispatcher(this IEntity obj, AnimatorDispatcher value) => obj.AddValue(AnimatorDispatcher, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasAnimatorDispatcher(this IEntity obj) => obj.HasValue(AnimatorDispatcher);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelAnimatorDispatcher(this IEntity obj) => obj.DelValue(AnimatorDispatcher);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetAnimatorDispatcher(this IEntity obj, AnimatorDispatcher value) => obj.SetValue(AnimatorDispatcher, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveInt GetAmmo(this IEntity obj) => obj.GetValue<ReactiveInt>(Ammo);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetAmmo(this IEntity obj, out ReactiveInt value) => obj.TryGetValue(Ammo, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddAmmo(this IEntity obj, ReactiveInt value) => obj.AddValue(Ammo, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasAmmo(this IEntity obj) => obj.HasValue(Ammo);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelAmmo(this IEntity obj) => obj.DelValue(Ammo);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetAmmo(this IEntity obj, ReactiveInt value) => obj.SetValue(Ammo, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetMaxAmmo(this IEntity obj) => obj.GetValue<int>(MaxAmmo);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetMaxAmmo(this IEntity obj, out int value) => obj.TryGetValue(MaxAmmo, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddMaxAmmo(this IEntity obj, int value) => obj.AddValue(MaxAmmo, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasMaxAmmo(this IEntity obj) => obj.HasValue(MaxAmmo);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelMaxAmmo(this IEntity obj) => obj.DelValue(MaxAmmo);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetMaxAmmo(this IEntity obj, int value) => obj.SetValue(MaxAmmo, value);

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
        public static ReactiveInt GetKills(this IEntity obj) => obj.GetValue<ReactiveInt>(Kills);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetKills(this IEntity obj, out ReactiveInt value) => obj.TryGetValue(Kills, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddKills(this IEntity obj, ReactiveInt value) => obj.AddValue(Kills, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasKills(this IEntity obj) => obj.HasValue(Kills);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelKills(this IEntity obj) => obj.DelValue(Kills);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetKills(this IEntity obj, ReactiveInt value) => obj.SetValue(Kills, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float GetShotCooldown(this IEntity obj) => obj.GetValue<float>(ShotCooldown);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetShotCooldown(this IEntity obj, out float value) => obj.TryGetValue(ShotCooldown, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddShotCooldown(this IEntity obj, float value) => obj.AddValue(ShotCooldown, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasShotCooldown(this IEntity obj) => obj.HasValue(ShotCooldown);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelShotCooldown(this IEntity obj) => obj.DelValue(ShotCooldown);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetShotCooldown(this IEntity obj, float value) => obj.SetValue(ShotCooldown, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveBool GetIsShotPress(this IEntity obj) => obj.GetValue<ReactiveBool>(IsShotPress);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetIsShotPress(this IEntity obj, out ReactiveBool value) => obj.TryGetValue(IsShotPress, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddIsShotPress(this IEntity obj, ReactiveBool value) => obj.AddValue(IsShotPress, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasIsShotPress(this IEntity obj) => obj.HasValue(IsShotPress);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelIsShotPress(this IEntity obj) => obj.DelValue(IsShotPress);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetIsShotPress(this IEntity obj, ReactiveBool value) => obj.SetValue(IsShotPress, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 GetSeePoint(this IEntity obj) => obj.GetValue<Vector3>(SeePoint);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetSeePoint(this IEntity obj, out Vector3 value) => obj.TryGetValue(SeePoint, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddSeePoint(this IEntity obj, Vector3 value) => obj.AddValue(SeePoint, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasSeePoint(this IEntity obj) => obj.HasValue(SeePoint);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelSeePoint(this IEntity obj) => obj.DelValue(SeePoint);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetSeePoint(this IEntity obj, Vector3 value) => obj.SetValue(SeePoint, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BaseEvent<int> GetDamageRequest(this IEntity obj) => obj.GetValue<BaseEvent<int>>(DamageRequest);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetDamageRequest(this IEntity obj, out BaseEvent<int> value) => obj.TryGetValue(DamageRequest, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddDamageRequest(this IEntity obj, BaseEvent<int> value) => obj.AddValue(DamageRequest, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasDamageRequest(this IEntity obj) => obj.HasValue(DamageRequest);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelDamageRequest(this IEntity obj) => obj.DelValue(DamageRequest);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetDamageRequest(this IEntity obj, BaseEvent<int> value) => obj.SetValue(DamageRequest, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ParticleSystem GetDamageVFX(this IEntity obj) => obj.GetValue<ParticleSystem>(DamageVFX);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetDamageVFX(this IEntity obj, out ParticleSystem value) => obj.TryGetValue(DamageVFX, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddDamageVFX(this IEntity obj, ParticleSystem value) => obj.AddValue(DamageVFX, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasDamageVFX(this IEntity obj) => obj.HasValue(DamageVFX);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelDamageVFX(this IEntity obj) => obj.DelValue(DamageVFX);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetDamageVFX(this IEntity obj, ParticleSystem value) => obj.SetValue(DamageVFX, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AudioSource GetDamageSoundPlayer(this IEntity obj) => obj.GetValue<AudioSource>(DamageSoundPlayer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetDamageSoundPlayer(this IEntity obj, out AudioSource value) => obj.TryGetValue(DamageSoundPlayer, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddDamageSoundPlayer(this IEntity obj, AudioSource value) => obj.AddValue(DamageSoundPlayer, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasDamageSoundPlayer(this IEntity obj) => obj.HasValue(DamageSoundPlayer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelDamageSoundPlayer(this IEntity obj) => obj.DelValue(DamageSoundPlayer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetDamageSoundPlayer(this IEntity obj, AudioSource value) => obj.SetValue(DamageSoundPlayer, value);
    }
}
