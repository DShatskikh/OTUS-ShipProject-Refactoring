namespace Game
{
    public sealed class SoundPlayHandler : BaseHandler<SoundPlayEvent>
    {
        private readonly AudioPlayer _audioPlayer;

        public SoundPlayHandler(EventBus eventBus, AudioPlayer audioPlayer) : base(eventBus)
        {
            _audioPlayer = audioPlayer;
        }

        protected override void OnHandleEvent(SoundPlayEvent evt)
        {
            _audioPlayer.PlaySound(evt.Sound);
        }
    }
}