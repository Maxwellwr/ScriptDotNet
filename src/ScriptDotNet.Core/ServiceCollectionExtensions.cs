// -----------------------------------------------------------------------
// <copyright file="ServiceCollectionExtensions.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using ScriptDotNet;
using ScriptDotNet.Network;
using ScriptDotNet.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddScriptDotNet(this IServiceCollection services, int port = 0)
        {
            services.AddTransient<IAttackService, AttackService>();
            services.AddTransient<ICharStatsService, CharStatsService>();
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IConnectionService, ConnectionService>();
            services.AddTransient<IContextMenuService, ContextMenuService>();
            services.AddSingleton<IEventSystemService, EventSystemService>();
            services.AddTransient<IGameObjectService, GameObjectService>();
            services.AddTransient<IGestureService, GestureService>();
            services.AddTransient<IGlobalService, GlobalService>();
            services.AddTransient<IGumpService, GumpService>();
            services.AddTransient<IICQService, ICQService>();
            services.AddTransient<IInfoWindowService, InfoWindowService>();
            services.AddTransient<IJournalService, JournalService>();
            services.AddTransient<ILayerService, LayerService>();
            services.AddTransient<IMapService, MapService>();
            services.AddTransient<IMarketService, MarketService>();
            services.AddTransient<IMenuService, MenuService>();
            services.AddTransient<IMoveItemService, MoveItemService>();
            services.AddTransient<IMoveService, MoveService>();
            services.AddTransient<IObjectSearchService, ObjectSearchService>();
            services.AddTransient<IPartyService, PartyService>();
            services.AddTransient<IReagentService, ReagentService>();
            services.AddTransient<ISkillSpellService, SkillSpellService>();
            services.AddTransient<IStealthService, StealthService>();
            services.AddTransient<ISystemService, SystemService>();
            services.AddTransient<ITargetService, TargetService>();
            services.AddTransient<ITileService, TileService>();
            services.AddTransient<ITradeService, TradeService>();
            services.AddTransient<ITelegramService, TelegramService>();
            services.AddTransient<IViberService, ViberService>();

            services.AddSingleton<IStealthClient>(p =>
            {
                return new StealthClient("localhost", port);
            });
            services.AddSingleton<Stealth, Stealth>();

            return services;
        }
    }
}
