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
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
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

        public abstract byte[] PackToFrame();

        public abstract void UnpackFromFrame(byte[] frame);

        public virtual byte[] PackFrame([NotNull] MessagePackSerializer cmdSerializer) {
            var stream = new MemoryStream();
            cmdSerializer.Pack(stream, this);

            byte[] baCmd = stream.ToArray();
            Console.WriteLine($"> cmd len= {baCmd.Length}");
            string hex = BitConverter.ToString(baCmd).Replace("-", "");
            Console.WriteLine($"val = {hex}");

            cw.cmd = baCmd;
            var cwSerializer = MessagePackSerializer.Get<CommandWrapper>();
            stream.SetLength(0);
            cwSerializer.Pack(stream, cw);
            return stream.ToArray();
        }

        public virtual Command UnpackFrame(byte[] frame, [NotNull] MessagePackSerializer cmdSerializer) {
            var stream = new MemoryStream(frame);
            var cwSerializer = MessagePackSerializer.Get<CommandWrapper>();
            byte[] baCmd = cwSerializer.Unpack(stream).cmd;

            stream = new MemoryStream(baCmd);
            return (Command)cmdSerializer.Unpack(stream);
        }
    }
}