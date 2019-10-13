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
    public sealed class SignalWrapper {
        public SignalWrapper() {} // Default Ctor is a MUST for Serializer Unpacker

        [MessagePackMember(0)] public Int32 ID { get; set; }
        [MessagePackMember(1)] public List<UInt32> sig { get; set; } = new List<UInt32>();
    }

    public abstract partial class Signal {
        protected readonly ID eID;

        public Signal(ID eID) {
            this.eID = eID;
        }

        protected abstract MessagePackSerializer getSerializer();

        public static Signal UnpackFrame(byte[] frame) {
            //Util.WriteBytes("sig frame", frame);
            var swSerializer = MessagePackSerializer.Get<SignalWrapper>();
            var stream = new MemoryStream(frame);
            var sw = swSerializer.Unpack(stream);

            ID eID = (ID)sw.ID;
            Console.WriteLine($" > signal[{eID}] received");

            if (sw.sig.Count > 0) {
                Type sigCls = Type.GetType($"idq4p.{eID}");
                try {
                    Signal sig = (Signal)Activator.CreateInstance(sigCls);

                    byte[] baSig = new byte[sw.sig.Count]; int si = 0;
                    sw.sig.ForEach( b => baSig[si++] = (byte)(0xff & b));

                    var sigSerializer = sig.getSerializer();
                    stream = new MemoryStream(baSig);
                    sig = (Signal)sigSerializer.Unpack(stream);

                    return sig;
                } catch {
                    Console.WriteLine("  - Nested signal handler not defined");
                    Console.WriteLine($"  - {sw.sig.Count} signal bytes discarded");
                }
            }
            return null;
        }
    }
}