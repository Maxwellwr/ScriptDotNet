using ScriptDotNet.Network;

namespace ScriptDotNet.Services
{
    public class ViberService : BaseMessanger, IViberService
    {
        public ViberService(IStealthClient client, IEventSystemService eventSystemService)
            : base(client, eventSystemService)
        {

        }

        protected override MessangerType MessangerType => MessangerType.Viber;
    }
}
