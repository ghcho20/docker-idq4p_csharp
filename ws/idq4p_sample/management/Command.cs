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
using System.Collections.Generic;

using MsgPack.Serialization;

namespace idq4p {
    public sealed class CommandWrapper {
        public CommandWrapper(uint ID) => this.ID = ID;

        [MessagePackMember(0)] public uint ID { get; set; }
        [MessagePackMember(1)] public uint direction { get; set; } = 1; // request
        [MessagePackMember(2)] public List<byte> cmd { get; set; }
    }

    public abstract class Command {
        protected readonly CommandWrapper cw;

        public Command(uint ID) => this.cw = new CommandWrapper(ID);

        public abstract byte[] PackToFrame();

        public abstract void UnpackFromFrame(byte[] frame);

        private static void printToHex(string ID, byte[] bytes) {
            string hex = BitConverter.ToString(bytes).Replace("-", "");
            Console.WriteLine($"> {ID}[{bytes.Length}]:{hex}");
        }
        public virtual byte[] PackFrame([NotNull] MessagePackSerializer cmdSerializer) {
            var stream = new MemoryStream();
            cmdSerializer.Pack(stream, this);
            byte[] baCmd = stream.ToArray();
            printToHex("cmd", baCmd);

            cw.cmd = new List<byte>(baCmd);
            var cwSerializer = MessagePackSerializer.Get<CommandWrapper>();
            stream.SetLength(0);
            cwSerializer.Pack(stream, cw);

            byte[] fr = stream.ToArray();
            printToHex("req", fr);

            return fr;
        }

        public virtual Command UnpackFrame(byte[] frame, [NotNull] MessagePackSerializer cmdSerializer) {
            printToHex("rep", frame);
            var stream = new MemoryStream(frame);
            var cwSerializer = MessagePackSerializer.Get<CommandWrapper>();
            byte[] baCmd = cwSerializer.Unpack(stream).cmd.ToArray();

            printToHex("cmd", baCmd);
            stream = new MemoryStream(baCmd);
            return (Command)cmdSerializer.Unpack(stream);
        }
    }
}