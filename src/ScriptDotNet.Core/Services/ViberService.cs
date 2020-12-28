// -----------------------------------------------------------------------
// <copyright file="ViberService.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using ScriptDotNet.Network;

namespace ScriptDotNet.Services
{
    public class ViberService : BaseMessanger, IViberService
    {
        public ViberService(IStealthClient client, IEventSystemService eventSystemService)
            : base(client, eventSystemService)
        {
        }

        protected override MessangerType MessangerType => MessangerType.Viber;
    }
}
