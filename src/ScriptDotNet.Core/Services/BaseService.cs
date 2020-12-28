// -----------------------------------------------------------------------
// <copyright file="BaseService.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using ScriptDotNet.Network;

namespace ScriptDotNet.Services
{
    public abstract class BaseService
    {
        public BaseService(IStealthClient client)
        {
            Client = client;
        }

        protected IStealthClient Client { get; set; }
    }
}
