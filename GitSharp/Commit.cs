namespace GitSharp
{
    public class Commit : GitObject
    {
        protected override void LoadBody(GitObjectStream content)
        {
            var body = content.ReadToEnd().ToAsciiString();
            var lines = body.Split('\n');

            foreach (var line in lines)
            {
                if (line.StartsWith("tree"))
                    TreeId = GetTreeId(line);

                if (line.StartsWith("author"))
                    Author = GetSignature(line);

                if (line.StartsWith("committer"))
                    Committer = GetSignature(line);
            }

            Comment = ReadComment(body);
        }

        private string GetTreeId(string line)
        {
            return line.Substring(line.IndexOf(' ') + 1);
        }

        private string GetSignature(string line)
        {
            string author = line.Substring(line.IndexOf(' ') + 1);

            author = author.Substring(0, author.LastIndexOf('>') + 1); // remote the timestamp for now

            return author;
        }

        private string ReadComment(string body)
        {
            return body.Substring(body.IndexOf("\n\n") + 2).TrimEnd();
        }

        public string TreeId { get; private set; }
        public string Author { get; private set; }
        public string Committer { get; private set; }
        public string Comment { get; private set; }
    }
}