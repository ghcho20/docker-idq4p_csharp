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
    public class OnMonitorDetector_Temperature_NewValue : Signal {
        [MessagePackMember(0)] public Single value { get; set; }

        public OnMonitorDetector_Temperature_NewValue() : base(ID.OnMonitorDetector_Temperature_NewValue) {}

        protected override MessagePackSerializer getSerializer() =>
            MessagePackSerializer.Get<OnMonitorDetector_Temperature_NewValue>();

        public override string ToString() => $"temperature= {value}";
    }
}