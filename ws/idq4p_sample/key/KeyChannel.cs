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
using System.Collections;
using System.Collections.Generic;
using System.Threading;

using NetMQ;
using NetMQ.Sockets;

namespace idq4p {
    public static class KeyChannel {
        public static SubscriberSocket Open(string dstIp) {
            string req = "tcp://" + dstIp + ":5560";
            Console.WriteLine($"connect to: {req}");
            var sock =  new SubscriberSocket();
            sock.Connect(req);
            return sock;
        }

        public static void ReceiveKey(this SubscriberSocket sock, int timo=9) {
            sock.SubscribeToAnyTopic();

            while (true) {
                Console.WriteLine("------------------ Wait for Key ------------------");
                byte[] frame = sock.ReceiveFrameBytes();
                var key = Key.UnpackFrame(frame);
                if (key != null) {
                    Console.WriteLine($"  + {key}");
                }
            }
        }
    }
}