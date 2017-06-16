using System;
using System.IO;
using System.IO.Pipes;
using System.Diagnostics;

class Program
{
	public static void Main()
	{
		AnonymousPipeServerStream pipeServer =
			new AnonymousPipeServerStream(PipeDirection.Out,
				HandleInheritability.Inheritable);
		var clientPipeHandle = pipeServer.GetClientHandleAsString();
		Console.WriteLine(clientPipeHandle);

		Process pipeClient = new Process();
		pipeClient.StartInfo.FileName = "client.exe";
		pipeClient.StartInfo.Arguments = clientPipeHandle;
		pipeClient.StartInfo.UseShellExecute = false;
		pipeClient.Start();

		pipeServer.DisposeLocalCopyOfClientHandle();
		pipeServer.WriteByte(45);
		pipeServer.Flush();
		Console.WriteLine("Press any key to quit");
		Console.ReadKey();
		pipeServer.Dispose();
	}
}