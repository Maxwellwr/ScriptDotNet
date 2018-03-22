using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptDotNet2.Services
{
    public interface IICQService
    {
        bool ICQConnected { get; }

        void ICQConnect(string UIN, string password);
        void ICQDisconnect();
        void ICQSendText(string DestinationUIN, string Text);
        void ICQSetStatus(byte Num);
        void ICQSetXStatus(byte Num);
    }
}
