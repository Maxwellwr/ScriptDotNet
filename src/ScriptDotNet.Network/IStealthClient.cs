using System;

namespace ScriptDotNet.Network
{
    public interface IStealthClient: IDisposable
    {
        event EventHandler<ServerEventArgs> ServerEventRecieve;
        event EventHandler StartStopRecieve;
        event EventHandler TerminateRecieve;

        void Connect();
        void SendPacket(PacketType packetType, params object[] parameters);
        T SendPacket<T>(PacketType packetType, params object[] parameters);
        T WaitReply<T>(PacketType type);
    }
}