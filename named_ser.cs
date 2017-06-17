using System;
using System.IO;
using System.IO.Pipes;

public static class Program
{
	public static void Main()
	{
		Console.WriteLine("hello world");
		var stream = new NamedPipeServerStream("test_pipe", PipeDirection.InOut, 4);
		Console.WriteLine("waiting for a client to connect");
		stream.WaitForConnection();
		Console.WriteLine("client connected!");
		stream.WriteByte(67);
		stream.Flush();
		StreamWriter writer = new StreamWriter(stream);
		writer.Write("hello client!");
		writer.Flush();
		Console.WriteLine("Press any key to exit...");
		Console.ReadKey();
	}
}