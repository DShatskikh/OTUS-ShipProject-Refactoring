using UnityEngine;

namespace Game
{
    public struct SoundPlayEvent : IEvent
    {
        public AudioClip Sound;

        public SoundPlayEvent(AudioClip sound)
        {
            Sound = sound;
        }
    }
}