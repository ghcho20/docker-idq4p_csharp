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
        [MessagePackMember(0)] public UInt32 maj { get; set; }
        [MessagePackMember(1)] public UInt32 min { get; set; }
        [MessagePackMember(2)] public UInt32 rev { get; set; }

        public GetProtocolVersion() : base(1) { }

        protected override MessagePackSerializer getSerializer() {
            return MessagePackSerializer.Get<GetProtocolVersion>();
        }

        public override Command Set(Command cmd) {
            var me = (GetProtocolVersion)cmd;
            this.maj = me.maj;
            this.min = me.min;
            this.rev = me.rev;
            return this;
        }

        public override string ToString() {
                return ($"idq4p ver: {maj}.{min}.{rev}");
        }
    }
}