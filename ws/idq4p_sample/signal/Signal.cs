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

        [MessagePackMember(0)] public uint ID { get; set; }
        [MessagePackMember(1)] public List<uint> cmd { get; set; } = new List<uint>();
    }

    public abstract partial class Signal {
        private readonly ID eID;

        public Signal(ID eID) {
            this.eID = eID;
        }

        protected abstract MessagePackSerializer getSerializer();

        public static void UnpackFrame(byte[] frame) {
            printToHex("sig frame", frame);
            var swSerializer = MessagePackSerializer.Get<SignalWrapper>();
            var stream = new MemoryStream(frame);
            var sw = swSerializer.Unpack(stream);

            ID eID = (ID)sw.ID;
            Console.WriteLine($" signal[{eID}] received");
        }

        private static void printToHex(string ID, byte[] bytes) {
            string hex = BitConverter.ToString(bytes).Replace("-", "");
            Console.WriteLine($"  + {ID}[{bytes.Length}]:{hex}");
        }
    }
}