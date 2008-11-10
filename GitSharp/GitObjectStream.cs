using System;
using System.Collections.Generic;
using System.IO;

namespace GitSharp
{
    public class GitObjectStream : IDisposable
    {
        private readonly MemoryStream stream;

        public GitObjectStream(byte[] bytes)
        {
            stream = new MemoryStream(bytes);
        }

        public byte[] ReadToChar(char stop)
        {
            var bytes = new List<byte>();

            int current;

            while ((current = stream.ReadByte()) != stop)
            {
                bytes.Add((byte)current);
            }

            return bytes.ToArray();
        }

        public byte[] ReadWord()
        {
            return ReadToChar(' ');
        }

        public byte[] ReadToNull()
        {
            return ReadToChar('\0');
        }

        public void Rewind()
        {
            stream.Position = 0;
        }

        public byte[] ReadToEnd()
        {
            var bytes = new List<byte>();

            while (!IsEndOfFile)
            {
                bytes.Add((byte)stream.ReadByte());
            }

            return bytes.ToArray();
        }

        public byte[] ReadBytes(int numberOfBytes)
        {
            var bytes = new List<byte>();
            
            for (int i = 0; i < numberOfBytes; i++)
            {
                bytes.Add((byte)stream.ReadByte());
            }

            return bytes.ToArray();
        }

        public void Dispose()
        {
            stream.Dispose();
        }

        public bool IsEndOfFile
        {
            get { return stream.Position >= stream.Length; }
        }

        public long Position
        {
            get { return stream.Position; }
            set { stream.Position = value; }
        }

        public long Length
        {
            get { return stream.Length; }
        }
    }
}