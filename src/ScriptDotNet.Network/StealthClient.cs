// -----------------------------------------------------------------------
// <copyright file="StealthClient.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Buffers.Binary;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Drenalol.TcpClientIo.Client;
using Drenalol.TcpClientIo.Converters;
using Drenalol.TcpClientIo.Options;

namespace ScriptDotNet.Network
{
    public class StealthClient : IStealthClient
    {
        private readonly CancellationTokenSource _cts = new();
        private readonly string _host;
        private readonly uint _port;
        private readonly ConcurrentQueue<Packet> _replies;
        private TcpClient _client;
        private BinaryReader _reader;
        private BinaryWriter _writer;
        private ushort _returnId = 1;


        public StealthClient(string host, uint port)
        {
            _host = host;
            _port = port;
            _replies = new ConcurrentQueue<Packet>();
        }

        public event EventHandler<ServerEventArgs> ServerEventRecieve;

        public event EventHandler StartStopRecieve;

        public event EventHandler TerminateRecieve;

        public void Connect()
        {
            var intPort = FindPort();

            Trace.WriteLine(string.Format("Connect Stealth client. Host: {0}, Port: {1}", _host, intPort),
                "Stealth.Network");
            _client = new TcpClient(_host, (int) intPort);
            _reader = new BinaryReader(_client.GetStream());
            _writer = new BinaryWriter(_client.GetStream());

            Trace.WriteLine("Start reciever", "Stealth.Network");
            var opt = TcpClientIoOptions.Default;
            opt.Converters = new List<TcpConverter>()
            {
                new P()
            }
            var t = new TcpClientIo<uint, Request<int>, Request<int>>(_client, );

            var factory = new TaskFactory(
                _cts.Token,
                TaskCreationOptions.LongRunning,
                TaskContinuationOptions.LongRunning,
                TaskScheduler.Default);
            factory.StartNew(Receiver, _cts.Token);
        }

        public void Dispose()
        {
            _cts.Cancel();
            _client?.Close();
            _reader?.Dispose();
            _writer?.Dispose();
        }

        public void SendPacket(PacketType packetType, params object[] parameters)
        {
            lock (this)
            {
                var packet = new Packet(packetType);
                packet.AddParameters(parameters);

                SendPacket(packet);
            }
        }

        public T SendPacket<T>(PacketType packetType, params object[] parameters)
        {
            lock (this)
            {
                var packet = new Packet(packetType, GetNextReturnId());
                packet.AddParameters(parameters);

                SendPacket(packet);
                return WaitReply<T>(packet.ReturnId);
            }
        }

        private uint FindPort()
        {
            if (_port == 0)
            {
                var tcpClient = new TcpClient(_host, 47602);
                var stream = tcpClient.GetStream();
                var buffer = new byte[] {0x00, 0x04, 0xEF, 0xBE, 0xAD, 0xDE};
                stream.Write(buffer, 0, 6);
                stream.Flush();
                buffer = new byte[4];
                var readed = stream.Read(buffer, 0, 2);
                var len = BinaryPrimitives.ReadUInt16LittleEndian(buffer.AsSpan());
                stream.Read(buffer, 0, len);
                if (len == 2)
                {
                    return BinaryPrimitives.ReadUInt16BigEndian(buffer);
                }
                else
                {
                    return BinaryPrimitives.ReadUInt32BigEndian(buffer);
                }
            }

            return _port;
        }

        private void Receiver(object state)
        {
            CancellationToken token = (CancellationToken) state;
            while (!token.IsCancellationRequested)
            {
                if (_reader != null && _reader.BaseStream.CanRead && ((NetworkStream) _reader.BaseStream).DataAvailable)
                {
                    while (((NetworkStream) _reader.BaseStream).DataAvailable)
                    {
                        var buffer = _reader.ReadBytes(4).AsSpan();
                        var packetLen = BinaryPrimitives.ReadInt32BigEndian(buffer);
                        buffer = _reader.ReadBytes(packetLen).AsSpan();
                        Packet packet =
                            new Packet((PacketType) BinaryPrimitives.ReadUInt16LittleEndian(buffer.Slice(0, 2)),
                                buffer.Slice(2).ToArray());
                        Trace.WriteLine($"Read packet. Type: {packet.Method}, Param: {packet}", "Stealth.Network");
                        ProcessPacket(packet);
                    }
                }
                else
                {
                    Thread.Sleep(10);
                }
            }

            token.ThrowIfCancellationRequested();
        }

