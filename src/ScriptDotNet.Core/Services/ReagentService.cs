// -----------------------------------------------------------------------
// <copyright file="ReagentService.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using ScriptDotNet.Network;

namespace ScriptDotNet.Services
{
    public class ReagentService : BaseService, IReagentService
    {
        public ReagentService(IStealthClient client, IObjectSearchService objectSearchService)
            : base(client)
        {
            ObjectSearchService = objectSearchService;
        }

        public IObjectSearchService ObjectSearchService { get; private set; }

        public int BMCount
        {
            get
            {
                ObjectSearchService.FindTypeEx((ushort)Reagents.BM, 0x0000, ObjectSearchService.Backpack, true);
                return ObjectSearchService.FindFullQuantity;
            }
        }

        public int BPCount
        {
            get
            {
                ObjectSearchService.FindTypeEx((ushort)Reagents.BP, 0x0000, ObjectSearchService.Backpack, true);
                return ObjectSearchService.FindFullQuantity;
            }
        }

        public int GACount
        {
            get
            {
                ObjectSearchService.FindTypeEx((ushort)Reagents.GA, 0x0000, ObjectSearchService.Backpack, true);
                return ObjectSearchService.FindFullQuantity;
            }
        }

        public int GSCount
        {
            get
            {
                ObjectSearchService.FindTypeEx((ushort)Reagents.GS, 0x0000, ObjectSearchService.Backpack, true);
                return ObjectSearchService.FindFullQuantity;
            }
        }

        public int MRCount
        {
            get
            {
                ObjectSearchService.FindTypeEx((ushort)Reagents.MR, 0x0000, ObjectSearchService.Backpack, true);
                return ObjectSearchService.FindFullQuantity;
            }
        }

        public int NSCount
        {
            get
            {
                ObjectSearchService.FindTypeEx((ushort)Reagents.NS, 0x0000, ObjectSearchService.Backpack, true);
                return ObjectSearchService.FindFullQuantity;
            }
        }

        public int SACount
        {
            get
            {
                ObjectSearchService.FindTypeEx((ushort)Reagents.SA, 0x0000, ObjectSearchService.Backpack, true);
                return ObjectSearchService.FindFullQuantity;
            }
        }

        public int SSCount
        {
            get
            {
                ObjectSearchService.FindTypeEx((ushort)Reagents.SS, 0x0000, ObjectSearchService.Backpack, true);
                return ObjectSearchService.FindFullQuantity;
            }
        }
    }
}
