// -----------------------------------------------------------------------
// <copyright file="ExecEventProcData.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

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
