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

using MsgPack.Serialization;

namespace idq4p {
    public sealed class CommandWrapper {
        public CommandWrapper(uint iD)
        {
            ID = iD;
        }

        public uint ID { get; set; }
        public uint direction { get; set; } = 1; // request
        public byte[] cmd { get; set; }
    }

    public abstract class Command {
        protected readonly CommandWrapper cw;

        public Command(uint ID) => this.cw = new CommandWrapper(ID);

        public virtual byte[] Pack(byte[] cmd = null) {
            Console.WriteLine($"> cmd len= {cmd.Length}");
            string hex = BitConverter.ToString(cmd).Replace("-", "");
            Console.WriteLine($"val = {hex}");
            cw.cmd = cmd;
            var ser = MessagePackSerializer.Get<CommandWrapper>();
            var stream = new MemoryStream();
            ser.Pack(stream, cw);
            return stream.ToArray();
        }

        public virtual byte[] Unpack(byte[] frame) {
            var stream = new MemoryStream(frame);
            var ser = MessagePackSerializer.Get<CommandWrapper>();
            var cw = ser.Unpack(stream);
            return cw.cmd;
        }
    }
}