// -----------------------------------------------------------------------
// <copyright file="Stealth.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using Microsoft.Extensions.DependencyInjection;

using ScriptDotNet.Network;
using ScriptDotNet.Services;

using System;
using System.Diagnostics;

namespace ScriptDotNet
{
    public partial class Stealth : IDisposable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.NamingRules", "SA1306:Field names should begin with lower-case letter", Justification = "OK")]
        private readonly Version SUPPORTEDVERSION = new Version(8, 10, 6, 0);

        private IStealthClient _client;
        private bool _isStopped;
        private IServiceProvider _serviceProvider;

        public Stealth(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _isStopped = false;

            Trace.WriteLine("Create Stealth client", "Stealth.Main");
            _client = serviceProvider.GetRequiredService<IStealthClient>();

            _client.StartStopRecieve += Client_StartStopRecieve;
            _client.TerminateRecieve += Client_TerminateRecieve;
            _client.Connect();
            SetScriptVersion();
            CheckSupportedVersion();
        }

        public event EventHandler<StartStopEventArgs> StartStop;

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

        public T GetStealthService<T>() => _serviceProvider.GetService<T>();

        public void Dispose()
        {
            if (_client != null)
            {
                _client.Dispose();
                _client = null;
            }

            Environment.Exit(0);
        }

        private void SetScriptVersion()
        {
            _client.SendPacket(PacketType.SCLangVersion, (byte)3, 0x00000001u);
        }

        private void CheckSupportedVersion()
        {
            var stealthService = _serviceProvider.GetRequiredService<IStealthService>();
            var about = stealthService.StealthInfo;
            Version ver = new Version(about.StealthVersion[0], about.StealthVersion[1], about.StealthVersion[2], about.GITRevNumber);
            if (ver < SUPPORTEDVERSION)
            {
                throw new NotSupportedException($"Support Stealth version {SUPPORTEDVERSION} or above");
            }
        }

        private void Client_TerminateRecieve(object sender, EventArgs e)
        {
            Dispose();
        }

        private void Client_StartStopRecieve(object sender, EventArgs e)
        {
            _isStopped = !_isStopped;
            OnStartStop(_isStopped);
        }

        private void OnStartStop(bool isStopped)
        {
            StartStop?.Invoke(this, new StartStopEventArgs(isStopped));
        }
    }
}
