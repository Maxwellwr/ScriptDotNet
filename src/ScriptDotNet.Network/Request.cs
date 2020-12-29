using System;
using Drenalol.TcpClientIo.Attributes;
using Drenalol.TcpClientIo.Converters;

namespace ScriptDotNet.Network
{
    public class Request<T>
    {
        // TcpDataType.BodyLength mandatory if TcpDataType.Body set
        [TcpData(0, 4, TcpDataType = TcpDataType.BodyLength, Reverse = true)]
        public uint BodyLength { get; set; }
        
        // TcpDataType.Body mandatory if TcpDataType.BodyLength set
        [TcpData(4, TcpDataType = TcpDataType.Body, Reverse = true)]
        public P<T> Data { get; set; }
    }

    public class P<T>
    {
        [TcpData(0, 2, Reverse = true)] 
        public ushort Method { get; set; }

        [TcpData(2, 2, Reverse = true)] 
        public ushort ReturnId { get; set; }

        public T Data { get; set; }
    }
}