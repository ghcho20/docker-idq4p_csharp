/*
 * Created on Sat Oct 12 2019
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

namespace idq4p {
    partial class CommandRunner {
        private static List<string> CmdRunList { get; set; } = new List<string>() {
            "Restart",
            "GetProtocolVersion",
            "GetSoftwareVersion",
            "GetBoardInformation",
            "SubscribeSignals"
        };
    }
}