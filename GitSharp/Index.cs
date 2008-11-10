using System;

namespace GitSharp
{
    public class Index
    {
        public IndexHeader Header { get; private set; }

        public void Load(GitObjectStream content)
        {
            Header = new IndexHeader();
            Header.Load(content);
        }
    }

    public class IndexHeader
    {
        private const int SignatureSize = 4;
        private const int VersionSize = 4;
        private const int EntriesSize = 4;

        public string Signature { get; private set; }
        public int Version { get; private set; }
        public int Entries { get; private set; }

        public void Load(GitObjectStream content)
        {
            var signatureBytes = content.ReadBytes(SignatureSize);
            var versionBytes = content.ReadBytes(VersionSize);
            var entriesBytes = content.ReadBytes(EntriesSize);

            Signature = signatureBytes.ToAsciiString();
            Version = ToInt32(versionBytes);
            Entries = ToInt32(entriesBytes);
        }

        private int ToInt32(byte[] bytes)
        {
            // nasty
            string value = "";

            foreach (var b in bytes)
            {
                value += b.ToString();
            }

            return Convert.ToInt32(value);
        }
    }
}