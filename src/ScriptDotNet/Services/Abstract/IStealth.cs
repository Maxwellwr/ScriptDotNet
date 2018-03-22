using ScriptDotNet2.Common;
using ScriptDotNet2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScriptDotNet2.Services
{
    public interface IStealth:IAttackService,
                                ICharStatsService,
                                IClientService,
                                IConnectionService,
                                IContextMenuService, 
                                IEasyUOService, 
                                IEventSystemService,
                                IGameObjectService,
                                IGestureService, 
                                IGlobalService, 
                                IGumpService,
                                IICQService,
                                IInfoWindowService, 
                                IJournalService, 
                                ILayerService,
                                IMapService,
                                IMarketService, 
                                IMenuService, 
                                IMoveItemService,
                                IMoveService, 
                                IObjectSearchService, 
                                IPartyService, 
                                IReagentService, 
                                ISkillSpellService, 
                                IStealthService,
                                ISystemService, 
                                ITargetService,
                                ITileService,
                                ITradeService
    {
    }
}
