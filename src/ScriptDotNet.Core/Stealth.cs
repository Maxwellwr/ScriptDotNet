using System;
using System.Diagnostics;
using ScriptDotNet.Network;
using ScriptDotNet.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ScriptDotNet
{
    public partial class Stealth : IDisposable
    {
        private readonly Version SUPPORTED_VERSION = new Version(8, 8, 5, 0);

        #region Events
        public event EventHandler<StartStopEventArgs> StartStop;
        #endregion

        private IStealthClient _client;
        private bool _isStopped;
        private IServiceProvider _serviceProvider;

        #region Common used services
        public IConnectionService Connection => _serviceProvider.GetService<IConnectionService>();
        public IClientService Client => _serviceProvider.GetService<IClientService>();
        public IJournalService Journal => _serviceProvider.GetService<IJournalService>();
        public IObjectSearchService Search => _serviceProvider.GetService<IObjectSearchService>();
        public IGameObjectService GameObject => _serviceProvider.GetService<IGameObjectService>();
        public IMoveItemService MoveItem => _serviceProvider.GetService<IMoveItemService>();
        public IMoveService Move => _serviceProvider.GetService<IMoveService>();
        public ITargetService Target => _serviceProvider.GetService<ITargetService>();
        public ICharStatsService Char => _serviceProvider.GetService<ICharStatsService>();
        public IGumpService Gump => _serviceProvider.GetService<IGumpService>();
        public ISkillSpellService SkillSpell => _serviceProvider.GetService<ISkillSpellService>();
        public IViberService Viber => _serviceProvider.GetService<IViberService>();
        public ITelegramService Telegram => _serviceProvider.GetService<ITelegramService>();
        #endregion

        public Stealth(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;            
            _isStopped = false;

            Trace.WriteLine("Create Stealth client", "Stealth.Main");
            _client = serviceProvider.GetRequiredService<IStealthClient>();

            _client.StartStopRecieve += _client_StartStopRecieve;
            _client.TerminateRecieve += _client_TerminateRecieve;
            _client.Connect();
            CheckSupportedVersion();
        }

        public T GetStealthService<T>() => _serviceProvider.GetService<T>();

        private void CheckSupportedVersion()
        {
            var stealthService = _serviceProvider.GetRequiredService<IStealthService>();
            var about = stealthService.StealthInfo;
            Version ver = new Version(about.StealthVersion[0], about.StealthVersion[1], about.StealthVersion[2], about.GITRevNumber);
            if (ver < SUPPORTED_VERSION)
                throw new NotSupportedException($"Support Stealth version {SUPPORTED_VERSION} or above");
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
            StartStop?.Invoke(this, new StartStopEventArgs(isStopped));
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

    }

}
