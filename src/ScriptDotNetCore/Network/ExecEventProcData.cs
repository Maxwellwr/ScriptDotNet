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

        public ExecEventProcData(byte eventCode, EventTypes eventType, ArrayList param)
        {
            EventCode = eventCode;
            EventType = eventType;
            Parameters = param;
        }

        public byte EventCode { get; private set; }
        public EventTypes EventType { get; private set; }
        public ArrayList Parameters { get; private set; }
    }
}
