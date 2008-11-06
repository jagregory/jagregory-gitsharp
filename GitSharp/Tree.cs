using System.Collections.Generic;

namespace GitSharp
{
    public class Tree : GitObject
    {
        protected override void LoadBody(GitObjectStream content)
        {
            Contents = new List<TreeEntry>();

            while (!content.IsEndOfFile)
            {
                var entry = new TreeEntry();

                entry.Mode = content.ReadWord().ToAsciiString();
                entry.Path = content.ReadToNull().ToAsciiString();
                entry.Sha1 = ReadSha1(content);

                Contents.Add(entry);
            }
        }

        private string ReadSha1(GitObjectStream content)
        {
            byte[] word = content.ReadBytes(20);

            return word.ToHexString().ToLower();
        }

        public IList<TreeEntry> Contents { get; set; }
    }
}