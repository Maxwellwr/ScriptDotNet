// -----------------------------------------------------------------------
// <copyright file="Packet.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Buffers.Binary;
using System.IO;
using System.Linq;
using System.Text;

namespace ScriptDotNet.Network
{
    public class Packet
    {
        public Packet()
        {
            Data = new byte[0];
        }

        public Packet(PacketType method, ushort returnId = 0)
            : this()
        {
            Method = method;
            ReturnId = returnId;
        }

        public Packet(PacketType method, byte[] data)
        {
            Method = method;
            Data = data;
        }

        public PacketType Method { get; private set; }

        public ushort ReturnId { get; set; }

        public int DataLength
        {
            get { return Data.Length; }
        }

        public byte[] Data { get; private set; }

        public override string ToString()
        {
            return string.Join(" ", Data.Select(b => b.ToString("X2")));
        }

        public void AddParameters(params object[] p)
        {
            using (MemoryStream ms = new MemoryStream())
            using (BinaryWriter bw = new BinaryWriter(ms))
            {
                foreach (var item in p)
                {
                    AddParameter(bw, item);
                }

                Data = ms.ToArray();
            }
        }

        public byte[] GetBytes()
        {
            Span<byte> buffer = stackalloc byte[DataLength + 4];
            BinaryPrimitives.WriteUInt16BigEndian(buffer.Slice(0, 2), (ushort)Method);
            BinaryPrimitives.WriteUInt16BigEndian(buffer.Slice(2, 2), ReturnId);
            new Span<byte>(Data).CopyTo(buffer.Slice(4, DataLength));
            return buffer.ToArray();
        }

        private void AddParameter(BinaryWriter bw, object p)
        {
            switch (Type.GetTypeCode(p.GetType()))
            {
                case TypeCode.Boolean:
                    bw.Write((bool)p);
                    break;
                case TypeCode.Byte:
                    bw.Write((byte)p);
                    break;
                case TypeCode.Char:
                    bw.Write((char)p);
                    break;
                case TypeCode.Decimal:
                    bw.Write((decimal)p);
                    break;
                case TypeCode.Double:
                    bw.Write((double)p);
                    break;
                case TypeCode.Single:
                    bw.Write((float)p);
                    break;
                case TypeCode.Int16:
                    bw.Write((short)p);
                    break;
                case TypeCode.String:
                    byte[] bytes = Encoding.Unicode.GetBytes((string)p);
                    bw.Write(((string)p).Length);
                    bw.Write(bytes, 0, bytes.Length);
                    break;
                case TypeCode.Int32:
                    bw.Write((int)p);
                    break;
                case TypeCode.Int64:
                    bw.Write((long)p);
                    break;
                case TypeCode.SByte:
                    bw.Write((sbyte)p);
                    break;
                case TypeCode.UInt16:
                    bw.Write((ushort)p);
                    break;
                case TypeCode.UInt32:
                    bw.Write((uint)p);
                    break;
                case TypeCode.UInt64:
                    bw.Write((ulong)p);
                    break;
                case TypeCode.DateTime:
                    bw.Write(((DateTime)p).ToDouble());
                    break;
                default:
                    if (p.GetType() == typeof(byte[]))
                    {
                        bw.Write((byte[])p);
                    }
                    else if (p.GetType() == typeof(char[]))
                    {
                        bw.Write((char[])p);
                    }
                    else if (p.GetType() == typeof(ushort[]))
                    {
                        byte[] bytearray = ((ushort[])p).SelectMany(i => BitConverter.GetBytes(i)).ToArray();
                        bw.Write(bytearray);
                    }
                    else if (p.GetType() == typeof(uint[]))
                    {
                        byte[] bytearray = ((uint[])p).SelectMany(i => BitConverter.GetBytes(i)).ToArray();
                        bw.Write(bytearray);
                    }
                    else
                    {
                        throw new ArgumentException("List type not supported");
                    }

                    break;
            }
        }
    }
}
