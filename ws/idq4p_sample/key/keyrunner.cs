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
using System.Threading;

using NetMQ;
using NetMQ.Sockets;

namespace idq4p {
    partial class KeySubscriber {
        private static void LogHeader(string headline) {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine($"** {headline} **");
        }

        public static void Run(string dstIp) {
            SubscriberSocket sock = KeyChannel.Open(dstIp);
            LogHeader($"start receiving keys from Clavis3[{dstIp}");
            sock.ReceiveKey();
        }
    }
}