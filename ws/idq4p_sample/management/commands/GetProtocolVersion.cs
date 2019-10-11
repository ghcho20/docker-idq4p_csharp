/*
 * Created on Thu Oct 10 2019
 *
 * The IDQ License (IDQ)
 * Copyright (c) 2019 ID Quantique, https://www.idquantique.com/
 *
 * THIS COMPUTER PROGRAM IS PROPRIETARY AND CONFIDENTIAL TO ID QUANTIQUE AND ITS LICENSORS
 * AND CONTAINS TRADE SECRETS OF ID QUANTIQUE THAT ARE PURSUANT TO A WRITTEN AGREEMENT
 * CONTAINING RESTRICTIONS ON USE AND DISCLOSURE.
 * ANY USE, REPRODUCTION, OR TRANSFER EXCEPT AS PROVIDED IN SUCH AGREEMENT IS STRICTLY PROHIBITED.
 */

using System;
using System.IO;

using NetMQ;
using NetMQ.Sockets;
using MsgPack.Serialization;

namespace idq4p {
    public class GetProtocolVersion : Command {
        public uint maj { get; set; } = 1234;
        public uint min { get; set; } = 1234;
        public uint rev { get; set; } = 1234;

        public GetProtocolVersion() : base(1) {}

        override public byte[] Pack(byte[] cmd = null) {
            var ser = MessagePackSerializer.Get<GetProtocolVersion>();
            var stream = new MemoryStream();
            ser.Pack(stream, this);
            return base.Pack(stream.ToArray());
        }

        override public byte[] Unpack(byte[] frame) {
            byte[] cmd = base.Unpack(frame);
            var stream = new MemoryStream(cmd);
            var ser = MessagePackSerializer.Get<GetProtocolVersion>();
            var c = ser.Unpack(stream);
            this.maj = c.maj;
            this.min = c.min;
            this.rev = c.rev;
            return cmd;
        }
    }
}