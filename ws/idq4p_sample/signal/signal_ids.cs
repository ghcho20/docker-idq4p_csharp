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

namespace idq4p {
    public abstract partial class Signal {
        public enum ID {
            Heartbeat = 0,
            OnSystemState_Changed,
            OnUpdateSoftware_Progress,
            OnPowerUpComponentsState_Changed,
            OnAlignmentState_Changed,
            OnOptimizingOpticsState_Changed,
            OnShutdownState_Changed,
            OnKeySecurity_OutOfRange,
            OnKeyAuthentication_Mismatch,
            OnKeySecurity_SignalFailure,
            OnKeySecurity_RepeatedFailure,
            OnKeyDeliverer_Exception,
            OnCommandServer_Exception,

            /* Alice */
            OnLaser_BiasCurrent_NewValue = 101,
            OnLaser_BiasCurrent_AbsoluteOutOfRange,
            OnLaser_BiasCurrent_OperationOutOfRange,
            OnLaser_Temperature_NewValue,
            OnLaser_Temperature_AbsoluteOutOfRange,
            OnLaser_Temperature_OperationOutOfRange,
            OnLaser_Power_NewValue,
            OnLaser_Power_AboluteOutOfRange,
            OnLaser_Power_OperationOutOfRange,
            OnLaser_TECCurrent_NewValue,
            OnLaser_TECCurrent_AbsoluteOutOfRange,
            OnLaser_TECCurrent_OperationOutOfRange,
            // there's more

            /* Bob */
            OnIF_Temperature_NewValue = 201,
            OnIF_Temperature_AbsoluteOutOfRange,
            OnIF_Temperature_OperationOutOfRange,
            OnFilter_Temperature_NewValue,
            OnFilter_Temperature_AbsoluteOutOfRange,
            OnFilter_Temperature_OperationOutOfRange,
            OnDataDetector_Temperature_NewValue,
            OnDataDetector_Temperature_AbsoluteOutOfRange,
            OnDataDetector_Temperature_OperationOutOfRange,
            OnDataDetector_BiasCurrent_NewValue,
            OnDataDetector_BiasCurrent_AbsoluteOutOfRange,
            OnDataDetector_BiasCurrent_OperationOutOfRange,
            OnMonitorDetector_Temperature_NewValue,
            OnMonitorDetector_Temperature_AbsoluteOutOfRange,
            OnMonitorDetector_Temperature_OperationOutOfRange,
            OnMonitorDetector_BiasCurrent_NewValue,
            OnMonitorDetector_BiasCurrent_AbsoluteOutOfRange,
            OnMonitorDetector_BiasCurrent_OperationOutOfRange,

            /* Hardware Signals from FPGA */
            OnQber_NewValue = 219,
            OnVisibility_NewValue,
            OnFPGA_Failure,
            OnKeyRate_NewValue,
            OnCompressionRatio_NewValue,
            OnTotalDetectionCount_NewValue,

            /* System Signals from processor */
            OnPowerSupply_Alarm = 250,
            OnCpuTemperature_NewValue,
            OnUptime_NewValue,
            OnCpuLoad_NewValue,
            OnMemoryUsage_NewValue,

            /* Supplemental Signals (from manual-mode) */
            OnDataDetectionRate_NewVale = 301,
            OnMonitorDetectionRate_NewVale,
            OnDataTimebins_NewVale,
            OnMonitorTimebins_NewVale,
            OnDataDelay_NewVale,
            OnMonitorDelay_NewVale,
            OnDataShift_NewVale,
            OnMonitorShift_NewVale,
            OnDataStep_NewVale,
            OnMonitorStep_NewVale,
        }
    }
}