        private void ProcessPacket(Packet packet)
        {
            switch (packet.Method)
            {
                case PacketType.SCZero:
                    break;
                case PacketType.SCReturnValue:
                    packet.ReturnId = BinaryPrimitives.ReadUInt16LittleEndian(packet.Data.AsSpan());
                    _replies.Enqueue(packet);
                    break;

                case PacketType.SCScriptDLLTerminate:
                    new Task(OnTerminateRecieve).Start();
                    break;

                case PacketType.SCPauseResumeScript:
                    new Task(OnStartStopRevieve).Start();
                    break;

                case PacketType.SCExecEventProc:
                    var span = packet.Data.AsSpan();
                    var eventType = (EventTypes) span[0];
                    var paramCount = span[1];
                    span = span.Slice(2);
                    ArrayList parameters = new ArrayList(paramCount);
                    int pos = 0;
                    for (int i = 0; i < paramCount; i++)
                    {
                        var type = (DataType) span[pos++];
                        switch (type)
                        {
                            case DataType.UnicodeString:
                                var size = BinaryPrimitives.ReadInt32LittleEndian(span.Slice(pos));
                                pos += 4;
                                parameters.Add(Encoding.Unicode.GetString(span.Slice(pos, size * 2).ToArray()));
                                pos += size * 2;
                                break;
                            case DataType.Cardinal:
                                parameters.Add(BinaryPrimitives.ReadUInt32LittleEndian(span.Slice(pos)));
                                pos += 4;
                                break;
                            case DataType.Integer:
                                parameters.Add(BinaryPrimitives.ReadInt32LittleEndian(span.Slice(pos)));
                                pos += 4;
                                break;
                            case DataType.Word:
                                parameters.Add(BinaryPrimitives.ReadUInt16LittleEndian(span.Slice(pos)));
                                pos += 2;
                                break;
                            case DataType.Smallint:
                                parameters.Add(BinaryPrimitives.ReadInt16LittleEndian(span.Slice(pos)));
                                pos += 2;
                                break;
                            case DataType.Byte:
                                parameters.Add(span[pos++]);
                                break;
                            case DataType.ShortInt:
                                parameters.Add((sbyte) span[pos++]);
                                break;
                            case DataType.Boolean:
                                parameters.Add(span[pos++] > 0);
                                break;
                        }
                    }

                    ExecEventProcData data = new ExecEventProcData(eventType, parameters);
                    new Task(() => OnServerEventRecieve(data)).Start();
                    break;
                default:
                    throw new Exception("Recieve unknown packet. ID: " + (ushort) packet.Method);
            }
        }

        private void OnTerminateRecieve()
        {
            TerminateRecieve?.Invoke(this, new EventArgs());
        }

        private void OnStartStopRevieve()
        {
            StartStopRecieve?.Invoke(this, new EventArgs());
        }

        private void OnServerEventRecieve(ExecEventProcData data)
        {
            ServerEventRecieve?.Invoke(this, new ServerEventArgs(data));
        }

        private void SendPacket(Packet packet)
        {
            while (_writer == null || !_writer.BaseStream.CanWrite)
            {
                Thread.Sleep(10);
            }

            var pb = packet.GetBytes();
            Span<byte> lb = stackalloc byte[4];
            BinaryPrimitives.WriteInt32BigEndian(lb, pb.Length);

            Trace.WriteLine(
                string.Format(
                    "Send packet. Length: {0}, Type: {1}, ReturnId: {2}, Data: {3}",
                    string.Join(" ", lb.ToArray().Select(b => b.ToString("X2"))),
                    string.Join(" ", pb.AsSpan().Slice(0, 2).ToArray().Select(b => b.ToString("X2"))),
                    string.Join(" ", pb.AsSpan().Slice(2, 2).ToArray().Select(b => b.ToString("X2"))),
                    string.Join(" ", pb.AsSpan().Slice(4).ToArray().Select(b => b.ToString("X2")))),
                "Stealth.Network");

            _writer.Write(lb.ToArray());
            _writer.Write(pb);
            _writer.Flush();
        }

