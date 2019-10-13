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
using System.Collections;
using System.Collections.Generic;

using MsgPack.Serialization;

namespace idq4p {
    public sealed class CommandWrapper {
        public CommandWrapper() {} // Default Ctor is a MUST for Serializer Unpacker

        public CommandWrapper(uint ID) { this.ID = ID; }

        [MessagePackMember(0)] public uint ID { get; set; }
        [MessagePackMember(1)] public uint direction { get; set; } = 1; // request
        [MessagePackMember(2)] public List<ulong> cmd { get; set; } = new List<ulong>();
    }

    public abstract class Command {
        private readonly uint ID = 1;

        public Command(uint ID) => this.ID = ID;

        protected abstract MessagePackSerializer getSerializer();

        public virtual byte[] PackFrame() {
            var cw = new CommandWrapper(ID);
            var stream = new MemoryStream();
            var cmdSerializer = getSerializer();
            if (cmdSerializer != null) {
                cmdSerializer.Pack(stream, this);
                byte[] baCmd = stream.ToArray();
                Util.WriteBytes("cmd", baCmd);

                foreach(byte c in baCmd) cw.cmd.Add(c);
                Console.WriteLine($"  + n_cmds = {cw.cmd.Count}");
            }
            var cwSerializer = MessagePackSerializer.Get<CommandWrapper>();
            stream.SetLength(0);
            cwSerializer.Pack(stream, cw);

            byte[] fr = stream.ToArray();
            Util.WriteBytes("req", fr);

            return fr;
        }

        public virtual Command UnpackFrame(byte[] frame) {
            Util.WriteBytes("rep", frame);
            var cwSerializer = MessagePackSerializer.Get<CommandWrapper>();
            var stream = new MemoryStream(frame);
            var cwr = cwSerializer.Unpack(stream);
            Console.WriteLine($"  + n_cmds= {cwr.cmd.Count}");
            if (cwr.cmd.Count > 0) {
                byte[] baCmd = new byte[cwr.cmd.Count]; int ci = 0;
                cwr.cmd.ForEach( a => baCmd[ci++] = (byte)(0xff & a));

                Util.WriteBytes("cmd", baCmd);
                stream = new MemoryStream(baCmd);
                var cmdSerializer = getSerializer();
                //return (Command)cmdSerializer.Unpack(stream);
                var cmd = (Command)cmdSerializer.Unpack(stream);
                Set(cmd);
                return cmd;
            } else {
                return this;
            }
        }

        public virtual Command Set(Command cmd) => this;
    }
}