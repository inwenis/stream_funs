using System;
using System.IO;
using System.IO.Pipes;
using System.Security.Principal;

public static class Program
{
	public static void Main()
	{
		NamedPipeClientStream pipeStream =
			new NamedPipeClientStream(".", "test_pipe",
				PipeDirection.InOut, PipeOptions.None,
				TokenImpersonationLevel.Impersonation);
		pipeStream.Connect();
		var msg = pipeStream.ReadByte();
		Console.WriteLine(msg);
		StreamReader reader = new StreamReader(pipeStream);
		Console.WriteLine(reader.ReadLine());
		Console.WriteLine(reader.ReadLine());
	}
}