namespace GitSharp
{
    public abstract class GitObject
    {
        public void Load(string content)
        {
            var headAndBody = content.Split('\0');

            LoadHeader(headAndBody[0]);
            LoadBody(headAndBody[1]);
        }

        protected virtual void LoadHeader(string header)
        {
            ContentLength = long.Parse(header.Substring(header.IndexOf(' ')));
        }

        protected abstract void LoadBody(string body);
        
        public long ContentLength { get; private set; }
    }
}