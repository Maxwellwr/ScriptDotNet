namespace ScriptDotNet
{
    public class StartStopEventArgs
    {
        public StartStopEventArgs(bool isStopped)
        {
            IsStopped = isStopped;
        }
        public bool IsStopped { get; private set; }
    }


}
