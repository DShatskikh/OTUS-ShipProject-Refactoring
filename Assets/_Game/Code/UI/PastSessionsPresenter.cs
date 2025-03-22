using System;
using System.Linq;
using VContainer.Unity;

namespace Game
{
    public sealed class PastSessionsPresenter : IInitializable
    {
        private readonly PastSessionsView _view;
        private readonly SessionTimeSystem _sessionTimeSystem;

        public PastSessionsPresenter(PastSessionsView view, SessionTimeSystem sessionTimeSystem)
        {
            _view = view;
            _sessionTimeSystem = sessionTimeSystem;
        }

        public void Initialize()
        {
            var text = "Прошлые сессии:";
            var session = _sessionTimeSystem.GetSessions.ToArray();

            for (int i = 0; i < _sessionTimeSystem.GetSessions.Count(); i++)
            {
                var startTime = DateTime.ParseExact(session[i].StartGameTime, "yyyy-MM-dd HH:mm:ss", null);
                var endTime = DateTime.ParseExact(session[i].ExitGameTime, "yyyy-MM-dd HH:mm:ss", null);
                
                var startTimeText = SessionTimeSystem.GetTextTime(startTime);
                var endTimeText = SessionTimeSystem.GetTextTime(endTime);
                var substractText = SessionTimeSystem.GetTextTime(endTime - startTime);
                
                text += $"\n[{i}] Начало: {startTimeText} \nКонец: {endTimeText} \nВремя: {substractText}\n";
            }
            
            _view.SetText(text);
        }
    }
}