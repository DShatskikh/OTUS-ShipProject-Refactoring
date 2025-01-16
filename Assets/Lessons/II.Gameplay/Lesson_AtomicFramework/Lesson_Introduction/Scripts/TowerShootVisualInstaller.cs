using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Lessons.Lesson_AtomicFramework
{
    public class TowerShootVisualInstaller : SceneEntityInstallerBase
    {
        public TowerShootAudioBehaviour ShootAudioBehaviour;
        
        public override void Install(IEntity entity)
        {
            entity.AddShootEvent(new BaseEvent());
            entity.AddBehaviour(ShootAudioBehaviour);
        }
    }
    
    [Serializable]
    public class TowerShootAudioBehaviour : IEntityInit
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;

        public void Init(IEntity entity)
        {
            entity.GetShootEvent().Subscribe(() =>
            {
                _audioSource.PlayOneShot(_audioClip);
            });
        }
    }
}