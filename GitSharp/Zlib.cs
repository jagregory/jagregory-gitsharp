using System.IO;

namespace GitSharp
{
    public class Zlib
    {
        public byte[] Decompress(string path)
        {
            return Decompress(new FileStream(path, FileMode.Open));
        }

        public byte[] Decompress(Stream input)
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

                byte[] content = new byte[output.Length];

                output.Read(content, 0, (int)output.Length);

                return content;
            }
        }
    }
}