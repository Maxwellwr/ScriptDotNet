// -----------------------------------------------------------------------
// <copyright file="GumpTextEntryEventArgs.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace ScriptDotNet
{
    public class GumpTextEntryEventArgs : EventArgs
    {
        public GumpTextEntryEventArgs(uint gumpTextEntryId, string title, byte inputStyle, uint maxValue, string title2)
        {
            GumpTextEntryID = gumpTextEntryId;
            Title = title;
            InputStyle = inputStyle;
            MaxValue = maxValue;
            Title2 = title2;
        }

        public uint GumpTextEntryID { get; private set; }

        public string Title { get; set; }

        public byte InputStyle { get; set; }

        public uint MaxValue { get; set; }

        public string Title2 { get; set; }
    }
}
