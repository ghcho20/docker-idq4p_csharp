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
using System.Collections.Generic;

using NetMQ;
using NetMQ.Sockets;

namespace idq4p {
    partial class CommandRunner {
        private static void startOfCommand(string cmdName) {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine($"** {cmdName} **");
        }

        public static void Run(string dstIp) {
            using RequestSocket sock = ManagementChannel.Open(dstIp);

            CmdRunList.ForEach(cline => {
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

                startOfCommand(cline);
                if (sock.ReqAndRep(cmd)) {
                    Console.WriteLine($"== {cmd.ToString()} ==");
                }
            });
        }
    }
}