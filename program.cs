using System.Linq;

class Program
{
	static void FileStreamAndBufferedStream()
	{
		System.IO.Stream fileStream = System.IO.File.Open("./file.txt", System.IO.FileMode.Open);
		System.IO.BufferedStream bufferedStream = new System.IO.BufferedStream(fileStream);
		System.Console.WriteLine("CanRead: " + bufferedStream.CanRead);
		System.Console.WriteLine("CanWrite: " + bufferedStream.CanWrite);
		System.Console.WriteLine("CanSeek: " + bufferedStream.CanSeek);
		System.Console.WriteLine("Length: " + bufferedStream.Length);
		System.Console.WriteLine("Position: " + bufferedStream.Position);
		int firstByte = bufferedStream.ReadByte();
		System.Console.WriteLine("Byte:" + firstByte);
		bufferedStream.Position = 0;
		System.Console.WriteLine("Position: " + bufferedStream.Position);
		bufferedStream.WriteByte((byte)(firstByte + 1));
		bufferedStream.Flush();
		//bufferedStream.Position = 0;
		//firstByte = bufferedStream.ReadByte();
		//bufferedStream.Dispose();
		System.Console.WriteLine("Byte:" + firstByte);
	}

	static void MemoryStream()
	{
		System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
		byte[] helloWorldBytes = System.Text.Encoding.Unicode.GetBytes("hello world");
		memoryStream.Write(helloWorldBytes, 0, helloWorldBytes.Length);
		System.Console.WriteLine("Length: " + memoryStream.Length);
		memoryStream.Position = 0;
		int byteReadFromStream;
		System.Collections.Generic.List<byte> list = new System.Collections.Generic.List<byte>();
		while((byteReadFromStream = memoryStream.ReadByte()) != -1)
		{
			list.Add((byte)byteReadFromStream);
		}
		byte[] bytesFromStream = list.ToArray();
		string bytesFromStreamAsString = System.Text.Encoding.UTF8.GetString(bytesFromStream);
		System.Console.WriteLine(bytesFromStreamAsString);
	}

	static void GzipStream()
	{
		System.IO.FileStream newFileStream = new System.IO.FileStream("compressed.gz", System.IO.FileMode.Create);
		System.IO.Compression.GZipStream gZipStream =
			new System.IO.Compression.GZipStream(newFileStream, System.IO.Compression.CompressionLevel.Fastest);
		byte[] bytes = System.Text.Encoding.Unicode.GetBytes("This is some text that will be compressed");
		gZipStream.Write(bytes, 0, bytes.Length);
		gZipStream.Dispose();
		System.IO.Compression.GZipStream decompressStream =
			new System.IO.Compression.GZipStream(System.IO.File.OpenRead("compressed.gz"), System.IO.Compression.CompressionMode.Decompress);
		System.IO.StreamReader streamReader = new System.IO.StreamReader(decompressStream, System.Text.Encoding.Unicode);
		System.Console.WriteLine(streamReader.ReadToEnd());
	}

	static void StreamReader()
	{
		System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(System.Text.Encoding.Unicode.GetBytes("hello world :)"));
		// System.IO.StreamReader memoryStreamReader = new System.IO.StreamReader(memoryStream, System.Text.Encoding.UTF8);
		System.IO.StreamReader memoryStreamReader = new System.IO.StreamReader(memoryStream, System.Text.Encoding.Unicode);
		System.Console.Write((char)memoryStreamReader.Read());
		System.Console.Write((char)memoryStreamReader.Read());
		System.Console.Write((char)memoryStreamReader.Read());
		System.Console.Write((char)memoryStreamReader.Read());
		System.Console.WriteLine();
		System.Console.WriteLine(memoryStreamReader.ReadLine());

		System.IO.StreamReader fileStreamReader =
			new System.IO.StreamReader(System.IO.File.OpenRead(@"D:\refs\installs\officesp2010-kb2687455-fullfile-x86-en-us.exe"));
		System.Console.WriteLine("here I am just before calling async ReadToEnd");
		var task = ReadToEnd(fileStreamReader);
		System.Console.WriteLine("here I am just after the call to ReadToEnd");
		task.Wait();
	}

	static async System.Threading.Tasks.Task ReadToEnd(System.IO.StreamReader streamReader)
	{
		string allText = await streamReader.ReadToEndAsync();
		System.Console.WriteLine("after await in ReadToEnd");
	}

