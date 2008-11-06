namespace GitSharp
{
    public abstract class GitObject
    {
        public void Load(GitObjectStream content)
        {
            LoadHeader(content);
            LoadBody(content);
        }

        protected virtual void LoadHeader(GitObjectStream content)
        {
            Type = ReadType(content);
            ContentLength = ReadContentLength(content);
        }

        private string ReadType(GitObjectStream content)
        {
            byte[] word = content.ReadWord();

            return word.ToAsciiString();
        }

        private long ReadContentLength(GitObjectStream content)
        {
            byte[] word = content.ReadToNull();

            return long.Parse(word.ToAsciiString());
        }

        protected abstract void LoadBody(GitObjectStream body);

        public string Type { get; private set; }
        public long ContentLength { get; private set; }
    }
}