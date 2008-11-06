using System;

namespace GitSharp
{
    public class ObjectFactory
    {
        public GitObject CreateFromContent(GitObjectStream content)
        {
            string type = ReadHeading(content);

            GitObject obj;

            if (type == "commit")
                obj = new Commit();
            else if (type == "tree")
                obj = new Tree();
            else
                throw new NotImplementedException("Support for file type is not implemented.");

            content.Rewind();

            obj.Load(content);

            return obj;
        }

        private string ReadHeading(GitObjectStream content)
        {
            byte[] word = content.ReadWord();

            return new System.Text.ASCIIEncoding().GetString(word);
        }
    }
}