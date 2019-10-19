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
using System.Text;

using MsgPack.Serialization;

namespace idq4p {
    public class Key {
        [MessagePackMember(0)] public string ID { get; set; }
        [MessagePackMember(1)] public List<Byte> key { get; set; } = new List<Byte>();
        public static Key UnpackFrame(byte[] frame) {
            Util.WriteBytes("key frame", frame);
            var kSerializer = MessagePackSerializer.Get<Key>();
            var stream = new MemoryStream(frame);
            var key = kSerializer.Unpack(stream);

            return key;
        }

        public override string ToString() {
            string rep = " key ID= " + ID;
            if (ID.Length > 9) { // 9 is "heartbeat"
                string kvHex = BitConverter.ToString(key.ToArray()).Replace("-", "");
                rep += "\n     value = " + kvHex;
            }

            return rep;
        }
    }
}