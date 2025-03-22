using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public sealed class SessionTimeSystem
    {
        private DateTime _startGameTime;
        private AllSessionsData _allSessionsData = new();
        private int _currentIndex;

        public IEnumerable<SessionData> GetSessions => _allSessionsData.SessionsData;
        
        public SessionTimeSystem()
        {
            _startGameTime = DateTime.Now;
            Load();
        }

        public TimeSpan GetSessionTime() => 
            DateTime.Now - _startGameTime;
        
        public string GetTextTime()
        {
            return GetTextTime(GetSessionTime());
        }

        public static string GetTextTime(TimeSpan span) => 
            $"Время сессии: {span.Hours}:{span.Minutes}:{span.Seconds}";

        public static string GetTextTime(DateTime dateTime) => 
            $"Время сессии: {dateTime.Hour}:{dateTime.Minute}:{dateTime.Second}";
        
        public void Save()
        {
            if (_currentIndex >= _allSessionsData.SessionsData.Count)
            {
                _allSessionsData.SessionsData.Add(new SessionData()
                {
                    StartGameTime = _startGameTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    ExitGameTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                });

                _currentIndex = _allSessionsData.SessionsData.Count - 1;
            }
            else
            {
                var sessionData = _allSessionsData.SessionsData[_currentIndex];
                sessionData.ExitGameTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                _allSessionsData.SessionsData[_currentIndex] = sessionData;
            }

            var data = JsonUtility.ToJson(_allSessionsData);
            PlayerPrefs.SetString("Session", data);
            PlayerPrefs.Save();
        }

        private void Load()
        {
            var data = PlayerPrefs.GetString("Session");
            
            if (data == "")
                return;
            
            _allSessionsData = JsonUtility.FromJson<AllSessionsData>(data);
            _currentIndex = _allSessionsData.SessionsData.Count;
        }
    }
}