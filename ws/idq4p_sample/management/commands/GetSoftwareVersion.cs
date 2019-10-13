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
    public class GetSoftwareVersion : Command {
        [MessagePackMember(0)] public UInt32 swID { get; set; }
        [MessagePackMember(1)] public UInt32 maj { get; set; }
        [MessagePackMember(2)] public UInt32 min { get; set; }
        [MessagePackMember(3)] public UInt32 rev { get; set; }
        [MessagePackMember(4)] public Int64 bld { get; set; }

        private enum SWVer {
            CommunicatorService = 1,
            BoardSupervisorService,
            RegulatorServiceAlice,
            RegulatorServiceBob,
            FgpaConfiguration
        }

        public GetSoftwareVersion() : base(2) => swID = (UInt32)SWVer.CommunicatorService;

        public GetSoftwareVersion(string swID) : this() => this.swID = Convert.ToUInt32(swID);

        protected override MessagePackSerializer getSerializer() {
            return MessagePackSerializer.Get<GetSoftwareVersion>();
        }

        public override Command Set(Command cmd) {
            var me = (GetSoftwareVersion)cmd;
            this.swID = me.swID;
            this.maj = me.maj;
            this.min = me.min;
            this.rev = me.rev;
            this.bld = me.bld;
            return this;
        }

        public override string ToString() {
                SWVer swID = (SWVer)this.swID;
                return ($"SW[{swID}] ver: {maj}.{min}.{rev}.{bld}");
        }
    }
}