namespace GitSharp
{
    public class Blob : GitObject
    {
        protected override void LoadBody(GitObjectStream content)
        {
            Content = content.ReadToEnd().ToAsciiString();
        }

        public string Content { get; private set; }
    }
}