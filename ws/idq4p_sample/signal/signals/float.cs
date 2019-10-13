/*
 * Created on Sun Oct 13 2019
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
using System.IO;
using System.Collections;
using System.Collections.Generic;

using MsgPack.Serialization;

namespace idq4p {
    public class BodyFloat : Signal {
        [MessagePackMember(0)] public Single value { get; set; }

        protected override MessagePackSerializer getSerializer() =>
            MessagePackSerializer.Get<BodyFloat>();

        public override string ToString() => $"value= {value}";
    }

    public class OnIF_Temperature_NewValue : BodyFloat { }
    public class OnMonitorDetector_Temperature_NewValue : BodyFloat { }
    public class OnFilter_Temperature_NewValue : BodyFloat { }
    public class OnCpuTemperature_NewValue : BodyFloat { }
    public class OnLaser_Temperature_NewValue : BodyFloat { }
    public class OnLaser_Power_NewValue : BodyFloat { }
    public class OnLaser_TECCurrent_NewValue : BodyFloat { }
    public class OnDataDetector_Temperature_NewValue : BodyFloat { }
    public class OnDataDetector_BiasCurrent_NewValue : BodyFloat { }
    public class OnMonitortaDetector_Temperature_NewValue : BodyFloat { }
    public class OnMonitorDetector_BiasCurrent_NewValue : BodyFloat { }
    public class OnQber_NewValue : BodyFloat { }
    public class OnVisibility_NewValue : BodyFloat { }
    public class OnKeyRate_NewValue : BodyFloat { }
    public class OnCompressionRatio_NewValue : BodyFloat { }
}