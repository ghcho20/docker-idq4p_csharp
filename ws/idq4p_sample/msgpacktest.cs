using System;
using System.IO;
using System.Collections.Generic;

using MsgPack;
using MsgPack.Serialization;

using idq4p;

namespace idq4p {
    public class GetProtocolVer {
        public uint maj { get; set; } = 1234;
        public uint min { get; set; } = 1234;
        public uint rev { get; set; } = 1234;
    }

    public class MsgPackTest {
        public static void test() {
            var ser = MessagePackSerializer.Get<GetProtocolVer>();
            var stream = new MemoryStream();
            var gpv = new GetProtocolVer();

            ser.Pack(stream, gpv);
            byte[] bytes = stream.ToArray();

            string hex = BitConverter.ToString(bytes).Replace("-", "");
            Console.WriteLine($" >> pack len= {bytes.Length}");
            Console.WriteLine($"{hex}");
            foreach (byte b in bytes) {
                Console.Write(b.ToString("X2") + " ");
            }
            Console.WriteLine();
        }


        private static string[] frameDumps = {
            "92 cc d5 96 cc 91 cc ca cc c2 1f cc ff 0b",
            "92 cc c9 96 cc 91 cc ca 41 cc f1 4b cc 82",
            "92 cc cc 96 cc 91 cc ca 41 cc f1 6d 48",
            "92 cc c9 96 cc 91 cc ca 41 cc f1 cc b0 cc d3",
            "92 01 92 cc 91 01 00 06 92 01 92 cc 91 01",
        };

        public static void signal_test() {
            foreach(string frDump in frameDumps) {
                string[] inFrame = frDump.Split(' ');
                byte[] frame = new byte[inFrame.Length];
                for (int i=0; i<frame.Length; i++) {
                    frame[i] = Convert.ToByte(inFrame[i], 16);
                }

                Console.WriteLine("------------------ Wait for Signal ------------------");
                Signal sig = Signal.UnpackFrame(frame);
                if (sig != null) {
                    Console.WriteLine($"  + {sig}");
                }
            }
        }

        public static void FlatPacking() {
            FlatPack tx = new FlatPack();
            var stream = new MemoryStream();
            var ser = MessagePackSerializer.Get<FlatPack>();
            ser.Pack(stream, tx);
            byte[] frame = stream.ToArray();
            Util.WriteBytes("tx", frame);

            var des = MessagePackSerializer.Get<FlatPackHdr>();
            stream = new MemoryStream(frame);
            var rx = des.Unpack(stream);
            Console.WriteLine($"out= {rx}");

            var desf = MessagePackSerializer.Get<FlatPack>();
            stream = new MemoryStream(frame);
            var rx2 = desf.Unpack(stream);
            Console.WriteLine($"out= {rx2}");
        }

        public static void FlatPackingNormal() {
            FlatPack tx = new FlatPack();
            var stream = new MemoryStream();
            var ser = MessagePackSerializer.Get<FlatPack>();
            ser.Pack(stream, tx);
            byte[] frame = stream.ToArray();
            Util.WriteBytes("tx", frame);

            var des = MessagePackSerializer.Get<FlatPack>();
            stream = new MemoryStream(frame);
            var rx = des.Unpack(stream);
            Console.WriteLine($"out= {rx}");
        }
    }

    public class FlatPackHdr {
        [MessagePackMember(0)] public UInt32 cmd { get; set; } = 101;
        [MessagePackMember(1)] public UInt32 dir { get; set; } = 1;

        public override string ToString() => $"{cmd}-{dir}";
    }

    public class FlatPack : FlatPackHdr {
        [MessagePackMember(2)] public UInt32 maj { get; set; } = 0;
        [MessagePackMember(3)] public UInt32 min { get; set; } = 12;
        [MessagePackMember(4)] public UInt32 rev { get; set; } = 1;

        public override string ToString() => $"{cmd}-{dir} : {maj}.{min}.{rev}";
    }
}