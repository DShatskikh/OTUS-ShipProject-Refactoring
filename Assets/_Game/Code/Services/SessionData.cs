using System;
using System.Collections.Generic;

namespace Game
{
    [Serializable]
    public struct SessionData
    {
        public string StartGameTime;
        public string ExitGameTime;
    }
    
    [Serializable]
    public class AllSessionsData
    {
        public List<SessionData> SessionsData = new();
    }
}