using ScriptDotNet.Network;

namespace ScriptDotNet.Services
{
    public class TelegramService : BaseMessanger, ITelegramService
    {
        public TelegramService(IStealthClient client, IEventSystemService eventSystemService)
            : base(client, eventSystemService)
        {

        }

        protected override MessangerType MessangerType => MessangerType.Telegram;
    }
}
