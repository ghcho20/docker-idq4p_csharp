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
    public class SubscribeSignal : Command {
        [MessagePackMember(0)] public UInt32 sigID { get; set; }

        public SubscribeSignal() : base(10) =>
            this.sigID = (UInt32)(Signal.ID)Enum.Parse(typeof(Signal.ID), "OnCpuTemperature_NewValue", true);

        public SubscribeSignal(string sigID) : this() =>
            this.sigID = (UInt32)(Signal.ID)Enum.Parse(typeof(Signal.ID), sigID, true);

        protected override MessagePackSerializer getSerializer() {
            return MessagePackSerializer.Get<SubscribeSignal>();
        }

        public override string ToString() {
            Signal.ID sigID = (Signal.ID) this.sigID;
            return ($"Signal[{sigID}]");
        }
    }
}