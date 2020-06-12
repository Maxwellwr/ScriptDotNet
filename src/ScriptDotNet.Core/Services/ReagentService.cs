using ScriptDotNet.Network;

namespace ScriptDotNet.Services
{
    public class ReagentService: BaseService, IReagentService
    {
        public readonly IObjectSearchService _objectSearchService;

        public ReagentService(IStealthClient client, IObjectSearchService objectSearchService)
            :base(client)
        {
            _objectSearchService = objectSearchService;
        }

        public int BMCount
        {
            get
            {
                _objectSearchService.FindTypeEx((ushort)Reagents.BM, 0x0000, _objectSearchService.Backpack, true);
                return _objectSearchService.FindFullQuantity;
            }
        }

        public int BPCount
        {
            get
            {
                _objectSearchService.FindTypeEx((ushort)Reagents.BP, 0x0000, _objectSearchService.Backpack, true);
                return _objectSearchService.FindFullQuantity;
            }
        }

        public int GACount
        {
            get
            {
                _objectSearchService.FindTypeEx((ushort)Reagents.GA, 0x0000, _objectSearchService.Backpack, true);
                return _objectSearchService.FindFullQuantity;
            }
        }

        public int GSCount
        {
            get
            {
                _objectSearchService.FindTypeEx((ushort)Reagents.GS, 0x0000, _objectSearchService.Backpack, true);
                return _objectSearchService.FindFullQuantity;
            }
        }

        public int MRCount
        {
            get
            {
                _objectSearchService.FindTypeEx((ushort)Reagents.MR, 0x0000, _objectSearchService.Backpack, true);
                return _objectSearchService.FindFullQuantity;
            }
        }

        public int NSCount
        {
            get
            {
                _objectSearchService.FindTypeEx((ushort)Reagents.NS, 0x0000, _objectSearchService.Backpack, true);
                return _objectSearchService.FindFullQuantity;
            }
        }

        public int SACount
        {
            get
            {
                _objectSearchService.FindTypeEx((ushort)Reagents.SA, 0x0000, _objectSearchService.Backpack, true);
                return _objectSearchService.FindFullQuantity;
            }
        }

        public int SSCount
        {
            get
            {
                _objectSearchService.FindTypeEx((ushort)Reagents.SS, 0x0000, _objectSearchService.Backpack, true);
                return _objectSearchService.FindFullQuantity;
            }
        }
    }
}
