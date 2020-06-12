using Microsoft.Extensions.DependencyInjection;
using ScriptDotNet;
using ScriptDotNet.Network;
using ScriptDotNet.Services;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

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
                                
            services.AddSingleton<IStealthClient>(p => {
                if (port == 0)
                    port = FindPortByWinMsg();
                if (port == -1)
                    return null;
                return new StealthClient("localhost", port);
            } );
            services.AddSingleton<Stealth, Stealth>();

            return services;
        }

        private static int FindPortByWinMsg()
        {
            //Start message queue
            Win32Wrapper.PeekMessage(out Win32Wrapper.NativeMessage msg, 0, (uint)0x600, (uint)0x600, Win32Wrapper.PM_REMOVE);

            Trace.WriteLine("Prepare message for Stealth", "Stealth.Main");
            var procstring = Process.GetCurrentProcess().Id.ToString("X8") + Process.GetCurrentProcess().MainModule.FileName.Replace(".vshost", "") + '\0';
            Trace.WriteLine(string.Format("Procstring: {0}", procstring), "Stealth.Main");
            var aCopyData = new Win32Wrapper.CopyDataStruct
            {
                dwData = (uint)Win32Wrapper.GetCurrentThreadId(),
                cbData = Process.GetCurrentProcess().MainModule.FileName.Replace(".vshost", "").Length + 8 + 1,
                lpData = Marshal.StringToHGlobalAnsi(procstring)
            };

            IntPtr copyDataPtr = aCopyData.MarshalToPtr();

            try
            {
                Trace.WriteLine("Find Stealth window", "Stealth.Main");
                IntPtr tWndPtr = Win32Wrapper.FindWindowEx(IntPtr.Zero, IntPtr.Zero, "TStealthForm", null);
                if (tWndPtr != IntPtr.Zero)
                {
                    Trace.WriteLine("Stealth window found. Send message.", "Stealth.Main");
                    IntPtr ret = Win32Wrapper.SendMessage(tWndPtr, Win32Wrapper.WM_COPYDATA, IntPtr.Zero, copyDataPtr);
                    Trace.WriteLine("Message sended. Wait message from Stealth.", "Stealth.Main");
                    while (!Win32Wrapper.PeekMessage(out msg, 0, (uint)0x600, (uint)0x600, Win32Wrapper.PM_REMOVE))
                    {
                        Thread.Sleep(10);
                    }
                    Trace.WriteLine(string.Format("Message recieved. Port: {0}", (int)(msg.wParam)), "Stealth.Main");
                }
                else
                    throw new InvalidOperationException("Could not attach to Stealth. Exiting.");
            }
            catch (InvalidOperationException)
            {
                return -1;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex, "Stealth.Main");
                return -1;
            }
            finally
            {
                Marshal.FreeHGlobal(copyDataPtr);
            }

            return (int)(msg.wParam);
        }
    }
}
