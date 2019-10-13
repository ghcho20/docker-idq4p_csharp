/*
 * Created on Sun Oct 13 2019
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
using System.Collections;
using System.Collections.Generic;

using MsgPack.Serialization;

namespace idq4p {
    public class BodyInt32 : Signal {
        [MessagePackMember(0)] public Int32 value { get; set; }

        protected override MessagePackSerializer getSerializer() =>
            MessagePackSerializer.Get<BodyInt32>();

        public override string ToString() => $"value= {value}";
    }

    public class OnSystemState_Changed : BodyInt32 {
        protected override MessagePackSerializer getSerializer() =>
            MessagePackSerializer.Get<OnSystemState_Changed>();

        public override string ToString() {
            SystemState st = (SystemState)value;
            return $"system state= {st}";
        }
    }
}