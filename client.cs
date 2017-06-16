using System;
using System.IO.Pipes;

public static class Program
{
	public static void Main(string[] args)
	{
		PipeStream pipeClient =
			new AnonymousPipeClientStream(PipeDirection.In, args[0]);
		var from_pipe = pipeClient.ReadByte();
		Console.WriteLine("[Client]");
		Console.WriteLine(from_pipe);
	}
}