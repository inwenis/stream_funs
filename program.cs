class Program
{
	public static void Main()
	{
		System.Console.WriteLine("hello world");

		System.IO.Stream fileStream = System.IO.File.Open("./file.txt", System.IO.FileMode.Open);
		System.IO.BufferedStream bufferedStream = new System.IO.BufferedStream(fileStream);
		System.Console.WriteLine("CanRead: " + bufferedStream.CanRead);
		System.Console.WriteLine("CanWrite: " + bufferedStream.CanWrite);
		System.Console.WriteLine("CanSeek: " + bufferedStream.CanSeek);
		System.Console.WriteLine("Length: " + bufferedStream.Length);
		System.Console.WriteLine("Position: " + bufferedStream.Position);
		int @byte = bufferedStream.ReadByte();
		System.Console.WriteLine("Byte:" + @byte);
		bufferedStream.Position = 0;
		System.Console.WriteLine("Position: " + bufferedStream.Position);
		bufferedStream.WriteByte((byte)(@byte + 1));
		bufferedStream.Flush();
		//bufferedStream.Position = 0;
		//@byte = bufferedStream.ReadByte();
		//bufferedStream.Dispose();
		System.Console.WriteLine("Byte:" + @byte);
		
		System.Console.WriteLine();
		System.Console.WriteLine("Memory Stream");
		System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
		byte[] bytes = System.Text.Encoding.Unicode.GetBytes("hello world");

		memoryStream.Write(bytes, 0, bytes.Length);
		System.Console.WriteLine("Length: " + memoryStream.Length);
		memoryStream.Position = 0;

		int readByte;
		System.Collections.Generic.List<byte> list = new System.Collections.Generic.List<byte>();
		while((readByte = memoryStream.ReadByte()) != -1)
		{
			list.Add((byte)readByte);
		}
		byte[] bytesFromStream = list.ToArray();

		string string2 = System.Text.Encoding.UTF8.GetString(bytesFromStream);
		System.Console.WriteLine(string2);

		System.Console.WriteLine();
		System.Console.WriteLine("Gzip Stream");

		System.IO.FileStream newFileStream = new System.IO.FileStream("compressed.gz", System.IO.FileMode.Create);
		System.IO.Compression.GZipStream gZipStream =
			new System.IO.Compression.GZipStream(newFileStream, System.IO.Compression.CompressionLevel.Fastest);
		gZipStream.Write(bytes, 0, bytes.Length);
		gZipStream.Dispose();
		System.Console.WriteLine("The End");

		//binnary, stream, string, text
		System.Console.WriteLine();
		System.Console.WriteLine("Stream Reader");

		memoryStream.Position = 0;
		// System.IO.StreamReader streamReader = new System.IO.StreamReader(memoryStream, System.Text.Encoding.UTF8);
		System.IO.StreamReader streamReader = new System.IO.StreamReader(memoryStream, System.Text.Encoding.Unicode);
		// System.IO.StreamReader streamReader = new System.IO.StreamReader(memoryStream);
		
		System.Console.Write((char)streamReader.Read());
		System.Console.Write((char)streamReader.Read());
		System.Console.Write((char)streamReader.Read());
		System.Console.Write((char)streamReader.Read());
	}
}