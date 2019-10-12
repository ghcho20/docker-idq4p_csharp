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
using System.Text;

using NetMQ;
using NetMQ.Sockets;
using MsgPack.Serialization;

namespace idq4p {
    public class GetBoardInformation : Command {
        [MessagePackMember(0)] public uint bdID { get; set; }
        [MessagePackMember(1)] public StringBuilder bdInfo { get; set; } = new StringBuilder();

        private enum BdID {
            QkeComE = 1,
            QkeHost,
            QkeAlice,
            QkeBob,
            QkeFpga
        }

        public GetBoardInformation() : base(3) => bdID = (uint)BdID.QkeComE;

        public GetBoardInformation(string bdID) : this() => this.bdID = Convert.ToUInt32(bdID);

        protected override MessagePackSerializer getSerializer() {
            return MessagePackSerializer.Get<GetBoardInformation>();
        }

        public override Command Set(Command cmd) {
            var me = (GetBoardInformation)cmd;
            this.bdID = me.bdID;
            this.bdInfo= me.bdInfo;
            return this;
        }

        public override string ToString() {
                BdID bdID = (BdID)this.bdID;
                return ($"Board[{bdID}] description: {bdInfo}");
        }
    }
}