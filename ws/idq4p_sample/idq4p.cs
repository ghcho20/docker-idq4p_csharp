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
                Console.WriteLine("  > dotnet run <clavis3 IP> <mode = mgmt|sig|key|restart|check>");
                Console.WriteLine("    mgmt    = request commands over Management channel");
                Console.WriteLine("    sig     = monitor Signal channel");
                Console.WriteLine("    key     = monitor Key channel");
                Console.WriteLine("    restart = restart system");
                return;
            }

            Console.WriteLine("-----------------------------------------");
            switch(args[1]) {
                case "mgmt":
                    CommandRunner.Run(args[0]);
                    break;

                case "sig":
                    SigSubscriber.Run(args[0]);
                    break;

                case "key":
                    KeySubscriber.Run(args[0]);
                    break;

                case "restart":
                    CommandRunner.Restart(args[0]);
                    break;

                case "off":
                    CommandRunner.PowerOff(args[0]);
                    break;

                case "check":
                    CommandRunner.CheckSystem(args[0]);
                    break;
            }
        }
    }
}