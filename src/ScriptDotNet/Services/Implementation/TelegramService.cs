using ScriptDotNet2.Common;
using ScriptDotNet2.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptDotNet2.Services.Implementation
{
    public class TelegramService : BaseMessanger, ITelegramService
    {
        public TelegramService(StealthClient client)
            : base(client)
        {

        }

        protected override MessangerType MessangerType => MessangerType.Telegram;
    }
}