        private T WaitReply<T>(ushort returnId)
        {
            while (_replies.Count == 0)
            {
                Thread.Sleep(10);
            }

            Packet packet;
            bool getPacket;
            do
            {
                getPacket = _replies.TryDequeue(out packet);
            } while (!getPacket && packet.ReturnId != returnId);

            if (typeof(T).IsValueType && Type.GetTypeCode(typeof(T)) != TypeCode.DateTime)
            {
                return packet.Data.Skip(2).ToArray().MarshalToObject<T>();
            }
            else
            {
                switch (Type.GetTypeCode(typeof(T)))
                {
                    case TypeCode.String:
                    {
                        uint len = BitConverter.ToUInt32(packet.Data, 2);
                        return (T) (object) Encoding.Unicode.GetString(packet.Data.Skip(6).ToArray());
                    }

                    case TypeCode.DateTime:
                        return (T) (object) BitConverter.ToDouble(packet.Data, 2).ToDateTime();
                    default:
                        if (typeof(T).IsArray)
                        {
                            var elementType = typeof(T).GetElementType();
                            byte[] barray = packet.Data.Skip(2).ToArray();
                            if (barray == null || barray.Length == 0)
                            {
                                return default(T);
                            }

                            T uarray = (T) Activator.CreateInstance(typeof(T),
                                new object[]
                                    {barray.Length / System.Runtime.InteropServices.Marshal.SizeOf(elementType)});
                            Buffer.BlockCopy(barray, 0, uarray as Array, 0, barray.Length);
                            return uarray;
                        }

                        if (typeof(T).IsGenericType && typeof(T).GetInterfaces().Any(i => i == typeof(IList)))
                        {
                            byte[] barray = packet.Data.Skip(2).ToArray();
                            var result = Activator.CreateInstance<T>() as IList;
                            var elementType = typeof(T).GetGenericArguments()[0];

                            if (barray == null || barray.Length == 0)
                            {
                                return (T) Activator.CreateInstance(typeof(T));
                            }

                            if (elementType.IsPrimitive)
                            {
                                Array uarray = Array.CreateInstance(elementType,
                                    barray.Length / System.Runtime.InteropServices.Marshal.SizeOf(elementType));
                                Buffer.BlockCopy(barray, 0, uarray as Array, 0, barray.Length);

                                foreach (var item in uarray)
                                {
                                    result.Add(item);
                                }
                            }
                            else if (Type.GetTypeCode(elementType) == TypeCode.String)
                            {
                                uint len = BitConverter.ToUInt32(barray, 0);
                                var str = Encoding.Unicode.GetString(barray.Skip(4).ToArray());
                                str.Split(Environment.NewLine.ToArray(), StringSplitOptions.RemoveEmptyEntries).ToList()
                                    .ForEach(s => result.Add(s));
                            }
                            else
                            {
                                uint itemCount;

                                itemCount = BitConverter.ToUInt16(barray, 0);
                                barray = barray.Skip(2).ToArray();

                                if (elementType.GetInterfaces().Any(intf => intf == typeof(IDeserialized)))
                                {
                                    using (MemoryStream str = new MemoryStream(barray))
                                    using (var br = new BinaryReader(str))
                                    {
                                        while (str.Position < str.Length)
                                        {
                                            var el = br.MarshalToObject(elementType);
                                            result.Add(el);
                                        }
                                    }
                                }
                                else
                                {
                                    var itemSize = System.Runtime.InteropServices.Marshal.SizeOf(elementType);
                                    if (itemCount > 0)
                                    {
                                        var uarray = barray.SplitN(itemSize)
                                            .Select(b => b.ToArray().MarshalToObject(elementType)).ToList();
                                        uarray.ForEach(el => result.Add(el));
                                    }
                                }
                            }

                            return (T) result;
                        }

                        throw new InvalidOperationException($"Type '{typeof(T)}' not supported.");
                }
            }
        }

        private ushort GetNextReturnId()
        {
            if (_returnId == ushort.MaxValue)
            {
                _returnId = 1;
            }

            return _returnId++;
        }
    }
}