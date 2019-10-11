using System;
using System.IO;
using MsgPack.Serialization;

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
}