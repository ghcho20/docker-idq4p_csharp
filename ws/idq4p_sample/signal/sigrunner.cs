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
    partial class SigSubscriber {
        private static void LogHeader(string headline) {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine($"** {headline} **");
        }

        public static void SubscribeSignals(string dstIp) {
            using RequestSocket sock = ManagementChannel.Open(dstIp);

            SubscriptionList.ForEach(cline => {
                string[] cls_arg = cline.Split(' ');
                Type cmdType = Type.GetType($"idq4p.{cls_arg[0]}");
                Command cmd;
                try {
                    if (cls_arg.Length == 1) {
                        cmd = (Command)Activator.CreateInstance(cmdType);
                    } else {
                        cmd = (Command)Activator.CreateInstance(cmdType, new Object[] {cls_arg[1]});
                    }
                } catch {
                    Console.WriteLine($"@@ Failed to load command class: {cline} @@");
                    return;
                }

                LogHeader(cline);
                if (sock.ReqAndRep(cmd)) {
                    Console.WriteLine($"== {cmd.ToString()} ==");
                }
            });
        }

        public static void Run(string dstIp) {
            SubscribeSignals(dstIp);
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine();

            SubscriberSocket sock = SignalChannel.Open(dstIp);
            LogHeader("start receiving signals");
            sock.ReceiveSignal();
        }
    }
}