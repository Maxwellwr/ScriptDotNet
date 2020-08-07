﻿using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Buffers.Binary;

namespace ScriptDotNet.Network
{
    public class Packet
    {
        public Packet()
        {
            Data = new byte[0];
        }

        public PacketType Method;
        public ushort ReturnId;
        public int DataLength { get { return Data.Length; } }
        public byte[] Data;
        
        public override string ToString()
        {
            return string.Join(" ", Data.Select(b => b.ToString("X2")));
        }

        public void AddParameters(params object[] p)
        {
            using (MemoryStream _ms = new MemoryStream())
            using (BinaryWriter _bw = new BinaryWriter(_ms))
            {
                foreach (var item in p)
                {
                    AddParameter(_bw, item);
                }
                Data = _ms.ToArray();
            }
        }

        private void AddParameter(BinaryWriter _bw, object p)
        {
            switch (Type.GetTypeCode(p.GetType()))
            {
                case TypeCode.Boolean:
                    _bw.Write((bool)p);
                    break;
                case TypeCode.Byte:
                    _bw.Write((byte)p);
                    break;
                case TypeCode.Char:
                    _bw.Write((char)p);
                    break;
                case TypeCode.Decimal:
                    _bw.Write((decimal)p);
                    break;
                case TypeCode.Double:
                    _bw.Write((double)p);
                    break;
                case TypeCode.Single:
                    _bw.Write((float)p);
                    break;
                case TypeCode.Int16:
                    _bw.Write((short)p);
                    break;
                case TypeCode.String:
                    byte[] bytes = Encoding.Unicode.GetBytes((string)p);
                    _bw.Write(((string)p).Length);
                    _bw.Write(bytes, 0, bytes.Length);
                    break;
                case TypeCode.Int32:
                    _bw.Write((int)p);
                    break;
                case TypeCode.Int64:
                    _bw.Write((long)p);
                    break;
                case TypeCode.SByte:
                    _bw.Write((sbyte)p);
                    break;
                case TypeCode.UInt16:
                    _bw.Write((ushort)p);
                    break;
                case TypeCode.UInt32:
                    _bw.Write((uint)p);
                    break;
                case TypeCode.UInt64:
                    _bw.Write((ulong)p);
                    break;
                case TypeCode.DateTime:
                    _bw.Write(((DateTime)p).ToDouble());
                    break;
                default:
                    if (p.GetType() == typeof(byte[]))
                    {
                        _bw.Write((byte[])p);
                    }
                    else if (p.GetType() == typeof(char[]))
                    {
                        _bw.Write((char[])p);
                    }
                    else if (p.GetType() == typeof(ushort[]))
                    {
                        byte[] bytearray = ((ushort[])p).SelectMany(i => BitConverter.GetBytes(i)).ToArray();
                        _bw.Write(bytearray);
                    }
                    else if (p.GetType() == typeof(uint[]))
                    {
                        byte[] bytearray = ((uint[])p).SelectMany(i => BitConverter.GetBytes(i)).ToArray();
                        _bw.Write(bytearray);
                    }
                    else
                    {
                        throw new ArgumentException("List type not supported");
                    }

                    break;
            }
        }

        public byte[] GetBytes()
        {
            Span<byte> buffer = stackalloc byte[DataLength + 4];
            BinaryPrimitives.WriteUInt16LittleEndian(buffer.Slice(0, 2), (ushort)Method);
            BinaryPrimitives.WriteUInt16LittleEndian(buffer.Slice(2, 2), ReturnId);
            new Span<byte>(Data).CopyTo(buffer.Slice(4, DataLength));
            return buffer.ToArray();
        }
    }
}
