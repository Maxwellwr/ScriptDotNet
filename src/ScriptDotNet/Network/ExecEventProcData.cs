using ScriptDotNet2.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptDotNet2.Network
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
