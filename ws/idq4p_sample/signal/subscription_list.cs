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
    partial class SigSubscriber {
        private static List<string> SubscriptionList { get; } = new List<string>() {
            "SubscribeSignal", // default = OnCpuTemperature_NewValue
            "SubscribeSignal Heartbeat",
            "SubscribeSignal OnSystemState_Changed",

            /* Alice */
            "SubscribeSignal OnLaser_Temperature_NewValue",
            "SubscribeSignal OnLaser_Power_NewValue",
            "SubscribeSignal OnLaser_TECCurrent_NewValue",

            /* Bob */
            "SubscribeSignal OnIF_Temperature_NewValue",
            "SubscribeSignal OnFilter_Temperature_NewValue",
            "SubscribeSignal OnDataDetector_Temperature_NewValue",
            "SubscribeSignal OnDataDetector_BiasCurrent_NewValue",
            "SubscribeSignal OnMonitortaDetector_Temperature_NewValue",
            "SubscribeSignal OnMonitorDetector_BiasCurrent_NewValue",

            /* FPGA */
            "SubscribeSignal OnQber_NewValue",
            "SubscribeSignal OnVisibility_NewValue",
            "SubscribeSignal OnKeyRate_NewValue",
            "SubscribeSignal OnCompressionRatio_NewValue",
            "SubscribeSignal OnTotalDetectionCount_NewValue",
        };
    }
}