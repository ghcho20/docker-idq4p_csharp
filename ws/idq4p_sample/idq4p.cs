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

            Console.WriteLine("+++++++++++++++++++++++++++++++++");
            switch(args[1]) {
                case "mgmt":
                    CommandRunner.Run(args[0]);
                    break;

                case "mon":
                    MsgPackTest.test();
                    break;
            }
        }
    }
}
