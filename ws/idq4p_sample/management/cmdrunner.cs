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
using NetMQ;
using NetMQ.Sockets;

namespace idq4p {
    class CommandRunner {
        public static void Run(string dstIp) {
            //ManagementChannel.PUTest(new GetProtocolVersion());
            using (RequestSocket sock = ManagementChannel.Open(dstIp)) {
                var cmd = new GetProtocolVersion();
                var rep = (GetProtocolVersion) sock.ReqAndRep(cmd);
                Console.WriteLine($"> protocol version: {rep.maj}.{rep.min}.{rep.rev}");
            }
        }
    }
}