	public static void Main()
	{
		System.Console.WriteLine("---------------------------");
		System.Console.WriteLine("FileStream");
		FileStreamAndBufferedStream();
		System.Console.WriteLine("---------------------------");
		System.Console.WriteLine("MemoryStream");
		MemoryStream();
		System.Console.WriteLine("---------------------------");
		System.Console.WriteLine("GzipStream");
		GzipStream();
		System.Console.WriteLine("---------------------------");
		System.Console.WriteLine("StreamReader");
		StreamReader();
		// //binnary, stream, string, text

		

		// System.Console.WriteLine("StreamWriter");

		// System.IO.FileStream newFileStream2 = new System.IO.FileStream("newfile.txt", System.IO.FileMode.Create);
		// System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(newFileStream2);
		// streamWriter.Write("hello");
		// streamWriter.Flush();

		// System.IO.StringReader stringReader = new System.IO.StringReader(System.IO.File.ReadAllText(@"C:\Users\filip.kucharczyk\Downloads\Poland (11).xml"));
		// System.Console.WriteLine(stringReader.ReadLine());

		// System.Console.WriteLine("BinaryReader");

		// System.IO.BinaryWriter binaryWriter = new System.IO.BinaryWriter(new System.IO.MemoryStream(), System.Text.Encoding.UTF32);
		// System.IO.BinaryReader binaryReader = new System.IO.BinaryReader(binaryWriter.BaseStream, System.Text.Encoding.UTF8);
		

		// var builder = new System.Text.StringBuilder();
		// for(int i = 0; i < 1073741823/2 - 1; ++i)
		// {
		// 	builder.Append("a");
		// }

		// binaryWriter.Write(10);
		// System.Console.WriteLine("binaryWriter.Write(builder.ToString());");
		// binaryWriter.Write(builder.ToString());
		// binaryWriter.BaseStream.Position = 0;
		// System.Console.WriteLine(binaryReader.ReadInt32());
		// System.Console.WriteLine(binaryReader.ReadByte());
		// System.Console.WriteLine(binaryReader.ReadByte());
		// System.Console.WriteLine(binaryReader.ReadByte());
		// System.Console.WriteLine(binaryReader.ReadByte());
		// System.Console.WriteLine(binaryReader.ReadByte());
		// System.Console.WriteLine(binaryReader.ReadByte());
		// System.Console.WriteLine(binaryReader.ReadByte());
		// System.Console.WriteLine(binaryReader.ReadByte());
		// System.Console.WriteLine(binaryReader.ReadByte());
		// System.Console.WriteLine(binaryReader.ReadByte());
		// System.Console.WriteLine(binaryReader.ReadByte());
		// System.Console.WriteLine(binaryReader.ReadByte());
		// System.Console.WriteLine(binaryReader.ReadByte());
		// return;

		// System.Console.WriteLine(binaryReader.ReadByte());
		// System.Console.WriteLine(binaryReader.ReadByte());
		// System.Console.WriteLine(binaryReader.ReadByte());

		// System.Console.WriteLine(binaryReader.ReadByte());

		// System.Console.WriteLine(binaryReader.ReadByte());
		// System.Console.WriteLine(binaryReader.ReadByte());

		// System.Console.WriteLine(binaryReader.ReadByte());
		// System.Console.WriteLine(binaryReader.ReadByte());

		// System.Console.WriteLine(binaryReader.ReadByte());
		// System.Console.WriteLine(binaryReader.ReadByte());


		// return;

		// binaryWriter.Write(11);
		// binaryWriter.BaseStream.Position = 0;

		// memoryStream.Position = 0;
		// System.Console.WriteLine(binaryReader.ReadByte());
		// System.Console.WriteLine(binaryReader.ReadByte());
		// System.Console.WriteLine(binaryReader.ReadByte());
		// System.Console.WriteLine(binaryReader.ReadByte());

		// System.Console.WriteLine(binaryReader.ReadByte());
		// System.Console.WriteLine(binaryReader.ReadByte());

		// System.Console.WriteLine(binaryReader.ReadByte());
		// System.Console.WriteLine(binaryReader.ReadByte());

		// System.Console.WriteLine(binaryReader.ReadByte());
		// System.Console.WriteLine(binaryReader.ReadByte());

		// System.Console.WriteLine(binaryReader.ReadByte());
		// System.Console.WriteLine(binaryReader.ReadByte());
		// System.Console.WriteLine(binaryReader.ReadByte());
		// System.Console.WriteLine(binaryReader.ReadByte());

		
		// //System.Console.WriteLine(binaryReader.ReadString());
	}
}