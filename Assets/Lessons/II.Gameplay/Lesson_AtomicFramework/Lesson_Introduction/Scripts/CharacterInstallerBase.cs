using Atomic.Entities;
using UnityEngine;

namespace Lessons.Lesson_AtomicFramework
{
    public class CharacterInstallerBase : SceneEntityInstallerBase
    {
        [SerializeField] private CharacterInstaller _characterInstaller;
        
        public override void Install(IEntity entity)
        {
            entity.Install(_characterInstaller);
        }
    }
}