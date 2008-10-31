using System;
using System.IO;

namespace GitSharp
{
    public class Compression
    {
        public string Decompress(string path)
        {
            return Decompress(new FileStream(path, FileMode.Open));
        }

        public string Decompress(Stream input)
        {
            using (var output = new MemoryStream())
            using (var zipStream = new zlib.ZOutputStream(output))
            {
                using (input)
                {
                    var buffer = new byte[2000];
                    int len;

                    while ((len = input.Read(buffer, 0, 2000)) > 0)
                    {
                        zipStream.Write(buffer, 0, len);
                    }
                }

                // reset output stream to start so we can read it to a string
                output.Position = 0;

                using (var reader = new StreamReader(output))
                    return reader.ReadToEnd();
            }
        }
    }
}