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
using ZeroMQ;

namespace idq4p {
    public class ManagementChannel {
        /*
        private static ZSocket sock = new ZSocket(ZSocketType.REQ);

        static ManagementChannel() {} // for compiler not to mark beforefieldinit

        public static ZSocket Open(string dstIp) {
            sock.Connect("tcp://" + dstIp + ":5560");
            return sock;
        }
        */
        public static ZSocket Open(string dstIp) {
            using(var context = new ZContext()) {
                var sock = new ZSocket(context, ZSocketType.REQ);
                sock.Connect("tcp://" + dstIp + ":5560");
                return sock;
            }
        }
    }
}