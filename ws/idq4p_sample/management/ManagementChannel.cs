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
using NetMQ;
using NetMQ.Sockets;

namespace idq4p {
    public static class ManagementChannel {
        public static RequestSocket Open(string dstIp) {
            string req = ">tcp://" + dstIp + ":5561";
            Console.WriteLine($"connect to: {req}");
            return new RequestSocket(req);
        }

        public static bool ReqAndRep(this RequestSocket sock, Command cmd) {
            byte[] req = cmd.PackToFrame();

            var zmsg = new NetMQMessage();
            zmsg.Append(req);
            if (!sock.TrySendMultipartMessage(TimeSpan.FromSeconds(9), zmsg)) {
                Console.WriteLine("Tx time-out");
                return false;
            }
            Console.WriteLine("ReqAndRep: Unpack");
            byte[] rep;
            if (!sock.TryReceiveFrameBytes(TimeSpan.FromSeconds(9), out rep)) {
                Console.WriteLine("Rx time-out");
                return false;
            }
            cmd.UnpackFromFrame(rep);
            return true;
        }
    }
}