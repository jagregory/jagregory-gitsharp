using System;
using System.Collections.Generic;

namespace GitSharp
{
    public class Index
    {
        public IndexHeader Header { get; private set; }
        public string Sha1Signature { get; private set; }
        public IList<IndexEntry> Entries { get; private set; }

        public Index()
        {
            Entries = new List<IndexEntry>();
        }

        public void Load(GitObjectStream content)
        {
            ReadSignature(content);

            Header = new IndexHeader();
            Header.Load(content);

            while (content.Position < content.Length - 20)
            {
                var entry = new IndexEntry();

                entry.Load(content);

                Entries.Add(entry);
            }
        }

        private void ReadSignature(GitObjectStream content)
        {
            content.Position = content.Length - 20;
         
            Sha1Signature = content.ReadToEnd().ToHexString();
            
            content.Rewind();
        }
    }

    public class IndexEntry
    {
        public IndexTime Created { get; private set; }
        public IndexTime Modified { get; private set; }
        public string Signature { get; private set; }
        public string Name { get; private set; }

        public void Load(GitObjectStream content)
        {
            Created = new IndexTime();
            Created.Load(content);

            Modified = new IndexTime();
            Modified.Load(content);

            var dev = content.ReadBytes(4);
            var ino = content.ReadBytes(4);
            var mode = content.ReadBytes(4);
            var uid = content.ReadBytes(4);
            var gid = content.ReadBytes(4);
            var size = content.ReadBytes(4);
            Signature = content.ReadBytes(20).ToHexString();
            var flags = content.ReadBytes(2);

            Name = content.ReadToNull().ToAsciiString();

            content.ReadToNextNonNull();
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
            Version = versionBytes.ToInt32();
            Entries = entriesBytes.ToInt32();
        }
    }
}