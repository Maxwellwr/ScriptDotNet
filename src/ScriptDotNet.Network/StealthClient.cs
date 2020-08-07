using System;
using System.Buffers.Binary;
using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ScriptDotNet.Network
{
    public class StealthClient : IStealthClient
    {
        public event EventHandler<ServerEventArgs> ServerEventRecieve;
        public event EventHandler StartStopRecieve;
        public event EventHandler TerminateRecieve;

        TcpClient _client;
        BinaryReader _reader;
        BinaryWriter _writer;
        ConcurrentQueue<Packet> _replyes;
        readonly CancellationTokenSource _cts = new CancellationTokenSource();

        ushort _returnId = 1;

        string _host;
        int _port;

        public StealthClient(string host, int port)
        {
            _host = host;
            _port = port;
            _replyes = new ConcurrentQueue<Packet>();
        }

        public void Connect()
        {
            Trace.WriteLine(string.Format("Connect Stealth client. Host: {0}, Port: {1}", _host, _port), "Stealth.Network");
            _client = new TcpClient(_host, _port);
            _reader = new BinaryReader(_client.GetStream());
            _writer = new BinaryWriter(_client.GetStream());

            Trace.WriteLine("Start reciever", "Stealth.Network");
            var factory = new TaskFactory(_cts.Token, TaskCreationOptions.LongRunning, TaskContinuationOptions.LongRunning, TaskScheduler.Default);
            factory.StartNew(Receiver, _cts.Token);
        }

        public void Dispose()
        {
            _cts.Cancel();
            if (_client != null)
                _client.Close();
            if (_reader != null)
                _reader.Dispose();
            if (_writer != null)
                _writer.Dispose();
        }

        void Receiver(object state)
        {
            CancellationToken token = (CancellationToken)state;

            while (!token.IsCancellationRequested)
            {
                if (_reader != null && _reader.BaseStream.CanRead && ((NetworkStream)_reader.BaseStream).DataAvailable)
                {
                    while (((NetworkStream)_reader.BaseStream).DataAvailable)
                    {

                        var buffer = _reader.ReadBytes(4).AsSpan();
                        var packetLen = BinaryPrimitives.ReadInt32BigEndian(buffer);

                        buffer = _reader.ReadBytes(packetLen).AsSpan();
                        Packet packet = new Packet();
                        packet.Method = (PacketType)BinaryPrimitives.ReadUInt16LittleEndian(buffer.Slice(0,2));
                        packet.Data = buffer.Slice(2).ToArray();
                        //packet.UnusedData = _reader.ReadBytes((int)(packetLen - 4U - 2U - 4U - dataLength));

                        //Trace.WriteLineIf(packet.UnusedData.Length > 0,
                        //    $"Read packet. Type: {packet.Method}, UnusedData: {string.Join(",", packet.UnusedData.Select(b => b.ToString("X2")))}", "Stealth.Network");

                        Trace.WriteLine($"Read packet. Type: {packet.Method}, Param: {packet}", "Stealth.Network");

                        ProcessPacket(packet);
                    }

                }
                else
                    Thread.Sleep(10);
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
                    _replyes.Enqueue(packet);
                    break;

                case PacketType.SCScriptDLLTerminate:
                    new Task(OnTerminateRecieve).Start();
                    break;

                case PacketType.SCPauseResumeScript:
                    new Task(OnStartStopRevieve).Start();
                    break;

                case PacketType.SCExecEventProc:
                    var span = packet.Data.AsSpan();
                    var eventType = (EventTypes)span[0];
                    var paramCount = span[1];
                    span = span.Slice(2);
                    ArrayList parameters = new ArrayList(paramCount);
                    int pos = 0;
                    for (int i = 0; i < paramCount; i++)
                    {
                        var type = (DataType)span[pos++];
                        switch (type)
                        {
                            case DataType.parUnicodeString:
                                var size = BinaryPrimitives.ReadInt32LittleEndian(span.Slice(pos));
                                pos += 4;
                                parameters.Add(Encoding.Unicode.GetString(span.Slice(pos, size * 2).ToArray()));
                                pos += size * 2;
                                break;
                            case DataType.parInteger:
                                parameters.Add(BinaryPrimitives.ReadInt32LittleEndian(span.Slice(pos)));
                                pos += 4;
                                break;
                            case DataType.parCardinal:
                                parameters.Add(BinaryPrimitives.ReadUInt16LittleEndian(span.Slice(pos)));
                                pos += 2;
                                break;
                            case DataType.parBoolean:
                                parameters.Add(span[pos++] > 0);
                                break;
                            case DataType.parWord:
                                parameters.Add(BinaryPrimitives.ReadInt16LittleEndian(span.Slice(pos)));
                                pos += 2;
                                break;
                            case DataType.parByte:
                                parameters.Add(span[pos++]);
                                break;
                        }
                    }

                    ExecEventProcData data = new ExecEventProcData(eventType, parameters);
                    new Task(() => OnServerEventRecieve(data)).Start();
                    break;
                default:
                    throw new Exception("Recieve unknown packet. ID: " + (ushort)packet.Method);
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
                Thread.Sleep(10);

            Trace.WriteLine(string.Format("Send packet. Type: {0}, Param: {1}",
                    packet.Method,
                    packet.ToString()),
                "Stealth.Network");
            var pb = packet.GetBytes();
            Span<byte> lb = stackalloc byte[4];
            BinaryPrimitives.WriteInt32BigEndian(lb, pb.Length);
            _writer.Write(lb.ToArray());
            _writer.Write(pb);
            _writer.Flush();

        }



        public void SendPacket(PacketType packetType, params object[] parameters)
        {
            lock (this)
            {
                var packet = new Packet() { Method = packetType, ReturnId = 0 };
                packet.AddParameters(parameters);

                SendPacket(packet);
            }
        }

        public T SendPacket<T>(PacketType packetType, params object[] parameters)
        {
            lock (this)
            {
                var packet = new Packet() { Method = packetType, ReturnId = GetNextReturnId() };
                packet.AddParameters(parameters);

                SendPacket(packet);
                return WaitReply<T>(packet.ReturnId);
            }
        }

        private T WaitReply<T>(ushort returnId)
        {
            while (_replyes.Count == 0)
                Thread.Sleep(10);

            Packet packet;
            bool getPacket;
            do
            {
                getPacket = _replyes.TryDequeue(out packet);
            } while (!getPacket && packet.ReturnId != returnId);

            if (typeof(T).IsValueType && Type.GetTypeCode(typeof(T)) != TypeCode.DateTime)
                return packet.Data.Skip(2).ToArray().MarshalToObject<T>();
            else
            {
                switch (Type.GetTypeCode(typeof(T)))
                {
                    case TypeCode.String:
                    {
                        uint len = BitConverter.ToUInt32(packet.Data, 2);
                        return (T)(object)Encoding.Unicode.GetString(packet.Data.Skip(6).ToArray());
                    }
                    case TypeCode.DateTime:
                        return (T)(object)BitConverter.ToDouble(packet.Data, 2).ToDateTime();
                    default:
                        if (typeof(T).IsArray)
                        {
                            var elementType = typeof(T).GetElementType();
                            byte[] barray = packet.Data.Skip(2).ToArray();
                            if (barray == null || barray.Length == 0)
                                return default(T);
                            T uarray = (T)Activator.CreateInstance(typeof(T), new object[] { barray.Length / System.Runtime.InteropServices.Marshal.SizeOf(elementType) });
                            Buffer.BlockCopy(barray, 0, uarray as Array, 0, barray.Length);
                            return uarray;
                        }
                        if (typeof(T).IsGenericType && typeof(T).GetInterfaces().Any(i => i == typeof(IList)))
                        {

                            byte[] barray = packet.Data.Skip(2).ToArray();
                            T result = Activator.CreateInstance<T>();
                            var elementType = typeof(T).GetGenericArguments()[0];

                            if (barray == null || barray.Length == 0)
                                return (T)Activator.CreateInstance(typeof(T));
                            if (elementType.IsPrimitive)
                            {
                                Array uarray = Array.CreateInstance(elementType, barray.Length / System.Runtime.InteropServices.Marshal.SizeOf(elementType));
                                Buffer.BlockCopy(barray, 0, uarray as Array, 0, barray.Length);

                                foreach (var item in uarray)
                                {
                                    (result as IList).Add(item);
                                }
                            }
                            else if (Type.GetTypeCode(elementType) == TypeCode.String)
                            {
                                uint len = BitConverter.ToUInt32(barray, 0);
                                var str = Encoding.Unicode.GetString(barray.Skip(4).ToArray());
                                str.Split(Environment.NewLine.ToArray(), StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(s => (result as IList).Add(s));
                            }
                            else
                            {
                                uint itemCount;
                                //switch (replyId)
                                //{
                                //    case PacketType.SCReadStaticsXY:
                                //    case PacketType.SCGetBuffBarInfo:
                                //        itemCount = (uint)barray[0];
                                //        barray = barray.Skip(1).ToArray();
                                //        break;
                                //    default:
                                        itemCount = BitConverter.ToUInt32(barray, 0);
                                        barray = barray.Skip(4).ToArray();
                                //        break;
                                //}

                                if (elementType.GetInterfaces().Any(intf => intf == typeof(IDeserialized)))
                                {
                                    using (MemoryStream str = new MemoryStream(barray))
                                    using (var br = new BinaryReader(str))
                                    {
                                        while (str.Position < str.Length)
                                        {
                                            var el = br.MarshalToObject(elementType);
                                            (result as IList).Add(el);
                                        }
                                    }
                                }
                                else
                                {
                                    var itemSize = System.Runtime.InteropServices.Marshal.SizeOf(elementType);
                                    if (itemCount > 0)
                                    {
                                        var uarray = barray.SplitN(itemSize).Select(b => b.ToArray().MarshalToObject(elementType)).ToList();
                                        uarray.ForEach(el => (result as IList).Add(el));
                                    }
                                }
                            }
                            return result;
                        }
                        throw new InvalidOperationException($"Type '{typeof(T)}' not supported.");
                }
            }
        }

        private ushort GetNextReturnId()
        {
            if (_returnId == ushort.MaxValue)
                _returnId = 1;
            return _returnId++;
        }
    }

}

