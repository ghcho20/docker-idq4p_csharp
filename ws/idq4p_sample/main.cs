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

namespace idq4p
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2) {
                Console.WriteLine("> invalid options");
                Console.WriteLine("> usage:");
                Console.WriteLine("  > dotnet run <clavis3 IP> <mode = mgmt|mon>");
                Console.WriteLine("    mgmt = request commands over Management channel");
                Console.WriteLine("    mon  = subscibe to Signal and Key channel");
                return;
            }

            CommandHandler.parser(args);
        }
    }
}
