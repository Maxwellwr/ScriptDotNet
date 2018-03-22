using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Win32;
using ScriptDotNet2.Network;
using System.IO;
using System.Collections;
using ScriptDotNet2.Data;
using System.Reflection;
using ScriptDotNet2.Common;
using ScriptDotNet2.Services;

namespace ScriptDotNet2
{
    public partial class Stealth : IDisposable
    {
        private readonly Version SUPPORTED_VERSION = new Version(8, 7, 2, 1278);

        #region Events
        public event EventHandler<StartStopEventArgs> StartStop;
        #endregion

        private StealthClient _client;
        private bool _isStopped;

        private static Stealth _instance;
        public static Stealth Default
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Stealth();
                }
                return _instance;
            }
        }

        #region Common used services
        public IConnectionService Connection { get { return GetService<IConnectionService>(); } }
        public IClientService Client { get { return GetService<IClientService>(); } }
        public IJournalService Journal { get { return GetService<IJournalService>(); } }
        public IObjectSearchService Search { get { return GetService<IObjectSearchService>(); } }
        public IGameObjectService GameObject { get { return GetService<IGameObjectService>(); } }
        public IMoveItemService MoveItem { get { return GetService<IMoveItemService>(); } }
        public IMoveService Move { get { return GetService<IMoveService>(); } }
        public ITargetService Target { get { return GetService<ITargetService>(); } }
        public ICharStatsService Char { get { return GetService<ICharStatsService>(); } }
        public IGumpService Gump { get { return GetService<IGumpService>(); } }
        public ISkillSpellService SkillSpell { get { return GetService<ISkillSpellService>(); } }
        public IViberService Viber { get { return GetService<IViberService>(); } }
        public ITelegramService Telegram { get { return GetService<ITelegramService>(); } }
        #endregion

        private Stealth()
        {
            int port = GetPortFromCommandLineArgs();

            if (port == 0)
                port = FindPortByWinMsg();

            _isStopped = false;

            Trace.WriteLine("Create Stealth client", "Stealth.Main");
            _client = new StealthClient("localhost", port);

            _client.StartStopRecieve += _client_StartStopRecieve;
            _client.TerminateRecieve += _client_TerminateRecieve;
            _client.Connect();
            ServiceManager.SetClient(_client);
            CheckSupportedVersion();
        }

        private int GetPortFromCommandLineArgs()
        {
            var args = Environment.GetCommandLineArgs();
            int port = 0;
            if (args.Length > 1 && int.TryParse(args[1], out port) && port > 50908 && port < 52000)
                return port;
            return 0;
        }

        private void CheckSupportedVersion()
        {
            var stealthService = GetService<IStealthService>();
            var about = stealthService.StealthInfo;
            Version ver = new Version(about.StealthVersion[0], about.StealthVersion[1], about.StealthVersion[2], about.GITRevNumber);
            if (ver < SUPPORTED_VERSION)
                throw new NotSupportedException($"Support Stealth version {SUPPORTED_VERSION} or above");
        }

        private int FindPortByWinMsg()
        {
            Win32.NativeMessage msg;
            //Start message queue
            Win32.PeekMessage(out msg, 0, (uint)0x600, (uint)0x600, Win32.PM_REMOVE);

            Trace.WriteLine("Prepare message for Stealth", "Stealth.Main");
            var procstring = Process.GetCurrentProcess().Id.ToString("X8") + Process.GetCurrentProcess().MainModule.FileName.Replace(".vshost", "") + '\0';
            Trace.WriteLine(string.Format("Procstring: {0}", procstring), "Stealth.Main");
            var aCopyData = new Win32.CopyDataStruct
            {
                dwData = (uint)Win32.GetCurrentThreadId(),
                cbData = Process.GetCurrentProcess().MainModule.FileName.Replace(".vshost", "").Length + 8 + 1,
                lpData = Marshal.StringToHGlobalAnsi(procstring)
            };

            IntPtr copyDataPtr = aCopyData.MarshalToPtr();

            try
            {
                Trace.WriteLine("Find Stealth window", "Stealth.Main");
                IntPtr tWndPtr = Win32.FindWindowEx(IntPtr.Zero, IntPtr.Zero, "TStealthForm", null);
                if (tWndPtr != IntPtr.Zero)
                {
                    Trace.WriteLine("Stealth window found. Send message.", "Stealth.Main");
                    IntPtr ret = Win32.SendMessage(tWndPtr, Win32.WM_COPYDATA, IntPtr.Zero, copyDataPtr);
                    Trace.WriteLine("Message sended. Wait message from Stealth.", "Stealth.Main");
                    while (!Win32.PeekMessage(out msg, 0, (uint)0x600, (uint)0x600, Win32.PM_REMOVE))
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
                throw;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex, "Stealth.Main");
            }
            finally
            {
                Marshal.FreeHGlobal(copyDataPtr);
            }

            return (int)(msg.wParam);
        }

        ~Stealth()
        {
            Dispose();
        }

        void _client_TerminateRecieve(object sender, EventArgs e)
        {
            Dispose();
        }

        void _client_StartStopRecieve(object sender, EventArgs e)
        {
            _isStopped = !_isStopped;
            OnStartStop(_isStopped);
        }

        private void OnStartStop(bool isStopped)
        {
            var handle = StartStop;
            if (handle != null)
                handle(this, new StartStopEventArgs(isStopped));
        }

        public void Dispose()
        {
            if (_client != null)
            {
                _client.Dispose();
                _client = null;
            }
            Environment.Exit(0);
        }

        public T GetService<T>()
        {
            return ServiceManager.GetService<T>();
        }

    }

}
