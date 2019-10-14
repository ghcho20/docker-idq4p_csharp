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

namespace idq4p {
    public enum SystemState {
        PoweredOff,
        PoweringOn,
        ExecutingSelfTest,
        ExecutingGeneralInit,
        ExecutingSecurityInit,
        Running,
        PoweringOff,
        HandlingError,
        UpdatingSoftware,
        Zeroizing
    }

    public class Util {
        public static void WriteBytes(string ID, byte[] bytes) {
            string hex = BitConverter.ToString(bytes).Replace("-", "");
            Console.WriteLine($"  + {ID}[{bytes.Length}]:{hex}");
        }
    }
}