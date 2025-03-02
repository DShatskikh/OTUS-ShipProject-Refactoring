namespace Game
{
    public class StartTask : EventTask
    {
        public StartTask()
        {
            
        }
        
        protected override void OnRun()
        {
            Finish();
        }
    }
}