using System.Collections;

namespace ScriptDotNet.Network
{
    public class ExecEventProcData
    {
        public ExecEventProcData()
        {

        }

        public ExecEventProcData(EventTypes eventType, ArrayList param)
        {
            EventType = eventType;
            Parameters = param;
        }

        public EventTypes EventType { get; private set; }
        public ArrayList Parameters { get; private set; }
    }
}
