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
            "GetSystemState",
            //"Restart",
            "GetProtocolVersion",
            "GetSoftwareVersion 1",
            "GetSoftwareVersion 2",
            "GetSoftwareVersion 3",
            "GetSoftwareVersion 4",
            "GetSoftwareVersion 5",
            "GetBoardInformation 1",
            //"GetBoardInformation 2",
            "GetBoardInformation 3",
            //"GetBoardInformation 4",
            //"GetBoardInformation 5",
            "SubscribeSignal", // default = OnCpuTemperature_NewValue
            "SubscribeSignal OnSystemState_Changed",
        };
    }
}