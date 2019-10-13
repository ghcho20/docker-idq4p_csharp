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
    public class GetSystemState : Command {
        [MessagePackMember(0)] public UInt32 sysState { get; set; }

        public GetSystemState() : base(108) { }

        protected override MessagePackSerializer getSerializer() {
            return MessagePackSerializer.Get<GetSystemState>();
        }

        public override Command Set(Command cmd) {
            var me = (GetSystemState)cmd;
            this.sysState = me.sysState;
            return this;
        }

        public override string ToString() {
                SystemState sysState = (SystemState)this.sysState;
                return ($"System State = {sysState}");
        }
    }
}